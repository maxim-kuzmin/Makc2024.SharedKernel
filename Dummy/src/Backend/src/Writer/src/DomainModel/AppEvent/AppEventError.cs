namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Ошибка события приложения.
/// </summary>
public enum AppEventError
{
  /// <summary>
  /// Дата создания недействительна.
  /// </summary>
  CreatedAtIsInvalid,

  /// <summary>
  /// Имя пустое.
  /// </summary>
  NameIsEmpty,

  /// <summary>
  /// Имя слишком длинное.
  /// </summary>
  NameIsTooLong
}
