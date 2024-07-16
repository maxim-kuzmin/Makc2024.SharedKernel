namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;

public interface IDummyItemUpdateActionService
{
  Task<DummyItemUpdateActionDTO?> UpdateAsync(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken = default);
}
