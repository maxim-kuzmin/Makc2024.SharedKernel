namespace Makc2024.Dummy.Writer.DomainUseCases.Customer;

public interface ICustomerRepository : IReadRepository<CustomerEntity>,
  IRepository<CustomerEntity>
{
}
