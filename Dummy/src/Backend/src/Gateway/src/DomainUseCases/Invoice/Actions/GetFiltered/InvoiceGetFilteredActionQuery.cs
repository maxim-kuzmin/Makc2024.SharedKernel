namespace Gateway.DomainUseCases.Invoice.Actions.GetFiltered;

public record InvoiceGetFilteredActionQuery(
  QueryPage Page,
  InvoiceFilteredQueryFilter Filter) : IQuery<Result<IEnumerable<InvoiceGetFilteredActionDTO>>>;
