namespace Makc2024.Dummy.Gateway.DomainUseCases.User;

public interface IUserRepository : IReadRepository<UserEntity>,
  IRepository<UserEntity>
{
}
