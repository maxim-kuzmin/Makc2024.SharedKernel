namespace Makc2024.Dummy.Writer.DomainModel.App;

public class AppSession
{
  public string? AccessToken { get; set; }

  public ClaimsPrincipal User { get; set; } = null!;
}
