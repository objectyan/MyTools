using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OY.Common.XML.Modle
{
    /// <summary>
    /// 字段定义信息
    /// </summary>
    public class XMLModle
    {
        #region 私有字段
        /// <summary>
        /// 属性名
        /// </summary>
        private string _name;

        /// <summary>
        /// 数据类型
        /// </summary>
        private string _dataType;

        /// <summary>
        /// 属性类型
        /// 1.类
        /// 2.属性字段
        /// </summary>
        private int _attrType;

        /// <summary>
        /// 说明信息
        /// </summary>
        private string _description;
       
        /// <summary>
        /// 特性说明
        /// </summary>
        private string _attrName;

        #endregion

        #region 属性字段
        
        /// <summary>
        /// 属性名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        /// <summary>
        /// 属性类型
        /// 1.类
        /// 2.属性字段
        /// </summary>
        public int AttrType
        {
            get { return _attrType; }
            set { _attrType = value; }
        }

        /// <summary>
        /// 说明信息
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// 特性说明
        /// </summary>
        public string AttrName
        {
            get { return _attrName; }
            set { _attrName = value; }
        }
        #endregion
    }


}
