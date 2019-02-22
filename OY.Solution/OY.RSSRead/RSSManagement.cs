using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OY.RSSRead.Interface;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace OY.RSSRead
{
    public class RSSManagement : IRSSManagement
    {

        /// <summary>
        /// 临时文件路劲
        /// </summary>
        private string _path;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RSSManagement()
        {
            _path = Assembly.GetExecutingAssembly().Location + "data.dat";
            //_path = this.GetType().Assembly.Location;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RSSManagement(string path)
        {
            _path = path;
        }

        /// <summary>
        /// 读取RSS地址
        /// </summary>
        /// <param name="IsList">是否返回单个还是集合</param>
        /// <returns>返回数据</returns>
        public Model.DataModel GetReadRSSAddress(bool IsList = false, int pageSize = 10, int pageIndex = 0)
        {
            Model.DataModel dm = new Model.DataModel();
            try
            {
                dm.Status = 1;
                return dm;
            }
            catch (Exception ex)
            {
                dm.Info = ex.StackTrace + "\r\n" + ex.Message;
                dm.Status = 0;
                return dm;
            }
        }

        /// <summary>
        /// 操作RSS地址 —— 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Model.DataModel SetReadRSSAddressInsert(Model.RSSAddress item)
        {
            Model.DataModel dm = new Model.DataModel();
            try
            {
                List<Model.RSSAddress> ls = new List<Model.RSSAddress>();
                FileStream stream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Model.RSSAddress>));//字符串
                BinaryFormatter bf = new BinaryFormatter();//二进制
                if (stream.Length > 0)
                {
                    ls = bf.Deserialize(stream) as List<Model.RSSAddress>;//二进制
                    //ls = xmlSerializer.Deserialize(stream) as List<Model.RSSAddress>;//字符串
                }
                ls.Add(item);
                //xmlSerializer.Serialize(stream, ls);//字符串
                bf.Serialize(stream, ls);//二进制
                stream.Close();
                dm.Status = 1;
                return dm;
            }
            catch (Exception ex)
            {
                dm.Info = ex.StackTrace + "\r\n" + ex.Message;
                dm.Status = 0;
                return dm;
            }
        }

        /// <summary>
        /// 操作RSS地址 —— 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Model.DataModel SetReadRSSAddressUpdate(Model.RSSAddress item)
        {
            Model.DataModel dm = new Model.DataModel();
            try
            {
                List<Model.RSSAddress> ls = new List<Model.RSSAddress>();
                FileStream stream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Model.RSSAddress>));//字符串
                //BinaryFormatter bf = new BinaryFormatter();//二进制
                if (stream.Length > 0)
                {
                    //ls = bf.Deserialize(stream) as List<Model.RSSAddress>;//二进制
                    ls = xmlSerializer.Deserialize(stream) as List<Model.RSSAddress>;//字符串
                    Model.RSSAddress ra = ls.SingleOrDefault(x => x.No.Equals(item.No));
                    if (ra != null)
                    {
                        ls.Remove(ra);
                    }
                    stream.SetLength(0);
                }
                for (int i = 0; i < 1000000000; i++)
                {
                    item.No = "No" + i;
                    ls.Add(item);
                }
                xmlSerializer.Serialize(stream, ls);//字符串
                //bf.Serialize(stream, ls);//二进制
                stream.Close();
                dm.Status = 1;
                return dm;
            }
            catch (Exception ex)
            {
                dm.Info = ex.StackTrace + "\r\n" + ex.Message;
                dm.Status = 0;
                return dm;
            }
        }

        /// <summary>
        /// 操作RSS地址 —— 删除
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Model.DataModel SetReadRSSAddressDelete(Model.RSSAddress item)
        {
            Model.DataModel dm = new Model.DataModel();
            try
            {
                dm.Status = 1;
                return dm;
            }
            catch (Exception ex)
            {
                dm.Info = ex.StackTrace + "\r\n" + ex.Message;
                dm.Status = 0;
                return dm;
            }
        }

        /// <summary>
        /// 获取对应的RSS信息
        /// </summary>
        /// <param name="RSSAddress"></param>
        /// <returns></returns>
        public Model.DataModel GetReadRSSInfo(List<Model.RSSAddress> itemInfo)
        {
            Model.DataModel dm = new Model.DataModel();
            try
            {
                dm.Status = 1;
                return dm;
            }
            catch (Exception ex)
            {
                dm.Info = ex.StackTrace + "\r\n" + ex.Message;
                dm.Status = 0;
                return dm;
            }
        }
    }
}
