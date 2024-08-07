namespace Makc2024.Dummy.Gateway.DomainModel.App.Config;

public record AppConfigOptionsAuthentication(
  string Issuer,
  string Audience,
  string Key);
