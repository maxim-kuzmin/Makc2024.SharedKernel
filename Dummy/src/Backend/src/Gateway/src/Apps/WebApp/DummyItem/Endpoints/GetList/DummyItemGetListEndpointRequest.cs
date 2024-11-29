namespace Makc2024.Dummy.Gateway.Apps.WebApp.DummyItem.Endpoints.GetList;

public record DummyItemGetListEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
