namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Command;

public interface IDummyItemCommandService
{
  Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken);

  Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken);

  Task<Result<DummyItemGetActionDTO>> Update(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken);
}
