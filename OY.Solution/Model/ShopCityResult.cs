using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// ShopCityResult Data Structure.
    /// </summary>
    [Serializable]
    public class ShopCityResult 
    {
        /// <summary>
        /// 以城市维度分的店铺列表
        /// </summary>
        [XmlArray("cityshoplist")]
        [XmlArrayItem("top_shop_group_by_city")]
        public List<TopShopGroupByCity> Cityshoplist { get; set; }
    }
}
