using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// CategoryResult Data Structure.
    /// </summary>
    [Serializable]
    public class CategoryResult 
    {
        /// <summary>
        /// 类目列表集合
        /// </summary>
        [XmlArray("categorylist")]
        [XmlArrayItem("root_category")]
        public List<RootCategory> Categorylist { get; set; }
    }
}
