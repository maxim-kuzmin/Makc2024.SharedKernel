namespace Makc2024.Dummy.Writer.DomainUseCases.Revenue.Actions.GetList;

public interface IRevenueGetListActionService
{
  Task<IEnumerable<RevenueGetListActionDTO>> GetListAsync(
    CancellationToken cancellationToken = default);
}
