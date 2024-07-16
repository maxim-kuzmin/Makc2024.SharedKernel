namespace Makc2024.Dummy.Gateway.Infrastructure.Customer;

public class CustomerRepository(AppDbContext dbContext) :
  AppRepositoryBase<CustomerEntity>(dbContext),
  ICustomerRepository
{
}
