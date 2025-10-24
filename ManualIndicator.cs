using System;
using System.Collections.Generic;

public class ManualIndicator : IManualIndicator
{
    public string EvaluateManual(PhysicalCharacteristics characteristics)
    {
        var score = 0;
        var reasons = new List<string>();

        if (characteristics.TeethCount == 9)
        {
            score += 3;
            reasons.Add("Correct number of teeth (9).");
        }

        if (characteristics.ColoredTeethCount == 0)
        {
            score += 1;
            reasons.Add("No colored teeth as expected.");
        }

        if (!string.IsNullOrEmpty(characteristics.NoseColor) &&
            (characteristics.NoseColor.Contains("brown", StringComparison.OrdinalIgnoreCase) || characteristics.NoseColor.Contains("red", StringComparison.OrdinalIgnoreCase)))
        {
            score += 1;
            reasons.Add("Nose color matches typical brown-red.");
        }

        if (characteristics.EyesGlossy)
        {
            score += 1;
            reasons.Add("Eyes are glossy as expected.");
        }

        // Add non-scoring descriptive hints
        if (!string.IsNullOrEmpty(characteristics.EarColor)) reasons.Add($"Ear color: {characteristics.EarColor}.");
        if (!string.IsNullOrEmpty(characteristics.FurColor)) reasons.Add($"Fur color: {characteristics.FurColor}.");

        string verdict;
        if (score >= 4) verdict = "High likelihood the product is genuine.";
        else if (score >= 2) verdict = "Medium likelihood — product may be genuine but not certain.";
        else verdict = "Low likelihood the product is genuine.";

        var details = string.Join(" ", reasons);
        return $"{verdict} (score {score})\nDetails: {details}";
    }
}