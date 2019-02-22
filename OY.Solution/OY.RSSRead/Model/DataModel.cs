using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OY.RSSRead.Model
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// 数据状态
        /// </summary>
        private int _status;

        /// <summary>
        /// 数据状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        private string _info;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        /// <summary>
        /// 数据结果
        /// </summary>
        private object _data;

        /// <summary>
        /// 数据结果
        /// </summary>
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// 数据总条数
        /// </summary>
        private int _iRowCount;

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int IRowCount
        {
            get { return _iRowCount; }
            set { _iRowCount = value; }
        }

        /// <summary>
        /// 第几页
        /// </summary>
        private int _pageIndex;

        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        /// <summary>
        /// 每页个数
        /// </summary>
        private int _pageSize;

        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 每页显示的开始数
        /// </summary>
        private int _pageBeg;

        /// <summary>
        /// 每页显示的开始数
        /// </summary>
        public int PageBeg
        {
            get { return _pageBeg; }
            set { _pageBeg = value; }
        }

        /// <summary>
        /// 每页显示的结束数
        /// </summary>
        private int _pageEnd;

        /// <summary>
        /// 每页显示的结束数
        /// </summary>
        public int PageEnd
        {
            get { return _pageEnd; }
            set { _pageEnd = value; }
        }
    }


}
