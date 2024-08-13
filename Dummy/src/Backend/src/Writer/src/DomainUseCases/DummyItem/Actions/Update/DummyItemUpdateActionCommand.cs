namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;

public record DummyItemUpdateActionCommand(
  long Id,
  string Name) : ICommand<Result<DummyItemGetActionDTO>>;
