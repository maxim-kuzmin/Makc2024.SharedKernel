namespace Makc2024.Dummy.Writer.Infrastructure.Customer;

public class CustomerRepository(AppDbContext dbContext) :
  AppRepositoryBase<CustomerEntity>(dbContext),
  ICustomerRepository
{
}
