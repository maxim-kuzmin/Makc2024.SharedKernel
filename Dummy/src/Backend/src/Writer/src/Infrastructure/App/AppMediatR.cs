namespace Makc2024.Dummy.Writer.Infrastructure.App;

public class AppMediatR
{
  public static readonly Assembly[] Assemblies;

  static AppMediatR()
  {
    var domainModelAssembly = Assembly.GetAssembly(typeof(RevenueEntity))!;
    
    var domainUseCasesAssembly = Assembly.GetAssembly(typeof(RevenueGetListActionDTO))!;

    Assemblies = [domainModelAssembly, domainUseCasesAssembly];
  }
}
