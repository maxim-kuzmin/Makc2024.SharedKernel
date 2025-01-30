namespace Makc2024.Dummy.Shared.Core.Crypto;

/// <summary>
/// Интерфейс сервиса шифрования.
/// </summary>
public interface ICryptoService
{
  /// <summary>
  /// Расшифровать.
  /// </summary>
  /// <param name="textToDecrypt">Текст для расшифровки.</param>
  /// <returns>Расшифрованный текст.</returns>
  string Decrypt(string textToDecrypt);

  /// <summary>
  /// Зашифровать.
  /// </summary>
  /// <param name="textToEncrypt">Текст для шифровки.</param>
  /// <returns>Зашифрованный текст.</returns>
  string Encrypt(string textToEncrypt);
}
