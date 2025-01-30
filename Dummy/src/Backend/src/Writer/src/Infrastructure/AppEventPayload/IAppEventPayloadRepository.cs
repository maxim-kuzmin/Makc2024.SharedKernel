namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload;

/// <summary>
/// Интерфейс репозитория полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadRepository : IReadRepository<AppEventPayloadEntity>,
  IRepository<AppEventPayloadEntity>
{
}
