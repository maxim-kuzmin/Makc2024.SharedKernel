namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;

public interface IDummyItemUpdateActionService
{
  Task<Result<DummyItemUpdateActionDTO>> UpdateAsync(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken = default);
}
