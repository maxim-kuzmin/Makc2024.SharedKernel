namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных действия по получению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemSingleDTO(long Id, string Name);
