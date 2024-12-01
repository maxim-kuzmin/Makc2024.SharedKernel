namespace Makc2024.Dummy.Shared.Core.Event;

public interface IEventSource
{
  IEnumerable<EventBase> GetEvents();

  void RegisterEvent(EventBase entityEvent);

  void ClearEvents();
}
