namespace Makc2024.Dummy.Writer.UIs.WebUI.Invoice.Endpoints.Update;

public record InvoiceUpdateEndpointRequest(int Amount, Guid CustomerId, Guid Id, string Status);
