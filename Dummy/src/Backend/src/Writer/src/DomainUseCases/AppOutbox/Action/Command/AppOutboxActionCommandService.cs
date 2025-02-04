namespace Makc2024.Dummy.Writer.DomainUseCases.AppOutbox.Action.Command;

/// <summary>
/// Сервис команд действия с исходящими сообщениями приложения.
/// </summary>
public class AppOutboxActionCommandService(
  IAppEventActionCommandService _appEventActionCommandService,
  IAppEventPayloadActionCommandService _appEventPayloadActionCommandService
  ) : IAppOutboxActionCommandService
{
  /// <inheritdoc/>
  public Task<Result> Produce(CancellationToken cancellationToken)
  {
    return Task.FromResult(Result.NoContent());
  }

  /// <inheritdoc/>
  public async Task<Result> Save(AppOutboxSaveActionCommand command, CancellationToken cancellationToken)
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
