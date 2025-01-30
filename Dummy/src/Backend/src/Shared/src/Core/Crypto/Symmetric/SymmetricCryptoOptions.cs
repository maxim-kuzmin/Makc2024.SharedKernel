namespace Makc2024.Dummy.Shared.Core.Crypto.Symmetric;

/// <summary>
/// Параметры симметричного шифрования.
/// </summary>
/// <param name="Password">Пароль.</param>
/// <param name="Salt">Соль.</param>
/// <param name="Iterations">Повторения.</param>
public record SymmetricCryptoOptions(
  string Password,
  string Salt,
  int Iterations);
