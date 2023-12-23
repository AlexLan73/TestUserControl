using MahApps.Metro.Controls;
using Prism.Regions;
using System.Windows;
using QuikUC.ViewModels;

namespace QuikUC.Views;

/// <summary>
/// Interaction logic for VLoadTSecCodeQuik.xaml
/// </summary>
public partial class VLoadTSecCodeQuik : MetroWindow
{
/*
  public VLoadTSecCodeQuik()
  {
    InitializeComponent();
  }
*/
  public VLoadTSecCodeQuik(IRegionManager regionManager)
  {
    InitializeComponent();
    this.Loaded += (_, _) =>
    {
      ((VLoadTSecCodeQuikViewModel)this.DataContext).SetParam(this);
    };
    RegionManager.SetRegionManager(this, regionManager);
    RegionManager.UpdateRegions();
  }


}
