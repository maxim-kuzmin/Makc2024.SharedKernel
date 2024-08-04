namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionHandler(AppDbContext _db) : IDummyItemGetByIdActionHandler
{
  public async Task<Result<DummyItemGetByIdActionDTO>> Handle(
    DummyItemGetByIdActionQuery request,
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

    var dto = await _db.Database.SqlQuery<DummyItemGetByIdActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
