namespace Makc2024.Dummy.Gateway.DomainModel.App;

public interface IAppSession
{
  bool IsUserAuthenticated { get; }

  string UserName { get; }
}
