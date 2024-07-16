namespace Gateway.UIs.WebUI.Invoice.Endpoints.GetById;

public class InvoiceGetByIdEndpointSettings
{
  public const string Route = $"{InvoiceEndpointSettings.Root}/{{id:Guid}}";
}
