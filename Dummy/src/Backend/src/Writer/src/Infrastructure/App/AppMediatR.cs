namespace Makc2024.Dummy.Writer.Infrastructure.App;

public class AppMediatR
{
  public static readonly Assembly[] Assemblies;

  static AppMediatR()
  {
    var domainModelAssembly = Assembly.GetAssembly(typeof(DummyItemEntity))!;
    
    var domainUseCasesAssembly = Assembly.GetAssembly(typeof(DummyItemGetListActionDTO))!;

    Assemblies = [domainModelAssembly, domainUseCasesAssembly];
  }
}
