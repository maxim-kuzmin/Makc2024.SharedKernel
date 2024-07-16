namespace Makc2024.Dummy.Gateway.Infrastructure.Revenue.Entity;

public class RevenueEntityTypeConfiguration : IEntityTypeConfiguration<RevenueEntity>
{
  public void Configure(EntityTypeBuilder<RevenueEntity> builder)
  {
    var appSettings = AppDbContext.GetAppDbSettings();

    var entitySettings = appSettings.Entities.Revenue;

    builder.ToTable(entitySettings.Table, appSettings.Schema);

    builder.HasKey(e => e.Month).HasName(entitySettings.PrimaryKey);

    builder.Property(x => x.Month)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForMonth)
      .HasColumnName(entitySettings.ColumnForMonth);

    builder.Property(x => x.Value)
      .HasColumnName(entitySettings.ColumnForValue);
  }
}
