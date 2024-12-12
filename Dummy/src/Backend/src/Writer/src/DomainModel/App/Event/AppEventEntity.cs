namespace Makc2024.Dummy.Writer.DomainModel.App.Event;

/// <summary>
/// Сущность события приложения.
/// </summary>
public class AppEventEntity : EntityBaseWithIdProperty<long>, IAggregateRoot
{
  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = null!;

  /// <summary>
  /// Дата создания.
  /// </summary>
  public DateTimeOffset CreationDate { get; set; }
}
