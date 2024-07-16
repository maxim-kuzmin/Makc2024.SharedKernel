namespace Gateway.DomainUseCases.Revenue.Actions.GetList;

public record RevenueGetListActionQuery() : IQuery<Result<IEnumerable<RevenueGetListActionDTO>>>;
