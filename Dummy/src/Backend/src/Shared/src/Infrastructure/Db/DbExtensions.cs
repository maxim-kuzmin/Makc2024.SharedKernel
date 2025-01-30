namespace Makc2024.Dummy.Shared.Infrastructure.Db;

/// <summary>
/// Расширения базы данных.
/// </summary>
public static class DbExtensions
{
  /// <summary>
  /// Создать запрос из SQL с форматированием. Подробности здесь:
  /// <see cref="Helpers.IDbHelperForSQL.CreateQueryFromSqlWithFormat{T}(string, IEnumerable{object}?)"/>
  /// </summary>
  /// <typeparam name="T">Тип данных, возвращаемый запросом.</typeparam>
  /// <param name="dbContext">Контекст базы данных.</param>
  /// <param name="sqlWithFormat">SQL с форматированием.</param>
  /// <param name="parameters">Параметры.</param>
  /// <returns>Запрос.</returns>
  public static IQueryable<T> CreateQueryFromSqlWithFormat<T>(
    this DbContext dbContext, 
    string sqlWithFormat,
    IEnumerable<object>? parameters = null)
  {
    if (parameters?.Any() == true)
    {
      var sql = FormattableStringFactory.Create(sqlWithFormat, [.. parameters]);

      return dbContext.Database.SqlQuery<T>(sql);
    }
    else
    {
      return dbContext.Database.SqlQueryRaw<T>(sqlWithFormat);
    }    
  }
}
