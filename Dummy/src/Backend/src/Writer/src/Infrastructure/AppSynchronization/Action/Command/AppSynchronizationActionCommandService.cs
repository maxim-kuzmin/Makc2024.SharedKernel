namespace Makc2024.Dummy.Writer.Infrastructure.AppSynchronization.Action.Command;

/// <summary>
/// Сервис команд действия с синхронизацией приложения.
/// </summary>
public class AppSynchronizationActionCommandService(
  IAppEventActionCommandService _appEventActionCommandService,
  IAppEventPayloadActionCommandService _appEventPayloadActionCommandService
  ) : IAppSynchronizationActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Start(AppSynchronizationStartActionCommand command, CancellationToken cancellationToken)
  {
    var appEventActionCommandResult = await _appEventActionCommandService.Create(
      new(false, command.AppEventName),
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

  /// <inheritdoc/>
  public Task<Result> Finish()
  {
    return Task.FromResult(Result.NoContent());
  }
}
