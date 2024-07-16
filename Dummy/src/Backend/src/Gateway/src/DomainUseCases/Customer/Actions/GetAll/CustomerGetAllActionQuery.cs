namespace Gateway.DomainUseCases.Customer.Actions.GetAll;

public record CustomerGetAllActionQuery : IQuery<Result<IEnumerable<CustomerGetAllActionDTO>>>;
