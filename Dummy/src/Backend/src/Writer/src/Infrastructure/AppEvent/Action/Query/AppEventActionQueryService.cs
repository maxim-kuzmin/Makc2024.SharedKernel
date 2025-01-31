﻿namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Action.Query;

/// <summary>
/// Сервис запросов действия над событием приложения.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public class AppEventActionQueryService(
  IAppDbHelperForSQL _appDbHelperForSQL,
  AppDbSettings _appDbSettings,
  AppSession _appSession) : IAppEventActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventGetActionDTO>> Get(
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

    var dtoTask = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<AppEventGetActionDTO>(
      sql,
      parameters).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventGetListActionDTO>> GetList(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    string? userName = _appSession.User.Identity?.Name;

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

    var dto = new AppEventGetListActionDTO(items, totalCount);

    return Result.Success(dto);
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

  private async Task<List<AppEventGetListActionDTOItem>> GetItems(
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

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<AppEventGetListActionDTOItem>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }
}
