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

    var entitySettings = appDbSettings.Entities.AppEventPayload;

    builder.ToTable(entitySettings.Table, appDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entitySettings.PrimaryKey);

    builder.HasOne(x => x.Event)
      .WithMany(x => x.Payloads)
      .HasForeignKey(x => x.AppEventId)
      .IsRequired()
      .HasConstraintName(entitySettings.ForeignKeyForAppEventId);

    builder.Property(x => x.AppEventId)
      .IsRequired()
      .HasColumnName(entitySettings.ColumnForAppEventId);

    builder.Property(x => x.Entity)
      .IsRequired()
      .HasMaxLength(AppEventPayloadSettings.MaxLengthForEntity)
      .HasColumnName(entitySettings.ColumnForEntity);

    builder.Property(x => x.EntityId)
      .IsRequired()
      .HasMaxLength(AppEventPayloadSettings.MaxLengthForEntityId)
      .HasColumnName(entitySettings.ColumnForEntityId);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entitySettings.ColumnForId);

    builder.Property(x => x.Name)
      .HasMaxLength(AppEventPayloadSettings.MaxLengthForName)
      .HasColumnName(entitySettings.ColumnForName);

    builder.Property(x => x.NewValue)
      .HasColumnName(entitySettings.ColumnForNewValue);

    builder.Property(x => x.OldValue)
      .HasColumnName(entitySettings.ColumnForOldValue);
  }
}
