namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class DummyItemResources(IStringLocalizer<DummyItemResources> _stringLocalizer) : IDummyItemResources
{
  /// <inheritdoc/>
  public string GetNameIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:NameIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetNameIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:Format:NameIsTooLong", maxLength];
  }
}
