namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public class AppLogger
{
  static AppLogger()
  {
    Log.Logger = new LoggerConfiguration()
      .Enrich.FromLogContext()
      .WriteTo.Console()
      .CreateLogger();
  }

  public static Microsoft.Extensions.Logging.ILogger Create<T>()
  {
    return new SerilogLoggerFactory(Log.Logger).CreateLogger<T>();
  }

  public static void CloseAndFlush()
  {
    Log.CloseAndFlush();
  }
}
