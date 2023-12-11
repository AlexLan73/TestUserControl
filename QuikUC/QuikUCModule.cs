using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QuikUC.Constants;
using QuikUC.Views;

namespace QuikUC;

public class QuikUCModule : IModule
{
  public void OnInitialized(IContainerProvider containerProvider)
  {
    var regionManager = containerProvider.Resolve<IRegionManager>();
    regionManager.RegisterViewWithRegion(NameRegions.VLoadSecCodeFromClass, typeof(VQJSIM));
    regionManager.RegisterViewWithRegion(NameRegions.VLoadSecCodeFromClass, typeof(VSPBFUT));
    regionManager.RegisterViewWithRegion(NameRegions.VLoadSecCodeFromClass, typeof(VSPBFUT));

  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.Register<VLoadTSecCodeQuik>();
//    containerRegistry.Register<VQJSIM>();
//    containerRegistry.Register<VRestClass>();
//    containerRegistry.Register<VSPBFUT>();

  }

}