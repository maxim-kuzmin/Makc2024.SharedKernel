using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

namespace Makc2024.Dummy.Gateway.Infrastructure.App;

public class AppMediatR
{
  public static readonly Assembly[] Assemblies;

  static AppMediatR()
  {
    var domainUseCasesAssembly = Assembly.GetAssembly(typeof(DummyItemGetListActionDTO))!;

    Assemblies = [domainUseCasesAssembly];
  }
}
