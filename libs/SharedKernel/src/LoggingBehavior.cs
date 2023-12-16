using MediatR;
using Microsoft.Extensions.Logging;

namespace Makc2024.SharedKernel;

/// <summary>
/// Логирующее поведение.
/// Добавляет логирование в обработку запросов библиотекой MediatR.
/// Настраивается добавлением одного экземпляром сервиса на каждый запрос (scope).
/// 
/// Пример для Autofac:
/// builder
///   .RegisterType&lt;Mediator&gt;()
///   .As&lt;IMediator&gt;()
///   .InstancePerLifetimeScope();
///
/// builder
///   .RegisterGeneric(typeof(LoggingBehavior&lt;,&gt;))
///      .As(typeof(IPipelineBehavior&lt;,&gt;))
///   .InstancePerLifetimeScope();
///
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class LoggingBehavior<TRequest, TResponse> : ArdalisSharedKernel.LoggingBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
{
  public LoggingBehavior(ILogger<Mediator> logger)
    : base(logger)
  {
  }
}

