namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Action.Query;

/// <summary>
/// Сервис запросов действия над событием приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_appDbContext">Контекст базы данных приложения.</param>
public class AppEventActionQueryService(
  AppSession _appSession,
  AppDbContext _appDbContext) : IAppEventActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventGetActionDTO>> Get(
    AppEventGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    var appEventEntitySettings = entitiesDbSettings.AppEvent;

    var parameters = new List<object>();

    var parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{appEventEntitySettings.ColumnForId}}" "Id",
  "{{appEventEntitySettings.ColumnForCreatedAt}}" "CreatedAt",
  "{{appEventEntitySettings.ColumnForIsPublished}}" "IsPublished",
  "{{appEventEntitySettings.ColumnForName}}" "Name"
from
  "{{appEventEntitySettings.Schema}}"."{{appEventEntitySettings.Table}}"
where
  "{{appEventEntitySettings.ColumnForId}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var dtoTask = _appDbContext.Database.SqlQuery<AppEventGetActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventGetListActionDTO>> GetList(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    var appEventEntitySettings = entitiesDbSettings.AppEvent;

    var parameters = new List<object>();

    var parameterIndex = 0;
    var sqlFormatToFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      sqlFormatToFilter = $$"""

where
  ae."{{appEventEntitySettings.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  ae."{{appEventEntitySettings.ColumnForName}}" ilike {{{parameterIndex}}}
      
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");

      parameterIndex++;
    }

    var totalCountSqlFormat = $$"""

select
  count(*)
from
  "{{appEventEntitySettings.Schema}}"."{{appEventEntitySettings.Table}}" ae
{{sqlFormatToFilter}}

""";

    var totalCountSql = FormattableStringFactory.Create(totalCountSqlFormat, [.. parameters]);

    var totalCountDataTask = _appDbContext.Database.SqlQuery<long>(totalCountSql).ToListAsync(cancellationToken);

    var totalCountData = await totalCountDataTask.ConfigureAwait(false);

    var totalCountDto = totalCountData[0];

    var itemsSqlFormat = $$"""

select
  ae."{{appEventEntitySettings.ColumnForId}}" "Id",
  ae."{{appEventEntitySettings.ColumnForCreatedAt}}" "CreatedAt",
  ae."{{appEventEntitySettings.ColumnForIsPublished}}" "IsPublished",
  ae."{{appEventEntitySettings.ColumnForName}}" "Name"
from
  "{{appEventEntitySettings.Schema}}"."{{appEventEntitySettings.Table}}" ae
{{sqlFormatToFilter}}
order by
  ae."{{appEventEntitySettings.ColumnForId}}" desc
    
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

    var itemDTOTask = _appDbContext.Database.SqlQuery<AppEventGetListActionDTOItem>(itemsSql).ToListAsync(cancellationToken);

    var itemsDTO = await itemDTOTask.ConfigureAwait(false);

    var dto = new AppEventGetListActionDTO(itemsDTO, totalCountDto);

    return Result.Success(dto);
  }
}
