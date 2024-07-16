namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;

public interface IDummyItemDeleteActionService
{
  Task<bool> DeleteAsync(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken = default);
}
