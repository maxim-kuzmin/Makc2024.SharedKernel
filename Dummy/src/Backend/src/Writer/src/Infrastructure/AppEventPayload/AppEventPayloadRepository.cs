namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload;

public class AppEventPayloadRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventPayloadEntity>(dbContext),
  IAppEventPayloadRepository
{
}
