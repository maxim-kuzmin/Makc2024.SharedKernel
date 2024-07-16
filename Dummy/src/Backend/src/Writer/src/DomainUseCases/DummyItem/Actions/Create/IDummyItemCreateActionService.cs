namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;

public interface IDummyItemCreateActionService
{
  Task<long?> CreateAsync(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken = default);
}
