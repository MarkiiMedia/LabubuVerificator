public class Product
{
    public required string VerificationCode { get; set; }
    public required string ProductName { get; set; }
    public required string Manufacturer { get; set; }
    // Add other relevant fields
}

public static class ProductDatabase
{
    public static List<Product> Products = new List<Product>
    {
        new Product { VerificationCode = "ABC123", ProductName = "Labubu Toy", Manufacturer = "Labubu Inc." },
        // Add more sample products
    };
}