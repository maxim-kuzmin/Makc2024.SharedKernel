namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Сущность полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadEntity : EntityBaseWithIdProperty<long>, IAggregateRoot
{
  /// <summary>
  /// Идентификатор события приложения.
  /// </summary>
  public long AppEventId { get; set; }

  /// <summary>
  /// Токен конкуренции.
  /// </summary>
  public Guid ConcurrencyToken { get; set; }

  /// <summary>
  /// Данные.
  /// </summary>
  public string Data { get; set; } = null!;

  /// <summary>
  /// Событие.
  /// </summary>
  public AppEventEntity? Event { get; private set; }
}
