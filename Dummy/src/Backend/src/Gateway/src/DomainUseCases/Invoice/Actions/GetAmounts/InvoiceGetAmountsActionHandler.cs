namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetAmounts;

public class InvoiceGetAmountsActionHandler(IInvoiceGetAmountsActionService _service) :
  IQueryHandler<InvoiceGetAmountsActionQuery, Result<InvoiceGetAmountsActionDTO>>
{
  public async Task<Result<InvoiceGetAmountsActionDTO>> Handle(
    InvoiceGetAmountsActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetAmountsAsync(cancellationToken);

    return Result.Success(result);
  }
}
