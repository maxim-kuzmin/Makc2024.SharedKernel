namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;

public interface IDummyItemCreateActionService
{
  Task<Result<long>> CreateAsync(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken = default);
}
