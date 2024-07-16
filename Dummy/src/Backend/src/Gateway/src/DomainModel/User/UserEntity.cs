namespace Makc2024.Dummy.Gateway.DomainModel.User;

public class UserEntity : EntityBaseWithId<Guid>, IAggregateRoot
{
  public string Email { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string Password { get; set; } = null!;

  public sealed override object DeepCopy()
  {
    return base.DeepCopy();
  }
}
