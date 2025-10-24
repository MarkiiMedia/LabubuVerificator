/// <summary>
/// Interface for implementing product verification by code.
/// This interface defines the contract for any class that will verify products
/// using their verification codes.
/// </summary>
public interface ICodeVerifier
{
    /// <summary>
    /// Attempts to verify a product using its verification code.
    /// </summary>
    /// <param name="code">The verification code to check</param>
    /// <param name="product">When the method returns, contains the verified product if found; otherwise, null</param>
    /// <returns>true if the code matches a verified product; otherwise, false</returns>
    bool VerifyByCode(string code, out VerifiableProduct? product);
}