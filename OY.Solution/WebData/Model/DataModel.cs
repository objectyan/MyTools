using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData.Model;

namespace WebDataTests.Model
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string AttrName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string AttrValue { get; set; }
        /// <summary>
        /// 标签类型
        /// </summary>
        public NodeType NodeType { get; set; }

        /// <summary>
        /// 获取值中的数据说明
        /// </summary>
        public string Title { get; set; }

        private bool? isIdentityTitle = null;

        /// <summary>
        /// 标题是否自动增长
        /// </summary>
        public bool IsIdentityTitle
        {
            get { return isIdentityTitle.HasValue ? isIdentityTitle.Value : false; }
            set { isIdentityTitle = value; }
        }

        /// <summary>
        /// 判断是否含下级标签是否
        /// </summary>
        public bool IsChildNode
        {
            get
            {
                return ChildInfo != null && ChildInfo.Count > 0;
            }
        }

        /// <summary>
        /// 标签深度 不能与AttrValue 和 AttrName同用 并且大于0
        /// </summary>
        public int TagDepth { get; set; }

        /// <summary>
        /// 下级
        /// </summary>
        public List<DataModel> ChildInfo { get; set; }
    }
}
