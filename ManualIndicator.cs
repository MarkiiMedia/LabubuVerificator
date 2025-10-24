using System;
using System.Collections.Generic;

/// <summary>
/// Implements the manual evaluation process for products based on their physical characteristics.
/// This class assigns scores to different characteristics and provides a detailed evaluation report.
/// </summary>
public class ManualIndicator : IManualIndicator
{
    /// <summary>
    /// Evaluates a product's authenticity by examining its physical characteristics.
    /// Each characteristic contributes to a score, and additional descriptive information is included.
    /// 
    /// Scoring system:
    /// - Correct teeth count (9): 3 points
    /// - No colored teeth: 1 point
    /// - Correct nose color (brown-red): 1 point
    /// - Glossy eyes: 1 point
    /// 
    /// Maximum possible score: 6 points
    /// Verdict thresholds:
    /// - High likelihood: >= 4 points
    /// - Medium likelihood: 2-3 points
    /// - Low likelihood: 0-1 points
    /// </summary>
    /// <param name="characteristics">The physical characteristics to evaluate</param>
    /// <returns>A detailed evaluation report including score, verdict, and specific observations</returns>
    public string EvaluateManual(PhysicalCharacteristics characteristics)
    {
        var score = 0;
        var reasons = new List<string>();

        // Check teeth count - most important characteristic (3 points)
        if (characteristics.TeethCount == 9)
        {
            score += 3;
            reasons.Add("Correct number of teeth (9).");
        }

        // Check for colored teeth - should be none (1 point)
        if (characteristics.ColoredTeethCount == 0)
        {
            score += 1;
            reasons.Add("No colored teeth as expected.");
        }

        // Check nose color - should be brown-red (1 point)
        if (!string.IsNullOrEmpty(characteristics.NoseColor) &&
            (characteristics.NoseColor.Contains("brown", StringComparison.OrdinalIgnoreCase) || 
             characteristics.NoseColor.Contains("red", StringComparison.OrdinalIgnoreCase)))
        {
            score += 1;
            reasons.Add("Nose color matches typical brown-red.");
        }

        // Check eye glossiness (1 point)
        if (characteristics.EyesGlossy)
        {
            score += 1;
            reasons.Add("Eyes are glossy as expected.");
        }

        // Add descriptive information (no points, just for reference)
        if (!string.IsNullOrEmpty(characteristics.EarColor)) reasons.Add($"Ear color: {characteristics.EarColor}.");
        if (!string.IsNullOrEmpty(characteristics.FurColor)) reasons.Add($"Fur color: {characteristics.FurColor}.");

        // Determine verdict based on total score
        string verdict;
        if (score >= 4) verdict = "High likelihood the product is genuine.";
        else if (score >= 2) verdict = "Medium likelihood — product may be genuine but not certain.";
        else verdict = "Low likelihood the product is genuine.";

        // Combine all observations into a detailed report
        var details = string.Join(" ", reasons);
        return $"{verdict} (score {score})\nDetails: {details}";
    }
}