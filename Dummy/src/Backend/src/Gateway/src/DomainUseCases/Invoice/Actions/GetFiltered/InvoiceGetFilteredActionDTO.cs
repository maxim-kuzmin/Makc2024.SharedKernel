namespace Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetFiltered;

public record InvoiceGetFilteredActionDTO(
  int Amount,
  Guid CustomerId,
  DateOnly Date,
  string Email,
  string Name,
  Guid Id,
  string ImageUrl,
  string Status);
