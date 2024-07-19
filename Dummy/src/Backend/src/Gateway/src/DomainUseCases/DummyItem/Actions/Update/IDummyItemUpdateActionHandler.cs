namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;

public interface IDummyItemUpdateActionHandler :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemUpdateActionDTO>>;
