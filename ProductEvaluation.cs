using System;
using System.Collections.Generic;

/// <summary>
/// Provides public API for evaluating products based on their physical characteristics.
/// This class serves as the main entry point for manual product evaluation.
/// </summary>
public class ProductEvaluation
{
    /// <summary>
    /// The manual indicator instance used for all product evaluations.
    /// </summary>
    private static readonly ManualIndicator Indicator = new ManualIndicator();

    /// <summary>
    /// Simple evaluation method that only requires the teeth count.
    /// Use this for quick evaluations when only teeth count is available.
    /// </summary>
    /// <param name="teethCount">The number of teeth on the product</param>
    /// <returns>A detailed evaluation report focusing on teeth count</returns>
    public static string EvaluateBasic(int teethCount)
    {
        var characteristics = new PhysicalCharacteristics
        {
            TeethCount = teethCount
        };

        return Indicator.EvaluateManual(characteristics);
    }

    /// <summary>
    /// Comprehensive evaluation using all available physical characteristics.
    /// Use this when you have detailed information about the product.
    /// </summary>
    /// <param name="characteristics">Complete set of physical characteristics to evaluate</param>
    /// <returns>A detailed evaluation report considering all characteristics</returns>
    public static string Evaluate(PhysicalCharacteristics characteristics)
    {
        return Indicator.EvaluateManual(characteristics);
    }
}