namespace Makc2024.Dummy.Writer.Infrastructure.App.Actions.Login;

public class AppLoginActionHandler(IOptionsSnapshot<AppConfigOptions> _appConfigOptions) : IAppLoginActionHandler
{
  public Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, request.UserName)
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

    string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

    var dto = new AppLoginActionDTO(request.UserName, accessToken);

    var result = Result.Success(dto);

    return Task.FromResult(result);
  }
}
