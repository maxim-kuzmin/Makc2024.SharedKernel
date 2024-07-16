namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  private static readonly AppDbSettings _appDbSettings = new();

  public DbSet<CustomerEntity> Customers => base.Set<CustomerEntity>();
  public DbSet<InvoiceEntity> Invoices => base.Set<InvoiceEntity>();
  public DbSet<RevenueEntity> Revenues => base.Set<RevenueEntity>();
  public DbSet<UserEntity> Users => base.Set<UserEntity>();

  public static AppDbSettings GetAppDbSettings() => _appDbSettings;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
