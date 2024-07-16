namespace Shared.Types;

public struct NonNullableStringType(string value) : IEquatable<NonNullableStringType>
{
  public string Value { get; private set; } = value;

  public readonly bool Equals(NonNullableStringType other) => Value == other.Value;

  public static bool operator ==(NonNullableStringType left, NonNullableStringType right)
  {
    return left.Equals(right);
  }

  public static bool operator !=(NonNullableStringType left, NonNullableStringType right)
  {
    return !(left == right);
  }

  public static implicit operator NonNullableStringType(string value)
  {
    return new NonNullableStringType(value);
  }

  public static implicit operator string(NonNullableStringType value)
  {
    return value.Value;
  }

  public override readonly int GetHashCode()
  {
    return Value.GetHashCode();
  }

  public override readonly bool Equals(object? obj)
  {
    return obj is NonNullableStringType @string && Equals(@string);
  }
}
