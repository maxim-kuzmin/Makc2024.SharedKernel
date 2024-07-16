namespace Makc2024.Dummy.Writer.Infrastructure.Customer.Actions.GetCount;

public class CustomerGetCountActionService(AppDbContext _db) : ICustomerGetCountActionService
{
  public async Task<int> GetCountAsync(
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var customerEntitySettings = appDbSettings.Entities.Customer;

    string sqlFormat = $$"""
select
  count(*)
from
  "{{appDbSettings.Schema}}"."{{customerEntitySettings.Table}}"
""";

    var sql = FormattableStringFactory.Create(sqlFormat);

    var result = await _db.Database.SqlQuery<int>(sql).ToListAsync(cancellationToken);

    return result[0];
  }
}
