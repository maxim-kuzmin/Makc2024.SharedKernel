namespace Makc2024.Dummy.Shared.Core.Crypto.Symmetric;

public abstract class SymmetricCryptoService(SymmetricCryptoOptions _options) : ICryptoService
{
  private readonly byte[] _salt = Encoding.UTF8.GetBytes(_options.Salt);

  public abstract string Decrypt(string textToDecrypt);

  public abstract string Encrypt(string textToEncrypt);

  protected static ICryptoTransform CreateDecryptor(Aes algorithm)
  {
    return algorithm.CreateDecryptor();
  }

  protected static ICryptoTransform CreateEncryptor(Aes algorithm)
  {
    return algorithm.CreateEncryptor();
  }

  protected byte[] Transform(byte[] bytes, Func<Aes, ICryptoTransform> funcToGetCryptoTransform)
  {
    using var passwordBytes = new Rfc2898DeriveBytes(
      _options.Password,
      _salt,
      _options.Iterations,
      HashAlgorithmName.SHA256);

    using var algorithm = Aes.Create();

    algorithm.Key = passwordBytes.GetBytes(32);
    algorithm.IV = passwordBytes.GetBytes(16);

    using var ms = new MemoryStream();

    using var cs = new CryptoStream(ms, funcToGetCryptoTransform.Invoke(algorithm), CryptoStreamMode.Write);

    cs.Write(bytes, 0, bytes.Length);

    return ms.ToArray();
  }
}
