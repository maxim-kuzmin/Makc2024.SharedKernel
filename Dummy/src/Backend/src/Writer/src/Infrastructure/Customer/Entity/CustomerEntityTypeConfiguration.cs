namespace Makc2024.Dummy.Writer.Infrastructure.Customer.Entity;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
  public void Configure(EntityTypeBuilder<CustomerEntity> builder)
  {
    var appSettings = AppDbContext.GetAppDbSettings();

    var entitySettings = appSettings.Entities.Customer;

    builder.ToTable(entitySettings.Table, appSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entitySettings.PrimaryKey);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entitySettings.ColumnForId);

    builder.Property(x => x.Email)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForEmail)
      .HasColumnName(entitySettings.ColumnForEmail);

    builder.Property(x => x.ImageUrl)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForImageUrl)
      .HasColumnName(entitySettings.ColumnForImageUrl);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForName)
      .HasColumnName(entitySettings.ColumnForName);
  }
}
