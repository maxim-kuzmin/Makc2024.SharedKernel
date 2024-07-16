namespace Shared.DeepCopy;

public static class DeepCopyExtensions
{
  public static List<T>? ToDeepCopyList<T>(this IEnumerable<T>? value)
    where T : IDeepCopyable
  {
    return value?.Select(x => (T)x.DeepCopy()).ToList();
  }

  public static IReadOnlyCollection<T>? ToDeepCopyReadOnlyCollection<T>(this IEnumerable<T>? value)
    where T : IDeepCopyable
  {
    return value.ToDeepCopyList()?.AsReadOnly();
  }
}
