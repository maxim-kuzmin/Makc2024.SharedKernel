namespace Makc2024.Dummy.Writer.Infrastructure.User.Entity;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
  public void Configure(EntityTypeBuilder<UserEntity> builder)
  {
    var appSettings = AppDbContext.GetAppDbSettings();

    var entitySettings = appSettings.Entities.User;

    builder.ToTable(entitySettings.Table, appSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entitySettings.PrimaryKey);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entitySettings.ColumnForId);

    builder.Property(x => x.Email)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForEmail)
      .HasColumnName(entitySettings.ColumnForEmail);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForName)
      .HasColumnName(entitySettings.ColumnForName);

    builder.Property(x => x.Password)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForPassword)
      .HasColumnName(entitySettings.ColumnForPassword);

    builder.HasIndex(x => x.Email)
      .IsUnique()
      .HasDatabaseName(entitySettings.UniqueIndexForEmail);
  }
}
