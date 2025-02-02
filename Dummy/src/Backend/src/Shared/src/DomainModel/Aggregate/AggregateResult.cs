namespace Makc2024.Dummy.Shared.DomainModel.Aggregate;

/// <summary>
/// Результат агрегата.
/// </summary>
/// <typeparam name="TData">Тип данных.</typeparam>
/// <param name="Data">Данные.</param>
/// <param name="Errors">Ошибки.</param>
public record AggregateResult<TData>(TData? Data, HashSet<AppError>? Errors = null)
{
  /// <summary>
  /// Недействителен ли?
  /// </summary>
  public bool IsInvalid => Data == null || Errors?.Count > 0;

  /// <summary>
  /// Преобразовать к ошибкам валидации.
  /// </summary>
  /// <param name="funcToGetIdentifierByCode">Функция для получения идентификатора по коду.</param>
  /// <param name="funcToGetSeverityByCode">Функция для получения серьёзности по коду.</param>
  /// <returns>Ошибки валидации.</returns>
  public List<ValidationError> ToValidationErrors(
    Func<string, string>? funcToGetIdentifierByCode = null,
    Func<string, ValidationSeverity>? funcToGetSeverityByCode = null)
  {
    if (Errors == null || Errors.Count == 0)
    {
      return [];
    }

    List<ValidationError> result = new(Errors.Count);

    foreach (var error in Errors)
    {
      var validationError = new ValidationError(
        funcToGetIdentifierByCode != null ? funcToGetIdentifierByCode.Invoke(error.Code) : string.Empty,
        error.Message,
        error.Code,
        funcToGetSeverityByCode != null ? funcToGetSeverityByCode.Invoke(error.Code): ValidationSeverity.Error);

      result.Add(validationError);
    }

    return result;
  }
}
