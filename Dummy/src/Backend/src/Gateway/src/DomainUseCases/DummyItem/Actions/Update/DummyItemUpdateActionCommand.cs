namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;

public record DummyItemUpdateActionCommand(
  long Id,
  string Name) : ICommand<Result<DummyItemUpdateActionDTO>>;
