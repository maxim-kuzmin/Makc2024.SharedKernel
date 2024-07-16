namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

public interface IDummyItemGetListActionService
{
  Task<IEnumerable<DummyItemGetListActionDTO>> GetListAsync(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken = default);
}
