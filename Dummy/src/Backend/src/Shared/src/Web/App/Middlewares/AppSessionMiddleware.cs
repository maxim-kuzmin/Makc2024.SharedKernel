namespace Makc2024.Dummy.Shared.Web.App.Middlewares;

public class AppSessionMiddleware(RequestDelegate _next)
{
  public async Task InvokeAsync(HttpContext httpContext, AppSession appSession)
  {
    appSession.AccessToken = await httpContext.GetTokenAsync("access_token");

    appSession.User = httpContext.User;

    await _next(httpContext);
  }
}
