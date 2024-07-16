namespace Gateway.DomainUseCases.Invoice.Actions.GetAmounts;

public record InvoiceGetAmountsActionDTO(
  int Paid,
  int Pending);
