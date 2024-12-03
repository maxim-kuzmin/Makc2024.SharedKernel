namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem;

public interface IDummyItemService
{
  Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken);

  Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken);

  Task<Result<DummyItemGetActionDTO>> Get(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken);

  Task<Result<DummyItemGetListActionDTO>> GetList(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken);

  Task<Result<DummyItemGetActionDTO>> Update(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken);
}
