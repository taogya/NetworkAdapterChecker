using NetworkAdapterChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.ViewModels
{
    public class NetworkAdapterViewModel : ViewModelBase
    {
        public NetworkAdapterViewModel(NetworkAdapter adapter, DelegateCommand selectedItemCommand)
        {
            networkAdapter = adapter;
            SelectedItemCommand = selectedItemCommand;
        }

        private NetworkAdapter networkAdapter = new();
        /// <summary>
        /// ネットワークアダプタ
        /// </summary>
        public NetworkAdapter NetworkAdapter {
            get => networkAdapter;
            set => SetProperty(ref networkAdapter, value);
        }

        /// <summary>
        /// 選択された時の処理
        /// </summary>
        public DelegateCommand SelectedItemCommand { get; }
    }
}
