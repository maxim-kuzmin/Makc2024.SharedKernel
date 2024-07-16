namespace Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetAll;

public record CustomerGetAllActionQuery : IQuery<Result<IEnumerable<CustomerGetAllActionDTO>>>;
