namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Сущность события приложения.
/// </summary>
public class AppEventEntity : EntityBaseWithIdProperty<long>, IAggregateRoot
{
  /// <summary>
  /// Токен конкуренции.
  /// </summary>
  public Guid ConcurrencyToken { get; set; }

  /// <summary>
  /// Когда создано.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Опубликовано ли?
  /// </summary>
  public bool IsPublished { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = null!;

  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public IEnumerable<AppEventPayloadEntity>? Payloads { get; }
}
