using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CyberSecurity_Awareness_Chatbot
{
    public sealed class AudioPlayer
    {
        private bool _isPlaying;

        public bool IsPlaying => _isPlaying;

        public AudioPlayer()
        {
            _isPlaying = false;
        }

        // P/Invoke to play WAV files on Windows without requiring System.Windows.Extensions.
        // Uses synchronous playback so callers can wait for the sound to finish.
        [DllImport("winmm.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_SYNC = 0x0000;
        private const uint SND_ASYNC = 0x0001;
        private const uint SND_FILENAME = 0x00020000;
        private const uint SND_PURGE = 0x0040;

        /// <summary>
        /// Plays an audio file. If a relative filename is provided (no directory),
        /// the file is resolved from the application's base directory (output folder).
        /// Throws if the file does not exist.
        /// </summary>
        public Task PlayAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("filePath must not be null or empty.", nameof(filePath));
            }

            string resolvedPath = filePath;
            if (!Path.IsPathRooted(filePath))
            {
                // Resolve relative filenames to the app's base directory (output folder).
                resolvedPath = Path.Combine(AppContext.BaseDirectory, filePath);
            }

            if (!File.Exists(resolvedPath))
            {
                throw new FileNotFoundException($"Audio file not found: {resolvedPath}", resolvedPath);
            }

            return Task.Run(() =>
            {
                try
                {
                    _isPlaying = true;

                    // On Windows use winmm PlaySound (no compile-time dependency on System.Windows.Extensions).
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        // Synchronous playback so caller can wait until sound finishes.
                        PlaySound(resolvedPath, IntPtr.Zero, SND_SYNC | SND_FILENAME);
                    }
                    else
                    {
                        // Non-Windows best-effort: no reliable built-in cross-platform system call here.
                        // Silently do nothing (audio is best-effort) to avoid runtime errors on other OSes.
                    }
                }
                finally
                {
                    _isPlaying = false;
                }
            });
        }

        /// <summary>
        /// Best-effort: play the specified file only if it exists in the output directory.
        /// This static helper matches the previous usage pattern AudioPlayer.PlayExists("greeting.wav")
        /// and will return immediately if the file is missing (no exception).
        /// </summary>
        public static Task PlayExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("filePath must not be null or empty.", nameof(filePath));
            }

            string resolvedPath = filePath;
            if (!Path.IsPathRooted(filePath))
            {
                resolvedPath = Path.Combine(AppContext.BaseDirectory, filePath);
            }

            if (!File.Exists(resolvedPath))
            {
                // File missing — ignore and return completed task (best-effort playback).
                return Task.CompletedTask;
            }

            var player = new AudioPlayer();
            return player.PlayAsync(resolvedPath);
        }

        /// <summary>
        /// Convenience instance method to play "greeting.wav" from output directory.
        /// </summary>
        public Task PlayGreetingAsync()
        {
            return PlayExists("greeting.wav");
        }

        /// <summary>
        /// Attempts to stop any currently playing sound started via this helper.
        /// On Windows this calls PlaySound with null to stop playback.
        /// </summary>
        public void Stop()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Stop any playing sound
                    PlaySound(null, IntPtr.Zero, SND_PURGE);
                }
            }
            finally
            {
                _isPlaying = false;
            }
        }
    }
}