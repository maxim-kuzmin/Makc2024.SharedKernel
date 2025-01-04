namespace Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки события приложения.
/// </summary>
/// <param name="Id"></param>
public record AppEventPayloadGetActionQuery(long Id) : IQuery<Result<AppEventPayloadGetActionDTO>>;
