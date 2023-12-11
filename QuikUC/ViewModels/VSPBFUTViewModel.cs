using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;

namespace QuikUC.ViewModels;

public class VSPBFUTViewModel :  ReactiveObject, INavigationAware, IConfirmNavigationRequest
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

  public VSPBFUTViewModel()
  {
    Name = "- 0 ---  VSPBFUT ------ ";

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

/*
NavigationParameters keyValuePairs = new NavigationParameters();
keyValuePairs.Add("polq1", "!!!!!!!!");
    if (navigatePath != null)
      _regionManager.RequestNavigate("ContentRegion", navigatePath, NavigationComplete, keyValuePairs);

  public virtual void OnNavigatedTo(NavigationContext navigationContext) { }
  public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;
  public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }
  public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback) =>
    continuationCallback(true);



*/