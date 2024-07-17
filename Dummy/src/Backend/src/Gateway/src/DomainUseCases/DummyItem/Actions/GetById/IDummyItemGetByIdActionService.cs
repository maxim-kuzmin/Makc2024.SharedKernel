namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetById;

public interface IDummyItemGetByIdActionService
{
  Task<Result<DummyItemGetByIdActionDTO>> GetByIdAsync(
    DummyItemGetByIdActionQuery query,
    CancellationToken cancellationToken = default);
}
