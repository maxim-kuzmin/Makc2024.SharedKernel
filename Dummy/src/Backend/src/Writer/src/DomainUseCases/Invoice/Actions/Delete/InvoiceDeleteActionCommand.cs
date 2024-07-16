namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Delete;

public record InvoiceDeleteActionCommand(Guid Id) : ICommand<Result>;
