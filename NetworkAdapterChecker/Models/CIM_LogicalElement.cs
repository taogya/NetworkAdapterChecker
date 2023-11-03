using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.Models
{
    /// <summary>
    /// CIM_LogicalElement クラスは、プロファイル、プロセス、システム機能などの抽象システム コンポーネントを論理デバイスの形式で表すすべてのシステム コンポーネントの基本クラスです。 <br />
    /// https://learn.microsoft.com/ja-jp/windows/win32/cimwin32prov/cim-logicalelement
    /// </summary>
    public class CIM_LogicalElement : CIM_ManagedSystemElement
    {
        public CIM_LogicalElement() { }
        public CIM_LogicalElement(ManagementBaseObject obj) : base(obj) { }
    }
}
