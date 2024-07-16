namespace Makc2024.Dummy.Gateway.DomainUseCases.User.Actions.GetByEmail;

public record UserGetByEmailActionQuery(string Email) : IQuery<Result<UserGetByEmailActionDTO>>;
