namespace Makc2024.Dummy.Gateway.DomainUseCases.App.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с приложением.
/// </summary>
public interface IAppActionCommandService
{
  /// <summary>
  /// Вход.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken);
}
