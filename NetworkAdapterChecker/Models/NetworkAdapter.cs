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

        public NetworkAdapter() { }
        public NetworkAdapter(ManagementBaseObject obj) 
        {
#if PRIVATEDEBUG
            foreach(var o in obj.Properties)
            {
                Console.WriteLine($"{o.Name}: {o.Value}");
            }
#endif
            MSFT_NetAdapter = new(obj);
        }

        /// <summary>
        /// MSFT_NetAdapter
        /// </summary>
        public MSFT_NetAdapter MSFT_NetAdapter { get; private set; } = new();

        /// <summary>
        /// ネットワークアダプタの配列を返す
        /// </summary>
        /// <returns></returns>
        public static NetworkAdapter[] GetNetworkAdapters()
        {
            ManagementScope scope = new ManagementScope(@"\\.\ROOT\StandardCimv2");
            ObjectQuery query = new("SELECT * FROM MSFT_NetAdapter");
            ManagementObjectSearcher searcher = new(scope, query);
            ManagementObjectCollection collection = searcher.Get();

            List<NetworkAdapter> ret = new();
            foreach (var item in collection)
            {
                ret.Add(new(item));
            }

            return ret.ToArray();
        }
    }
}
