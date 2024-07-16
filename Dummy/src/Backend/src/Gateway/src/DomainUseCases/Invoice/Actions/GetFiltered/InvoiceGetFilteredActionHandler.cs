namespace Gateway.DomainUseCases.Invoice.Actions.GetFiltered;

public class InvoiceGetFilteredActionHandler(IInvoiceGetFilteredActionService _service) :
  IQueryHandler<InvoiceGetFilteredActionQuery, Result<IEnumerable<InvoiceGetFilteredActionDTO>>>
{
  public async Task<Result<IEnumerable<InvoiceGetFilteredActionDTO>>> Handle(
    InvoiceGetFilteredActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetFilteredAsync(request, cancellationToken);

    return Result.Success(result);
  }
}
