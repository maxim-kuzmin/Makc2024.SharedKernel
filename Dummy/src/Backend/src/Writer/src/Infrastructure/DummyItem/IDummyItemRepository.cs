namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IReadRepository<DummyItemEntity>,
  IRepository<DummyItemEntity>
{
}
