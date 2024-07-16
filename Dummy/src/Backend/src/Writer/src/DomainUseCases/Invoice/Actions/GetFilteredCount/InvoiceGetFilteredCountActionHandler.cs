namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetFilteredCount;

public class InvoiceGetFilteredCountActionHandler(IInvoiceGetFilteredCountActionService _service) :
  IQueryHandler<InvoiceGetFilteredCountActionQuery, Result<int>>
{
  public async Task<Result<int>> Handle(InvoiceGetFilteredCountActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _service.GetFilteredCountAsync(request);

    return Result.Success(result);
  }
}
