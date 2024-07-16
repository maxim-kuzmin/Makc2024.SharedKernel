namespace Makc2024.Dummy.Shared.Event;

public interface IEventDispatcher
{
  Task DispatchAndClearEvents(IEventSource eventSource, CancellationToken cancellationToken = default);
}
