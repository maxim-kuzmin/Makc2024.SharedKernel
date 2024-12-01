namespace Makc2024.Dummy.Shared.Core.Event;

public class EventSource : IEventSource
{
  private readonly List<EventBase> _events = [];

  public void ClearEvents() => _events.Clear();

  public IEnumerable<EventBase> GetEvents() => _events.AsReadOnly();

  public void RegisterEvent(EventBase evt) => _events.Add(evt);
}
