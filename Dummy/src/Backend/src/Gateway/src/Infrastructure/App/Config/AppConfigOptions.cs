namespace Makc2024.Dummy.Gateway.Infrastructure.App.Config;

public record AppConfigOptions
{
  public const string SectionKey = "App";

  public AppConfigOptionsAuthentication Authentication { get; set; } = null!;

  public AppConfigOptionsWriter Writer { get; set; } = null!;
}
