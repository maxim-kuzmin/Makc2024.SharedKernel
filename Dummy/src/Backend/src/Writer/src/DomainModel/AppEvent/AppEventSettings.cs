namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Настройки события приложения.
/// </summary>
/// <param name="MaxLengthForName">Максимальная длина для имени.</param>
public record AppEventSettings(int MaxLengthForName);
