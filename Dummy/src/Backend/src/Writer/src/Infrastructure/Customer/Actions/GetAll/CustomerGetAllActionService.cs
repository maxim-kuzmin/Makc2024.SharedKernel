namespace Gateway.Infrastructure.Customer.Actions.GetAll;

public class CustomerGetAllActionService(AppDbContext _db) : ICustomerGetAllActionService
{
  public async Task<IEnumerable<CustomerGetAllActionDTO>> GetAllAsync(    
    CancellationToken cancellationToken = default)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var customerEntitySettings = appDbSettings.Entities.Customer;

    string sqlFormat = $$"""
select
  "{{customerEntitySettings.ColumnForId}}" "Id",
  "{{customerEntitySettings.ColumnForName}}" "Name"
from
  "{{appDbSettings.Schema}}"."{{customerEntitySettings.Table}}"
order by
  "{{customerEntitySettings.ColumnForName}}" asc
""";

    var sql = FormattableStringFactory.Create(sqlFormat);

    var result = await _db.Database.SqlQuery<CustomerGetAllActionDTO>(sql).ToListAsync(cancellationToken);

    return result;
  }
}
