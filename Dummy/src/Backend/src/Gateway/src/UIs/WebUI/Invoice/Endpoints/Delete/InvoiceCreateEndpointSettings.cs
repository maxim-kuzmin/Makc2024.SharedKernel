﻿namespace Gateway.UIs.WebUI.Invoice.Endpoints.Delete;

public class InvoiceDeleteEndpointSettings
{
  public const string Route = $"{InvoiceEndpointSettings.Root}/{{id:Guid}}";
}
