namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionService(AppDbContext _db) : IDummyItemGetListActionService
{
  public async Task<IEnumerable<DummyItemGetListActionDTO>> GetListAsync(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var dummyItemEntitySettings = appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    int parameterIndex = 0;

    string sqlFormatToFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter.FullTextSearchQuery))
    {
      sqlFormatToFilter = $$"""
where
  di."{{dummyItemEntitySettings.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  di."{{dummyItemEntitySettings.ColumnForName}}" ilike {{{parameterIndex}}}
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");

      parameterIndex++;
    }

    string sqlFormat = $$"""
select
  di."{{dummyItemEntitySettings.ColumnForId}}" "Id",
  di."{{dummyItemEntitySettings.ColumnForName}}" "Name"
from
  "{{appDbSettings.Schema}}"."{{dummyItemEntitySettings.Table}}" di
{{sqlFormatToFilter}}
order by
  di."{{dummyItemEntitySettings.ColumnForId}}" desc
limit {{{parameterIndex++}}}
offset {{{parameterIndex++}}}
""";

    parameters.Add(query.Page.Count);

    parameters.Add((query.Page.Number - 1) * query.Page.Count);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<DummyItemGetListActionDTO>(sql).ToListAsync(cancellationToken);

    return result;
  }
}
