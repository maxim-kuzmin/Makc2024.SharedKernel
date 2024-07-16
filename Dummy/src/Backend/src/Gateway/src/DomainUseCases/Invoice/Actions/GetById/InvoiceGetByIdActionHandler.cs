namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetById;

public class InvoiceGetByIdActionHandler(IInvoiceGetByIdActionService _service) :
  IQueryHandler<InvoiceGetByIdActionQuery, Result<InvoiceGetByIdActionDTO>>
{
  public async Task<Result<InvoiceGetByIdActionDTO>> Handle(
    InvoiceGetByIdActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetByIdAsync(request, cancellationToken);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
