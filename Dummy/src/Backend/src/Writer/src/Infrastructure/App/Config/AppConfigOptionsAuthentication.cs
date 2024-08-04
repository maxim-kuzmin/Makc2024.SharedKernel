namespace Makc2024.Dummy.Writer.Infrastructure.App.Config;

public record AppConfigOptionsAuthentication(
  string Issuer,
  string Audience,
  string Key)
{
  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    byte[] keyBytes = Encoding.UTF8.GetBytes(Key);

    return new SymmetricSecurityKey(keyBytes);
  }
}
