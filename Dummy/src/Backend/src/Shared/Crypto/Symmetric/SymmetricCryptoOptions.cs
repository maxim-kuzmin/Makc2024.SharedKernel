namespace Makc2024.Dummy.Shared.Crypto.Symmetric;

public record SymmetricCryptoOptions(
  string Password,
  string Salt,
  int Iterations);
