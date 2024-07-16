namespace Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetFiltered;

public record CustomerGetFilteredActionDTO(
  string Email,
  string Name,
  Guid Id,
  string ImageUrl,
  int TotalInvoices,
  int TotalPaid,
  int TotalPending
);
