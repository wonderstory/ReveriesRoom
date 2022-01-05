using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Mvrck.ReveriesRoom.Windows;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<Views.MainWindow>();
    }

    protected override void InitializeShell(Window shell)
    {
        base.InitializeShell(shell);

        var regionManager = RegionManager.GetRegionManager(shell);
        regionManager.AddToRegion(Core.RegionNames.Content, Container.Resolve<Views.View>());
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
    }


    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();

        // アセンブリ名・名前空間双方について View → ViewModel として ViewModel を探す
        ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        {
            var viewName = viewType.FullName ?? string.Empty;
            viewName = viewName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName ?? string.Empty;
            viewAssemblyName = viewAssemblyName.Replace(".Views,", ".ViewModels,");
            var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
            var viewModelName = $"{viewName}{suffix}, {viewAssemblyName}";
            return Type.GetType(viewModelName);
        });
    }
}
