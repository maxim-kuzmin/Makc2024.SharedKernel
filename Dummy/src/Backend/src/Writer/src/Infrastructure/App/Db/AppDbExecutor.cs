namespace Makc2024.Dummy.Writer.Infrastructure.App.Db;

/// <summary>
/// Исполнитель базы данных приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbExecutor(AppDbContext dbContext) : DbExecutor<AppDbContext>(dbContext), IAppDbExecutor
{
}
