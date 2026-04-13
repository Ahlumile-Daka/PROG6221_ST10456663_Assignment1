using System;

namespace CyberSecurity_Awareness_Chatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            // Play greeting sound (best-effort). This will block until the WAV finishes.
            // Place greeting.wav in the project and set "Copy to Output Directory" = "Copy if newer".
            try
            {
                AudioPlayer.PlayExists("greeting.wav").GetAwaiter().GetResult();
            }
            catch
            {
                // swallow any unexpected audio errors — audio is best-effort
            }

            // Display ASCII Art Logo
            User.DisplayLogo();

            // Start the chatbot
            var chatbot = new Chatbot();
            chatbot.StartChat();

            Console.ResetColor();
            Console.WriteLine("\nThank you for using the Cybersecurity Awareness Bot!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
