namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Update;

public class InvoiceUpdateActionHandler(IInvoiceUpdateActionService _service) :
  ICommandHandler<InvoiceUpdateActionCommand, Result<InvoiceUpdateActionDTO>>
{
  public async Task<Result<InvoiceUpdateActionDTO>> Handle(
    InvoiceUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.UpdateAsync(request, cancellationToken);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
