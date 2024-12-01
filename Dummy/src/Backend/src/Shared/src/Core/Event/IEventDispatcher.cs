namespace Makc2024.Dummy.Shared.Core.Event;

public interface IEventDispatcher
{
  Task DispatchAndClearEvents(IEventSource eventSource, CancellationToken cancellationToken = default);
}
