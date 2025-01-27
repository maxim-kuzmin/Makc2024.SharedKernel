namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppEventResources(IStringLocalizer<AppEventResources> _stringLocalizer) : IAppEventResources
{
  /// <inheritdoc/>
  public string GetCreatedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:CreatedAtIsInvalid"];
  }

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
