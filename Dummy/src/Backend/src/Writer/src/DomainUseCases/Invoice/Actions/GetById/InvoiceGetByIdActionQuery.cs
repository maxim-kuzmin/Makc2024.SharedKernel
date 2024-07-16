namespace Gateway.DomainUseCases.Invoice.Actions.GetById;

public record InvoiceGetByIdActionQuery(Guid Id) : IQuery<Result<InvoiceGetByIdActionDTO>>;
