namespace Gateway.DomainUseCases.Invoice.Actions.Update;

public record InvoiceUpdateActionCommand(
  int Amount,
  Guid CustomerId,
  Guid Id,
  string Status) : ICommand<Result<InvoiceUpdateActionDTO>>;
