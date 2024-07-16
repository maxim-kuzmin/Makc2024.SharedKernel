namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem;

public interface IDummyItemRepository : IReadRepository<DummyItemEntity>,
  IRepository<DummyItemEntity>
{
}
