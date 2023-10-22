using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// ネットワーク デバイス上のネットワーク ポートの論理表現。 <br/>
    /// https://learn.microsoft.com/ja-jp/windows/win32/hyperv_v2/cim-networkport
    /// </summary>
    public class CIM_NetworkPort : CIM_LogicalPort
    {
        public CIM_NetworkPort(ManagementBaseObject obj) : base(obj) 
        {
            Speed = (UInt64)obj["Speed"];
#pragma warning disable CS0618 // 型またはメンバーが旧型式です
            OtherNetworkPortType = (string)obj["OtherNetworkPortType"];
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
            PortNumber = (UInt16)obj["PortNumber"];
            LinkTechnology = (UInt16)obj["LinkTechnology"];
            OtherLinkTechnology = (string)obj["OtherLinkTechnology"];
            PermanentAddress = (string)obj["PermanentAddress"];
            NetworkAddresses = (string[])obj["NetworkAddresses"];
            FullDuplex = (bool)obj["FullDuplex"];
            AutoSense = (bool)obj["AutoSense"];
            SupportedMaximumTransmissionUnit = (UInt64)obj["SupportedMaximumTransmissionUnit"];
            ActiveMaximumTransmissionUnit = (UInt64)obj["ActiveMaximumTransmissionUnit"];
        }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: オーバーライド ("Speed")、 単位 ("ビット/秒")、 MappingStrings ("MIB。IETF|MIB-II.ifSpeed", "MIF.DMTF|ネットワーク アダプター 802 ポート|001.5")、 PUnit ("bit/second")  <br/>
        /// ポートの現在の帯域幅 (ビット/秒)。 帯域幅が異なるポートの場合、または正確な推定ができないポートの場合、このプロパティには呼び出し帯域幅を含める必要があります。
        /// </summary>
        public override UInt64 Speed { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: 非推奨 ("CIM_NetworkPort。OtherPortType") 、ModelCorrespondence ("CIM_LogicalPort。PortType")  <br/>
        ///  注意  <br/>
        /// 非推奨の説明: PortType プロパティに 1 (その他) が含まれている場合のポートのモジュールの種類。  <br/>
        /// このプロパティの使用は非推奨とされます。 代わりに、CIM_LogicalPort クラスの PortType プロパティをお勧めします。
        /// </summary>
        [Obsolete("Use of this property is deprecated. We recommend \"PortType\" property instead.")]
        public virtual string OtherNetworkPortType { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// ネットワーク ポートのポート番号。 ネットワーク ポートは、多くの場合、論理モジュールまたはネットワーク要素に対して相対的に番号が付けられます。
        /// </summary>
        public virtual UInt16 PortNumber { get; }

        /// データ型: uint16  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: ModelCorrespondence ("CIM_NetworkPort。OtherLinkTechnology")  <br/>
        /// ポートで使用されるリンク テクノロジ。 "1" (other) に設定すると、 OtherLinkTechnology プロパティにはリンクの種類の説明が含まれます。  <br/>
        /// 不明 (0)  <br/>
        /// その他 (1)  <br/>
        /// イーサネット (2)  <br/>
        /// IB (3)  <br/>
        /// FC (4)  <br/>
        /// FDDI (5)  <br/>
        /// ATM (6)  <br/>
        /// トークン リング (7)  <br/>
        /// フレーム リレー (8)  <br/>
        /// 赤外線 (9)  <br/>
        /// BlueTooth (10)  <br/>
        /// ワイヤレス LAN (11)
        public virtual UInt16 LinkTechnology { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: ModelCorrespondence ("CIM_NetworkPort。LinkTechnology")  <br/>
        /// LinkTechnology が "1" (その他) に設定されている場合のリンク テクノロジ。
        /// </summary>
        public virtual string OtherLinkTechnology { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: MaxLen (64)、 MappingStrings ("MIF。DMTF|ネットワーク アダプター 802 ポート|001.2")  <br/>
        /// ポートにハードコーディングされたネットワーク アドレス。 ハードコーディングされたアドレスは、ファームウェアのアップグレードまたはソフトウェア構成を使用して変更できます。 この変更が行われると、このプロパティを同時に更新する必要があります。 アドレスが存在しない場合は、PermanentAddress を空白のままにする必要があります。
        /// </summary>
        public virtual string PermanentAddress { get; }

        /// <summary>
        /// データ型: 文字列 配列  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: MaxLen (64)、 MappingStrings ("MIF。DMTF|ネットワーク アダプター 802 ポート|001.3")  <br/>
        /// ポートのネットワーク アドレスを含む配列。
        /// </summary>
        public virtual string[] NetworkAddresses { get; }

        /// <summary>
        /// データ型: boolean  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// ポート が全二重モードで動作している場合は true。それ以外の場合は false。
        /// </summary>
        public virtual bool FullDuplex { get; }

        /// <summary>
        /// データ型: boolean  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// ポート が接続されているネットワーク メディアの速度またはその他の通信特性を自動的に決定できる場合は true。それ以外の場合は false。 
        /// </summary>
        public virtual bool AutoSense { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: Units ("Bytes")、 PUnit ("byte")  <br/>
        /// ポートでサポートされる最大伝送ユニット (MTU)。
        /// </summary>
        public virtual UInt64 SupportedMaximumTransmissionUnit { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: Units ("Bytes")、 PUnit ("byte")  <br/>
        /// ポートでサポートされているアクティブまたはネゴシエートされた最大伝送ユニット (MTU)。 
        /// </summary>
        public virtual UInt64 ActiveMaximumTransmissionUnit { get; }
    }
}
