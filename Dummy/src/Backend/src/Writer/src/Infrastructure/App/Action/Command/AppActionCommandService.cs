namespace Makc2024.Dummy.Writer.Infrastructure.App.Action.Command;

/// <summary>
/// Сервис команд действия с приложением.
/// </summary>
/// <param name="_appConfigOptions">Параметры конфигурации приложения.</param>
public class AppActionCommandService(IOptionsSnapshot<AppConfigOptions> _appConfigOptions) : IAppActionCommandService
{
  /// <inheritdoc/>
  public Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken)
  {
    var authentication = _appConfigOptions.Value.Authentication;
    
    if (authentication == null)
    {      
      return Task.FromResult<Result<AppLoginActionDTO>>(
        Result.CriticalError("Authentication configuration options not found"));
    }

    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, command.UserName)
    };

    var issuerSigningKey = authentication.GetSymmetricSecurityKey();

    var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

    var expires = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

    var jwt = new JwtSecurityToken(
      issuer: authentication.Issuer,
      audience: authentication.Audience,
      claims: claims,
      expires: expires,
      signingCredentials: signingCredentials);

    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

    var dto = new AppLoginActionDTO(command.UserName, accessToken);

    return Task.FromResult(Result.Success(dto));
  }
}
