namespace Makc2024.Dummy.Gateway.Infrastructure.User.Actions.GetByEmail;

public class UserGetByEmailActionService(AppDbContext _db) : IUserGetByEmailActionService
{
  public async Task<UserGetByEmailActionDTO?> GetByEmailAsync(
    UserGetByEmailActionQuery query,
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var userEntitySettings = appDbSettings.Entities.User;

    var parameters = new List<object>();

    int parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{userEntitySettings.ColumnForEmail}}" "Email",
  "{{userEntitySettings.ColumnForId}}" "Id",
  "{{userEntitySettings.ColumnForName}}" "Name",
"{{userEntitySettings.ColumnForPassword}}" "Password"
from
  "{{appDbSettings.Schema}}"."{{userEntitySettings.Table}}"
where
  "{{userEntitySettings.ColumnForEmail}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Email);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<UserGetByEmailActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    return result;
  }
}
