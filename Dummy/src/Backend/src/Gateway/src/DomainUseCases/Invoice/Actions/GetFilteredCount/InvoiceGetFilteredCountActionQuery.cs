namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetFilteredCount;

public record InvoiceGetFilteredCountActionQuery(
  InvoiceFilteredQueryFilter Filter) : IQuery<Result<int>>;
