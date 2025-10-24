using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides public API for verifying products using their verification codes.
/// This class serves as the main entry point for code-based product verification.
/// </summary>
public class CodeVerification
{
    /// <summary>
    /// The official verifier instance used for all code verification.
    /// Initialized with the official product database.
    /// </summary>
    private static readonly OfficialVerifier Official = new OfficialVerifier(VerifiableProductDatabase.Products);

    /// <summary>
    /// Simple verification that only returns whether a code is valid.
    /// Use this when you only need to know if a code is valid or not.
    /// </summary>
    /// <param name="code">The verification code to check</param>
    /// <returns>true if the code is valid; otherwise, false</returns>
    public static bool VerifyCode(string code)
    {
        return Official.VerifyByCode(code, out _);
    }

    /// <summary>
    /// Detailed verification that returns both the result and the matched product.
    /// Use this when you need access to the product details after verification.
    /// </summary>
    /// <param name="code">The verification code to check</param>
    /// <param name="product">When the method returns, contains the matching product if found; otherwise, null</param>
    /// <returns>true if the code is valid; otherwise, false</returns>
    public static bool VerifyCode(string code, out VerifiableProduct? product)
    {
        return Official.VerifyByCode(code, out product);
    }
}