namespace Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetFiltered;

public class InvoiceGetFilteredActionService(AppDbContext _db) : IInvoiceGetFilteredActionService
{
  public async Task<IEnumerable<InvoiceGetFilteredActionDTO>> GetFilteredAsync(
    InvoiceGetFilteredActionQuery query,
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
where
  cst."{{customerEntitySettings.ColumnForName}}" ilike {{{parameterIndex}}}
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

      parameterIndex++;
    }

    string sqlFormat = $$"""
select
  inv."{{invoiceEntitySettings.ColumnForAmount}}" "Amount",
  inv."{{invoiceEntitySettings.ColumnForDate}}" "Date",
  inv."{{invoiceEntitySettings.ColumnForId}}" "Id",
  inv."{{invoiceEntitySettings.ColumnForStatus}}" "Status",
  cst."{{customerEntitySettings.ColumnForEmail}}" "Email",
  cst."{{customerEntitySettings.ColumnForId}}" "CustomerId",
  cst."{{customerEntitySettings.ColumnForImageUrl}}" "ImageUrl",
  cst."{{customerEntitySettings.ColumnForName}}" "Name"
from
  "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}" inv
  join "{{appDbSettings.Schema}}"."{{customerEntitySettings.Table}}" cst
    on inv."{{invoiceEntitySettings.ColumnForCustomerId}}" = cst."{{customerEntitySettings.ColumnForId}}"
{{sqlFormatToFilter}}
order by
  inv."{{invoiceEntitySettings.ColumnForDate}}" desc
limit {{{parameterIndex++}}}
offset {{{parameterIndex++}}}
""";

    parameters.Add(query.Page.Count);

    parameters.Add((query.Page.Number - 1) * query.Page.Count);

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<InvoiceGetFilteredActionDTO>(sql).ToListAsync(cancellationToken);

    return result;
  }
}
