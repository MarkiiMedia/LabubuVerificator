using System;
using System.Collections.Generic;
using System.Linq;

public class OfficialVerifier : ICodeVerifier
{
    private readonly IEnumerable<VerifiableProduct> _products;

    public OfficialVerifier(IEnumerable<VerifiableProduct> products)
    {
        _products = products ?? Array.Empty<VerifiableProduct>();
    }

    public bool VerifyByCode(string code, out VerifiableProduct? product)
    {
        product = _products.FirstOrDefault(p => p.VerificationCode == code);
        return product != null;
    }
}