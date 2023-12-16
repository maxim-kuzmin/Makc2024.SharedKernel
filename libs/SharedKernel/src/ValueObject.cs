namespace Makc2024.SharedKernel;

/// <summary>
/// Объект-значение.
/// Источник: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
/// В C# 10+ в  большинстве случаев можно использовать `readonly record struct`.
/// Источник: https://nietras.com/2021/06/14/csharp-10-record-struct/
/// </summary>
[Serializable]
public abstract class ValueObject : ArdalisSharedKernel.ValueObject
{
}
