using Xunit;

public class StorageTests
{
    [Fact]
    public void AddAndGetCode_Works()
    {
        // Note: This touches the on-disk DB used by the sample app.
        var before = SimpleStorage.GetAllCodes();
        SimpleStorage.AddCode("TEST999", "Unit Series");
        var after = SimpleStorage.GetAllCodes();
        Assert.Contains("TEST999", after);
    }

    [Fact]
    public void UpdateVerificationInfo_ReturnsTuple()
    {
        SimpleStorage.AddCode("TMP123", "Series");
        var (ts, count) = SimpleStorage.UpdateVerificationInfo("TMP123");
        Assert.True(count >= 1);
    }
}
