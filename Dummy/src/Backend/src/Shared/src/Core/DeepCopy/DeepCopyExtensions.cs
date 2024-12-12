namespace Makc2024.Dummy.Shared.Core.DeepCopy;

/// <summary>
/// Расширения глубокой копии.
/// </summary>
public static class DeepCopyExtensions
{
  /// <summary>
  /// Преобразовать в список через глубокое копирование. 
  /// </summary>
  /// <typeparam name="T">Тип элемента списка.</typeparam>
  /// <param name="value">Преобразуемое значение.</param>
  /// <returns>Список, каждый элемент которого является глубокой копией элемента преобразуемого значения.</returns>
  public static List<T>? ToListViaDeepCopy<T>(this IEnumerable<T>? value)
    where T : IDeepCopyable
  {
    return value?.Select(x => (T)x.DeepCopy()).ToList();
  }

  /// <summary>
  /// Преобразовать в коллекцию только для чтения через глубокое копирование. 
  /// </summary>
  /// <typeparam name="T">Тип элемента списка.</typeparam>
  /// <param name="value">Преобразуемое значение.</param>
  /// <returns>
  /// Коллекция только для чтения, каждый элемент которой является глубокой копией элемента преобразуемого значения.
  /// </returns>
  public static IReadOnlyCollection<T>? ToReadOnlyCollectionViaDeepCopy<T>(this IEnumerable<T>? value)
    where T : IDeepCopyable
  {
    return value.ToListViaDeepCopy()?.AsReadOnly();
  }
}
