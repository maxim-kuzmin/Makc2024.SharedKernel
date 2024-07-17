namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

public interface IDummyItemGetListActionService
{
  Task<Result<IEnumerable<DummyItemGetListActionDTO>>> GetListAsync(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken = default);
}
