namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;

public record DummyItemDeleteActionCommand(long Id) : ICommand<Result>;
