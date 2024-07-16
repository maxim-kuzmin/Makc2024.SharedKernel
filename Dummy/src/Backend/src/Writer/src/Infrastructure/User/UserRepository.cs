namespace Makc2024.Dummy.Writer.Infrastructure.User;

public class UserRepository(AppDbContext dbContext) :
  AppRepositoryBase<UserEntity>(dbContext),
  IUserRepository
{
}
