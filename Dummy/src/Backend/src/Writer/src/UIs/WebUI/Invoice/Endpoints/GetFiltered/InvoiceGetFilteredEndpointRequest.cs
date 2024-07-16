namespace Makc2024.Dummy.Writer.UIs.WebUI.Invoice.Endpoints.GetFiltered;

public record InvoiceGetFilteredEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
