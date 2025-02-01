namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных списка фиктивных предметов.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record DummyItemListDTO(
  List<DummyItemSingleDTO> Items,
  long TotalCount) : ListDTO<DummyItemSingleDTO, long>(Items, TotalCount);
