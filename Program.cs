using System;

// Beginner-friendly single-file CLI entrypoint.
// Keeps things minimal so a C# newbie can read everything quickly.

class Program
{
    static void Main()
    {
        Console.WriteLine("Labubu Verifier - Simple Mode");
        Console.WriteLine("1) Verify by code");
        Console.WriteLine("2) Manual check (teeth, colored teeth, glossy eyes, nose color)");
        Console.Write("Choose 1 or 2: ");

        var choice = (Console.ReadLine() ?? string.Empty).Trim();
        if (choice == "1") VerifyByCode();
        else if (choice == "2") VerifyManually();
        else Console.WriteLine("Invalid choice. Exiting.");
    }

    static void VerifyByCode()
    {
        Console.Write("Enter verification code: ");
        var code = Console.ReadLine() ?? string.Empty;
        bool ok = SimpleVerifier.SimpleVerifyCode(code);
        if (ok)
        {
            var series = SimpleStorage.GetSeriesForCode(code);
            var timestamp = SimpleStorage.UpdateFirstVerification(code);
            var firstTimeMsg = string.IsNullOrEmpty(timestamp) ? "" : $"\nFirst verified: {timestamp}";
            Console.WriteLine($"Code is valid! Series: {series}{firstTimeMsg}");
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