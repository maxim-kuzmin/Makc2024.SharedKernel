namespace Makc2024.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению в базе данных события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxSaveActionHandler(IAppOutboxActionCommandService _service) :
  ICommandHandler<AppOutboxSaveActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppOutboxSaveActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Save(request, cancellationToken);
  }
}
