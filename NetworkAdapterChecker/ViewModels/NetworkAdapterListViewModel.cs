using NetworkAdapterChecker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetworkAdapterChecker.ViewModels
{
    public class NetworkAdapterListViewModel: ViewModelBase
    {
        public MainMenuViewModel Menu { get; private set; }

        [XmlIgnore]
        private ObservableCollection<NetworkAdapter> networkAdapterList = new();
        [XmlIgnore]
        public ObservableCollection<NetworkAdapter> NetworkAdapterList
        {
            get => networkAdapterList;
            set => SetProperty(ref networkAdapterList, value);
        }


        public NetworkAdapterListViewModel()
        {
            Menu = new();
            NetworkAdapterList = NetworkAdapter.GetNetworkAdapters();
        }
    }
}
