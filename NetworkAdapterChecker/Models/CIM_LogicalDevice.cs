using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// CIM_LogicalDevice クラスは、物理ハードウェアで実現できるハードウェア エンティティを表します。 <br />
    /// https://learn.microsoft.com/ja-jp/windows/win32/cimwin32prov/cim-logicaldevice
    /// </summary>
    public class CIM_LogicalDevice : CIM_LogicalElement
    {
        public CIM_LogicalDevice(ManagementBaseObject obj) : base(obj) 
        {
            Availability = (UInt16)obj["Availability"];
            ConfigManagerErrorCode = (UInt32)obj["ConfigManagerErrorCode"];
            ConfigManagerUserConfig = (bool)obj["ConfigManagerUserConfig"];
            CreationClassName = (string)obj["CreationClassName"];
            DeviceID = (string)obj["DeviceID"];
            PowerManagementCapabilities = (UInt16[])obj["PowerManagementCapabilities"];
            ErrorCleared = (bool)obj["ErrorCleared"];
            ErrorDescription = (string)obj["ErrorDescription"];
            LastErrorCode = (UInt32)obj["LastErrorCode"];
            PNPDeviceID = (string)obj["PNPDeviceID"];
            PowerManagementSupported = (bool)obj["PowerManagementSupported"];
            StatusInfo = (UInt16)obj["StatusInfo"];
            SystemCreationClassName = (string)obj["SystemCreationClassName"];
            SystemName = (string)obj["SystemName"];
        }

        /// <summary>
        /// データ型: uint16 <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: MappingStrings ("MIF.DMTF|運用状態|003.5"、"MIB。IETF|HOST-RESOURCES-MIB.hrDeviceStatus") <br/>
        /// デバイスの可用性と状態。 <br/>
        /// その他 (1) <br/>
        /// 不明 (2) <br/>
        /// 実行中/完全電源 (3) <br/>
        /// 警告 (4) <br/>
        /// In Test (5) <br/>
        /// 該当なし (6) <br/>
        /// 電源オフ (7) <br/>
        /// Off Line (8) <br/>
        /// オフデューティ (9) <br/>
        /// 機能低下 (10) <br/>
        /// インストールされていません (11) <br/>
        /// インストール エラー (12) <br/>
        /// 省電力 - 不明 (13) <br/>
        /// デバイスは省電力モードであることが知られていますが、正確な状態は不明です。 <br/>
        /// 省電力 - 低電力モード (14) <br/>
        /// デバイスは省電力状態ですが、引き続き機能しており、パフォーマンスが低下する可能性があります。 <br/>
        /// 省電力 - スタンバイ (15) <br/>
        /// デバイスは機能していませんが、すぐに完全な電力を供給できる可能性があります。 <br/>
        /// 電源サイクル (16) <br/>
        /// 省電力 - 警告 (17) <br/>
        /// デバイスは警告状態ですが、省電力モードでもあります。 <br/>
        /// 一時停止 (18) <br/>
        /// デバイスが一時停止しています。 <br/>
        /// 準備ができていません (19)
        /// デバイスの準備ができていません。 <br/>
        /// 未構成 (20) <br/>
        /// デバイスが構成されていません。 <br/>
        /// 休止 ( 21) <br/>
        /// デバイスは静かです。
        /// </summary>
        public virtual UInt16 Availability { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: スキーマ ("Win32")  <br/>
        /// Win32 Configuration Managerエラー コード。  <br/>
        /// このデバイスは正常に動作しています。 (0)  <br/>
        /// このデバイスが正しく構成されていません。 (1)  <br/>
        /// Windows では、このデバイスのドライバーを読み込めません。 (2)  <br/>
        /// このデバイスのドライバーが破損しているか、システムがメモリやその他のリソースで不足している可能性があります。 (3)  <br/>
        /// このデバイスは正常に動作していません。 そのドライバーまたはレジストリの 1 つが破損している可能性があります。 (4)  <br/>
        /// このデバイスのドライバーには、Windows で管理できないリソースが必要です。 (5)  <br/>
        /// このデバイスのブート構成が他のデバイスと競合しています。 (6)  <br/>
        /// フィルター処理できません。 (7)  <br/>
        /// デバイスのドライバー ローダーがありません。 (8)  <br/>
        /// 制御ファームウェアがデバイスのリソースを誤って報告しているため、このデバイスが正しく動作していません。 (9)  <br/>
        /// このデバイスを起動できません。 (10)  <br/>
        /// このデバイスは失敗しました。 (11)  <br/>
        /// このデバイスは、使用できる十分な空きリソースを見つけることができません。 (12)  <br/>
        /// Windows では、このデバイスのリソースを確認できません。 (13)  <br/>
        /// コンピューターを再起動するまで、このデバイスは正常に動作しません。 (14)  <br/>
        /// 再列挙の問題が発生している可能性があるため、このデバイスは正常に動作していません。 (15)  <br/>
        /// Windows では、このデバイスが使用するすべてのリソースを識別できません。 (16)  <br/>
        /// このデバイスは、不明なリソースの種類を要求しています。 (17)  <br/>
        /// このデバイスのドライバーを再インストールします。 (18)  <br/>
        /// VxD ローダーを使用してエラーが発生しました。 (19)  <br/>
        /// レジストリが破損している可能性があります。 (20)  <br/>
        /// システム エラー: このデバイスのドライバーを変更してみてください。 問題が解決しない場合は、ハードウェアのドキュメントを参照してください。 Windows はこのデバイスを削除しています。 (21)  <br/>
        /// このデバイスは無効になっています。 (22)  <br/>
        /// システム エラー: このデバイスのドライバーを変更してみてください。 それでも問題が解決しない場合は、ハードウェアのドキュメントを参照してください。 (23)  <br/>
        /// このデバイスが存在しない、正しく動作していない、またはすべてのドライバーがインストールされていない。 (24)  <br/>
        /// Windows はこのデバイスを引き続き設定しています。 (25)  <br/>
        /// Windows はこのデバイスを引き続き設定しています。 (26)  <br/>
        /// このデバイスには有効なログ構成がありません。 (27)  <br/>
        /// このデバイスのドライバーはインストールされていません。 (28)  <br/>
        /// デバイスのファームウェアで必要なリソースが提供されていないため、このデバイスは無効になっています。 (29)  <br/>
        /// このデバイスは、別のデバイスが使用している割り込み要求 (IRQ) リソースを使用しています。 (30)  <br/>
        /// Windows はこのデバイスに必要なドライバーを読み込むことができないため、このデバイスが正しく動作していません。 (31)
        /// </summary>
        public virtual UInt32 ConfigManagerErrorCode { get; }

        /// <summary>
        /// データ型: boolean  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: スキーマ ("Win32")  <br/>
        /// TRUE の場合、デバイスはユーザー定義の構成を使用します。
        /// </summary>
        public virtual bool ConfigManagerUserConfig { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: CIM_Key  <br/>
        /// インスタンスの作成で使用されるクラスまたはサブクラスの名前。 クラスの他のキー プロパティと共に使用する場合、このプロパティを使用すると、クラスとそのサブクラスのすべてのインスタンスを一意に識別できます。
        /// </summary>
        public virtual string CreationClassName { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: CIM_Key  <br/>
        /// 論理デバイスに一意の名前を付けるアドレスまたはその他の識別情報。
        /// </summary>
        public virtual string DeviceID { get; }

        /// <summary>
        /// データ型: uint16 配列  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 論理デバイスの特定の電源関連機能を示します。  <br/>
        /// 不明 (0)  <br/>
        /// 電源関連の容量は不明です。  <br/>
        /// サポートされていません (1)  <br/>
        /// このデバイスでは、電源関連の容量はサポートされていません。  <br/>
        /// 無効 (2)  <br/>
        /// 電源関連の容量が無効になっています。  <br/>
        /// 有効 (3)  <br/>
        /// 電源管理機能は現在有効になっていますが、正確な機能セットが不明であるか、情報が使用できません。  <br/>
        /// 自動的に入力された省電力モード (4)  <br/>
        /// デバイスは、使用状況やその他の条件に基づいて電源状態を変更できます。  <br/>
        /// 電源状態設定可能 (5)  <br/>
        /// SetPowerState メソッドがサポートされています。 このメソッドは親 CIM_LogicalDevice クラスで見つかり、実装できます。 詳細については、「 マネージド オブジェクト形式 (MOF) クラスの設計」を参照してください。  <br/>
        /// 電源循環がサポートされています (6)  <br/>
        /// SetPowerState メソッドは、PowerState パラメーターを 5 ("Power Cycle") に設定して呼び出すことができます。  <br/>
        /// 時間指定の電源オンがサポートされています (7)  <br/>
        /// SetPowerState メソッドは、PowerState パラメーターを 5 ("Power Cycle") に設定し、Time パラメーターを特定の日付と時刻または間隔に設定して電源オンを行って呼び出すことができます。
        /// </summary>
        public virtual UInt16[] PowerManagementCapabilities { get; }

        /// <summary>
        /// データ型: boolean  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// TRUE の場合、LastErrorCode プロパティで報告されたエラーはクリアされます。
        /// </summary>
        public virtual bool ErrorCleared { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// LastErrorCode プロパティに記録されたエラーと実行する修正アクションに関する情報を提供する自由形式の文字列。
        /// </summary>
        public virtual string ErrorDescription { get; }

        /// <summary>
        /// データ型: uint32  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 論理デバイスによって報告された最後のエラー コード。
        /// </summary>
        public virtual UInt32 LastErrorCode { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: スキーマ ("Win32")  <br/>
        /// 論理デバイスの Win32 プラグ アンド プレイデバイス識別子を示します。  <br/>
        /// 例: "*PNP030b"
        /// </summary>
        public virtual string PNPDeviceID { get; }

        /// <summary>
        /// データ型: ブール値  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// TRUE の場合、デバイスを電源管理できます。つまり、省電力状態になります。 FALSE の場合、PowerManagementCapabilities 配列の唯一のエントリは整数値 1 ("サポートされていません") である必要があります。  <br/>
        /// このプロパティは、電源管理機能が現在有効になっているか、有効になっているか、どの機能がサポートされているかを示しません。 詳細については、「 PowerManagementCapabilities 配列」を参照してください。
        /// </summary>
        public virtual bool PowerManagementSupported { get; }

        /// <summary>
        /// データ型: uint16  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: MappingStrings ("MIF.DMTF|運用状態|003.3")  <br/>
        /// 論理デバイスの状態。 このプロパティが論理デバイスに適用されない場合は、値 5 ("Not Applicable") を使用する必要があります。  <br/>
        /// その他 (1)  <br/>
        /// 不明 (2)  <br/>
        /// 有効 (3)  <br/>
        /// 無効 (4)  <br/>
        /// 適用なし (5)
        /// </summary>
        public virtual UInt16 StatusInfo { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: 伝達 ( "CIM_System。CreationClassName") )、CIM_Key  <br/>
        /// スコープ システムの作成クラス名。
        /// </summary>
        public virtual string SystemCreationClassName { get; }

        /// <summary>
        /// データ型: string  <br/>
        /// アクセスの種類: 読み取り専用  <br/>
        /// 修飾子: 伝達 ( "CIM_System。Name") 、CIM_Key  <br/>
        /// スコープ システムの名前。
        /// </summary>
        public virtual string SystemName { get; }
    }
}
