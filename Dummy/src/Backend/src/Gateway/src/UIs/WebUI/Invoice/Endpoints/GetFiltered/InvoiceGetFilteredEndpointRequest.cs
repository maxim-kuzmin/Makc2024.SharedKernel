namespace Gateway.UIs.WebUI.Invoice.Endpoints.GetFiltered;

public record InvoiceGetFilteredEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
