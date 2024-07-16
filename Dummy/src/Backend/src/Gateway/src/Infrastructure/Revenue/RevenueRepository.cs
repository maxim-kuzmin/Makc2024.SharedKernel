namespace Gateway.Infrastructure.Revenue;

public class RevenueRepository(AppDbContext dbContext) :
  AppRepositoryBase<RevenueEntity>(dbContext),
  IRevenueRepository
{
}
