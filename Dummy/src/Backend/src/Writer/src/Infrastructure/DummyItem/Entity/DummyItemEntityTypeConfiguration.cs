namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Entity;

public class DummyItemEntityTypeConfiguration : IEntityTypeConfiguration<DummyItemEntity>
{
  public void Configure(EntityTypeBuilder<DummyItemEntity> builder)
  {
    var appSettings = AppDbContext.GetAppDbSettings();

    var entitySettings = appSettings.Entities.DummyItem;

    builder.ToTable(entitySettings.Table, appSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entitySettings.PrimaryKey);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entitySettings.ColumnForId);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForName)
      .HasColumnName(entitySettings.ColumnForName);

    builder.HasIndex(x => x.Name)
      .IsUnique()
      .HasDatabaseName(entitySettings.UniqueIndexForName);
  }
}
