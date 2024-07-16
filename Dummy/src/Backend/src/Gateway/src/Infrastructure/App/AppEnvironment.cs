namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public class AppEnvironment
{
  public static void LoadVariables()
  {
    var loader = new EnvLoader();

    string? env = Environment.GetEnvironmentVariable("MY_ENVIRONMENT");

    if (string.IsNullOrWhiteSpace(env))
    {
      env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

      if (!string.IsNullOrWhiteSpace(env))
      {
        env = env.ToLower();
      }
    }

    if (!string.IsNullOrWhiteSpace(env))
    {
      loader.SetDefaultEnvFileName($".env.{env}");
    }

    loader.Load();
  }
}
