namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(AppDbContext _db) : IDummyItemGetActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
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

    parameters.Add(request.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var dtoTask = _db.Database.SqlQuery<DummyItemGetActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    var dto = await dtoTask.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
