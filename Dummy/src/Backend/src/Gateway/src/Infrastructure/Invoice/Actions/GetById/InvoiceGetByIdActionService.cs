namespace Makc2024.Dummy.Gateway.Infrastructure.Invoice.Actions.GetById;

public class InvoiceGetByIdActionService(AppDbContext _db) : IInvoiceGetByIdActionService
{
  public async Task<InvoiceGetByIdActionDTO?> GetByIdAsync(
    InvoiceGetByIdActionQuery query,
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var invoiceEntitySettings = appDbSettings.Entities.Invoice;

    var parameters = new List<object>();

    int parameterIndex = 0;

    var sqlFormat = $$"""
select
  "{{invoiceEntitySettings.ColumnForAmount}}" "Amount",
  "{{invoiceEntitySettings.ColumnForCustomerId}}" "CustomerId",
  "{{invoiceEntitySettings.ColumnForId}}" "Id",
  "{{invoiceEntitySettings.ColumnForStatus}}" "Status"
from
  "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}"
where
  "{{invoiceEntitySettings.ColumnForId}}" = {{{parameterIndex}}}
""";

    parameters.Add(query.Id);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<InvoiceGetByIdActionDTO>(sql).FirstOrDefaultAsync(cancellationToken);

    return result;
  }
}
