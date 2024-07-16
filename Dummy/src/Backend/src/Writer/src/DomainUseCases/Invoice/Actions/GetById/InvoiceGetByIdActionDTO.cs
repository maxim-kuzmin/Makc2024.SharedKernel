namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetById;

public record InvoiceGetByIdActionDTO(
  int Amount,
  Guid CustomerId,
  Guid Id,
  string Status);
