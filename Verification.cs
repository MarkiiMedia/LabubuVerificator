public static class Verification
{
    public static bool VerifyProductByCode(string code)
    {
        return ProductDatabase.Products.Any(p => p.VerificationCode == code);
    }

    public static string VerifyProductManually(string productName, string manufacturer)
    {
        // Simple heuristic for demonstration
        if (productName.Contains("Labubu") && manufacturer.Contains("Labubu Inc."))
        {
            return "The product is probably real.";
        }
        else
        {
            return "The product might not be real.";
        }
    }
}