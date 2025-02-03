namespace Makc2024.Dummy.Writer.DomainUseCases.AppProducer.Action.Command;

/// <summary>
/// Сервис команд действия с поставщиком приложения.
/// </summary>
public class AppProducerActionCommandService(
  IAppEventActionCommandService _appEventActionCommandService,
  IAppEventPayloadActionCommandService _appEventPayloadActionCommandService
  ) : IAppProducerActionCommandService
{
  /// <inheritdoc/>
  public Task<Result> Publish(CancellationToken cancellationToken)
  {
    return Task.FromResult(Result.NoContent());
  }

  /// <inheritdoc/>
  public async Task<Result> Save(AppProducerSaveActionCommand command, CancellationToken cancellationToken)
  {
    var appEventActionCommandResult = await _appEventActionCommandService.Create(
      new(false, command.AppEventName.ToString()),
      cancellationToken);

    foreach (var payload in command.AppEventPayloads)
    {
      await _appEventPayloadActionCommandService.Create(
        new(
          appEventActionCommandResult.Value.Id,
          JsonSerializer.Serialize(payload)
        ),
        cancellationToken);
    }

    return Result.NoContent();
  }
}
