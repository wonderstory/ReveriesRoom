using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;

namespace Mvrck.ReveriesRoom.Windows.Core.Mvvm;

public abstract class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
{
    protected IRegionManager RegionManager { get; }

    public RegionViewModelBase(IRegionManager regionManager)
    {
        RegionManager = regionManager;
    }

    public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        continuationCallback.Invoke(true);
    }

    public virtual bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
    }
}
