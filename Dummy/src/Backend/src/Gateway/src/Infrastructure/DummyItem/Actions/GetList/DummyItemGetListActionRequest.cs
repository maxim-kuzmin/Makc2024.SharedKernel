namespace Makc2024.Dummy.Gateway.UIs.WebUI.DummyItem.Endpoints.GetList;

public record DummyItemGetListActionRequest(int CurrentPage, int ItemsPerPage, string? Query);
