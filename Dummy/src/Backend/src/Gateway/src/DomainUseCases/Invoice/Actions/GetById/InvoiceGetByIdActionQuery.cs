namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetById;

public record InvoiceGetByIdActionQuery(Guid Id) : IQuery<Result<InvoiceGetByIdActionDTO>>;
