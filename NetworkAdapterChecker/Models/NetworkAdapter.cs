using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Collections.ObjectModel;

namespace NetworkAdapterChecker.Models
{
    public class NetworkAdapter
    {

        public MSFT_NetAdapter MSFT_NetAdapter { get; private set; }

        public NetworkAdapter(ManagementBaseObject obj) 
        {
            MSFT_NetAdapter = new(obj);
        }

        public static ObservableCollection<NetworkAdapter> GetNetworkAdapters()
        {
            ManagementScope scope = new ManagementScope(@"\\.\ROOT\StandardCimv2");
            ObjectQuery query = new("SELECT * FROM MSFT_NetAdapter");
            ManagementObjectSearcher searcher = new(scope, query);
            ManagementObjectCollection collection = searcher.Get();

            ObservableCollection<NetworkAdapter> ret = new();
            foreach (var item in collection)
            {
                ret.Add(new(item));
            }

            return ret;
        }
    }
}
