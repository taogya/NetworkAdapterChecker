using NetworkAdapterChecker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace NetworkAdapterChecker.ViewModels
{
    public class NetworkAdapterListViewModel: ViewModelBase
    {
        public NetworkAdapterListViewModel()
        {
            Menu = new(ExportCommand);
            foreach (var adapter in NetworkAdapter.GetNetworkAdapters())
            {
                NetworkAdapterList.Add(new(adapter, SelectNetworkAdapter));
            }
        }

        /// <summary>
        /// メニューバー用ViewModel
        /// </summary>
        public MainMenuViewModel Menu { get; private set; }


        private DelegateCommand? exportCommand;
        /// <summary>
        /// エクスポート
        /// </summary>
        public DelegateCommand ExportCommand
        {
            get
            {
                exportCommand ??= new DelegateCommand
                {
                    ExecuteHandler = ExportCommand_Execute,
                };
                return exportCommand;
            }
        }

        private void ExportCommand_Execute(object parameter)
        {
            MessageBox.Show("csv出力");
        }

        private DelegateCommand? networkAdaptersUpdate = null;
        /// <summary>
        /// ネットワークアダプタのリスト
        /// </summary>
        public DelegateCommand NetworkAdaptersUpdate
        {
            get
            {
                networkAdaptersUpdate ??= new DelegateCommand
                {
                    ExecuteHandler = NetworkAdaptersUpdate_Execute,
                };
                return networkAdaptersUpdate;
            }
        }
        private void NetworkAdaptersUpdate_Execute(object parameter)
        {
            NetworkAdapterList.Clear();
            SelectedNetworkAdapter = null;
            foreach (var adapter in NetworkAdapter.GetNetworkAdapters())
            {
                NetworkAdapterList.Add(new(adapter, SelectNetworkAdapter));
            }
        }

        private NetworkAdapter? selectedNetworkAdapter;
        /// <summary>
        /// 現在選択されているネットワークアダプタ
        /// </summary>
        public NetworkAdapter? SelectedNetworkAdapter
        {
            get => selectedNetworkAdapter;
            set => SetProperty(ref selectedNetworkAdapter, value);
        }

        private ObservableCollection<NetworkAdapterViewModel> networkAdapterList = new();
        /// <summary>
        /// ネットワークアダプタのリスト
        /// </summary>
        public ObservableCollection<NetworkAdapterViewModel> NetworkAdapterList
        {
            get => networkAdapterList;
            set => SetProperty(ref networkAdapterList, value);
        }

        private DelegateCommand? selectNetworkAdapter = null;
        /// <summary>
        /// ネットワークアダプタを選択したときの処理
        /// </summary>
        public DelegateCommand SelectNetworkAdapter
        {
            get
            {
                selectNetworkAdapter ??= new()
                {
                    ExecuteHandler = SelectNetworkAdapter_Executer,
                };
                return selectNetworkAdapter;
            }
            }
        

        private void SelectNetworkAdapter_Executer(object parameter)
        {
            SelectedNetworkAdapter = ((NetworkAdapterViewModel)parameter).NetworkAdapter;
        }
    }
}
