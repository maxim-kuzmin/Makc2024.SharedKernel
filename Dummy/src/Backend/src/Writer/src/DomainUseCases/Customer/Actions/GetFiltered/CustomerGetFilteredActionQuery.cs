namespace Gateway.DomainUseCases.Customer.Actions.GetFiltered;

public record CustomerGetFilteredActionQuery(
  CustomerFilteredQueryFilter Filter)
  : IQuery<Result<IEnumerable<CustomerGetFilteredActionDTO>>>;
