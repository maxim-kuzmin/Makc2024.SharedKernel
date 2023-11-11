using MediatR;

namespace Makc2024.SharedKernel;

/// <summary>
/// A base type for domain events. Depends on MediatR INotification.
/// Includes DateOccurred which is set on creation.
/// </summary>
public abstract class DomainEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

