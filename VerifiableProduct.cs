/// <summary>
/// Represents a product that can be verified using an official verification code.
/// This class contains only the essential information needed for code verification,
/// separate from physical characteristics.
/// </summary>
public class VerifiableProduct
{
    /// <summary>
    /// The unique verification code printed on the product or packaging.
    /// This is required and cannot be empty.
    /// </summary>
    public required string VerificationCode { get; set; }

    /// <summary>
    /// The official name of the product.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The name of the manufacturer who produced the product.
    /// </summary>
    public string Manufacturer { get; set; } = string.Empty;
}

/// <summary>
/// Provides a simple in-memory database of verified products.
/// In a real application, this would be replaced with a proper database or API client.
/// </summary>
public static class VerifiableProductDatabase
{
    /// <summary>
    /// List of officially verified products with their verification codes.
    /// This is a simple in-memory database for demonstration purposes.
    /// </summary>
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