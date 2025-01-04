namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Action.Query;

/// <summary>
/// Сервис запросов действия над фиктивным предметом.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_appDbContext">Контекст базы данных приложения.</param>
public class DummyItemActionQueryService(
  AppSession _appSession,
  AppDbContext _appDbContext) : IDummyItemActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemGetActionDTO>> Get(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    var dummyItemEntitySettings = entitiesDbSettings.DummyItem;

    var parameters = new List<object>();

    var parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{dummyItemEntitySettings.ColumnForId}}" "Id",
  "{{dummyItemEntitySettings.ColumnForName}}" "Name"
from
  "{{dummyItemEntitySettings.Schema}}"."{{dummyItemEntitySettings.Table}}"
where
  "{{dummyItemEntitySettings.ColumnForId}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var dtoTask = _appDbContext.Database.SqlQuery<DummyItemGetActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemGetListActionDTO>> GetList(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    var dummyItemEntitySettings = entitiesDbSettings.DummyItem;

    var parameters = new List<object>();

    var parameterIndex = 0;
    var sqlFormatToFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
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

    var totalCountSqlFormat = $$"""

select
  count(*)
from
  "{{dummyItemEntitySettings.Schema}}"."{{dummyItemEntitySettings.Table}}" di
{{sqlFormatToFilter}}

""";

    var totalCountSql = FormattableStringFactory.Create(totalCountSqlFormat, [.. parameters]);

    var totalCountDataTask = _appDbContext.Database.SqlQuery<long>(totalCountSql).ToListAsync(cancellationToken);

    var totalCountData = await totalCountDataTask.ConfigureAwait(false);

    var totalCountDto = totalCountData[0];

    var itemsSqlFormat = $$"""

select
  di."{{dummyItemEntitySettings.ColumnForId}}" "Id",
  di."{{dummyItemEntitySettings.ColumnForName}}" "Name"
from
  "{{dummyItemEntitySettings.Schema}}"."{{dummyItemEntitySettings.Table}}" di
{{sqlFormatToFilter}}
order by
  di."{{dummyItemEntitySettings.ColumnForId}}" desc
    
""";

    if (query.Page != null)
    {
      if (query.Page.Size > 0)
      {
        itemsSqlFormat += $$"""

        
limit
    {{{parameterIndex++}}}
        
""";

        parameters.Add(query.Page.Size);
      }

      if (query.Page.Number > 0)
      {
        itemsSqlFormat += $$"""

        
offset
    {{{parameterIndex++}}}
        
""";

        parameters.Add((query.Page.Number - 1) * query.Page.Size);
      }
    }

    var itemsSql = FormattableStringFactory.Create(itemsSqlFormat, [.. parameters]);

    var itemDTOTask = _appDbContext.Database.SqlQuery<DummyItemGetListActionDTOItem>(itemsSql).ToListAsync(cancellationToken);

    var itemsDTO = await itemDTOTask.ConfigureAwait(false);

    var dto = new DummyItemGetListActionDTO(itemsDTO, totalCountDto);

    return Result.Success(dto);
  }
}
