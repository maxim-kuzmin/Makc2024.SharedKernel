namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventDeleteActionHandler(IAppEventActionCommandService _service) :
  ICommandHandler<AppEventDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppEventDeleteActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Delete(request, cancellationToken);
  }
}
