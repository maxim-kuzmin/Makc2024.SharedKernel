namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
/// <param name="MaxLengthForData">Максимальная длина для данных.</param>
public record AppEventPayloadSettings(int MaxLengthForData);
