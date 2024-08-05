namespace Makc2024.Dummy.Gateway.DomainModel.App;

public class AppSession
{
  public string? AccessToken { get; set; }

  public ClaimsPrincipal User { get; set; } = null!;
}
