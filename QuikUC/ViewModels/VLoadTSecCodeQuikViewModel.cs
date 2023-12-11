using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using DynamicData;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Prism.Regions;
using QuikUC.Constants;
using Prism.Events;
using Prism.Ioc;
using QuikUC.Views;
using ImTools;

namespace QuikUC.ViewModels;

public class VLoadTSecCodeQuikViewModel : ReactiveObject
{
  #region __ DATA __
  #region ----  Title  ----
  private string _title = "";
  public string Title
  {
    get => _title;
    set => this.RaiseAndSetIfChanged(ref _title, value);
  }
  #endregion

  #region __ Name __
  private string _name = "";

  [Reactive]
  public string Name
  {
    get => _name;
    set => this.RaiseAndSetIfChanged(ref _name, value);
  }
  #endregion

  #region __ SelectT __
  private string _selectT = "";
  [Reactive]
  public string SelectT
  {
    get => _selectT;
//    set => SetProperty(ref _selectT, value);
    set => this.RaiseAndSetIfChanged(ref _selectT, value);
  }
  #endregion

  #region ___ DClass ___
  /// <summary>
  /// SourceCache<string, string>  - у меня стоит class SourceCache<class, string>
  ///    DClass - данные могут динамически add/del 
  /// </summary>
  private SourceCache<string, string> DClass { get; set; } = new SourceCache<string, string>(t => t);
  #endregion

  private ReadOnlyObservableCollection<string> _lsIsCheck;
  public ReadOnlyObservableCollection<string> LsIsCheck => _lsIsCheck;

  #endregion

  private readonly IRegionManager _region;
  private readonly IContainerProvider _container;
  private readonly IEventAggregator _ea;


  public VLoadTSecCodeQuikViewModel(IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator ea)
  {
    _region = regionManager;
    _container = containerProvider;
    _ea = ea;

    Title = "Грузим SecCode & Class с бирже";
    Name = "Выбираем тикер из классов";

    _ = LoadDataAsync();

    _ = DClass.Connect()
      .ObserveOnDispatcher(DispatcherPriority.Normal)
      .ObserveOn(RxApp.MainThreadScheduler)
      .Bind(out _lsIsCheck)
      .Subscribe();

    _ = this.WhenAnyValue(x => x.SelectT).Subscribe(t =>
        {
          if (string.IsNullOrEmpty(t))  return;

          switch (t)
          {
            case "SPBFUT":
              _region.RequestNavigate(NameRegions.VLoadSecCodeFromClass, nameof(VSPBFUT));
              break;

            case "QJSIM":
              _region.RequestNavigate(NameRegions.VLoadSecCodeFromClass, nameof(VQJSIM));
              break;

            default:
              _region.RequestNavigate(NameRegions.VLoadSecCodeFromClass, nameof(VRestClass));
              break;
          }

        });

  }

  private async Task LoadDataAsync()
  {   // Вызов модуля, обращение к свободному Quik,  запрос на биржу о классах
    await Task.Delay(1000);

    List<string> list = new List<string> { "SMS", "CROSSRATE", "EQRP_INFO", "QJSIM", "SPBFUT", "SPBOPT", "UP", "IA" };
    DClass.AddOrUpdate(list);
  }


}
