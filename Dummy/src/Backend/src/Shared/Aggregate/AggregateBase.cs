namespace Makc2024.Dummy.Shared.Aggregate;

public class AggregateBase : EventSource
{
  private readonly HashSet<string> _changedProperties = [];

  protected bool HasChangedProperty(string propertyName)
  {
    return _changedProperties.Contains(propertyName);
  }

  protected void SetChangedProperty(string propertyName)
  {
    _changedProperties.Add(propertyName);
  }
}
