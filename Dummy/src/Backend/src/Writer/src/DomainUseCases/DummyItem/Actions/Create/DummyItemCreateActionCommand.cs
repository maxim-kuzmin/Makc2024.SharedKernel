namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;

public record DummyItemCreateActionCommand(
  string Name) : ICommand<Result<long>>;
