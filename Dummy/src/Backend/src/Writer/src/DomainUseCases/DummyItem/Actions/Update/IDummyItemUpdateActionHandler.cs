namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;

public interface IDummyItemUpdateActionHandler :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemUpdateActionDTO>>;
