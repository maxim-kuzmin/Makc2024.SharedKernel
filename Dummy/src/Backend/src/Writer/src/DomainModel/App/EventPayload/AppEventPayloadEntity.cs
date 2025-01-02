namespace Makc2024.Dummy.Writer.DomainModel.App.EventPayload;

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
  /// Сущность.
  /// </summary>
  public string Entity { get; set; } = null!;

  /// <summary>
  /// Идентификатор сущности.
  /// </summary>
  public string EntityId { get; set; } = null!;

  /// <summary>
  /// Имя.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Новое значение.
  /// </summary>
  public string? NewValue { get; set; }

  /// <summary>
  /// Старое значение.
  /// </summary>
  public string? OldValue { get; set; }

  /// <summary>
  /// Событие.
  /// </summary>
  public AppEventEntity Event { get; private set; } = null!;
}
