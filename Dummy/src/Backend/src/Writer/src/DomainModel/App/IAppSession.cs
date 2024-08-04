namespace Makc2024.Dummy.Writer.DomainModel.App;

public interface IAppSession
{
  string? AccessToken { get; set; }

  ClaimsPrincipal User { get; set; }
}
