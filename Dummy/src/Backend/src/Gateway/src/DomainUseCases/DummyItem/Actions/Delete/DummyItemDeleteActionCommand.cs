namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;

public record DummyItemDeleteActionCommand(long Id) : ICommand<Result>;
