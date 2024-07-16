namespace Makc2024.Dummy.Gateway.UIs.WebUI.Invoice.Endpoints.Update;

public record InvoiceUpdateEndpointRequest(int Amount, Guid CustomerId, Guid Id, string Status);
