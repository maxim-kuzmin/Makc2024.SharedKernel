namespace Makc2024.Dummy.Writer.DomainUseCases.AppProducer.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению в базе данных события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppProducerSaveActionHandler(IAppProducerActionCommandService _service) :
  ICommandHandler<AppProducerSaveActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppProducerSaveActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Save(request, cancellationToken);
  }
}
