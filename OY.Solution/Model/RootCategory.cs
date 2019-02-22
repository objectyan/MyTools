using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// RootCategory Data Structure.
    /// </summary>
    [Serializable]
    public class RootCategory 
    {
        /// <summary>
        /// 一级类目对象
        /// </summary>
        [XmlElement("category")]
        public Category Category { get; set; }

        /// <summary>
        /// categroy的list
        /// </summary>
        [XmlArray("childslist")]
        [XmlArrayItem("category")]
        public List<Category> Childslist { get; set; }
    }
}
