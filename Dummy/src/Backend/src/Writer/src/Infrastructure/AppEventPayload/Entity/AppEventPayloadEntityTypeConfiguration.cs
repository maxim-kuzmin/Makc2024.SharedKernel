namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Entity;

/// <summary>
/// Конфигурация типа сущности полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadEntityTypeConfiguration : IEntityTypeConfiguration<AppEventPayloadEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<AppEventPayloadEntity> builder)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entityDbSettings = appDbSettings.Entities.AppEventPayload;

    builder.ToTable(entityDbSettings.Table, entityDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entityDbSettings.PrimaryKey);

    builder.HasOne(x => x.Event)
      .WithMany(x => x.Payloads)
      .HasForeignKey(x => x.AppEventId)
      .IsRequired()
      .HasConstraintName(entityDbSettings.ForeignKeyForAppEventId);

    builder.Property(x => x.AppEventId)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForAppEventId);

    builder.Property(x => x.Entity)
      .IsRequired()
      .HasMaxLength(entityDbSettings.MaxLengthForEntity)
      .HasColumnName(entityDbSettings.ColumnForEntity);

    builder.Property(x => x.EntityId)
      .IsRequired()
      .HasMaxLength(entityDbSettings.MaxLengthForEntityId)
      .HasColumnName(entityDbSettings.ColumnForEntityId);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entityDbSettings.ColumnForId);

    builder.Property(x => x.Name)
      .HasMaxLength(entityDbSettings.MaxLengthForName)
      .HasColumnName(entityDbSettings.ColumnForName);

    builder.Property(x => x.NewValue)
      .HasColumnName(entityDbSettings.ColumnForNewValue);

    builder.Property(x => x.OldValue)
      .HasColumnName(entityDbSettings.ColumnForOldValue);
  }
}
