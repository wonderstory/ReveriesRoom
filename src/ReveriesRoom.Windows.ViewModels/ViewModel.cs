using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Reactive.Bindings;
using Mvrck.ReveriesRoom.Windows.Core.Mvvm;

namespace Mvrck.ReveriesRoom.Windows.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        public ReactivePropertySlim<string> Prop { get; } = new();

        public ViewModel()
        {
            Prop.Value = "88888888";
        }
    }
}
