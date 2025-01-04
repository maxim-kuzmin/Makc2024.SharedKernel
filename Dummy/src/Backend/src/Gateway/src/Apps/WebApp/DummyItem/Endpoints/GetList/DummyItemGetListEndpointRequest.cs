namespace Makc2024.Dummy.Gateway.Apps.WebApp.DummyItem.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка фиктивных предметов.
/// </summary>
public record DummyItemGetListEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
