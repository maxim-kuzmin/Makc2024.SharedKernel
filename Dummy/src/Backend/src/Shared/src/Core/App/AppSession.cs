namespace Makc2024.Dummy.Shared.Core.App;

public class AppSession
{
  public string? AccessToken { get; set; }

  public ClaimsPrincipal User { get; set; } = null!;
}
