using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// StaffEvalStatById Data Structure.
    /// </summary>
    [Serializable]
    public class StaffEvalStatById 
    {
        /// <summary>
        /// 客服评价
        /// </summary>
        [XmlArray("evaluations")]
        [XmlArrayItem("evaluation")]
        public List<Evaluation> Evaluations { get; set; }

        /// <summary>
        /// 客服人员ID
        /// </summary>
        [XmlElement("service_staff_id")]
        public string ServiceStaffId { get; set; }
    }
}
