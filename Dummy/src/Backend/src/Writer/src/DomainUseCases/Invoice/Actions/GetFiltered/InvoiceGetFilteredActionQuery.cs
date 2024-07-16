namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetFiltered;

public record InvoiceGetFilteredActionQuery(
  QueryPage Page,
  InvoiceFilteredQueryFilter Filter) : IQuery<Result<IEnumerable<InvoiceGetFilteredActionDTO>>>;
