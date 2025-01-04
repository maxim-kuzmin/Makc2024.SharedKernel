namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Настройки фиктивного предмета.
/// </summary>
public abstract class DummyItemSettings
{
  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
