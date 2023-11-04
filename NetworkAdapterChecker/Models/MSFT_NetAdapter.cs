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
        public MSFT_NetAdapter() { }
        public MSFT_NetAdapter(ManagementBaseObject obj) : base(obj) 
        {
            InterfaceDescription = GetValue<string>(obj, "InterfaceDescription");
            InterfaceName = GetValue<string>(obj, "InterfaceName");
            NetLuid = GetValue<ulong>(obj, "NetLuid");
            InterfaceGuid = GetValue<string>(obj, "InterfaceGuid");
            InterfaceIndex = GetValue<uint>(obj, "InterfaceIndex");
            DeviceName = GetValue<string>(obj, "DeviceName");
            NetLuidIndex = GetValue<uint>(obj, "NetLuidIndex");
            Virtual = GetValue<bool>(obj, "Virtual");
            Hidden = GetValue<bool>(obj, "Hidden");
            NotUserRemovable = GetValue<bool>(obj, "NotUserRemovable");
            IMFilter = GetValue<bool>(obj, "IMFilter");
            InterfaceType = (uint)obj["InterfaceType"];
            HardwareInterface = GetValue<bool>(obj, "HardwareInterface");
            WdmInterface = GetValue<bool>(obj, "WdmInterface");
            EndPointInterface = GetValue<bool>(obj, "EndPointInterface");
            iSCSIInterface = GetValue<bool>(obj, "iSCSIInterface");
            State = GetValue<uint>(obj, "State");
            NdisMedium = GetValue<uint>(obj, "NdisMedium");
            NdisPhysicalMedium = GetValue<uint>(obj, "NdisPhysicalMedium");
            InterfaceOperationalStatus = GetValue<uint>(obj, "InterfaceOperationalStatus");
            OperationalStatusDownDefaultPortNotAuthenticated = GetValue<bool>(obj, "OperationalStatusDownDefaultPortNotAuthenticated");
            OperationalStatusDownMediaDisconnected = GetValue<bool>(obj, "OperationalStatusDownMediaDisconnected");
            OperationalStatusDownInterfacePaused = GetValue<bool>(obj, "OperationalStatusDownInterfacePaused");
            OperationalStatusDownLowPowerState = GetValue<bool>(obj, "OperationalStatusDownLowPowerState");
            InterfaceAdminStatus = GetValue<uint>(obj, "InterfaceAdminStatus");
            MediaConnectState = GetValue<uint>(obj, "MediaConnectState");
            MtuSize = GetValue<uint>(obj, "MtuSize");
            VlanID = GetValue<ushort>(obj, "VlanID");
            TransmitLinkSpeed = GetValue<ulong>(obj, "TransmitLinkSpeed");
            ReceiveLinkSpeed = GetValue<ulong>(obj, "ReceiveLinkSpeed");
            PromiscuousMode = GetValue<bool>(obj, "PromiscuousMode");
            DeviceWakeUpEnable = GetValue<bool>(obj, "DeviceWakeUpEnable");
            ConnectorPresent = GetValue<bool>(obj, "ConnectorPresent");
            MediaDuplexState = GetValue<uint>(obj, "MediaDuplexState");
            DriverDate = GetValue<string>(obj, "DriverDate");
            DriverDateData = GetValue<ulong>(obj, "DriverDateData");
            DriverVersionString = GetValue<string>(obj, "DriverVersionString");
            DriverName = GetValue<string>(obj, "DriverName");
            DriverDescription = GetValue<string>(obj, "DriverDescription");
            MajorDriverVersion = GetValue<ushort>(obj, "MajorDriverVersion");
            MinorDriverVersion = GetValue<ushort>(obj, "MinorDriverVersion");
            DriverMajorNdisVersion = GetValue<byte>(obj, "DriverMajorNdisVersion");
            DriverMinorNdisVersion = GetValue<byte>(obj, "DriverMinorNdisVersion");
            PnPDeviceID = GetValue<string>(obj, "PnPDeviceID");
            DriverProvider = GetValue<string>(obj, "DriverProvider");
            ComponentID = GetValue<string>(obj, "ComponentID");
            LowerLayerInterfaceIndices = GetValue<uint[]>(obj, "LowerLayerInterfaceIndices");
            HigherLayerInterfaceIndices = GetValue<uint[]>(obj, "HigherLayerInterfaceIndices");
            AdminLocked = GetValue<bool>(obj, "AdminLocked");
        }

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 「ifDesc」または表示名とも呼ばれるインターフェイスの説明は、インストール中にネットワーク アダプターに割り当てられる一意の名前です。この名前は変更できず、ネットワーク アダプタがアンインストールされない限り保持されます。
        /// </summary>
        public string? InterfaceDescription { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークインターフェースのローカルで一意な識別子。InterfaceType_NetluidIndex 形式で。例: イーサネット_2。
        /// </summary>
        public string? InterfaceName { get; } = null;

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 64 ビット数値としてのネットワーク インターフェイスのローカル一意識別子 (LUID)。
        /// </summary>
        public ulong? NetLuid { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークインターフェイスのGUID。
        /// </summary>
        public string? InterfaceGuid { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークインターフェースを識別するインデックス。このインデックス値は、ネットワーク アダプタが無効になってから有効になると変更される可能性があるため、永続的であると見なすべきではありません。
        /// </summary>
        public uint? InterfaceIndex { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// このアダプターのデバイス オブジェクトの名前。
        /// </summary>
        public string? DeviceName { get; } = null;

        /// <summary>
        /// /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// インストール時にネットワーク アダプターに割り当てられたインデックス。このインデックスはインターフェイス タイプの範囲内で一意です。
        /// </summary>
        public uint? NetLuidIndex { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは物理ネットワーク カードをエミュレートします。
        /// </summary>
        public bool? Virtual { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは非表示になっており、どのユーザー インターフェイスにも表示されません。
        /// </summary>
        public bool? Hidden { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ユーザーはネットワーク アダプターを削除できません。
        /// </summary>
        public bool? NotUserRemovable { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは、中間フィルター コンポーネントのアダプター エッジです。
        /// </summary>
        public bool? IMFilter { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// Internet Assigned Names Authority (IANA) によって定義されたインターフェイス タイプ。
        /// </summary>
        public uint? InterfaceType { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターのインターフェイスは、ハードウェア デバイスによって提供されます。
        /// </summary>
        public bool? HardwareInterface { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプタの下位レベルのインターフェイスは、USB などの WDM バス ドライバです。
        /// </summary>
        public bool? WdmInterface { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// このインターフェイスはエンドポイント デバイスであり、ネットワークに接続する真のネットワーク インターフェイスではありません。
        /// </summary>
        public bool? EndPointInterface { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// このインターフェイスは iSCSI ソフトウェア イニシエータによって使用され、ページング パス内にあります。
        /// </summary>
        public bool? iSCSIInterface { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターのプラグ アンド プレイの状態。  <br/>
        /// 不明(0)  <br/>
        /// プレゼント(1)  <br/>
        /// 始めました(2)  <br/>
        /// 無効(3)
        /// </summary>
        public uint? State { get; } = null;

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
        public uint? NdisMedium { get; } = null;

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
        public uint? NdisPhysicalMedium { get; } = null;

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
        public uint? InterfaceOperationalStatus { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターのデフォルトポートは認証されていません。
        /// </summary>
        public bool? OperationalStatusDownDefaultPortNotAuthenticated { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターはメディア接続状態ではありません。
        /// </summary>
        public bool? OperationalStatusDownMediaDisconnected { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは一時停止状態です。
        /// </summary>
        public bool? OperationalStatusDownInterfacePaused { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターは低電力状態です。
        /// </summary>
        public bool? OperationalStatusDownLowPowerState { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// RFC 2863 に記載されているネットワーク アダプターの管理ステータス。  <br/>
        /// 上(1)  <br/>
        /// ダウン(2)  <br/>
        /// テスト(3)
        /// </summary>
        public uint? InterfaceAdminStatus { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターの接続状態を指定します。  <br/>
        /// 不明(0)  <br/>
        /// 接続済み(1)  <br/>
        /// 切断されました(2)
        /// </summary>
        public uint? MediaConnectState { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターがサポートする最大転送単位 (MTU) サイズ。この値には、リンク層ヘッダーのサイズは含まれません。
        /// </summary>
        public uint? MtuSize { get; } = null;

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスタイプ: 読み取り/書き込み  <br/>
        /// ネットワーク アダプタに設定された仮想 LAN 識別子。
        /// </summary>
        public ushort? VlanID { get; } = null;

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ビット/秒単位の送信リンク速度。
        /// </summary>
        public ulong? TransmitLinkSpeed { get; } = null;

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 受信リンク速度 (ビット/秒)。
        /// </summary>
        public ulong? ReceiveLinkSpeed { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// インターフェイスが無差別モードの場合は TRUE、そうでない場合は FALSE。
        /// </summary>
        public bool? PromiscuousMode { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターが Wake-on-LAN 機能をサポートしており、その機能が有効になっている場合は TRUE、有効になっていない場合は FALSE。
        /// </summary>
        public bool? DeviceWakeUpEnable { get; } = null;

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプターにコネクタが存在するかどうかを示します。この値は、これが物理アダプターの場合は TRUE に設定され、物理アダプターではない場合は FALSE に設定されます。
        /// </summary>
        public bool? ConnectorPresent { get; } = null;

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターのメディア二重状態。
        /// </summary>
        public uint? MediaDuplexState { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// YYYY-MM-DD 形式のネットワーク アダプター ドライバーの日付。
        /// </summary>
        public string? DriverDate { get; } = null;

        /// <summary>
        /// データ型: uint64  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// FILETIME 形式のネットワーク アダプター ドライバーの日付。これは、1601 年 1 月 1 日 (UTC) からの 100 ナノ秒間隔の数を表す 64 ビット値です。
        /// </summary>
        public ulong? DriverDateData { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーのバージョンを表す文字列。
        /// </summary>
        public string? DriverVersionString { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプタードライバーの名前。
        /// </summary>
        public string? DriverName { get; } = null;

        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプタードライバーの説明。
        public string? DriverDescription { get; } = null;

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーのメジャー バージョン。
        /// </summary>
        public ushort? MajorDriverVersion { get; } = null;

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーのマイナー バージョン。
        /// </summary>
        public ushort? MinorDriverVersion { get; } = null;

        /// <summary>
        /// データ型: uint8  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーが準拠する NDIS のメジャー バージョン。
        /// </summary>
        public byte? DriverMajorNdisVersion { get; } = null;

        /// <summary>
        /// データ型: uint8  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワーク アダプター ドライバーが準拠する NDIS のマイナー バージョン。
        /// </summary>
        public byte? DriverMinorNdisVersion { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// プラグ アンド プレイ デバイス ID。
        /// </summary>
        public string? PnPDeviceID { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ドライバープロバイダー名。
        /// </summary>
        public string? DriverProvider { get; } = null;

        /// <summary>
        /// データ型:文字列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// PnP コンポーネント ID。ネットワーク アダプターのハードウェア ID とも呼ばれます。
        /// </summary>
        public string? ComponentID { get; } = null;

        /// <summary>
        /// データ型: uint32配列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 下位層インターフェイスのインターフェイス インデックス。
        /// </summary>
        public uint[]? LowerLayerInterfaceIndices { get; }

        /// <summary>
        /// データ型: uint32配列  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// 上位層インターフェイスのインターフェイス インデックス。
        /// </summary>
        public uint[]? HigherLayerInterfaceIndices { get; }

        /// <summary>
        /// データ型:ブール値  <br/>
        /// アクセスタイプ: 読み取り専用  <br/>
        /// ネットワークアダプターの管理状態。True の場合、ネットワーク アダプターはロックされており、アダプターのロックが解除されない限り、そのプロパティの多くは変更できません。
        /// </summary>
        public bool? AdminLocked { get; } = null;
    }
}
