namespace Gateway.DomainUseCases.Customer;

public interface ICustomerRepository : IReadRepository<CustomerEntity>,
  IRepository<CustomerEntity>
{
}
