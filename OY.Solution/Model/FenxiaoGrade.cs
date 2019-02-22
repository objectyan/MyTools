using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// FenxiaoGrade Data Structure.
    /// </summary>
    [Serializable]
    public class FenxiaoGrade 
    {
        /// <summary>
        /// 记录创建时间
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [XmlElement("grade_id")]
        public long GradeId { get; set; }

        /// <summary>
        /// 记录最后修改时间
        /// </summary>
        [XmlElement("modified")]
        public string Modified { get; set; }

        /// <summary>
        /// 分销商等级名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
