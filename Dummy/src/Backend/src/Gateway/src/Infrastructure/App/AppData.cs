namespace Gateway.Infrastructure.App;

public static class AppData
{
  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    if (await dbContext.Revenues.AnyAsync()) // DB has been seeded
    {
      return;
    }

    await PopulateTestDataAsync(dbContext);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    using var tran = dbContext.Database.BeginTransaction();

    dbContext.Customers.AddRange(CreateCustomers());
    dbContext.Revenues.AddRange(CreateRevenues());
    dbContext.Users.AddRange(CreateUsers());

    await dbContext.SaveChangesAsync();

    var customers = await dbContext.Customers.ToListAsync();

    dbContext.Invoices.AddRange(CreateInvoices(customers));

    await dbContext.SaveChangesAsync();

    tran.Commit();
  }

  private static List<CustomerEntity> CreateCustomers() =>
    [
      new()
      {
        Name = "Delba de Oliveira",
        Email = "delba@oliveira.com",
        ImageUrl = "/customers/delba-de-oliveira.png"
      },
      new()
      {
        Name = "Lee Robinson",
        Email = "lee@robinson.com",
        ImageUrl = "/customers/lee-robinson.png"
      },
      new()
      {
        Name = "Hector Simpson",
        Email = "hector@simpson.com",
        ImageUrl = "/customers/hector-simpson.png"
      },
      new()
      {
        Name = "Steven Tey",
        Email = "steven@tey.com",
        ImageUrl = "/customers/steven-tey.png"
      },
      new()
      {
        Name = "Steph Dietz",
        Email = "steph@dietz.com",
        ImageUrl = "/customers/steph-dietz.png"
      },
      new()
      {
        Name = "Michael Novotny",
        Email = "michael@novotny.com",
        ImageUrl = "/customers/michael-novotny.png"
      },
      new()
      {
        Name = "Evil Rabbit",
        Email = "emil@kowalski.com",
        ImageUrl = "/customers/evil-rabbit.png"
      },
      new()
      {
        Name = "Emil Kowalski",
        Email = "evil@rabbit.com",
        ImageUrl = "/customers/emil-kowalski.png"
      },
      new()
      {
        Name = "Amy Burns",
        Email = "amy@burns.com",
        ImageUrl = "/customers/amy-burns.png"
      },
      new()
      {
        Name = "Balazs Orban",
        Email = "balazs@orban.com",
        ImageUrl = "/customers/balazs-orban.png"
      },
    ];

  private static List<InvoiceEntity> CreateInvoices(List<CustomerEntity> customers) =>
    [
      new()
      {
        CustomerId = customers[0].Id,
        Amount = 15795,
        Status = "pending",
        Date = new DateOnly(2022, 12, 06)
      },
      new()
      {
        CustomerId = customers[1].Id,
        Amount = 20348,
        Status = "pending",
        Date = new DateOnly(2022, 11, 14)
      },
      new()
      {
        CustomerId = customers[4].Id,
        Amount = 3040,
        Status = "paid",
        Date = new DateOnly(2022, 10, 29)
      },
      new()
      {
        CustomerId = customers[3].Id,
        Amount = 44800,
        Status = "paid",
        Date = new DateOnly(2023, 09, 10)
      },
      new()
      {
        CustomerId = customers[5].Id,
        Amount = 34577,
        Status = "pending",
        Date = new DateOnly(2023, 08, 05)
      },
      new()
      {
        CustomerId = customers[7].Id,
        Amount = 54246,
        Status = "pending",
        Date = new DateOnly(2023, 07, 16)
      },
      new()
      {
        CustomerId = customers[6].Id,
        Amount = 666,
        Status = "pending",
        Date = new DateOnly(2023, 06, 27)
      },
      new()
      {
        CustomerId = customers[3].Id,
        Amount = 32545,
        Status = "paid",
        Date = new DateOnly(2023, 06, 09)
      },
      new()
      {
        CustomerId = customers[4].Id,
        Amount = 1250,
        Status = "paid",
        Date = new DateOnly(2023, 06, 17)
      },
      new()
      {
        CustomerId = customers[5].Id,
        Amount = 8546,
        Status = "paid",
        Date = new DateOnly(2023, 06, 07)
      },
      new()
      {
        CustomerId = customers[1].Id,
        Amount = 500,
        Status = "paid",
        Date = new DateOnly(2023, 08, 19)
      },
      new()
      {
        CustomerId = customers[5].Id,
        Amount = 8945,
        Status = "paid",
        Date = new DateOnly(2023, 06, 03)
      },
      new()
      {
        CustomerId = customers[2].Id,
        Amount = 8945,
        Status = "paid",
        Date = new DateOnly(2023, 06, 18)
      },
      new()
      {
        CustomerId = customers[0].Id,
        Amount = 8945,
        Status = "paid",
        Date = new DateOnly(2023, 10, 04)
      },
      new()
      {
        CustomerId = customers[2].Id,
        Amount = 1000,
        Status = "paid",
        Date = new DateOnly(2022, 06, 05)
      },
  ];

  private static List<RevenueEntity> CreateRevenues() =>
      [
        new()
      {
        Month = "Jan",
        Value = 2000
      },
      new()
      {
        Month = "Feb",
        Value = 1800
      },
      new()
      {
        Month = "Mar",
        Value = 2200
      },
      new()
      {
        Month = "Apr",
        Value = 2500
      },
      new()
      {
        Month = "May",
        Value = 2300
      },
      new(){
        Month = "Jun",
        Value = 3200
      },
      new()
      {
        Month = "Jul",
        Value = 3500
      },
      new()
      {
        Month = "Aug",
        Value = 3700
      },
      new()
      {
        Month = "Sep",
        Value = 2500
      },
      new()
      {
        Month = "Oct",
        Value = 2800
      },
      new()
      {
        Month = "Nov",
        Value = 3000
      },
      new()
      {
        Month = "Dec",
        Value = 4800
      }
      ];

  private static List<UserEntity> CreateUsers() =>
    [
      new()
      {
        Name = "User",
        Email = "user@nextmail.com",
        Password = "123456"
      }
    ];
}
