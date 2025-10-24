using System;

// Beginner-friendly single-file CLI entrypoint.
// Keeps things minimal so a C# newbie can read everything quickly.

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); // Clear screen for cleaner display
            Console.WriteLine("Labubu Verifier - Simple Mode");
            Console.WriteLine("1) Verify by code");
            Console.WriteLine("2) Manual check (teeth, colored teeth, glossy eyes, nose color)");
            Console.WriteLine("3) Exit program");
            Console.Write("Choose 1-3: ");

            var choice = (Console.ReadLine() ?? string.Empty).Trim();
            if (choice == "1") VerifyByCode();
            else if (choice == "2") VerifyManually();
            else if (choice == "3") break;
            else
            {
                Console.WriteLine("\nInvalid choice, press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            if (choice == "1" || choice == "2")
            {
                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }

    static void VerifyByCode()
    {
        Console.Write("Enter verification code: ");
        var code = Console.ReadLine() ?? string.Empty;
        bool ok = SimpleVerifier.SimpleVerifyCode(code);
        if (ok)
        {
            var series = SimpleStorage.GetSeriesForCode(code);
            var (timestamp, verificationCount) = SimpleStorage.UpdateVerificationInfo(code);
            var timeMsg = string.IsNullOrEmpty(timestamp) ? "" : $"\nFirst verified: {timestamp}";
            
            string statusMsg;
            if (verificationCount == 1)
            {
                statusMsg = "First time ever checked MUNDUS";
            }
            else if (verificationCount >= 2 && verificationCount <= 4)
            {
                statusMsg = "Several checks have been made on this product MUNDUS";
            }
            else // 5 or more
            {
                statusMsg = "Product checked too many times, still genuine, but suspicious MUNDUS";
            }

            Console.WriteLine($"Code is valid! Series: {series}{timeMsg}\n{statusMsg}");
        }
        else
        {
            Console.WriteLine("Code not found.");
        }
    }

    static void VerifyManually()
    {
        Console.Write("Number of teeth (e.g. 9): ");
        int.TryParse(Console.ReadLine() ?? string.Empty, out var teeth);

        Console.Write("Number of colored teeth (e.g. 0): ");
        int.TryParse(Console.ReadLine() ?? string.Empty, out var colored);

        Console.Write("Eyes glossy? (y/n): ");
        var eyes = (Console.ReadLine() ?? string.Empty).Trim().ToLower() == "y";

        Console.Write("Nose color (e.g. brown-red): ");
        var nose = Console.ReadLine() ?? string.Empty;

        var verdict = SimpleVerifier.SimpleEvaluateManual(teeth, colored, eyes, nose);
        Console.WriteLine($"Manual result: {verdict}");
    }
}