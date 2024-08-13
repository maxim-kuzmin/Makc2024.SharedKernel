namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;

public interface IDummyItemCreateActionHandler :
  ICommandHandler<DummyItemCreateActionCommand, Result<DummyItemGetActionDTO>>;
