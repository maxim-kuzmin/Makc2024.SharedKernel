namespace Gateway.DomainUseCases.Invoice.Actions.GetAmounts;

public record InvoiceGetAmountsActionQuery() : IQuery<Result<InvoiceGetAmountsActionDTO>>;
