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
        Name = "Delba de Oliveira"
      },
      new()
      {
        Name = "Lee Robinson"
      },
      new()
      {
        Name = "Hector Simpson"
      },
      new()
      {
        Name = "Steven Tey"
      },
      new()
      {
        Name = "Steph Dietz"
      },
      new()
      {
        Name = "Michael Novotny"
      },
      new()
      {
        Name = "Evil Rabbit"
      },
      new()
      {
        Name = "Emil Kowalski"
      },
      new()
      {
        Name = "Amy Burns"
      },
      new()
      {
        Name = "Balazs Orban"
      },
    ];
}
