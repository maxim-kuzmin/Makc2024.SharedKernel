namespace Makc2024.Dummy.Gateway.UIs.WebUI.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppWebUILayer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptions appConfigOptions)
  {
    Guard.Against.Null(logger, nameof(logger));

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

    services.AddAuthorization();

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

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware

    app.UseHttpsRedirection();

    logger.LogInformation("{Layer} layer used", nameof(WebUI));

    return app;
  }
}
