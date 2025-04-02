using System;
using System.Media;
using System.Threading;

class CyberAskBot
{
    static void Main()
    {
        Console.Title = "Cybersecurity Awareness Bot";
        Console.ForegroundColor = ConsoleColor.Cyan;
        DisplayAsciiArt();
        PlayVoiceGreeting();
        Console.ResetColor();

        Console.Write("\nWhat's your name? ");
        string userName = Console.ReadLine();
        Console.WriteLine($"\nHello {userName}, I'm here to help you stay safe online!\n");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nChoose a topic or type your question:");
            Console.WriteLine("[1] Phishing");
            Console.WriteLine("[2] Strong Passwords");
            Console.WriteLine("[3] Safe Browsing");
            Console.WriteLine("[4] Exit");
            Console.Write("Your choice: ");
            Console.ResetColor();

            string userInput = Console.ReadLine().ToLower().Trim();

            if (userInput == "4" || userInput == "exit") break;

            HandleUserInput(userInput);
        }

        Console.WriteLine("\nGoodbye! Stay safe online!");
    }

    static void DisplayAsciiArt()
    {
        Console.WriteLine(@"
       
                    $$\                                  $$$$$$\            $$\             $$$$$$$\            $$\     
                    $$ |                                $$  __$$\           $$ |            $$  __$$\           $$ |    
 $$$$$$$\ $$\   $$\ $$$$$$$\   $$$$$$\   $$$$$$\        $$ /  $$ | $$$$$$$\ $$ |  $$\       $$ |  $$ | $$$$$$\$$$$$$\   
$$  _____|$$ |  $$ |$$  __$$\ $$  __$$\ $$  __$$\       $$$$$$$$ |$$  _____|$$ | $$  |      $$$$$$$\ |$$  __$$\_$$  _|  
$$ /      $$ |  $$ |$$ |  $$ |$$$$$$$$ |$$ |  \__|      $$  __$$ |\$$$$$$\  $$$$$$  /       $$  __$$\ $$ /  $$ |$$ |    
$$ |      $$ |  $$ |$$ |  $$ |$$   ____|$$ |            $$ |  $$ | \____$$\ $$  _$$<        $$ |  $$ |$$ |  $$ |$$ |$$\ 
\$$$$$$$\ \$$$$$$$ |$$$$$$$  |\$$$$$$$\ $$ |            $$ |  $$ |$$$$$$$  |$$ | \$$\       $$$$$$$  |\$$$$$$  |\$$$$  |
 \_______| \____$$ |\_______/  \_______|\__|            \__|  \__|\_______/ \__|  \__|      \_______/  \______/  \____/ 
          $$\   $$ |                                                                                                    
          \$$$$$$  |                                                                                                    
           \______/                                                                                                     

        Cybersecurity Awareness Bot
        ");
    }


     static void PlayVoiceGreeting()
    {
        try
        {
            // Full file path for the sound
            string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greetingVoice.wav");

            // Check if the file exists before attempting to play it
            if (System.IO.File.Exists(soundPath))
            {
                SoundPlayer player = new SoundPlayer(soundPath);
                player.PlaySync();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; // Dark Red for errors
                Console.WriteLine("[Audio Error] Cannot find the greeting.wav at the path: " + soundPath);
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; // Dark Red for errors
            Console.WriteLine("[Audio Error] Unable to play the greeting sound: " + ex.Message);
            Console.ResetColor();
        }
    }

    static void HandleUserInput(string input)
    {
        switch (input)
        {
            case "1":
            case "phishing":
            case "what is phishing":
                SimulatedTyping("Phishing is a cyber attack where scammers trick you into revealing personal information via fake emails or websites.");
                break;
            case "2":
            case "strong passwords":
            case "how do i create a strong password":
                SimulatedTyping("A strong password should be at least 12 characters long, with a mix of letters, numbers, and symbols.");
                break;
            case "3":
            case "safe browsing":
            case "how can i browse safely online":
                SimulatedTyping("Use HTTPS websites, avoid clicking suspicious links, and keep your software up to date.");
                break;
            default:
                SimulatedTyping("I didn't quite understand that. Try selecting a number from the menu or rephrasing your question.");
                break;
        }
    }

    static void SimulatedTyping(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
        Console.WriteLine("\n");
    }
}
