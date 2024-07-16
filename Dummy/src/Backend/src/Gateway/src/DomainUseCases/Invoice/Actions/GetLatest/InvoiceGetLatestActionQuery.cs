namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetLatest;

public record InvoiceGetLatestActionQuery(
  int Limit) : IQuery<Result<IEnumerable<InvoiceGetLatestActionDTO>>>;
