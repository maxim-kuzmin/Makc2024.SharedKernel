namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;

public interface IDummyItemCreateActionHandler :
  ICommandHandler<DummyItemCreateActionCommand, Result<DummyItemGetActionDTO>>;
