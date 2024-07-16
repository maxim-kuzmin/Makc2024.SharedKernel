namespace Makc2024.Dummy.Writer.Infrastructure.App.Repository;

public class AppRepositoryBase<TAggregateRoot>(AppDbContext dbContext) :
  RepositoryBase<TAggregateRoot>(dbContext),
  IReadRepository<TAggregateRoot>,
  IRepository<TAggregateRoot>
  where TAggregateRoot : class, IAggregateRoot
{
}
