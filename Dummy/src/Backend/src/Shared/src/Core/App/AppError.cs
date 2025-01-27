namespace Makc2024.Dummy.Shared.Core.App;

/// <summary>
/// Ошибка приложения.
/// </summary>
/// <param name="Code">Код.</param>
/// <param name="Message">Сообщение.</param>
public record AppError(string Code, string Message);
