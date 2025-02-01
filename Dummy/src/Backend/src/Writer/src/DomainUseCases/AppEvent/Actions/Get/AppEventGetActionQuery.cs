using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению события приложения.
/// </summary>
/// <param name="Id"></param>
public record AppEventGetActionQuery(long Id) : IQuery<Result<AppEventSingleDTO>>;
