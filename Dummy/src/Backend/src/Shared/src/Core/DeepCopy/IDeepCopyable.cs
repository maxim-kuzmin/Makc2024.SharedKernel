namespace Makc2024.Dummy.Shared.Core.DeepCopy;

public interface IDeepCopyable
{
  /// <summary>
  /// Глубоко копировать.
  /// </summary>
  /// <returns>Глубокая копия.</returns>
  object DeepCopy();
}
