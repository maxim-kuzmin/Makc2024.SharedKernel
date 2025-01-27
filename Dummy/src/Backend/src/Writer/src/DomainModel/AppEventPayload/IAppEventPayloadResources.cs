namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Интерфейс ресурсов нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadResources
{
  /// <summary>
  /// Получить сообщение об ошибке недействительного идентификатора события приложения.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetAppEventIdIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке пустых данных.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetDataIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинных данных.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetDataIsTooLongErrorMessage(int maxLength);
}
