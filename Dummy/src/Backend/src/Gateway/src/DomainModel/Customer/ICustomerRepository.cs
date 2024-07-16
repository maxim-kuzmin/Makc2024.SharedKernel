namespace Makc2024.Dummy.Gateway.DomainUseCases.Customer;

public interface ICustomerRepository : IReadRepository<CustomerEntity>,
  IRepository<CustomerEntity>
{
}
