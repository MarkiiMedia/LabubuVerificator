using Xunit;

public class VerifierTests
{
    [Theory]
    [InlineData(9, 0, true, "brown-red", "High score - Could be genuine")]
    [InlineData(8, 1, true, "blue", "Low score - Likely not genuine")]
    public void ManualEvaluation_ReturnsExpectedVerdict(int teethCount, int coloredTeethCount, bool eyesGlossy, string noseColor, string expected)
    {
        var result = SimpleVerifier.SimpleEvaluateManual(teethCount, coloredTeethCount, eyesGlossy, noseColor);
        Assert.Equal(expected, result);
    }
}
