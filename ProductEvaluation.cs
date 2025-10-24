using System;
using System.Collections.Generic;

public class ProductEvaluation
{
    private static readonly ManualIndicator Indicator = new ManualIndicator();

    // Simple manual method accepting basic parameters
    public static string EvaluateBasic(int teethCount)
    {
        var characteristics = new PhysicalCharacteristics
        {
            TeethCount = teethCount
        };

        return Indicator.EvaluateManual(characteristics);
    }

    // Full evaluation that accepts complete characteristics
    public static string Evaluate(PhysicalCharacteristics characteristics)
    {
        return Indicator.EvaluateManual(characteristics);
    }
}