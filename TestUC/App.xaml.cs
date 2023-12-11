using ControlzEx.Theming;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TestUC.Views;

namespace TestUC;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  protected override Window CreateShell()
  {
    return Container.Resolve<MainWindow>();
  }

  protected override void OnStartup(StartupEventArgs e)
  {
    base.OnStartup(e);
    ThemeManager.Current.ChangeTheme(this, "Dark.Green");
  }

  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {

  }

  protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    moduleCatalog.AddModule<QuikUC.QuikUCModule>();
  }


}
