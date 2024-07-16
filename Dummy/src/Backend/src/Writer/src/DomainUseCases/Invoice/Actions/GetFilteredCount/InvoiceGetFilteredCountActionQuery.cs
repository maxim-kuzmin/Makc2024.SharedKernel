namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetFilteredCount;

public record InvoiceGetFilteredCountActionQuery(
  InvoiceFilteredQueryFilter Filter) : IQuery<Result<int>>;
