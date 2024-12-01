namespace Makc2024.Dummy.Shared.Core.Crypto.Symmetric;

public record SymmetricCryptoOptions(
  string Password,
  string Salt,
  int Iterations);
