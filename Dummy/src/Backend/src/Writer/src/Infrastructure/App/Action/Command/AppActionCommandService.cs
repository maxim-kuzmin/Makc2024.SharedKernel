﻿namespace Makc2024.Dummy.Writer.Infrastructure.App.Action.Command;

/// <summary>
/// Сервис команд действия с приложением.
/// </summary>
/// <param name="_appConfigOptions">Параметры конфигурации приложения.</param>
public class AppActionCommandService(IOptionsSnapshot<AppConfigOptions> _appConfigOptions) : IAppActionCommandService
{
  /// <inheritdoc/>
  public Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken)
  {
    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, command.UserName)
    };

    var issuerSigningKey = _appConfigOptions.Value.Authentication.GetSymmetricSecurityKey();

    var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

    var expires = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

    var jwt = new JwtSecurityToken(
      issuer: _appConfigOptions.Value.Authentication.Issuer,
      audience: _appConfigOptions.Value.Authentication.Audience,
      claims: claims,
      expires: expires,
      signingCredentials: signingCredentials);

    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

    var dto = new AppLoginActionDTO(command.UserName, accessToken);

    var result = Result.Success(dto);

    return Task.FromResult(result);
  }
}
