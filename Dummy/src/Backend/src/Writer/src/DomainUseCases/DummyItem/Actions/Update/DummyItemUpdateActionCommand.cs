namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;

/// <summary>
/// Команда действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemUpdateActionCommand(
  long Id,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;
