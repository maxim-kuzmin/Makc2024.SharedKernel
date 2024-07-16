namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetById;

public interface IDummyItemGetByIdActionService
{
  Task<DummyItemGetByIdActionDTO?> GetByIdAsync(
    DummyItemGetByIdActionQuery query,
    CancellationToken cancellationToken = default);
}
