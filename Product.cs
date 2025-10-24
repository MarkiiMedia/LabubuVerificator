/// <summary>
/// Represents the physical and visual characteristics of a product
/// that can be manually verified. These characteristics are used
/// to assess the likelihood of a product being genuine.
/// </summary>
public class PhysicalCharacteristics
{
    /// <summary>
    /// The total number of teeth on the product.
    /// Genuine products typically have exactly 9 teeth.
    /// </summary>
    public int TeethCount { get; set; }

    /// <summary>
    /// The number of colored teeth on the product.
    /// Genuine products typically have 0 colored teeth.
    /// </summary>
    public int ColoredTeethCount { get; set; }

    /// <summary>
    /// The color of the product's ears.
    /// Used for descriptive purposes in the evaluation.
    /// </summary>
    public string EarColor { get; set; } = string.Empty;

    /// <summary>
    /// The color of the product's fur.
    /// Used for descriptive purposes in the evaluation.
    /// </summary>
    public string FurColor { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the eyes have a glossy finish.
    /// Genuine products typically have glossy eyes.
    /// </summary>
    public bool EyesGlossy { get; set; }

    /// <summary>
    /// The color of the product's nose.
    /// Genuine products typically have a brown-red nose.
    /// </summary>
    public string NoseColor { get; set; } = string.Empty;
}

/// <summary>
/// Provides sample physical characteristics for testing the manual evaluation system.
/// In a real application, this would be used for reference comparisons.
/// </summary>
public static class PhysicalCharacteristicsDatabase
{
    /// <summary>
    /// Sample characteristics of known genuine products.
    /// Used for testing and as a reference for the evaluation system.
    /// </summary>
    public static List<PhysicalCharacteristics> SampleCharacteristics = new List<PhysicalCharacteristics>
    {
        new PhysicalCharacteristics
        {
            TeethCount = 9,
            ColoredTeethCount = 0,
            EarColor = "pink",
            FurColor = "brown",
            EyesGlossy = true,
            NoseColor = "brown-red"
        },
        // Add more sample characteristics here for manual evaluation testing
    };
}