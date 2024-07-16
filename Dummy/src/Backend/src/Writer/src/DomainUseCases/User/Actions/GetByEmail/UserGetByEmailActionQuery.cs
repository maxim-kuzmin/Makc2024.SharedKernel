namespace Gateway.DomainUseCases.User.Actions.GetByEmail;

public record UserGetByEmailActionQuery(string Email) : IQuery<Result<UserGetByEmailActionDTO>>;
