namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Update;

public record InvoiceUpdateActionDTO(
  int Amount,
  Guid CustomerId,
  Guid Id,
  string Status);
