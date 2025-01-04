namespace Makc2024.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка событий приложения.
/// </summary>
public record AppEventGetListEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
