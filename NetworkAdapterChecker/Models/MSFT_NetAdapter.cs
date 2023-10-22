using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// 論理ネットワークアダプター <br />
    /// https://learn.microsoft.com/ja-jp/previous-versions/windows/desktop/legacy/hh968170(v=vs.85)
    /// </summary>
    public class MSFT_NetAdapter : CIM_NetworkPort
    {
        public MSFT_NetAdapter(ManagementBaseObject obj) : base(obj) 
        {
            InterfaceDescription = (string)obj["InterfaceDescription"];
            InterfaceName = (string)obj["InterfaceName"];
            NetLuid = (UInt64)obj["NetLuid"];
            InterfaceGuid = (string)obj["InterfaceGuid"];
            InterfaceIndex = (UInt32)obj["InterfaceIndex"];
            DeviceName = (string)obj["DeviceName"];
            NetLuidIndex = (UInt32)obj["NetLuidIndex"];
            Virtual = (bool)obj["Virtual"];
            Hidden = (bool)obj["Hidden"];
            NotUserRemovable = (bool)obj["NotUserRemovable"];
            IMFilter = (bool)obj["IMFilter"];
            InterfaceType = (UInt32)obj["InterfaceType"];
            HardwareInterface = (bool)obj["HardwareInterface"];
            WdmInterface = (bool)obj["WdmInterface"];
            EndPointInterface = (bool)obj["EndPointInterface"];
            iSCSIInterface = (bool)obj["iSCSIInterface"];
            State = (UInt32)obj["State"];
            NdisMedium = (UInt32)obj["NdisMedium"];
            NdisPhysicalMedium = (UInt32)obj["NdisPhysicalMedium"];
            InterfaceOperationalStatus = (UInt32)obj["InterfaceOperationalStatus"];
            OperationalStatusDownDefaultPortNotAuthenticated = (bool)obj["OperationalStatusDownDefaultPortNotAuthenticated"];
            OperationalStatusDownMediaDisconnected = (bool)obj["OperationalStatusDownMediaDisconnected"];
            OperationalStatusDownInterfacePaused = (bool)obj["OperationalStatusDownInterfacePaused"];
            OperationalStatusDownLowPowerState = (bool)obj["OperationalStatusDownLowPowerState"];
            InterfaceAdminStatus = (UInt32)obj["InterfaceAdminStatus"];
            MediaConnectState = (UInt32)obj["MediaConnectState"];
            MtuSize = (UInt32)obj["MtuSize"];
            VlanID = (UInt16)obj["VlanID"];
            TransmitLinkSpeed = (UInt64)obj["TransmitLinkSpeed"];
            ReceiveLinkSpeed = (UInt64)obj["ReceiveLinkSpeed"];
            PromiscuousMode = (bool)obj["PromiscuousMode"];
            DeviceWakeUpEnable = (bool)obj["DeviceWakeUpEnable"];
            ConnectorPresent = (bool)obj["ConnectorPresent"];
            MediaDuplexState = (UInt32)obj["MediaDuplexState"];
            DriverDate = (string)obj["DriverDate"];
            DriverDateData = (UInt64)obj["DriverDateData"];
            DriverVersionString = (string)obj["DriverVersionString"];
            DriverName = (string)obj["DriverName"];
            DriverDescription = (string)obj["DriverDescription"];
            MajorDriverVersion = (UInt16)obj["MajorDriverVersion"];
            MinorDriverVersion = (UInt16)obj["MinorDriverVersion"];
            DriverMajorNdisVersion = (byte)obj["DriverMajorNdisVersion"];
            DriverMinorNdisVersion = (byte)obj["DriverMinorNdisVersion"];
            PnPDeviceID = (string)obj["PnPDeviceID"];
            DriverProvider = (string)obj["DriverProvider"];
            ComponentID = (string)obj["ComponentID"];
            LowerLayerInterfaceIndices = (UInt32[])obj["LowerLayerInterfaceIndices"];
            HigherLayerInterfaceIndices = (UInt32[])obj["HigherLayerInterfaceIndices"];
            AdminLocked = (bool)obj["AdminLocked"];
        }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 「ifDesc」または表示名とも呼ばれるインターフェイスの説明は、インストール中にネットワーク アダプターに割り当てられる一意の名前です。この名前は変更できず、ネットワーク アダプタがアンインストールされない限り保持されます。
        /// </summary>
        public string InterfaceDescription { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークインターフェースのローカルで一意な識別子。InterfaceType_NetluidIndex 形式で。例: イーサネット_2。
        /// </summary>
        public string InterfaceName { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 64 ビット数値としてのネットワーク インターフェイスのローカル一意識別子 (LUID)。
        /// </summary>
        public UInt64 NetLuid { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークインターフェイスのGUID。
        /// </summary>
        public string InterfaceGuid { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークインターフェースを識別するインデックス。このインデックス値は、ネットワーク アダプタが無効になってから有効になると変更される可能性があるため、永続的であると見なすべきではありません。
        /// </summary>
        public UInt32 InterfaceIndex { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// このアダプターのデバイス オブジェクトの名前。
        /// </summary>
        public string DeviceName { get; }

        /// <summary>
        /// /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// インストール時にネットワーク アダプターに割り当てられたインデックス。このインデックスはインターフェイス タイプの範囲内で一意です。
        /// </summary>
        public UInt32 NetLuidIndex { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは物理ネットワーク カードをエミュレートします。
        /// </summary>
        public bool Virtual { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは非表示になっており、どのユーザー インターフェイスにも表示されません。
        /// </summary>
        public bool Hidden { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ユーザーはネットワーク アダプターを削除できません。
        /// </summary>
        public bool NotUserRemovable { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは、中間フィルター コンポーネントのアダプター エッジです。
        /// </summary>
        public bool IMFilter { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// Internet Assigned Names Authority (IANA) によって定義されたインターフェイス タイプ。
        /// </summary>
        public UInt32 InterfaceType { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターのインターフェイスは、ハードウェア デバイスによって提供されます。
        /// </summary>
        public bool HardwareInterface { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプタの下位レベルのインターフェイスは、USB などの WDM バス ドライバです。
        /// </summary>
        public bool WdmInterface { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// このインターフェイスはエンドポイント デバイスであり、ネットワークに接続する真のネットワーク インターフェイスではありません。
        /// </summary>
        public bool EndPointInterface { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// このインターフェイスは iSCSI ソフトウェア イニシエータによって使用され、ページング パス内にあります。
        /// </summary>
        public bool iSCSIInterface { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターのプラグ アンド プレイの状態。  <br/>
        /// 不明(0)  <br/>
        /// プレゼント(1)  <br/>
        /// 始めました(2)  <br/>
        /// 無効(3)
        /// </summary>
        public UInt32 State { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターのメディアタイプ。  <br/>
        /// 802.3 (0)  <br/>
        /// 802.5 (1)  <br/>
        /// FDDI (2)  <br/>
        /// WAN (3)  <br/>
        /// ローカルトーク(4)  <br/>
        /// ディックス(5)  <br/>
        /// 生のアークネット(6)  <br/>
        /// 878.2 (7)  <br/>
        /// ATM (8)  <br/>
        /// ワイヤレスWAN (9)  <br/>
        /// イルダ(10)  <br/>
        /// BPC (11)  <br/>
        /// 接続指向の WAN (12)  <br/>
        /// IP 1394 (13)  <br/>
        /// IB (14)  <br/>
        /// トンネル(15)  <br/>
        /// ネイティブ 802.11 (16)  <br/>
        /// ループバック(17)  <br/>
        /// WiMAX (18)  <br/>
        /// 知財(19) 
        /// </summary>
        public UInt32 NdisMedium { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターがサポートする物理メディアの種類。  <br/>
        /// 未指定(0)  <br/>
        /// 無線LAN (1)  <br/>
        /// ケーブルモデム(2)  <br/>
        /// 電話回線(3)  <br/>
        /// 電力線(4)  <br/>
        /// DSL (5)  <br/>
        /// FC (6)  <br/>
        /// 1394 (7)  <br/>
        /// ワイヤレスWAN (8)  <br/>
        /// ネイティブ 802.11 (9)  <br/>
        /// ブルートゥース(10)  <br/>
        /// インフィニバンド(11)  <br/>
        /// WiMAX (12)  <br/>
        /// UWB (13)  <br/>
        /// 802.3 (14)  <br/>
        /// 802.5 (15)  <br/>
        /// イルダ(16)  <br/>
        /// 有線WAN (17)  <br/>
        /// 有線接続指向の WAN (18)  <br/>
        /// その他(19)
        /// </summary>
        public UInt32 NdisPhysicalMedium { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 現在のネットワーク インターフェイスの動作ステータス。  <br/>
        /// 上(1)  <br/>
        /// ダウン(2)  <br/>
        /// テスト(3)  <br/>
        /// 不明(4)  <br/>
        /// 休眠中(5)  <br/>
        /// 存在しません(6)  <br/>
        /// 下層ダウン(7)
        /// </summary>
        public UInt32 InterfaceOperationalStatus { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターのデフォルトポートは認証されていません。
        /// </summary>
        public bool OperationalStatusDownDefaultPortNotAuthenticated { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターはメディア接続状態ではありません。
        /// </summary>
        public bool OperationalStatusDownMediaDisconnected { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは一時停止状態です。
        /// </summary>
        public bool OperationalStatusDownInterfacePaused { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは低電力状態です。
        /// </summary>
        public bool OperationalStatusDownLowPowerState { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// RFC 2863 に記載されているネットワーク アダプターの管理ステータス。  <br/>
        /// 上(1)  <br/>
        /// ダウン(2)  <br/>
        /// テスト(3)
        /// </summary>
        public UInt32 InterfaceAdminStatus { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターの接続状態を指定します。  <br/>
        /// 不明(0)  <br/>
        /// 接続済み(1)  <br/>
        /// 切断されました(2)
        /// </summary>
        public UInt32 MediaConnectState { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターがサポートする最大転送単位 (MTU) サイズ。この値には、リンク層ヘッダーのサイズは含まれません。
        /// </summary>
        public UInt32 MtuSize { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスタイプ: 読み取り/書き込み  <br/>
        /// ネットワーク アダプタに設定された仮想 LAN 識別子。
        /// </summary>
        public UInt16 VlanID { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ビット/秒単位の送信リンク速度。
        /// </summary>
        public UInt64 TransmitLinkSpeed { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 受信リンク速度 (ビット/秒)。
        /// </summary>
        public UInt64 ReceiveLinkSpeed { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// インターフェイスが無差別モードの場合は TRUE、そうでない場合は FALSE。
        /// </summary>
        public bool PromiscuousMode { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターが Wake-on-LAN 機能をサポートしており、その機能が有効になっている場合は TRUE、有効になっていない場合は FALSE。
        /// </summary>
        public bool DeviceWakeUpEnable { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターにコネクタが存在するかどうかを示します。この値は、これが物理アダプターの場合は TRUE に設定され、物理アダプターではない場合は FALSE に設定されます。
        /// </summary>
        public bool ConnectorPresent { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターのメディア二重状態。
        /// </summary>
        public UInt32 MediaDuplexState { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// YYYY-MM-DD 形式のネットワーク アダプター ドライバーの日付。
        /// </summary>
        public string DriverDate { get; }

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// FILETIME 形式のネットワーク アダプター ドライバーの日付。これは、1601 年 1 月 1 日 (UTC) からの 100 ナノ秒間隔の数を表す 64 ビット値です。
        /// </summary>
        public UInt64 DriverDateData { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーのバージョンを表す文字列。
        /// </summary>
        public string DriverVersionString { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプタードライバーの名前。
        /// </summary>
        public string DriverName { get; }

        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプタードライバーの説明。
        public string DriverDescription { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーのメジャー バージョン。
        /// </summary>
        public UInt16 MajorDriverVersion { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーのマイナー バージョン。
        /// </summary>
        public UInt16 MinorDriverVersion { get; }

        /// <summary>
        /// データ型: uint8  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーが準拠する NDIS のメジャー バージョン。
        /// </summary>
        public byte DriverMajorNdisVersion { get; }

        /// <summary>
        /// データ型: uint8  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーが準拠する NDIS のマイナー バージョン。
        /// </summary>
        public byte DriverMinorNdisVersion { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// プラグ アンド プレイ デバイス ID。
        /// </summary>
        public string PnPDeviceID { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ドライバープロバイダー名。
        /// </summary>
        public string DriverProvider { get; }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// PnP コンポーネント ID。ネットワーク アダプターのハードウェア ID とも呼ばれます。
        /// </summary>
        public string ComponentID { get; }

        /// <summary>
        /// データ型: uint32配列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 下位層インターフェイスのインターフェイス インデックス。
        /// </summary>
        public UInt32[] LowerLayerInterfaceIndices { get; }

        /// <summary>
        /// データ型: uint32配列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 上位層インターフェイスのインターフェイス インデックス。
        /// </summary>
        public UInt32[] HigherLayerInterfaceIndices { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターの管理状態。True の場合、ネットワーク アダプターはロックされており、アダプターのロックが解除されない限り、そのプロパティの多くは変更できません。
        /// </summary>
        public bool AdminLocked { get; }
    }
}
