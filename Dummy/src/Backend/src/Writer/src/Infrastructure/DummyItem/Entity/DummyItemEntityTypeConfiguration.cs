namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Entity;

/// <summary>
/// Конфигурация типа сущности фиктивного предмета.
/// </summary>
public class DummyItemEntityTypeConfiguration : IEntityTypeConfiguration<DummyItemEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<DummyItemEntity> builder)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entitySettings = appDbSettings.Entities.DummyItem;

    builder.ToTable(entitySettings.Table, appDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entitySettings.PrimaryKey);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entitySettings.ColumnForId);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(DummyItemSettings.MaxLengthForName)
      .HasColumnName(entitySettings.ColumnForName);

    builder.HasIndex(x => x.Name)
      .IsUnique()
      .HasDatabaseName(entitySettings.UniqueIndexForName);
  }
}
