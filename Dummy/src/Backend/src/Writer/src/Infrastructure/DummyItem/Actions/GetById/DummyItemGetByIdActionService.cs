namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionService(AppDbContext _db) : IDummyItemGetByIdActionService
{
  public async Task<DummyItemGetByIdActionDTO?> GetByIdAsync(
    DummyItemGetByIdActionQuery query,
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var dummyItemEntitySettings = appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    int parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{dummyItemEntitySettings.ColumnForId}}" "Id",
  "{{dummyItemEntitySettings.ColumnForName}}" "Name"
from
  "{{appDbSettings.Schema}}"."{{dummyItemEntitySettings.Table}}"
where
  "{{dummyItemEntitySettings.ColumnForId}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<DummyItemGetByIdActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    return result;
  }
}
