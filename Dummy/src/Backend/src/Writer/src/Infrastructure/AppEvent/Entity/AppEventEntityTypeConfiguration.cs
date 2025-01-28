namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.Entity;

/// <summary>
/// Конфигурация типа сущности события приложения.
/// </summary>
public class AppEventEntityTypeConfiguration : IEntityTypeConfiguration<AppEventEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<AppEventEntity> builder)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entityDbSettings = appDbSettings.Entities.AppEvent;

    builder.ToTable(entityDbSettings.Table, entityDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entityDbSettings.PrimaryKey);

    builder.Property(x => x.ConcurrencyToken)
      .IsConcurrencyToken()
      .HasColumnName(entityDbSettings.ColumnForConcurrencyToken);

    builder.Property(x => x.CreatedAt)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForCreatedAt);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entityDbSettings.ColumnForId);

    builder.Property(x => x.IsPublished)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForIsPublished);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForName);

    if (entityDbSettings.MaxLengthForName > 0)
    {
      builder.Property(x => x.Name).HasMaxLength(entityDbSettings.MaxLengthForName);
    }

    builder.HasIndex(x => x.Name)
      .IsUnique()
      .HasDatabaseName(entityDbSettings.UniqueIndexForName);
  }
}
