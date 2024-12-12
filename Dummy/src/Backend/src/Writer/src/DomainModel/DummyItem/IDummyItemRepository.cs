namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IReadRepository<DummyItemEntity>,
  IRepository<DummyItemEntity>
{
}
