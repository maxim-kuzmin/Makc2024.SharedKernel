namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Create;

public record InvoiceCreateActionCommand(
  int Amount,
  Guid CustomerId,
  DateOnly Date,
  string Status) : ICommand<Result<Guid>>;
