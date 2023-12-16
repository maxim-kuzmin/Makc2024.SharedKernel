using MediatR;

namespace Makc2024.SharedKernel;

/// <summary>
/// Отправитель доменных событий на основе библиотеки MediatR.
/// </summary>
public class MediatRDomainEventDispatcher : ArdalisSharedKernel.MediatRDomainEventDispatcher
{
  public MediatRDomainEventDispatcher(IMediator mediator)
    : base(mediator)
  {    
  }
}

