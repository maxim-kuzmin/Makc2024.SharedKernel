namespace Makc2024.Dummy.Writer.DomainModel.App.EventPayload;

/// <summary>
/// Интерфейс репозитория полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadRepository : IReadRepository<AppEventPayloadEntity>,
  IRepository<AppEventPayloadEntity>
{
}
