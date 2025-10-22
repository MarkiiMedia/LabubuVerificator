public class Product
{
    public required string VerificationCode { get; set; }
    public required string NumberOfTeeth { get; set; } // Antal tænder skal være 9, ellers falsk. Grænseværdier kan her testes
    public required string ProductName { get; set; }
    public required string Manufacturer { get; set; }
    // Add other relevant fields
}

public static class ProductDatabase
{
    public static List<Product> Products = new List<Product>
    {
        new Product { VerificationCode = "ABC123", ProductName = "Labubu Toy", Manufacturer = "Labubu Inc.", NumberOfTeeth = "9" },
        // Add more sample products
    };
}