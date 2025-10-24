public class PhysicalCharacteristics
{
    // Physical / visual attributes used for the manual indicator
    public int TeethCount { get; set; }
    public int ColoredTeethCount { get; set; }
    public string EarColor { get; set; } = string.Empty;
    public string FurColor { get; set; } = string.Empty;
    public bool EyesGlossy { get; set; }
    public string NoseColor { get; set; } = string.Empty;
}

public static class PhysicalCharacteristicsDatabase
{
    // Sample database for manual evaluation testing
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