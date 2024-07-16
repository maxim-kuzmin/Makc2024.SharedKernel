namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetById;

public record InvoiceGetByIdActionQuery(Guid Id) : IQuery<Result<InvoiceGetByIdActionDTO>>;
