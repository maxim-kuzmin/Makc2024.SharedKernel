namespace Makc2024.Dummy.Shared.Apps.WebApp.App.Middlewares;

/// <summary>
/// Промежуточный обработчик запроса для инициализации сессии приложения.
/// </summary>
/// <param name="_next">Следующий обработчик запроса.</param>
public class AppSessionMiddleware(RequestDelegate _next)
{
  /// <summary>
  /// Выполнить асинхронно.
  /// </summary>
  /// <param name="httpContext">HTTP-контекст.</param>
  /// <param name="appSession">Сессия приложения.</param>
  /// <returns>Задача.</returns>
  public async Task InvokeAsync(HttpContext httpContext, AppSession appSession)
  {
    appSession.AccessToken = await httpContext.GetTokenAsync("access_token");

    appSession.User = httpContext.User;

    await _next(httpContext);
  }
}
