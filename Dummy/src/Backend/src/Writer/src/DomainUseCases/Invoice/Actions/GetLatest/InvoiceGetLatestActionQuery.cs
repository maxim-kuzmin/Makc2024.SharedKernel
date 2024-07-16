namespace Gateway.DomainUseCases.Invoice.Actions.GetLatest;

public record InvoiceGetLatestActionQuery(
  int Limit) : IQuery<Result<IEnumerable<InvoiceGetLatestActionDTO>>>;
