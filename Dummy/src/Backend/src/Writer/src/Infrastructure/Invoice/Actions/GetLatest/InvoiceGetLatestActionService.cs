namespace Gateway.Infrastructure.Invoice.Actions.GetLatest;

public class InvoiceGetLatestActionService(AppDbContext _db) : IInvoiceGetLatestActionService
{
  public async Task<IEnumerable<InvoiceGetLatestActionDTO>> GetLatestAsync(
    InvoiceGetLatestActionQuery query,
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var customerEntitySettings = appDbSettings.Entities.Customer;
    var invoiceEntitySettings = appDbSettings.Entities.Invoice;

    var parameters = new List<object>();

    int parameterIndex = 0;

    var sqlFormat = $$"""
select
  inv."{{invoiceEntitySettings.ColumnForAmount}}" "Amount",
  inv."{{invoiceEntitySettings.ColumnForId}}" "Id",
  cst."{{customerEntitySettings.ColumnForEmail}}" "Email",
  cst."{{customerEntitySettings.ColumnForImageUrl}}" "ImageUrl",
  cst."{{customerEntitySettings.ColumnForName}}" "Name"
from
  "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}" inv
  join "{{appDbSettings.Schema}}"."{{customerEntitySettings.Table}}" cst
    on inv."{{invoiceEntitySettings.ColumnForCustomerId}}" = cst."{{customerEntitySettings.ColumnForId}}"
order by
  inv."{{invoiceEntitySettings.ColumnForDate}}" desc
limit {{{parameterIndex}}}
""";

    parameters.Add(query.Limit);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<InvoiceGetLatestActionDTO>(sql).ToListAsync(cancellationToken);

    return result;
  }
}
