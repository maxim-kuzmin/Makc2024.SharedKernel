namespace Makc2024.Dummy.Writer.Infrastructure.Revenue;

public class RevenueRepository(AppDbContext dbContext) :
  AppRepositoryBase<RevenueEntity>(dbContext),
  IRevenueRepository
{
}
