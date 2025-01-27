namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Интерфейс ресурсов фиктивного предмета.
/// </summary>
public interface IDummyItemResources
{
  /// <summary>
  /// Получить сообщение об ошибке пустого имени.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetNameIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного имени.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetNameIsTooLongErrorMessage(int maxLength);
}
