namespace Shared.Event;

public interface IEventSource
{
  IEnumerable<EventBase> GetEvents();

  void RegisterEvent(EventBase entityEvent);

  void ClearEvents();
}
