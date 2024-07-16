namespace Gateway.DomainUseCases.Invoice.Actions.GetFilteredCount;

public record InvoiceGetFilteredCountActionQuery(
  InvoiceFilteredQueryFilter Filter) : IQuery<Result<int>>;
