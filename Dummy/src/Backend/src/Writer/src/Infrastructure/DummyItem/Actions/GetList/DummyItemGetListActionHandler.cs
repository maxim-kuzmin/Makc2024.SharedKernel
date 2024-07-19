namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(AppDbContext _db) : IDummyItemGetListActionHandler
{
  public async Task<Result<List<DummyItemGetListActionDTO>>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var dummyItemEntitySettings = appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    int parameterIndex = 0;
    string sqlFormatToFilter = string.Empty;

    if (!string.IsNullOrEmpty(request.Filter.FullTextSearchQuery))
    {
      sqlFormatToFilter = $$"""
where
  di."{{dummyItemEntitySettings.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  di."{{dummyItemEntitySettings.ColumnForName}}" ilike {{{parameterIndex}}}
"""
      ;

      parameters.Add($"%{request.Filter.FullTextSearchQuery}%");

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
limit
    {{{parameterIndex++}}}
offset
    {{{parameterIndex++}}}
""";

    parameters.Add(request.Page.Count);

    parameters.Add((request.Page.Number - 1) * request.Page.Count);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var data = await _db.Database.SqlQuery<DummyItemGetListActionDTO>(sql).ToListAsync(cancellationToken);

    return Result.Success(data);
  }
}
