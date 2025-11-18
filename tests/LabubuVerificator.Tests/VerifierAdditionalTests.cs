using Xunit;

public class VerifierAdditionalTests
{
    [Fact]
    public void UpdateVerificationInfo_StoresCorrectDateFormat()
    {
        var code = "ABC123";
        var (timestamp, _) = SimpleStorage.UpdateVerificationInfo(code);
        // Expect timestamp in 'YYYY-MM-DD HH:MM:SS' format (e.g. 2025-11-18 13:45:30)
        Assert.Matches(@"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}", timestamp);
    }
}
