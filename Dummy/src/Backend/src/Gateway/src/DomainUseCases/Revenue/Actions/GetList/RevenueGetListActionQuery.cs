namespace Makc2024.Dummy.Gateway.DomainUseCases.Revenue.Actions.GetList;

public record RevenueGetListActionQuery() : IQuery<Result<IEnumerable<RevenueGetListActionDTO>>>;
