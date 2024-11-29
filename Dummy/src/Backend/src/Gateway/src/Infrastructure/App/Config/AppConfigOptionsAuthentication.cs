namespace Makc2024.Dummy.Gateway.Infrastructure.App.Config;

public record AppConfigOptionsAuthentication(
  string Issuer,
  string Audience,
  string Key);
