namespace Gateway.Infrastructure.Revenue.Actions.GetList;

public class RevenueGetListActionService(AppDbContext _db) : IRevenueGetListActionService
{
  public async Task<IEnumerable<RevenueGetListActionDTO>> GetListAsync(
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var revenueEntitySettings = appDbSettings.Entities.Revenue;

    var sqlFormat = $$"""
select
  "{{revenueEntitySettings.ColumnForMonth}}" "Month",
  "{{revenueEntitySettings.ColumnForValue}}" "Value"
from
  "{{appDbSettings.Schema}}"."{{revenueEntitySettings.Table}}"
""";

    var sql = FormattableStringFactory.Create(sqlFormat);

    var result = await _db.Database.SqlQuery<RevenueGetListActionDTO>(sql).ToListAsync(cancellationToken);

    return result;
  }
}
