using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Model
{
    /// <summary>
    /// 标签类型
    /// </summary>
    public enum NodeType
    {
        [Description("Div")]
        Div = 1,
        [Description("Img")]
        Img = 2,
        [Description("H1")]
        H1 = 4,
        [Description("P")]
        P = 8,
        [Description("A")]
        A = 16
    }
}
