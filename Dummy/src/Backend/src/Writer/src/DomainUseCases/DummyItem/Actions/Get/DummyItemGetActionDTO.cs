namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Объект передачи данных действия по получению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemGetActionDTO(
  long Id,
  string Name);
