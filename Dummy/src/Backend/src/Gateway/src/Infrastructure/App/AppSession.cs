namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public class AppSession : IAppSession
{
  public string? AccessToken { get; set; }

  public ClaimsPrincipal User { get; set; } = null!;
}
