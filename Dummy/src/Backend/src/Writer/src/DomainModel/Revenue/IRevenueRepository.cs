namespace Gateway.DomainModel.Revenue;

public interface IRevenueRepository : IReadRepository<RevenueEntity>,
  IRepository<RevenueEntity>
{
}
