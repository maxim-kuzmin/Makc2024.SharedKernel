namespace Makc2024.Dummy.Shared.Infrastructure.Db.Helpers;

/// <summary>
/// Интерфейс помощника базы данных для SQL.
/// </summary>
public interface IDbHelperForSQL
{
  /// <summary>
  /// Создать запрос из SQL с форматированием. Во втором аргументе указываются параметры, которые нужно вставить в
  /// строку SQL-запроса, указанную в первом параметре. Параметры вставляются в то место строки, где указан их индекс
  /// в фигурных скобках: {0}, {1} и так далее. Если параметры не переданы или не содержат ни одного значения, места
  /// для их подстановки не должны быть указаны в строке SQL-запроса, указанной в первом аргументе.  
  /// </summary>
  /// <typeparam name="T">Тип данных, возвращаемый запросом.</typeparam>
  /// <param name="sqlWithFormat">SQL с форматированием.</param>
  /// <param name="parameters">Параметры.</param>
  /// <returns>Запрос.</returns>
  IQueryable<T> CreateQueryFromSqlWithFormat<T>(string sqlWithFormat, IEnumerable<object>? parameters = null);
}
