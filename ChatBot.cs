using System;

namespace CyberSecurity_Awareness_Chatbot
{
    public class Chatbot
    {
        private string userName = "User";

        public void StartChat()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Welcome to the Cybersecurity Awareness Bot!");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            // Ask for user's name
            Console.Write("\nWhat is your name? ");
            userName = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(userName))
            {
                userName = "Friend";
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {userName}! I'm here to help you stay safe online.\n");
            Console.ResetColor();

            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n" + new string('-', 60));
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("What would you like to know about? (choose 1-10)");
                Console.ResetColor();

                Console.WriteLine("1. How are you?");
                Console.WriteLine("2. What's your purpose?");
                Console.WriteLine("3. Password safety tips");
                Console.WriteLine("4. How to spot phishing emails");
                Console.WriteLine("5. Safe browsing tips");
                Console.WriteLine("6. What is cybersecurity?");
                Console.WriteLine("7. Malware types and how to protect yourself");
                Console.WriteLine("8. Social engineering and common scams");
                Console.WriteLine("9. Incident response & reporting");
                Console.WriteLine("10. Exit");
                Console.WriteLine(new string('-', 60));

                Console.Write("\nEnter your choice (1-10): ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RespondToHowAreYou();
                        break;
                    case "2":
                        RespondToPurpose();
                        break;
                    case "3":
                        PasswordSafetyTips();
                        break;
                    case "4":
                        PhishingTips();
                        break;
                    case "5":
                        SafeBrowsingTips();
                        break;
                    case "6":
                        WhatIsCyberSecurity();
                        break;
                    case "7":
                        MalwareAndProtection();
                        break;
                    case "8":
                        SocialEngineeringAndScams();
                        break;
                    case "9":
                        IncidentResponseAndReporting();
                        break;
                    case "10":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nGoodbye, {userName}! Stay safe online!");
                        Console.ResetColor();
                        running = false;
                        break;
                    default:
                        HandleInvalidInput(input);
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }

        private void RespondToHowAreYou()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nI'm doing great, {userName}! Thanks for asking.");
            Console.WriteLine("As an AI, I'm always ready to help you with cybersecurity awareness.");
            Console.ResetColor();
        }

        private void RespondToPurpose()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nMy purpose is to help you become more aware of online threats, {userName}.");
            Console.WriteLine("I provide helpful information about password safety, phishing, malware, and safe browsing.");
            Console.ResetColor();
        }

        private void PasswordSafetyTips()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== PASSWORD SAFETY TIPS ===");
            Console.WriteLine("• Use strong, unique passwords (at least 12 characters)");
            Console.WriteLine("• Include uppercase, lowercase, numbers, and symbols");
            Console.WriteLine("• Never reuse the same password across multiple sites");
            Console.WriteLine("• Consider using a reputable password manager");
            Console.WriteLine("• Enable Two-Factor Authentication (2FA) wherever possible");
            Console.ResetColor();
        }

        private void PhishingTips()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== HOW TO SPOT PHISHING EMAILS ===");
            Console.WriteLine("• Check the sender's email address carefully");
            Console.WriteLine("• Look for urgent language or threats");
            Console.WriteLine("• Hover over links before clicking (don't trust the displayed text)");
            Console.WriteLine("• Never enter credentials on suspicious links");
            Console.WriteLine("• Be wary of unexpected attachments and spelling/grammar errors");
            Console.ResetColor();
        }

        private void SafeBrowsingTips()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== SAFE BROWSING TIPS ===");
            Console.WriteLine("• Always check if the website uses HTTPS (padlock icon)");
            Console.WriteLine("• Avoid clicking on pop-up ads and unknown links");
            Console.WriteLine("• Keep your browser and OS updated");
            Console.WriteLine("• Use an ad blocker and reputable antivirus software");
            Console.WriteLine("• Be cautious with public Wi‑Fi; use a VPN for sensitive activities");
            Console.ResetColor();
        }

        private void WhatIsCyberSecurity()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== WHAT IS CYBERSECURITY? ===");
            Console.WriteLine("Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks.");
            Console.WriteLine("It includes measures to prevent unauthorized access, data breaches, and service disruption.");
            Console.WriteLine("Key areas include: risk assessment, network security, endpoint protection, identity management, and incident response.");
            Console.ResetColor();
        }

        private void MalwareAndProtection()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== MALWARE TYPES & PROTECTION ===");
            Console.WriteLine("Common malware types:");
            Console.WriteLine("• Virus & Worms — self-replicating programs that spread across systems.");
            Console.WriteLine("• Trojan — disguised as legitimate software but performs malicious actions.");
            Console.WriteLine("• Ransomware — encrypts files and demands payment for recovery.");
            Console.WriteLine("• Spyware/Keyloggers — collect sensitive information without consent.");
            Console.WriteLine("• Adware — intrusive ads, sometimes bundled with malware.");
            Console.WriteLine("\nProtection steps:");
            Console.WriteLine("• Keep OS and applications updated (patching fixes vulnerabilities).");
            Console.WriteLine("• Use reputable antivirus/endpoint protection and enable real-time scanning.");
            Console.WriteLine("• Avoid running untrusted executables or opening unknown attachments.");
            Console.WriteLine("• Maintain regular backups (offline or immutable where possible) to recover from ransomware.");
            Console.ResetColor();
        }

        private void SocialEngineeringAndScams()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== SOCIAL ENGINEERING & COMMON SCAMS ===");
            Console.WriteLine("Social engineering tricks people into giving away information or access.");
            Console.WriteLine("Common tactics:");
            Console.WriteLine("• Phishing emails that mimic trusted senders.");
            Console.WriteLine("• Vishing (phone) and smishing (SMS) scams that request urgent action.");
            Console.WriteLine("• Pretexting — attackers create a fake situation to request info.");
            Console.WriteLine("\nHow to defend:");
            Console.WriteLine("• Verify unexpected requests through independent channels.");
            Console.WriteLine("• Don’t share credentials or MFA codes.");
            Console.WriteLine("• Be skeptical of unsolicited contact that asks for sensitive data.");
            Console.ResetColor();
        }

        private void IncidentResponseAndReporting()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== INCIDENT RESPONSE & REPORTING ===");
            Console.WriteLine("If you suspect a security incident:");
            Console.WriteLine("• Isolate affected devices (disconnect from the network if safe to do so).");
            Console.WriteLine("• Preserve evidence (do not power off or wipe devices unnecessarily).");
            Console.WriteLine("• Report to your organization's IT/security team or the platform provider.");
            Console.WriteLine("• If personal data was exposed, consider notifying affected parties and follow legal/regulatory guidance.");
            Console.WriteLine("• Recover from clean backups and rotate affected credentials.");
            Console.ResetColor();
        }

        private void HandleInvalidInput(string? input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\nI didn't quite understand that. Could you please rephrase?");
            }
            else
            {
                Console.WriteLine($"\nSorry, '{input}' is not a valid option. Please choose a number from 1 to 10.");
            }
            Console.ResetColor();
        }
    }
}