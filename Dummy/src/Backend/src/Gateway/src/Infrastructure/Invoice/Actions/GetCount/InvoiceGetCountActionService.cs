namespace Makc2024.Dummy.Gateway.Infrastructure.Invoice.Actions.GetCount;

public class InvoiceGetCountActionService(AppDbContext _db) : IInvoiceGetCountActionService
{
  public async Task<int> GetCountAsync(
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var invoiceEntitySettings = appDbSettings.Entities.Invoice;

    string sqlFormat = $$"""
select
  count(*)
from
  "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}"
""";

    var sql = FormattableStringFactory.Create(sqlFormat);

    var result = await _db.Database.SqlQuery<int>(sql).ToListAsync(cancellationToken);

    return result[0];
  }
}
