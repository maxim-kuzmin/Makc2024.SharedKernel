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

    builder.Property(x => x.ConcurrencyToken)
      .IsConcurrencyToken()
      .HasColumnName(entityDbSettings.ColumnForConcurrencyToken);

    builder.Property(x => x.Data)
      .IsRequired()      
      .HasColumnName(entityDbSettings.ColumnForData);

    if (entityDbSettings.MaxLengthForData > 0)
    {
      builder.Property(x => x.Data).HasMaxLength(entityDbSettings.MaxLengthForData);
    }
  }
}
