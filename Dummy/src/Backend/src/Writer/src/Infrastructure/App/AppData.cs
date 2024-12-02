namespace Makc2024.Dummy.Writer.Infrastructure.App;

public static class AppData
{
  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    bool isSeeded = await dbContext.DummyItem.AnyAsync().ConfigureAwait(false);

    if (isSeeded)
    {
      return;
    }

    await PopulateTestDataAsync(dbContext).ConfigureAwait(false);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    using var tran = dbContext.Database.BeginTransaction();

    dbContext.DummyItem.AddRange(CreateDummyItems());

    await dbContext.SaveChangesAsync().ConfigureAwait(false);

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
