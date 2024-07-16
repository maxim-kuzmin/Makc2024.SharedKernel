namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem;

public class DummyItemRepository(AppDbContext dbContext) :
  AppRepositoryBase<DummyItemEntity>(dbContext),
  IDummyItemRepository
{
}
