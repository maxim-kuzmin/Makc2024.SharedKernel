using System.Security.Claims;

namespace Makc2024.Dummy.Gateway.DomainModel.App;

public interface IAppSession
{
  string? AccessToken { get; set; }

  ClaimsPrincipal User { get; set; }
}
