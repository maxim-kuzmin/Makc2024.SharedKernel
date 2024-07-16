namespace Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetAll;

public record CustomerGetAllActionQuery : IQuery<Result<IEnumerable<CustomerGetAllActionDTO>>>;
