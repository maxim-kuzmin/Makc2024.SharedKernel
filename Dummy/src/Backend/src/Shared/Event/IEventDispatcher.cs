namespace Shared.Event;

public interface IEventDispatcher
{
  Task DispatchAndClearEvents(IEventSource eventSource, CancellationToken cancellationToken = default);
}
