namespace Makc2024.Dummy.Shared.Event;

public interface IEventSource
{
  IEnumerable<EventBase> GetEvents();

  void RegisterEvent(EventBase entityEvent);

  void ClearEvents();
}
