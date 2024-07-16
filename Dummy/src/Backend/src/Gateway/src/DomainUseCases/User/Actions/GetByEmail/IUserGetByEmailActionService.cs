namespace Makc2024.Dummy.Gateway.DomainUseCases.User.Actions.GetByEmail;

public interface IUserGetByEmailActionService
{
  Task<UserGetByEmailActionDTO?> GetByEmailAsync(
    UserGetByEmailActionQuery query,
    CancellationToken cancellationToken = default);
}
