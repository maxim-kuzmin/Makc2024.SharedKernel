namespace Gateway.Infrastructure.Invoice.Actions.GetFilteredCount;

public class InvoiceGetFilteredCountActionService(AppDbContext _db) : IInvoiceGetFilteredCountActionService
{
  public async Task<int> GetFilteredCountAsync(
    InvoiceGetFilteredCountActionQuery query,
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var customerEntitySettings = appDbSettings.Entities.Customer;
    var invoiceEntitySettings = appDbSettings.Entities.Invoice;

    var parameters = new List<object>();

    int parameterIndex = 0;

    string sqlFormatToFilter = string.Empty;

    if (!string.IsNullOrEmpty(query.Filter.FullTextSearchQuery))
    {
      sqlFormatToFilter = $$"""
  join "{{appDbSettings.Schema}}"."{{customerEntitySettings.Table}}" cst
    on inv."{{invoiceEntitySettings.ColumnForCustomerId}}" = cst."{{customerEntitySettings.ColumnForId}}"
where
  cst."{{customerEntitySettings.ColumnForName}}" ilike  {{{parameterIndex}}}
  or
  cst."{{customerEntitySettings.ColumnForEmail}}" ilike {{{parameterIndex}}}
  or
  inv."{{invoiceEntitySettings.ColumnForAmount}}"::text ilike {{{parameterIndex}}}
  or
  inv."{{invoiceEntitySettings.ColumnForDate}}"::text ilike {{{parameterIndex}}}
  or
  inv."{{invoiceEntitySettings.ColumnForStatus}}" ilike {{{parameterIndex}}}
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");
    }

    string sqlFormat = $$"""
select
  count(*)
from
  "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}" inv
{{sqlFormatToFilter}}
""";

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<int>(sql).ToListAsync(cancellationToken);

    return result[0];
  }
}
