namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetLatest;

public class InvoiceGetLatestActionHandler(IInvoiceGetLatestActionService _service) :
  IQueryHandler<InvoiceGetLatestActionQuery, Result<IEnumerable<InvoiceGetLatestActionDTO>>>
{
  public async Task<Result<IEnumerable<InvoiceGetLatestActionDTO>>> Handle(InvoiceGetLatestActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _service.GetLatestAsync(request);

    return Result.Success(result);
  }
}
