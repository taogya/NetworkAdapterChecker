using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Documents;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// CIM_ManagedSystemElement クラスは、システム要素階層の基底クラスです。 識別可能なシステム コンポーネントは、このクラスに含める候補です。 例としては、ファイルなどのソフトウェア コンポーネントが含まれます。ディスク ドライブやコントローラーなどのデバイス。チップやカードなどの物理コンポーネント。 <br />
    /// https://learn.microsoft.com/ja-jp/windows/win32/cimwin32prov/cim-managedsystemelement
    /// </summary>
    public class CIM_ManagedSystemElement : IEnumerable
    {
        const string DELIMITER = ", ";
        
        public CIM_ManagedSystemElement() { }

        public CIM_ManagedSystemElement(ManagementBaseObject obj)
        {
            Caption = GetValue<string>(obj, "Caption");
            Description = GetValue<string>(obj, "Description");
            InstallDate = GetValue<DateTime>(obj, "InstallDate");
            Name = GetValue<string>(obj, "Name");
            Status = GetValue<string>(obj, "Status");
        }

        /// <summary>
        /// ManagedObjectから値を取得する関数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public T? GetValue<T>(ManagementBaseObject obj, string key)
        {
            try
            {
                var ret = obj[key];
                return ret == null ? default : (T)ret;
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// foreachしたときに返す配列を取得する関数
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            List<KeyValuePair<string, object?>> ret = new();
            foreach (var obj in GetType().GetProperties().OrderBy((o) => o.Name))
            {
                var val = obj.GetValue(this);
                if (val != null && val.GetType().IsArray)
                {
                    if(val is int[] int_v)
                        val = string.Join(DELIMITER, int_v);
                    else if (val is uint[] uint_v)
                        val = string.Join(DELIMITER, uint_v);
                    else if (val is short[] short_v)
                        val = string.Join(DELIMITER, short_v);
                    else if (val is ushort[] ushort_v)
                        val = string.Join(DELIMITER, ushort_v);
                    else if (val is long[] long_v)
                        val = string.Join(DELIMITER, long_v);
                    else if (val is ulong[] ulong_v)
                        val = string.Join(DELIMITER, ulong_v);
                    else if (val is string[] string_v)
                        val = string.Join(DELIMITER, string_v);
                    else
                        val = string.Join(DELIMITER, val);
                }
                ret.Add(new(obj.Name, val));
            }
            return ret.GetEnumerator();
        }

        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: MaxLen(64)、 DisplayName("Caption") <br/>
        /// オブジェクトの短いテキスト説明。
        /// </summary>
        public virtual string? Caption { get; } = null;

        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: DisplayName("Description") <br/>
        /// オブジェクトのテキスト説明。
        /// </summary>
        public virtual string? Description { get; } = null;

        /// <summary>
        /// データ型: datetime <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: MappingStrings("MIF.DMTF|ComponentID|001.5"), DisplayName("インストール日") <br/>
        /// オブジェクトがインストールされたタイミングを示します。 値がない場合、オブジェクトがインストールされていないことを示すわけではありません。
        /// </summary>
        public virtual DateTime? InstallDate { get; } = null;

        /// <summary>
        /// データ型: string <br/>
        /// アクセスの種類: 読み取り専用 <br/>
        /// 修飾子: DisplayName("Name") <br/>
        /// オブジェクトが認識されるラベル。 サブクラス化すると、このプロパティをキー プロパティとしてオーバーライドできます。
        /// </summary>
        public virtual string? Name { get; } = null;

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
        public virtual string? Status { get; } = null;
    }
}
