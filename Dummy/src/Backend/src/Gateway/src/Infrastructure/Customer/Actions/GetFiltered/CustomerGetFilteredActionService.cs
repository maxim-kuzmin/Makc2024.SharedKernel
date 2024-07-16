namespace Makc2024.Dummy.Gateway.Infrastructure.Customer.Actions.GetFiltered;

public class CustomerGetFilteredActionService(AppDbContext _db) : ICustomerGetFilteredActionService
{
  public async Task<IEnumerable<CustomerGetFilteredActionDTO>> GetFilteredAsync(
    CustomerGetFilteredActionQuery query,
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
""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");
    }

    string sqlFormat = $$"""
select
  cst."{{customerEntitySettings.ColumnForEmail}}" "Email",
  cst."{{customerEntitySettings.ColumnForId}}" "Id",
  cst."{{customerEntitySettings.ColumnForImageUrl}}" "ImageUrl",
  cst."{{customerEntitySettings.ColumnForName}}" "Name",
  count(inv."{{invoiceEntitySettings.ColumnForId}}") "TotalInvoices",
  sum
  (
    case
      when inv."{{invoiceEntitySettings.ColumnForStatus}}" = 'paid'
      then inv."{{invoiceEntitySettings.ColumnForAmount}}"
      else 0
    end
  )  "TotalPaid",
  sum
  (
    case
      when inv."{{invoiceEntitySettings.ColumnForStatus}}" = 'pending'
      then inv."{{invoiceEntitySettings.ColumnForAmount}}"
      else 0
    end
  )  "TotalPending"
from
  "{{appDbSettings.Schema}}"."{{customerEntitySettings.Table}}" cst  
  join "{{appDbSettings.Schema}}"."{{invoiceEntitySettings.Table}}" inv
    on cst."{{customerEntitySettings.ColumnForId}}" = inv."{{invoiceEntitySettings.ColumnForCustomerId}}"
{{sqlFormatToFilter}}
group by
  cst."{{customerEntitySettings.ColumnForId}}",
  cst."{{customerEntitySettings.ColumnForName}}",
  cst."{{customerEntitySettings.ColumnForEmail}}",
  cst."{{customerEntitySettings.ColumnForImageUrl}}"
order by
  cst."{{customerEntitySettings.ColumnForName}}" asc
""";

    var sql = FormattableStringFactory.Create(sqlFormat, [.. parameters]);

    var result = await _db.Database.SqlQuery<CustomerGetFilteredActionDTO>(sql).ToListAsync(cancellationToken);

    return result;
  }
}
