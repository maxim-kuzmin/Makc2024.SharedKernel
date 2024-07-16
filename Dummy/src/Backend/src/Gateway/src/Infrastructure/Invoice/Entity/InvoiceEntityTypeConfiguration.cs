namespace Gateway.Infrastructure.Invoice.Entity;

public class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceEntity>
{
  public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
  {
    var appSettings = AppDbContext.GetAppDbSettings();

    var entitySettings = appSettings.Entities.Invoice;

    builder.ToTable(entitySettings.Table, appSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entitySettings.PrimaryKey);

    builder.Property(x => x.Amount)
      .IsRequired()
      .HasColumnName(entitySettings.ColumnForAmount);

    builder.Property(x => x.CustomerId)
      .IsRequired()
      .HasColumnName(entitySettings.ColumnForCustomerId);

    builder.Property(x => x.Date)
      .IsRequired()
      .HasColumnName(entitySettings.ColumnForDate);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entitySettings.ColumnForId);

    builder.Property(x => x.Status)
      .IsRequired()
      .HasMaxLength(entitySettings.MaxLengthForStatus)
      .HasColumnName(entitySettings.ColumnForStatus);

    builder.HasIndex(x => x.CustomerId)
      .HasDatabaseName(entitySettings.IndexForCuctomerId);

    builder.HasOne(x => x.Customer)
      .WithMany(x => x.Invoices)
      .HasForeignKey(x => x.CustomerId)
      .HasPrincipalKey(x => x.Id)
      .HasConstraintName(entitySettings.ForeignKeyToCustomer);
  }
}
