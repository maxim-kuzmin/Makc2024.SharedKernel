namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Action.Query;

/// <summary>
/// Сервис запросов действия с событием приложения.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public class AppEventActionQueryService(
  IAppDbHelperForSQL _appDbHelperForSQL,
  AppDbSettings _appDbSettings,
  AppSession _appSession) : AppEventActionQueryServiceBase(_appSession)
{
  /// <inheritdoc/>
  protected sealed override async Task<AppEventSingleDTO?> GetDTO(
    AppEventGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var sAppEvent = _appDbSettings.Entities.AppEvent;

    var parameters = new List<object>();

    var parameterIndex = 0;

    var sql = $$"""

select
  "{{sAppEvent.ColumnForId}}" "Id",
  "{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  "{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  "{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
where
  "{{sAppEvent.ColumnForId}}" = {{{parameterIndex}}}

""";

    parameters.Add(query.Id);

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<AppEventSingleDTO>(
      sql,
      parameters).FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  protected sealed override async Task<AppEventListDTO> GetDTO(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var sAppEvent = _appDbSettings.Entities.AppEvent;

    var parameters = new List<object>();

    var parameterIndex = 0;

    string sqlForFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      sqlForFilter = $$"""

where
  ae."{{sAppEvent.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  ae."{{sAppEvent.ColumnForName}}" ilike {{{parameterIndex}}}
      
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");

      parameterIndex++;
    }

    var totalCountSqlFormat = $$"""

select
  count(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae

{{sqlForFilter}}

""";

    var totalCountTask = GetTotalCount(
      sqlForFilter,
      parameters,
      sAppEvent,
      cancellationToken);

    var totalCount = await totalCountTask.ConfigureAwait(false);

    var itemsTask = GetItems(
      query,
      parameterIndex,
      sqlForFilter,
      parameters,
      sAppEvent,
      cancellationToken);

    var items = await itemsTask.ConfigureAwait(false);

    var result = items.ToAppEventListDTO(totalCount);

    return result;
  }

  private async Task<Result<long>> GetTotalCount(
    string sqlForFilter,
    List<object> parameters,
    AppEventEntityDbSettings sAppEvent,
    CancellationToken cancellationToken)
  {
    string sql = $$"""
    
select
  count(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae

{{sqlForFilter}}

""";

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<long>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result[0];
  }

  private async Task<List<AppEventSingleDTO>> GetItems(
    AppEventGetListActionQuery query,
    int parameterIndex,
    string sqlForFilter,
    List<object> parameters,
    AppEventEntityDbSettings sAppEvent,
    CancellationToken cancellationToken)
  {
    string sql = $$"""

select
  ae."{{sAppEvent.ColumnForId}}" "Id",
  ae."{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  ae."{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  ae."{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae

{{sqlForFilter}}

order by
  ae."{{sAppEvent.ColumnForId}}" desc
    
""";

    if (query.Page != null)
    {
      if (query.Page.Size > 0)
      {
        sql += $$"""
        
limit {{{parameterIndex++}}}
        
""";

        parameters.Add(query.Page.Size);
      }

      if (query.Page.Number > 0)
      {
        sql += $$"""
        
offset {{{parameterIndex++}}}
                
"""
        ;

        parameters.Add((query.Page.Number - 1) * query.Page.Size);
      }
    }

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<AppEventSingleDTO>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }
}
