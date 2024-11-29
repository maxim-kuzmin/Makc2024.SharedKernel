namespace Makc2024.Dummy.Gateway.Apps.WebApp.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppUILayer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptions appConfigOptions)
  {
    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    // see https://github.com/ardalis/AspNetCoreStartupServices
    services.Configure<ServiceConfig>(config =>
    {
      config.Services = new List<ServiceDescriptor>(services);

      // optional - default path to view services is /listallservices - recommended to choose your own path
      config.Path = "/mylistallservicespath";
    });

    services.AddFastEndpoints()
      .AddAuthorization()
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        byte[] keyBytes = Encoding.UTF8.GetBytes(appConfigOptions.Authentication.Key);

        var issuerSigningKey = appConfigOptions.Authentication.GetSymmetricSecurityKey();

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = appConfigOptions.Authentication.Issuer,
          ValidateAudience = true,
          ValidAudience = appConfigOptions.Authentication.Audience,
          ValidateLifetime = true,
          IssuerSigningKey = issuerSigningKey,
          ValidateIssuerSigningKey = true
        };
      });

    services.SwaggerDocument(options =>
    {
      options.ShortSchemaNames = true;
      options.EnableJWTBearerAuth = true;
    });

    logger.LogInformation("UI layer added");

    return services;
  }

  public static WebApplication UseAppUILayer(this WebApplication app, ILogger logger)
  {
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

    app.UseAuthentication()
      .UseAuthorization()
      .UseMiddleware<AppSessionMiddleware>()
      .UseFastEndpoints()
      .UseSwaggerGen(); // Includes AddFileServer and static files middleware

    app.UseHttpsRedirection();

    logger.LogInformation("UI layer used");

    return app;
  }

  private static SymmetricSecurityKey GetSymmetricSecurityKey(
    this AppConfigOptionsAuthentication options)
  {
    byte[] keyBytes = Encoding.UTF8.GetBytes(options.Key);

    return new SymmetricSecurityKey(keyBytes);
  }
}
