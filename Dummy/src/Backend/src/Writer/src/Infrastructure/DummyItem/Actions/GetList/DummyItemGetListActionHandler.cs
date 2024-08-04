namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(
  IAppSession _appSession,
  AppDbContext _db) : IDummyItemGetListActionHandler
{
  public async Task<Result<DummyItemGetListActionDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    string? userName = _appSession.User.Identity?.Name;

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

    string totalCountSqlFormat = $$"""
select
  count(*)
from
  "{{appDbSettings.Schema}}"."{{dummyItemEntitySettings.Table}}" di
{{sqlFormatToFilter}}
""";

    var totalCountSql = FormattableStringFactory.Create(totalCountSqlFormat, [.. parameters]);

    var totalCountData = await _db.Database.SqlQuery<long>(totalCountSql).ToListAsync(cancellationToken);

    long totalCountDto = totalCountData[0];

    string itemsSqlFormat = $$"""
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

    var itemsSql = FormattableStringFactory.Create(itemsSqlFormat, [.. parameters]);

    var itemsDto = await _db.Database.SqlQuery<DummyItemGetListActionDTOItem>(itemsSql).ToListAsync(cancellationToken);

    var dto = new DummyItemGetListActionDTO(itemsDto, totalCountDto);

    return Result.Success(dto);
  }
}
