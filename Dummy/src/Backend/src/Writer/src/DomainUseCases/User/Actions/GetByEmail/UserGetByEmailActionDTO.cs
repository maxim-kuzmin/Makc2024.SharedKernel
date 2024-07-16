namespace Makc2024.Dummy.Writer.DomainUseCases.User.Actions.GetByEmail;

public record UserGetByEmailActionDTO(
  string Email,
  Guid Id,
  string Name,
  string Password);
