namespace Gateway.UIs.WebUI.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppWebUILayer(this IServiceCollection services, ILogger logger)
  {
    Guard.Against.Null(logger, nameof(logger));

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddFastEndpoints().SwaggerDocument(options =>
    {
      options.ShortSchemaNames = true;
    });

    logger.LogInformation("{Layer} layer added", nameof(WebUI));

    return services;
  }

  public static WebApplication UseAppWebUILayer(this WebApplication app, ILogger logger)
  {
    Guard.Against.Null(logger, nameof(logger));

    if (app.Environment.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
    }
    else
    {
      app.UseDefaultExceptionHandler(); // from FastEndpoints
      app.UseHsts();
    }

    app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware

    app.UseHttpsRedirection();

    logger.LogInformation("{Layer} layer used", nameof(WebUI));

    return app;
  }
}
