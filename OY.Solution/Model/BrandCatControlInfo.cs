using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// BrandCatControlInfo Data Structure.
    /// </summary>
    [Serializable]
    public class BrandCatControlInfo 
    {
        /// <summary>
        /// 管控的品牌类目信息，一组列表
        /// </summary>
        [XmlArray("brand_cat_controls")]
        [XmlArrayItem("brand_cat_control")]
        public List<BrandCatControl> BrandCatControls { get; set; }
    }
}
