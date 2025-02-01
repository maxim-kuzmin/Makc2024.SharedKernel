namespace Makc2024.Dummy.Writer.Infrastructure.App;

/// <summary>
/// Данные приложения.
/// </summary>
public static class AppData
{
  /// <summary>
  /// Инициализировать асинхронно.
  /// </summary>
  /// <param name="appDbContext">Контекст базы данных приложения.</param>
  /// <returns>Задача.</returns>
  public static async Task InitializeAsync(AppDbContext appDbContext)
  {
    bool isSeeded = await appDbContext.DummyItem.AnyAsync().ConfigureAwait(false);

    if (isSeeded)
    {
      return;
    }

    await PopulateTestDataAsync(appDbContext).ConfigureAwait(false);
  }

  /// <summary>
  /// Заполнить тестовыми данными асинхронно.
  /// </summary>
  /// <param name="appDbContext">Контекст базы данных приложения.</param>
  /// <returns>Задача.</returns>
  public static async Task PopulateTestDataAsync(AppDbContext appDbContext)
  {
    using var tran = appDbContext.Database.BeginTransaction();

    appDbContext.DummyItem.AddRange(CreateDummyItems());

    await appDbContext.SaveChangesAsync().ConfigureAwait(false);

    tran.Commit();
  }

  private static List<DummyItemEntity> CreateDummyItems() =>
    [
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Delba de Oliveira"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Lee Robinson"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Hector Simpson"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Steven Tey"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Steph Dietz"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Michael Novotny"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Evil Rabbit"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Emil Kowalski"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Amy Burns"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Balazs Orban"
      },
    ];
}
