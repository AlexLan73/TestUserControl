using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Ioc;
using Prism.Events;

namespace QuikUC.ViewModels;

public class VRestClassViewModel : ReactiveObject, INavigationAware, IConfirmNavigationRequest
{
  #region __ Name __
  private string _name = "";
  [Reactive]
  public string Name
  {
    get => _name;
    set => this.RaiseAndSetIfChanged(ref _name, value);
  }
  #endregion
  #region ----  Title  ----
  private string _title = "";
  public string Title
  {
    get => _title;
    set => this.RaiseAndSetIfChanged(ref _title, value);
  }
  #endregion

  public VRestClassViewModel(IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator ea)
  {
    Name = "- 2 ---  VRestClass ------ ";

  }

  public virtual void OnNavigatedTo(NavigationContext navigationContext)
  {
  }
  public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;
  public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }
  public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
  {

  }

}

