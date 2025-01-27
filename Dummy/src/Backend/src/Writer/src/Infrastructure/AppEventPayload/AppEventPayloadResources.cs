namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppEventPayloadResources(IStringLocalizer<AppEventPayloadResources> _stringLocalizer) : IAppEventPayloadResources
{
  /// <inheritdoc/>
  public string GetAppEventIdIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:EventIdIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetDataIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:DataIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetDataIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:Format:DataIsTooLong", maxLength];
  }
}
