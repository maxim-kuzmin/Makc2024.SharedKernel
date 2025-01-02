namespace Makc2024.Dummy.Writer.DomainModel.App.Event;

/// <summary>
/// Интерфейс репозитория события приложения.
/// </summary>
public interface IAppEventRepository : IReadRepository<AppEventEntity>,
  IRepository<AppEventEntity>
{
}
