namespace Makc2024.Dummy.Gateway.Infrastructure.User;

public class UserRepository(AppDbContext dbContext) :
  AppRepositoryBase<UserEntity>(dbContext),
  IUserRepository
{
}
