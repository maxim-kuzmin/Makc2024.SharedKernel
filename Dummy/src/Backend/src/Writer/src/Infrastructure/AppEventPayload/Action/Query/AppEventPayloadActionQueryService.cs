namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Action.Query;

/// <summary>
/// Сервис запросов действия с полезной нагрузкой события приложения.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="appSession">Сессия приложения.</param>
public class AppEventPayloadActionQueryService(
  IAppDbHelperForSQL _appDbHelperForSQL,
  AppDbSettings _appDbSettings,
  AppSession appSession) : AppEventPayloadActionQueryServiceBase(appSession)
{
  /// <inheritdoc/>
  protected sealed override async Task<AppEventPayloadSingleDTO?> GetDTO(
    AppEventPayloadGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    var parameters = new List<object>();

    var parameterIndex = 0;

    string sql = $$"""

select
  "{{sAppEventPayload.ColumnForId}}" "Id",
  "{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  "{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}"
where
  "{{sAppEventPayload.ColumnForId}}" = {{{parameterIndex}}}

""";

    parameters.Add(query.Id);

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<AppEventPayloadSingleDTO>(
      sql,
      parameters).FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  protected sealed override async Task<AppEventPayloadListDTO> GetDTO(
    AppEventPayloadGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    var parameters = new List<object>();

    var parameterIndex = 0;

    string sqlForFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      sqlForFilter = $$"""

where
  aep."{{sAppEventPayload.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  aep."{{sAppEventPayload.ColumnForData}}" ilike {{{parameterIndex}}}
      
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");

      parameterIndex++;
    }

    var totalCountTask = GetTotalCount(
      sqlForFilter,
      parameters,
      sAppEventPayload,
      cancellationToken);

    var totalCount = await totalCountTask.ConfigureAwait(false);

    var itemsTask = GetItems(
      query,
      parameterIndex,
      sqlForFilter,
      parameters,
      sAppEventPayload,
      cancellationToken);

    var items = await itemsTask.ConfigureAwait(false);

    var result = items.ToAppEventPayloadListDTO(totalCount);

    return result;
  }

  private async Task<Result<long>> GetTotalCount(
    string sqlForFilter,
    List<object> parameters,
    AppEventPayloadEntityDbSettings sAppEventPayload,
    CancellationToken cancellationToken)
  {
    string sql = $$"""
    
select
  count(*)
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep

{{sqlForFilter}}

""";

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<long>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result[0];
  }

  private async Task<List<AppEventPayloadSingleDTO>> GetItems(
    AppEventPayloadGetListActionQuery query,
    int parameterIndex,
    string sqlForFilter,
    List<object> parameters,
    AppEventPayloadEntityDbSettings sAppEventPayload,
    CancellationToken cancellationToken)
  {
    string sql = $$"""

select
  aep."{{sAppEventPayload.ColumnForId}}" "Id",
  aep."{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  aep."{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep

{{sqlForFilter}}

order by
  aep."{{sAppEventPayload.ColumnForId}}" desc
    
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

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<AppEventPayloadSingleDTO>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }
}
