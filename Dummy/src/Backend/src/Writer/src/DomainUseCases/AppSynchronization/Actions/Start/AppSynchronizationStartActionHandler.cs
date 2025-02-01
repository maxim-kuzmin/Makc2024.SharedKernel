namespace Makc2024.Dummy.Writer.DomainUseCases.AppSynchronization.Actions.Start;

/// <summary>
/// Обработчик действия по запуску синхронизации приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppSynchronizationStartActionHandler(IAppSynchronizationActionCommandService _service) :
  ICommandHandler<AppSynchronizationStartActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppSynchronizationStartActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Start(request, cancellationToken);
  }
}
