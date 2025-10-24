public interface ICodeVerifier
{
    bool VerifyByCode(string code, out VerifiableProduct? product);
}