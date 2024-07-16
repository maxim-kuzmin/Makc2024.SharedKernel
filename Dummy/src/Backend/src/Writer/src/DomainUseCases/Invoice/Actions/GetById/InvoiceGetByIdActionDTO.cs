namespace Gateway.DomainUseCases.Invoice.Actions.GetById;

public record InvoiceGetByIdActionDTO(
  int Amount,
  Guid CustomerId,
  Guid Id,
  string Status);
