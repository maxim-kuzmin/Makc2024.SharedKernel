namespace Makc2024.Dummy.Writer.DomainModel.User;

public class UserAggregate(Guid userEntityId = default) : AggregateBase
{  
  private readonly UserEntity _userEntity = new() { Id = userEntityId };

  public string Email => _userEntity.Email;
  public Guid Id => _userEntity.Id;
  public string Name => _userEntity.Name;
  public string Password => _userEntity.Password;

  public UserEntity? GetUserEntityToCreate()
  {
    return (UserEntity)_userEntity.DeepCopy();
  }

  public UserEntity? GetUserEntityToDelete(UserEntity userEntity)
  {
    if (Id == default || userEntity.Id != Id)
    {
      return null;
    }

    return userEntity;
  }

  public UserEntity? GetUserEntityToUpdate(UserEntity userEntity)
  {
    if (Id == default || userEntity.Id != Id)
    {
      return null;
    }

    bool isOk = false;

    if (HasChangedProperty(Email) && userEntity.Email != Email)
    {
      userEntity.Email = Email;

      isOk = true;
    }

    if (HasChangedProperty(Name) && userEntity.Name != Name)
    {
      userEntity.Name = Name;

      isOk = true;
    }

    if (HasChangedProperty(Password) && userEntity.Password != Password)
    {
      userEntity.Password = Password;

      isOk = true;
    }

    return isOk ? userEntity : null;
  }

  public void UpdateEmail(string email)
  {
    _userEntity.Email = Guard.Against.NullOrEmpty(email, nameof(email));

    SetChangedProperty(nameof(Email));
  }

  public void UpdateName(string name)
  {
    _userEntity.Name = Guard.Against.NullOrEmpty(name, nameof(name));

    SetChangedProperty(nameof(Name));
  }

  public void UpdatePassword(string password)
  {
    _userEntity.Password = Guard.Against.NullOrEmpty(password, nameof(password));

    SetChangedProperty(nameof(Password));
  }
}
