namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public class AppSession(ClaimsPrincipal _claimsPrincipal) : IAppSession
{
  public bool IsUserAuthenticated { get; } = _claimsPrincipal.Identity?.IsAuthenticated == true;

  public string UserName { get; } = _claimsPrincipal.Identity?.Name ?? string.Empty;
}
