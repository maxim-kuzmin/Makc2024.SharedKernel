namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Сущность события приложения.
/// </summary>
public class AppEventEntity : EntityBaseWithIdProperty<long>, IAggregateRoot
{
  /// <summary>
  /// Дата создания.
  /// </summary>
  public DateTimeOffset CreationDate { get; set; }

  /// <summary>
  /// Признак опубликованности.
  /// </summary>
  public bool IsPublished { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = null!;

  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public IEnumerable<AppEventPayloadEntity> Payloads { get; } = [];
}
