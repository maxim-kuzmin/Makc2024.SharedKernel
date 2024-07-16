namespace Makc2024.Dummy.Writer.UIs.WebUI.Invoice.Endpoints.Create;

public record InvoiceCreateEndpointRequest(int Amount, Guid CustomerId, DateOnly Date, string Status);
