using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OY.Common.Model
{
    /// <summary>
    /// 类文件信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
    [ComVisible(true)]
    public class ClassInfoAttribute : Attribute
    {
        protected string _className;
        protected string _author;
        protected string _remark;
        /// <summary>
        /// 类文件特性
        /// </summary>
        /// <param name="ClassName">类名</param>
        /// <param name="Author">作者</param>
        /// <param name="Remark">备注</param>
        public ClassInfoAttribute(string ClassName, string Author, string Remark)
        {
            _className = ClassName;
            _author = Author;
            _remark = Remark;
        }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }

    /// <summary>
    /// 类属性信息
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ClassPropertyInfoAttribute : Attribute
    {
        protected string _propertyName;
        protected bool _isSerializable;
        /// <summary>
        /// 类属性特性
        /// </summary>
        /// <param name="PropertyName">属性名称</param>
        /// <param name="IsSerializable">属性是否支持序列号</param>
        public ClassPropertyInfoAttribute(string PropertyName, bool IsSerializable)
        {
            _propertyName = PropertyName;
            _isSerializable = IsSerializable;
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        /// <summary>
        /// 属性是否支持序列号
        /// </summary>
        public bool IsSerializable
        {
            get { return _isSerializable; }
            set { _isSerializable = value; }
        }
    }

    /// <summary>
    /// 类属性信息
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ClassTablePropertyAttribute : Attribute
    {
        /// <summary>
        /// 显示名
        /// </summary>
        private string _propertyPName;
        /// <summary>
        /// 显示名
        /// </summary>
        public string PropertyPName
        {
            get { return _propertyPName; }
            set { _propertyPName = value; }
        }
        /// <summary>
        /// 列名
        /// </summary>
        private string _propertyTName;
        /// <summary>
        /// 列名
        /// </summary>
        public string PropertyTName
        {
            get { return _propertyTName; }
            set { _propertyTName = value; }
        }
        /// <summary>
        /// 是否序列化
        /// </summary>
        private bool _isSerializable;
        /// <summary>
        /// 是否序列化
        /// </summary>
        public bool IsSerializable
        {
            get { return _isSerializable; }
            set { _isSerializable = value; }
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        private string _dataType;
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }
        /// <summary>
        /// 数据长度
        /// </summary>
        private int _length;
        /// <summary>
        /// 数据长度
        /// </summary>
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        /// <summary>
        /// 数据精度
        /// </summary>
        private int _precision;
        /// <summary>
        /// 数据精度
        /// </summary>
        public int Precision
        {
            get { return _precision; }
            set { _precision = value; }
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        private bool _isnull;
        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsNull
        {
            get { return _isnull; }
            set { _isnull = value; }
        }
        /// <summary>
        /// 类属性特性
        /// </summary>
        /// <param name="PropertyName">显示名</param>
        /// <param name="PropertyTName">列名</param> 
        /// <param name="IsSerializable">属性是否支持序列号</param>
        /// <param name="DataType">数据类型</param>
        /// <param name="Length">数据长度</param>
        /// <param name="Precision">数据精度</param>
        public ClassTablePropertyAttribute(string PropertyPName, string PropertyTName, bool IsSerializable = true, bool IsNull = false,
          string DataType = "nvarchar", int Length = 100, int Precision = 0)
        {
            this._dataType = DataType;
            this._isSerializable = IsSerializable;
            this._length = Length;
            this._precision = Precision;
            this._propertyPName = PropertyPName;
            this._propertyTName = PropertyTName;
        }

    }
}
