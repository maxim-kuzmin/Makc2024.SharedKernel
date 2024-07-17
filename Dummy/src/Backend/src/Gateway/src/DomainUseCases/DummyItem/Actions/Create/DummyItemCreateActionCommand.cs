namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;

public record DummyItemCreateActionCommand(
  string Name) : ICommand<Result<long>>;
