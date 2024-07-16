namespace Gateway.DomainUseCases.Invoice.Actions.Delete;

public class InvoiceDeleteActionHandler(IInvoiceDeleteActionService _service) :
  ICommandHandler<InvoiceDeleteActionCommand, Result>
{
  public async Task<Result> Handle(
    InvoiceDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var isOk = await _service.DeleteAsync(request, cancellationToken);

    return isOk ? Result.Success() : Result.NotFound();
  }
}
