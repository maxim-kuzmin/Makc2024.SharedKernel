namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem;

public class DummyItemService(
  AppSession _appSession,
  AppDbContext _db,
  IEventDispatcher _eventDispatcher,
  IDummyItemRepository _repository) : IDummyItemService
{
  public async Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemAggregate = new DummyItemAggregate();

    dummyItemAggregate.UpdateName(command.Name);

    var dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToCreate();

    if (dummyItemEntity == null)
    {
      return Result.Forbidden();
    }

    dummyItemEntity = await _repository.AddAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    var data = new DummyItemGetActionDTO(
      dummyItemEntity.Id,
      dummyItemEntity.Name);

    return Result.Success(data);
  }

  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemEntity = dummyItemAggregate.GetDummyItemEntityToDelete(dummyItemEntity);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  public async Task<Result<DummyItemGetActionDTO>> Get(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var dummyItemEntitySettings = appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    int parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{dummyItemEntitySettings.ColumnForId}}" "Id",
  "{{dummyItemEntitySettings.ColumnForName}}" "Name"
from
  "{{appDbSettings.Schema}}"."{{dummyItemEntitySettings.Table}}"
where
  "{{dummyItemEntitySettings.ColumnForId}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var dtoTask = _db.Database.SqlQuery<DummyItemGetActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  public async Task<Result<DummyItemGetListActionDTO>> GetList(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    string? userName = _appSession.User.Identity?.Name;

    var appDbSettings = AppDbContext.GetAppDbSettings();

    var dummyItemEntitySettings = appDbSettings.Entities.DummyItem;

    var parameters = new List<object>();

    int parameterIndex = 0;
    string sqlFormatToFilter = string.Empty;

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

    string totalCountSqlFormat = $$"""

select
  count(*)
from
  "{{appDbSettings.Schema}}"."{{dummyItemEntitySettings.Table}}" di
{{sqlFormatToFilter}}

""";

    var totalCountSql = FormattableStringFactory.Create(totalCountSqlFormat, [.. parameters]);

    var totalCountDataTask = _db.Database.SqlQuery<long>(totalCountSql).ToListAsync(cancellationToken);

    var totalCountData = await totalCountDataTask.ConfigureAwait(false);

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

    var itemDTOTask = _db.Database.SqlQuery<DummyItemGetListActionDTOItem>(itemsSql).ToListAsync(cancellationToken);

    var itemsDTO = await itemDTOTask.ConfigureAwait(false);

    var dto = new DummyItemGetListActionDTO(itemsDTO, totalCountDto);

    return Result.Success(dto);
  }

  public async Task<Result<DummyItemGetActionDTO>> Update(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken)
  {
    var dummyItemEntity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

    if (dummyItemEntity == null)
    {
      return Result.NotFound();
    }

    var dummyItemAggregate = new DummyItemAggregate(dummyItemEntity.Id);

    dummyItemAggregate.UpdateName(command.Name);

    var dummyItemEntityToUpdate = dummyItemAggregate.GetDummyItemEntityToUpdate(dummyItemEntity);

    if (dummyItemEntityToUpdate != null)
    {
      dummyItemEntity = dummyItemEntityToUpdate;

      await _repository.UpdateAsync(dummyItemEntity, cancellationToken).ConfigureAwait(false);
    }

    await _eventDispatcher.DispatchAndClearEvents(dummyItemAggregate, cancellationToken).ConfigureAwait(false);

    var data = new DummyItemGetActionDTO(
      dummyItemEntity.Id,
      dummyItemEntity.Name);

    return Result.Success(data);
  }
}
