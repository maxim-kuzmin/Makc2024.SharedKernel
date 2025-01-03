namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Entity;

/// <summary>
/// Конфигурация типа сущности события приложения.
/// </summary>
public class AppEventEntityTypeConfiguration : IEntityTypeConfiguration<AppEventEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<AppEventEntity> builder)
  {
    var dbSettings = AppDbContext.GetAppDbSettings();

    var entityDbSettings = dbSettings.Entities.AppEvent;

    builder.ToTable(entityDbSettings.Table, dbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entityDbSettings.PrimaryKey);

    builder.Property(x => x.CreationDate)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForCreationDate);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entityDbSettings.ColumnForId);

    builder.Property(x => x.IsPublished)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForIsPublished);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(AppEventSettings.MaxLengthForName)
      .HasColumnName(entityDbSettings.ColumnForName);

    builder.HasIndex(x => x.Name)
      .IsUnique()
      .HasDatabaseName(entityDbSettings.UniqueIndexForName);
  }
}
