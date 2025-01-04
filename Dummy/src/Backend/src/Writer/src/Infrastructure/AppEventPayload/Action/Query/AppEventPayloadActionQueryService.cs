namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Action.Query;

/// <summary>
/// Сервис запросов действия над полезной нагрузкой события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_appDbContext">Контекст базы данных приложения.</param>
public class AppEventPayloadActionQueryService(
  AppSession _appSession,
  AppDbContext _appDbContext) : IAppEventPayloadActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadGetActionDTO>> Get(
    AppEventPayloadGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    var appEventPayloadEntitySettings = entitiesDbSettings.AppEventPayload;

    var parameters = new List<object>();

    var parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{appEventPayloadEntitySettings.ColumnForId}}" "Id",
  "{{appEventPayloadEntitySettings.ColumnForName}}" "Name"
from
  "{{appEventPayloadEntitySettings.Schema}}"."{{appEventPayloadEntitySettings.Table}}"
where
  "{{appEventPayloadEntitySettings.ColumnForId}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var dtoTask = _appDbContext.Database.SqlQuery<AppEventPayloadGetActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadGetListActionDTO>> GetList(
    AppEventPayloadGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitiesDbSettings = appDbSettings.Entities;

    var appEventPayloadEntitySettings = entitiesDbSettings.AppEventPayload;

    var parameters = new List<object>();

    var parameterIndex = 0;
    var sqlFormatToFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      sqlFormatToFilter = $$"""

where
  di."{{appEventPayloadEntitySettings.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  di."{{appEventPayloadEntitySettings.ColumnForName}}" ilike {{{parameterIndex}}}
      
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");

      parameterIndex++;
    }

    var totalCountSqlFormat = $$"""

select
  count(*)
from
  "{{appEventPayloadEntitySettings.Schema}}"."{{appEventPayloadEntitySettings.Table}}" di
{{sqlFormatToFilter}}

""";

    var totalCountSql = FormattableStringFactory.Create(totalCountSqlFormat, [.. parameters]);

    var totalCountDataTask = _appDbContext.Database.SqlQuery<long>(totalCountSql).ToListAsync(cancellationToken);

    var totalCountData = await totalCountDataTask.ConfigureAwait(false);

    var totalCountDto = totalCountData[0];

    var itemsSqlFormat = $$"""

select
  di."{{appEventPayloadEntitySettings.ColumnForId}}" "Id",
  di."{{appEventPayloadEntitySettings.ColumnForName}}" "Name"
from
  "{{appEventPayloadEntitySettings.Schema}}"."{{appEventPayloadEntitySettings.Table}}" di
{{sqlFormatToFilter}}
order by
  di."{{appEventPayloadEntitySettings.ColumnForId}}" desc
    
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

    var itemDTOTask = _appDbContext.Database.SqlQuery<AppEventPayloadGetListActionDTOItem>(itemsSql).ToListAsync(cancellationToken);

    var itemsDTO = await itemDTOTask.ConfigureAwait(false);

    var dto = new AppEventPayloadGetListActionDTO(itemsDTO, totalCountDto);

    return Result.Success(dto);
  }
}
