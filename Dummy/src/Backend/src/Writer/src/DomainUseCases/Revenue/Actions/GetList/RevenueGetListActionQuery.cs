namespace Makc2024.Dummy.Writer.DomainUseCases.Revenue.Actions.GetList;

public record RevenueGetListActionQuery() : IQuery<Result<IEnumerable<RevenueGetListActionDTO>>>;
