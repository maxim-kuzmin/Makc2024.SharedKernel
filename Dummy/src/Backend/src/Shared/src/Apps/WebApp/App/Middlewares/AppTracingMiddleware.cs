namespace Makc2024.Dummy.Shared.Apps.WebApp.App.Middlewares;

/// <summary>
/// Промежуточный обработчик запроса для добавления заголовка с идентификатором трассировки.
/// </summary>
/// <param name="_next">Следующий обработчик запроса.</param>
public class AppTracingMiddleware(RequestDelegate _next)
{
  /// <summary>
  /// Выполнить асинхронно.
  /// </summary>
  /// <param name="httpContext">HTTP-контекст.</param>
  /// <returns>Задача.</returns>
  public async Task InvokeAsync(HttpContext httpContext)
  {
    var traceId = Activity.Current!.TraceId.ToString();

    const string key = "TraceId";

    using (LogContext.PushProperty(key, traceId))
    {
      httpContext.Response.Headers.Append(key, traceId);

      await _next(httpContext);
    }
  }
}
