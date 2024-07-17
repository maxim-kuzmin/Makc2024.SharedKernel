namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;

public interface IDummyItemDeleteActionService
{
  Task<Result<bool>> DeleteAsync(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken = default);
}
