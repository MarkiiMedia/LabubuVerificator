using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implements the official verification process for products using verification codes.
/// This class checks if a given code exists in the official database of verified products.
/// </summary>
public class OfficialVerifier : ICodeVerifier
{
    /// <summary>
    /// Collection of all officially verified products.
    /// This is injected through the constructor to allow for different data sources.
    /// </summary>
    private readonly IEnumerable<VerifiableProduct> _products;

    /// <summary>
    /// Initializes a new instance of the OfficialVerifier with a collection of verified products.
    /// </summary>
    /// <param name="products">Collection of officially verified products. If null, an empty collection is used.</param>
    public OfficialVerifier(IEnumerable<VerifiableProduct> products)
    {
        _products = products ?? Array.Empty<VerifiableProduct>();
    }

    /// <summary>
    /// Verifies a product by checking if its code exists in the official database.
    /// </summary>
    /// <param name="code">The verification code to check</param>
    /// <param name="product">When the method returns, contains the matching product if found; otherwise, null</param>
    /// <returns>true if the code matches an official product; otherwise, false</returns>
    public bool VerifyByCode(string code, out VerifiableProduct? product)
    {
        product = _products.FirstOrDefault(p => p.VerificationCode == code);
        return product != null;
    }
}