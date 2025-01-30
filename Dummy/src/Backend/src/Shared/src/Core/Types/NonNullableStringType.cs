namespace Makc2024.Dummy.Shared.Core.Types;

/// <summary>
/// Тип строки, не содержащей нулевое значение.
/// </summary>
/// <param name="value"></param>
public struct NonNullableStringType(string value) : IEquatable<NonNullableStringType>
{
  /// <summary>
  /// Значение.
  /// </summary>
  public string Value { get; private set; } = value;

  /// <summary>
  /// Равно.
  /// </summary>
  /// <param name="other">Другое значение.</param>
  /// <returns>Если равно другому значению, то true, иначе - false.</returns>
  public readonly bool Equals(NonNullableStringType other) => Value == other.Value;

  /// <summary>
  /// Оператор равенства.
  /// </summary>
  /// <param name="left">Левый операнд.</param>
  /// <param name="right">Правый операнд.</param>
  /// <returns>Если операнды равны, то true, иначе - false.</returns>
  public static bool operator ==(NonNullableStringType left, NonNullableStringType right)
  {
    return left.Equals(right);
  }

  /// <summary>
  /// Оператор неравенства.
  /// </summary>
  /// <param name="left">Левый операнд.</param>
  /// <param name="right">Правый операнд.</param>
  /// <returns>Если операнды не равны, то true, иначе - false.</returns>
  public static bool operator !=(NonNullableStringType left, NonNullableStringType right)
  {
    return !(left == right);
  }

  /// <summary>
  /// Оператор неявного преобразования к строке, не содержащей нулевое значение.
  /// </summary>
  /// <param name="value">Значение.</param>
  public static implicit operator NonNullableStringType(string value)
  {
    return new NonNullableStringType(value);
  }

  /// <summary>
  /// Оператор неявного преобразования к строке.
  /// </summary>
  /// <param name="value">Значение.</param>
  public static implicit operator string(NonNullableStringType value)
  {
    return value.Value;
  }

  /// <inheritdoc/>
  public override readonly int GetHashCode()
  {
    return Value.GetHashCode();
  }

  /// <inheritdoc/>
  public override readonly bool Equals(object? obj)
  {
    return obj is NonNullableStringType @string && Equals(@string);
  }
}
