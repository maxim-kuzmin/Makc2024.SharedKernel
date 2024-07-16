namespace Gateway.DomainUseCases.User;

public interface IUserRepository : IReadRepository<UserEntity>,
  IRepository<UserEntity>
{
}
