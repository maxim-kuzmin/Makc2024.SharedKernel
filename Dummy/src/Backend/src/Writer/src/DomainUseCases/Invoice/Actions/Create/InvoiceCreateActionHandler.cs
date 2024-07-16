namespace Gateway.DomainUseCases.Invoice.Actions.Create;

public class InvoiceCreateActionHandler(IInvoiceCreateActionService _service) :
  ICommandHandler<InvoiceCreateActionCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(
    InvoiceCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.CreateAsync(request, cancellationToken);

    return result != null ? Result.Success(result.Value) : Result.NotFound();
  }
}
