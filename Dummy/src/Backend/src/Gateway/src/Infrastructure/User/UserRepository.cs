namespace Gateway.Infrastructure.User;

public class UserRepository(AppDbContext dbContext) :
  AppRepositoryBase<UserEntity>(dbContext),
  IUserRepository
{
}
