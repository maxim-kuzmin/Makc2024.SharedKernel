namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList.DTO;

/// <summary>
/// Элемент объекта передачи данных действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemGetListActionDTOItem(
  long Id,
  string Name);
