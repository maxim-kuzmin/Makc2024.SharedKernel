namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetCount;

public class InvoiceGetCountActionHandler(IInvoiceGetCountActionService _service) :
  IQueryHandler<InvoiceGetCountActionQuery, Result<int>>
{
  public async Task<Result<int>> Handle(
    InvoiceGetCountActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetCountAsync(cancellationToken);

    return Result.Success(result);
  }
}
