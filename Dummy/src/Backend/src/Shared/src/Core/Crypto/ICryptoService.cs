namespace Makc2024.Dummy.Shared.Core.Crypto;

public interface ICryptoService
{
  string Decrypt(string textToDecrypt);
  string Encrypt(string textToEncrypt);
}
