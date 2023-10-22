using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// デバイスのポートまたは接続ポイントの抽象化。 <br />
    /// https://learn.microsoft.com/ja-jp/windows/win32/hyperv_v2/cim-logicalport
    /// </summary>
    public class CIM_LogicalPort : CIM_LogicalDevice
    {
        public CIM_LogicalPort(ManagementBaseObject obj) : base(obj) 
        {
            Speed = (UInt64)obj["Speed"];
            MaxSpeed = (UInt64)obj["MaxSpeed"];
            RequestedSpeed = (UInt64)obj["RequestedSpeed"];
            UsageRestriction = (UInt16)obj["UsageRestriction"];
            PortType = (UInt16)obj["PortType"];
            OtherPortType = (string)obj["OtherPortType"];
        }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: 単位 ("ビット/秒")、 PUnit ("bit/second")  <br/>
        /// ポートの帯域幅 (1 秒あたりのビット数)。
        /// </summary>
        public virtual UInt64 Speed { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: 単位 ("ビット/秒")、 PUnit ("bit/second")  <br/>
        /// ポートの最大帯域幅 (1 秒あたりのビット数)。
        /// </summary>
        public virtual UInt64 MaxSpeed { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスの種類: 読み取り/書き込み  <br/>
        /// 修飾子: 単位 ("ビット/秒")、 ModelCorrespondence ("CIM_LogicalPort。Speed")、 PUnit ("bit/second")  <br/>
        /// ポートの要求された帯域幅 (ビット/秒)。 実際の帯域幅は、 Speed プロパティで報告されます。
        /// </summary>
        public virtual UInt64 RequestedSpeed { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// ポートがフロントエンド ポートとバックエンド ポートのどちらに制限されているかを示します。  <br/>
        /// 不明 (0)  <br/>
        /// フロントエンドのみ (2)  <br/>
        /// バックエンドのみ (3)  <br/>
        /// 制限なし (4)
        /// </summary>
        public virtual UInt16 UsageRestriction { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: ModelCorrespondence ("CIM_NetworkPort。OtherNetworkPortType")  <br/>
        /// ポートの種類。  <br/>
        /// 不明 (0)  <br/>
        /// その他 (1)  <br/>
        /// 適用なし (2)  <br/>
        /// DMTF 予約済み (3..15999)  <br/>
        /// ベンダー予約済み (16000..65535)
        /// </summary>
        public virtual UInt16 PortType { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: ModelCorrespondence ("CIM_LogicalPort.PortType")  <br/>
        /// PortType が Other ("1") に設定されている場合のモジュールの種類について説明します。
        /// </summary>
        public virtual string OtherPortType { get; }
    };
}
