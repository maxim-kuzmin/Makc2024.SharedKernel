namespace Gateway.Infrastructure.Invoice.Actions.GetAmounts;

public class InvoiceGetAmountsActionService(AppDbContext _db) : IInvoiceGetAmountsActionService
{
  public async Task<InvoiceGetAmountsActionDTO> GetAmountsAsync(    
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var invoiceEntitySettings = appDbSettings.Entities.Invoice;

    var sqlFormat = $$"""
select
  sum
  (
    case
      when "{{invoiceEntitySettings.ColumnForStatus}}" = 'paid'
      then "{{invoiceEntitySettings.ColumnForAmount}}"
      else 0
    end
  )  "Paid",
  sum
  (
    case
      when "{{invoiceEntitySettings.ColumnForStatus}}" = 'pending'
      then "{{invoiceEntitySettings.ColumnForAmount}}"
      else 0
    end
  )  "Pending"
from
  "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}"
""";

    var sql = FormattableStringFactory.Create(sqlFormat);

    var result = await _db.Database.SqlQuery<InvoiceGetAmountsActionDTO>(sql).ToListAsync(cancellationToken);

    return result[0];
  }
}
