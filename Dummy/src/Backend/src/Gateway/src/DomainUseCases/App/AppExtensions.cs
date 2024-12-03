namespace Makc2024.Dummy.Gateway.DomainUseCases.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppDomainUseCasesLayer(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    logger.LogInformation("DomainUseCases layer added");

    return services;
  }
}
