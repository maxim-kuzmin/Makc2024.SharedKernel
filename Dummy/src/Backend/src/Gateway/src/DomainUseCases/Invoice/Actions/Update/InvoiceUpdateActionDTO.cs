namespace Gateway.DomainUseCases.Invoice.Actions.Update;

public record InvoiceUpdateActionDTO(
  int Amount,
  Guid CustomerId,
  Guid Id,
  string Status);
