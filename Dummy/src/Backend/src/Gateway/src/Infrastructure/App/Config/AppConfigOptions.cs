namespace Makc2024.Dummy.Gateway.Infrastructure.App.Config;

public record AppConfigOptions()
{
  public const string SectionKey = "App";

  public bool IsRetryEnabledByOrchestrator { get; set; }

  public string Language { get; set; } = null!;

  public AppConfigOptionsPostgreSQL PostgreSQL { get; set; } = null!;
}
