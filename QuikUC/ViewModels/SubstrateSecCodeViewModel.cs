using ImTools;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using QuikUC.Constants;
using QuikUC.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuikUC.ViewModels;

public class SubstrateSecCodeViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest
{
  private IRegionManager _regionManager;
  public SubstrateSecCodeViewModel(IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator ea)
  {
    _regionManager = regionManager;
  }

  public virtual void OnNavigatedTo(NavigationContext navigationContext)
  {
  }
  public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;
  public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }
  public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
  {
    if (continuationCallback != null)
    {
      var s =(string) navigationContext.Parameters["pole"];
      _regionManager.RegisterViewWithRegion(NameRegions.VLoadSecCodeFromClass, s);

    }

  }


}

