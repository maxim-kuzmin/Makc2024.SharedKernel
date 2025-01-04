namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent;

public class AppEventRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventEntity>(dbContext),
  IAppEventRepository
{
}
