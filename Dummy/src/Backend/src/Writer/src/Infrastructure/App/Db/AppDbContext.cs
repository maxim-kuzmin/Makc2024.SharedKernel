namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  private static readonly AppDbSettings _appDbSettings = new();

  public DbSet<DummyItemEntity> DummyItem => base.Set<DummyItemEntity>();

  public static AppDbSettings GetAppDbSettings() => _appDbSettings;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
