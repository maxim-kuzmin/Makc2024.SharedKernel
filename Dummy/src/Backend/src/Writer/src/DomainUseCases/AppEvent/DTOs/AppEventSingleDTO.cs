namespace Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="CreatedAt">Когда создано.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppEventSingleDTO(long Id, DateTimeOffset CreatedAt, bool IsPublished, string Name);
