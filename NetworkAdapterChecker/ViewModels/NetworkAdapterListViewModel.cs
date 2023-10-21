using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.ViewModels
{
    public class NetworkAdapterListViewModel: ViewModelBase
    {
        public MainMenu Menu { get; private set; }

        public NetworkAdapterListViewModel()
        {
            Menu = new();
        }
    }
}
