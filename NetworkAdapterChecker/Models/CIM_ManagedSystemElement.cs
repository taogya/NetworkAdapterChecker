using System;
using System.Management;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// CIM_ManagedSystemElement クラスは、システム要素階層の基底クラスです。 識別可能なシステム コンポーネントは、このクラスに含める候補です。 例としては、ファイルなどのソフトウェア コンポーネントが含まれます。ディスク ドライブやコントローラーなどのデバイス。チップやカードなどの物理コンポーネント。 <br />
    /// https://learn.microsoft.com/ja-jp/windows/win32/cimwin32prov/cim-managedsystemelement
    /// </summary>
    public class CIM_ManagedSystemElement
    {
        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: MaxLen(64)、 DisplayName("Caption") <br/>
        /// オブジェクトの短いテキスト説明。
        /// </summary>
        public virtual string Caption { get; }

        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: DisplayName("Description") <br/>
        /// オブジェクトのテキスト説明。
        /// </summary>
        public virtual string Description { get; }

        /// <summary>
        /// データ型: datetime <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: MappingStrings("MIF.DMTF|ComponentID|001.5"), DisplayName("インストール日") <br/>
        /// オブジェクトがインストールされたタイミングを示します。 値がない場合、オブジェクトがインストールされていないことを示すわけではありません。
        /// </summary>
        public virtual DateTime InstallDate { get; }

        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: DisplayName("Name") <br/>
        /// オブジェクトが認識されるラベル。 サブクラス化すると、このプロパティをキー プロパティとしてオーバーライドできます。
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: MaxLen (10)、 DisplayName ("Status") <br/>
        /// オブジェクトの現在の状態を示す文字列。 操作状態と非運用状態を定義できます。 運用状態には、"OK"、"機能低下"、"Pred Fail" を含めることができます。 "Pred Fail" は、要素が正しく機能しているが、エラー (SMART 対応ハード ディスク ドライブなど) を予測していることを示します。 <br/>
        /// 非運用状態には、"エラー"、"開始中"、"停止中"、および "サービス" が含まれる場合があります。 "サービス" は、ディスクミラー再チェックイン、ユーザーアクセス許可リストの再読み込み、またはその他の管理作業中に適用できます。 このような作業のすべてがオンラインであるわけではありませんが、マネージド要素は "OK" でも、他の状態の 1 つでもありません。 <br/>
        /// 次の値があります。 <br/>
        /// OK ("OK") <br/>
        /// エラー ("Error") <br/>
        /// 機能低下 ("Degraded") <br/>
        /// 不明 ("不明") <br/>
        /// Pred Fail ("Pred Fail") <br/>
        /// 開始 中 ("Starting") <br/>
        /// 停止 中 ("停止中") <br/>
        /// サービス ("Service") <br/>
        /// ストレス ( "ストレス") <br/>
        /// NonRecover ("NonRecover") <br/>
        /// 連絡先なし ("連絡先なし") <br/>
        /// Lost Comm ("Lost Comm")
        /// </summary>
        public virtual string Status { get; }


        public CIM_ManagedSystemElement(ManagementBaseObject obj)
        {
            Caption = (string)obj["Caption"];
            Description = (string)obj["Description"];
            InstallDate = (DateTime)obj["InstallDate"];
            Name = (string)obj["Name"];
            Status = (string)obj["Status"];
        }
    }
}
