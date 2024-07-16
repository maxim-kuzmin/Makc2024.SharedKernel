namespace Makc2024.Dummy.Writer.Infrastructure.User.Entity;

public class UserEntityDbSettings
{
  public string ColumnForEmail { get; }
  public string ColumnForId { get; }
  public string ColumnForName { get; }
  public string ColumnForPassword { get; }

  public int MaxLengthForEmail { get; }
  public int MaxLengthForName { get; }
  public int MaxLengthForPassword { get; }

  public string PrimaryKey { get; }

  public string Table { get; }

  public string UniqueIndexForEmail { get; }

  public UserEntityDbSettings()
  {
    Table = "users";

    PrimaryKey = $"pk_{Table}";

    ColumnForEmail = "email";
    ColumnForId = "id";
    ColumnForName = "name";
    ColumnForPassword = "password";

    MaxLengthForEmail = 255;
    MaxLengthForName = 255;
    MaxLengthForPassword = 255;

    UniqueIndexForEmail = $"ux_{Table}_email";
  }
}
