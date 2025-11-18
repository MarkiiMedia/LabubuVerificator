using Xunit;

public class ManualEvaluationTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(9)]
    [InlineData(100)]
    public void ManualEvaluation_HandlesInvalidTeethInput(int teeth)
    {
        var result = SimpleVerifier.SimpleEvaluateManual(teeth, 0, true, "brown");
        Assert.NotNull(result);
    }
}
