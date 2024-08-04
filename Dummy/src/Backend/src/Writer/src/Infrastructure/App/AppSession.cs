namespace Makc2024.Dummy.Writer.Infrastructure.App;

public class AppSession : IAppSession
{
  public string? AccessToken { get; set; }

  public ClaimsPrincipal User { get; set; } = null!;
}
