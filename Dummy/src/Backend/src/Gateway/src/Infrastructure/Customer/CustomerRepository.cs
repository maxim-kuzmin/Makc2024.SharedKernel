namespace Gateway.Infrastructure.Customer;

public class CustomerRepository(AppDbContext dbContext) :
  AppRepositoryBase<CustomerEntity>(dbContext),
  ICustomerRepository
{
}
