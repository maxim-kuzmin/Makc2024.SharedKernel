namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Action.Query;

/// <summary>
/// Сервис запросов действия с фиктивным предметом.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public class DummyItemActionQueryService(
  IAppDbHelperForSQL _appDbHelperForSQL,
  AppDbSettings _appDbSettings,
  AppSession _appSession) : IDummyItemActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemGetActionDTO>> Get(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var sDummyItem = _appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    var parameterIndex = 0;

    var sqlFormat = $$"""

select
  "{{sDummyItem.ColumnForId}}" "Id",
  "{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
where
  "{{sDummyItem.ColumnForId}}" = {{{parameterIndex}}}

""";

    parameters.Add(query.Id);

    var dtoTask = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<DummyItemGetActionDTO>(
      sqlFormat,
      parameters).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemGetListActionDTO>> GetList(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    string? userName = _appSession.User.Identity?.Name;

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    var parameterIndex = 0;

    var sqlForFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      sqlForFilter = $$"""

where
  di."{{sDummyItem.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  di."{{sDummyItem.ColumnForName}}" ilike {{{parameterIndex}}}
      
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");

      parameterIndex++;
    }

    var totalCountTask = GetTotalCount(
      sqlForFilter,
      parameters,
      sDummyItem,
      cancellationToken);

    var totalCount = await totalCountTask.ConfigureAwait(false);

    var itemsTask = GetItems(
      query,
      parameterIndex,
      sqlForFilter,
      parameters,
      sDummyItem,
      cancellationToken);

    var items = await itemsTask.ConfigureAwait(false);

    var dto = new DummyItemGetListActionDTO(items, totalCount);

    return Result.Success(dto);
  }

  private async Task<Result<long>> GetTotalCount(
    string sqlForFilter,
    List<object> parameters,
    DummyItemEntityDbSettings sDummyItem,
    CancellationToken cancellationToken)
  {
    string sql = $$"""
    
select
  count(*)
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di

{{sqlForFilter}}

""";

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<long>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result[0];
  }

  private async Task<List<DummyItemGetListActionDTOItem>> GetItems(
    DummyItemGetListActionQuery query,
    int parameterIndex,
    string sqlForFilter,
    List<object> parameters,
    DummyItemEntityDbSettings sDummyItem,
    CancellationToken cancellationToken)
  {
    string sql = $$"""

select
  di."{{sDummyItem.ColumnForId}}" "Id",
  di."{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di

{{sqlForFilter}}

order by
  di."{{sDummyItem.ColumnForId}}" desc
    
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

    var task = _appDbHelperForSQL.CreateQueryFromSqlWithFormat<DummyItemGetListActionDTOItem>(
      sql,
      parameters).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }
}
