using Microsoft.Win32;
using NetworkAdapterChecker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Resources;
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
            SaveFileDialog saveFileDialog = new()
            {
                AddExtension = true,
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                DefaultExt = "csv",
            };


            if (saveFileDialog.ShowDialog() == true)
            {
                string selectedPath = saveFileDialog.FileName;
                var properties = NetworkAdapterList.Select((adp) => adp.NetworkAdapter).ToList();
                if (properties.Count == 0)
                    return;

                try
                {

                    using var writer = new StreamWriter(selectedPath, false, Encoding.UTF8);
                    // ヘッダーの書き込み
                    List<string> header = new();
                    foreach (KeyValuePair<string, object?> keyVal in properties[0].MSFT_NetAdapter)
                        header.Add($"{keyVal.Key}");
                    writer.WriteLine(string.Join(",", header));
                    // データの書き込み
                    foreach (var property in properties)
                    {
                        List<string> data = new();
                        foreach (KeyValuePair<string, object?> keyVal in property.MSFT_NetAdapter)
                        {
                            var val = keyVal.Value;
                            if(val  != null)
                                val = val.ToString().Contains(",") ? $"\"{val}\"" : val;
                            data.Add($"{val}");
                        }
                        writer.WriteLine(string.Join(",", data));
                    }
                }
                catch
                {
                    MessageBox.Show((string)Application.Current.Resources.MergedDictionaries[0]["export_failed"],
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
