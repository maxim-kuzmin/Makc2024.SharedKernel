namespace Makc2024.Dummy.Writer.DomainUseCases.User;

public interface IUserRepository : IReadRepository<UserEntity>,
  IRepository<UserEntity>
{
}
