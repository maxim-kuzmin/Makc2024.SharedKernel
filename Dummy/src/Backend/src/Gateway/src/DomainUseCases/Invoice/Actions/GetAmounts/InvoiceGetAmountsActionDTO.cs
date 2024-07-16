namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetAmounts;

public record InvoiceGetAmountsActionDTO(
  int Paid,
  int Pending);
