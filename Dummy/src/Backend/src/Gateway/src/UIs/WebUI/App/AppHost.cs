﻿namespace Makc2024.Dummy.Gateway.UIs.WebUI.App;

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

      builder.Services
        .AddAppWebUILayer(logger)
        .AddAppInfrastructureLayer(logger, builder.Configuration, builder.Host);

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
