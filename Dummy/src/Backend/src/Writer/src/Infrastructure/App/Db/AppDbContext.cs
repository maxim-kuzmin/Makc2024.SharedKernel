namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

/// <summary>
/// Контекст базы данных приложения.
/// При старте приложения перед регистрацией класса в контейнере DI нужно обязательно вызвать статический метод Init.
/// </summary>
/// <param name="options">Параметры.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  private static readonly Lock _initLock = new();

  private static AppDbSettings? _appDbSettings = null; 

  /// <summary>
  /// Событие приложения.
  /// </summary>
  public DbSet<AppEventEntity> AppEvent => base.Set<AppEventEntity>();

  /// <summary>
  /// Полезная нагрузка события приложения.
  /// </summary>
  public DbSet<AppEventPayloadEntity> AppEventPayload => base.Set<AppEventPayloadEntity>();

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DbSet<DummyItemEntity> DummyItem => base.Set<DummyItemEntity>();

  /// <summary>
  /// Получить настройки базы данных приложения.
  /// </summary>
  /// <returns>Настройки базы данных приложения.</returns>
  public static AppDbSettings GetAppDbSettings()
  {
    return Guard.Against.Null(_appDbSettings, parameterName: nameof(_appDbSettings));
  }

  /// <summary>
  /// Инициализировать.
  /// Необходимо вызвать этот метод один раз при старте приложения перед регистрацией класса в контейнере DI.
  /// </summary>
  /// <param name="appDbSettings">Настройки базы данных приложения.</param>
  public static void Init(AppDbSettings appDbSettings)
  {
    lock (_initLock)
    {
      _appDbSettings = appDbSettings;
    }
  }

  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
