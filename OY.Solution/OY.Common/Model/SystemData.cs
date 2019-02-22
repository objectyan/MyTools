using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OY.Common.Model
{
    /// <summary>
    /// 数据传输协议
    /// </summary>
    public class ReturnDataModel
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        private bool _status;
        /// <summary>
        /// 返回状态
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        private object _data;
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }
        /// <summary>
        /// 返回信息
        /// </summary>
        private string _msg;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }

}
