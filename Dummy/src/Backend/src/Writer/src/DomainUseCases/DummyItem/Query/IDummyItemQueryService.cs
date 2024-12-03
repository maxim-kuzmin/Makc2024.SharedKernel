namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Query;

public interface IDummyItemQueryService
{
  Task<Result<DummyItemGetActionDTO>> Get(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken);

  Task<Result<DummyItemGetListActionDTO>> GetList(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken);
}
