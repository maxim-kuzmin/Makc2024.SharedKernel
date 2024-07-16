namespace Gateway.DomainUseCases.Invoice.Actions.GetCount;

public record InvoiceGetCountActionQuery() : IQuery<Result<int>>;
