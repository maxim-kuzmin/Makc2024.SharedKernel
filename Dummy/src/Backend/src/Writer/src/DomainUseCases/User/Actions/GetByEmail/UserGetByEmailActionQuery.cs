namespace Makc2024.Dummy.Writer.DomainUseCases.User.Actions.GetByEmail;

public record UserGetByEmailActionQuery(string Email) : IQuery<Result<UserGetByEmailActionDTO>>;
