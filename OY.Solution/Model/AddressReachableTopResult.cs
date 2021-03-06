using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// AddressReachableTopResult Data Structure.
    /// </summary>
    [Serializable]
    public class AddressReachableTopResult 
    {
        /// <summary>
        /// 筛单结果l列表
        /// </summary>
        [XmlArray("reachable_result_list")]
        [XmlArrayItem("address_reachable_result")]
        public List<AddressReachableResult> ReachableResultList { get; set; }
    }
}
