namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Delete;

public record InvoiceDeleteActionCommand(Guid Id) : ICommand<Result>;
