using MahApps.Metro.Controls;
using System.Windows;
using TestUC.ViewModels;

namespace TestUC.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow :  MetroWindow
{
  public MainWindow()
  {
    InitializeComponent();
    ((MainWindowViewModel)this.DataContext).SetParameters(this);
  }
}
