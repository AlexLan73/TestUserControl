using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using QuikUC.Views;
using System;
using System.Windows;
using System.Windows.Threading;
using TestUC.Views;

namespace TestUC.ViewModels;

public class MainWindowViewModel : BindableBase
{
  #region ___ DATA ___
  #region Title
  private string _title = "Prism Application";
  public string Title
  {
    get => _title; 
    set => SetProperty(ref _title, value); 
  }
  #endregion
  private readonly IRegionManager _region;
  private readonly IContainerProvider _container;
  private readonly IEventAggregator _ea;
  public DelegateCommand<string> NavigateCommand { get; private set; }

  private VLoadTSecCodeQuik _vLoadTSecCode;
  private MainWindow _mainWindow;
  private readonly Dispatcher _dispatcher = Application.Current != null ? Application.Current.Dispatcher : Dispatcher.CurrentDispatcher;
  #endregion

  public MainWindowViewModel(IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator ea)
  {
    _region = regionManager;
    _container = containerProvider;
    _ea = ea;
    NavigateCommand = new DelegateCommand<string>(Navigate);
  }

  private void Navigate(string command)
  {
    switch (command)
    {
      case "getquikclass":
        if (_vLoadTSecCode == null)
        {
          _vLoadTSecCode = _container.Resolve<VLoadTSecCodeQuik>();
          _vLoadTSecCode.Closed  += (_, _) =>{ _vLoadTSecCode = null; };
          _vLoadTSecCode.Show();
        }
        
        break;
    }
  }

  internal void SetParameters(MainWindow mainWindow)
  {
    _mainWindow = mainWindow;
    _mainWindow.Closed += (_, _) => 
    {
      _dispatcher.Invoke(() =>
      {
        _vLoadTSecCode?.Close();
      });
    };
  }
}
