public class VerifiableProduct
{
    public required string VerificationCode { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}

public static class VerifiableProductDatabase
{
    // Simple in-memory sample database for verification codes
    public static List<VerifiableProduct> Products = new List<VerifiableProduct>
    {
        new VerifiableProduct
        {
            VerificationCode = "ABC123",
            ProductName = "Labubu Toy",
            Manufacturer = "Labubu Inc."
        },
        // Add more sample products here for verification testing
    };
}