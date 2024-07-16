namespace Makc2024.Dummy.Writer.UIs.WebUI.DummyItem.Endpoints.GetList;

public record DummyItemGetListEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
