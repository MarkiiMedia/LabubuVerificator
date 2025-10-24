using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Labubu Product Verification System!");
        Console.WriteLine("If you have a verification code on your product or product emballage, select 1. Verification Code Check.");
        Console.WriteLine("This will help you quickly and officially verify the authenticity of your Labubu product.");
        Console.WriteLine("To get a verification code, please check the product packaging or contact Labubu customer support.");
        Console.WriteLine("If you do not have a verification code, you can choose 2. Manual Probability Check to assess the likelihood of your product being genuine based on its name and manufacturer.");
        Console.WriteLine("AND other similar methods that i will add later.");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Verification Code Check");
        Console.WriteLine("2. Manual Probability Check");

        string choice = Console.ReadLine() ?? string.Empty;

        switch (choice)
        {
            case "1":
                VerifyByCode();
                break;
            case "2":
                VerifyManually();
                break;
            default:
                Console.WriteLine("Invalid choice. Please restart the program and choose a valid option.");
                break;
        }

        void VerifyByCode()
        {
            Console.WriteLine("Enter verification code:");
            string code = Console.ReadLine() ?? string.Empty;

            if (CodeVerification.VerifyCode(code, out var matched))
            {
                Console.WriteLine("Product is verified! YES!");
                Console.WriteLine($"Product: {matched!.ProductName} by {matched!.Manufacturer}");
                Console.WriteLine($"Verified at: {DateTime.UtcNow:O} (demo timestamp)");
            }
            else
            {
                Console.WriteLine("Product verification failed.");
            }
        }

        void VerifyManually()
        {
            Console.WriteLine("Enter number of teeth:");
            var teethInput = Console.ReadLine() ?? string.Empty;
            int.TryParse(teethInput, out var teethCount);

            Console.WriteLine("Enter number of colored teeth (if any):");
            int.TryParse(Console.ReadLine() ?? string.Empty, out var coloredTeeth);

            Console.WriteLine("Enter ear color:");
            var earColor = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter fur color:");
            var furColor = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Are the eyes glossy? (y/n):");
            var eyesGlossy = (Console.ReadLine() ?? string.Empty).Trim().ToLower() == "y";

            Console.WriteLine("Enter nose color (e.g. brown-red):");
            var noseColor = Console.ReadLine() ?? string.Empty;

            var characteristics = new PhysicalCharacteristics
            {
                TeethCount = teethCount,
                ColoredTeethCount = coloredTeeth,
                EarColor = earColor,
                FurColor = furColor,
                EyesGlossy = eyesGlossy,
                NoseColor = noseColor
            };

            string result = ProductEvaluation.Evaluate(characteristics);
            Console.WriteLine(result);
        }
    }
}