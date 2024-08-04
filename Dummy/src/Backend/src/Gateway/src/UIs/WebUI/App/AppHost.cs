namespace Makc2024.Dummy.Gateway.UIs.WebUI.App;

public class AppHost
{
  public static Task RunAsync(string[] args)
  {
    var logger = AppLogger.Create<AppHost>();

    try
    {
      logger.LogInformation("Starting web application");

      AppEnvironment.LoadVariables();

      var builder = WebApplication.CreateBuilder(args);

      var appConfigSection = builder.Configuration.GetSection(AppConfigOptions.SectionKey);

      var appConfigOptions = appConfigSection.CreateAppConfigOptions();

      builder.Services
        .AddAppWebUILayer(logger, appConfigOptions)
        .AddAppInfrastructureLayer(logger, appConfigOptions, builder.Host, builder.Configuration, appConfigSection);

      var app = builder.Build();

      app.UseAppWebUILayer(logger);      

      app.Run();
    }
    catch (Exception ex)
    {
      logger.LogCritical(ex, "Application terminated unexpectedly");
    }
    finally
    {
      AppLogger.CloseAndFlush();
    }

    return Task.CompletedTask;
  }
}
