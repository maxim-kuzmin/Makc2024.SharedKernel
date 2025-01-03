using Makc2024.Dummy.Writer.DomainModel.AppEvent;

namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

/// <summary>
/// Контекст базы данных приложения.
/// </summary>
/// <param name="options">Параметры.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  private static readonly AppDbSettings _appDbSettings = new();

  /// <summary>
  /// Событие приложения.
  /// </summary>
  public DbSet<AppEventEntity> AppEvent => base.Set<AppEventEntity>();

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DbSet<DummyItemEntity> DummyItem => base.Set<DummyItemEntity>();

  /// <summary>
  /// Получить настройки базы данных приложения.
  /// </summary>
  /// <returns>Настройки базы данных приложения.</returns>
  public static AppDbSettings GetAppDbSettings() => _appDbSettings;

  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
