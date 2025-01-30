namespace Makc2024.Dummy.Shared.Core.Crypto.Symmetric;

/// <summary>
/// Сервис симметричного шифрования.
/// </summary>
/// <param name="_options">Параметры.</param>
public abstract class SymmetricCryptoService(SymmetricCryptoOptions _options) : ICryptoService
{
  private readonly byte[] _salt = Encoding.UTF8.GetBytes(_options.Salt);

  /// <inheritdoc/>
  public abstract string Decrypt(string textToDecrypt);

  /// <inheritdoc/>
  public abstract string Encrypt(string textToEncrypt);

  /// <summary>
  /// Создать расшифровальщик.
  /// </summary>
  /// <param name="algorithm">Алгоритм.</param>
  /// <returns>Расшифровальщик.</returns>
  protected static ICryptoTransform CreateDecryptor(Aes algorithm)
  {
    return algorithm.CreateDecryptor();
  }

  /// <summary>
  /// Создать шифровальщик.
  /// </summary>
  /// <param name="algorithm">Алгоритм.</param>
  /// <returns>Шифровальщик.</returns>
  protected static ICryptoTransform CreateEncryptor(Aes algorithm)
  {
    return algorithm.CreateEncryptor();
  }

  /// <summary>
  /// Трансформировать.
  /// </summary>
  /// <param name="bytes">Байты.</param>
  /// <param name="funcToGetCryptoTransform">Функция для получения шифровальной трансформации.</param>
  /// <returns>Трансформированные байты.</returns>
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
