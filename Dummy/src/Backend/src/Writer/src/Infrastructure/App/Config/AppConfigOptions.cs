namespace Makc2024.Dummy.Writer.Infrastructure.App.Config;

public record AppConfigOptions()
{
  public const string SectionKey = "App";

  public AppConfigOptionsAuthentication Authentication { get; set; } = null!;

  public bool IsRetryEnabledByOrchestrator { get; set; }

  public string Language { get; set; } = null!;

  public AppConfigOptionsPostgreSQL PostgreSQL { get; set; } = null!;
}
