namespace Makc2024.Dummy.Shared.Core.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Преобразовать к ошибке приложения.
  /// </summary>
  /// <param name="error">Ошибка.</param>
  /// <param name="errorMessage">Сообщение об ошибке.</param>
  /// <returns>Ошибка приложения.</returns>
  public static AppError ToAppError<T>(this T error, string errorMessage) where T: Enum
  {
    return new(error.ToAppErrorCode(), errorMessage);
  }

  /// <summary>
  /// Преобразовать к коду ошибки приложения.
  /// </summary>
  /// <param name="error">Ошибка.</param>
  /// <returns>Код ошибки приложения.</returns>
  public static string ToAppErrorCode<T>(this T error) where T : Enum
  {
    return $"{typeof(T).Name}.{error}";
  }
}
