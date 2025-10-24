using System;
using System.Collections.Generic;
using System.Linq;

public class CodeVerification
{
    private static readonly OfficialVerifier Official = new OfficialVerifier(VerifiableProductDatabase.Products);

    // Simple code check
    public static bool VerifyCode(string code)
    {
        return Official.VerifyByCode(code, out _);
    }

    // Overload returning the matched product if available
    public static bool VerifyCode(string code, out VerifiableProduct? product)
    {
        return Official.VerifyByCode(code, out product);
    }
}