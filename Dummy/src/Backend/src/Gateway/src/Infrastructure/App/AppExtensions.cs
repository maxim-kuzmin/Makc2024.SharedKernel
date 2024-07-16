namespace Gateway.Infrastructure.App;

public static class AppExtensions
{
  public static IServiceCollection AddAppInfrastructureLayer(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    IConfiguration configuration,
    IHostBuilder hostBuilder)
  {
    Guard.Against.Null(logger, nameof(logger));
    Guard.Against.Null(configuration, nameof(configuration));
    Guard.Against.Null(hostBuilder, nameof(hostBuilder));

    hostBuilder.UseSerilog((_, config) => config.ReadFrom.Configuration(configuration));

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppMediatR.Assemblies));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    services.AddScoped<IEventDispatcher, EventDispatcher>();

    var appConfigSection = configuration.GetSection(AppConfigOptions.SectionKey);

    services.Configure<AppConfigOptions>(appConfigSection);

    var appConfig = new AppConfigOptions();

    appConfigSection.Bind(appConfig);

    var connectionStringTemplate = configuration.GetConnectionString(appConfig.PostgreSQL.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    string? connectionString = appConfig.PostgreSQL.ToConnectionString(connectionStringTemplate);

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<ICustomerRepository, CustomerRepository>();

    services.AddScoped<ICustomerGetAllActionService, CustomerGetAllActionService>();
    services.AddScoped<ICustomerGetCountActionService, CustomerGetCountActionService>();
    services.AddScoped<ICustomerGetFilteredActionService, CustomerGetFilteredActionService>();

    services.AddScoped<IInvoiceRepository, InvoiceRepository>();    

    services.AddScoped<IInvoiceCreateActionService, InvoiceCreateActionService>();
    services.AddScoped<IInvoiceDeleteActionService, InvoiceDeleteActionService>();
    services.AddScoped<IInvoiceGetAmountsActionService, InvoiceGetAmountsActionService>();
    services.AddScoped<IInvoiceGetByIdActionService, InvoiceGetByIdActionService>();
    services.AddScoped<IInvoiceGetCountActionService, InvoiceGetCountActionService>();
    services.AddScoped<IInvoiceGetFilteredActionService, InvoiceGetFilteredActionService>();
    services.AddScoped<IInvoiceGetFilteredCountActionService, InvoiceGetFilteredCountActionService>();
    services.AddScoped<IInvoiceGetLatestActionService, InvoiceGetLatestActionService>();
    services.AddScoped<IInvoiceUpdateActionService, InvoiceUpdateActionService>();

    services.AddScoped<IRevenueRepository, RevenueRepository>();

    services.AddScoped<IRevenueGetListActionService, RevenueGetListActionService>();

    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IUserGetByEmailActionService, UserGetByEmailActionService>();

    logger.LogInformation("{Layer} layer added", nameof(Infrastructure));

    return services;
  }

  public static async Task UseAppInfrastructureLayerAsync(this IHost host, Microsoft.Extensions.Logging.ILogger logger)
  {
    using var scope = host.Services.CreateScope();

    var scopedServices = scope.ServiceProvider;

    try
    {
      var context = scopedServices.GetRequiredService<AppDbContext>();

      //await context.Database.MigrateAsync();
      await context.Database.EnsureCreatedAsync();

      await AppData.InitializeAsync(context);

      logger.LogInformation("{Layer} layer used", nameof(Infrastructure));
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
  }
}
