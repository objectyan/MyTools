using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WaimaiAgentOrderlistGetResponse.
    /// </summary>
    public class WaimaiAgentOrderlistGetResponse : TopResponse
    {
        /// <summary>
        /// 代送商订单分页结果
        /// </summary>
        [XmlElement("result")]
        public DdTopPaginationForAgentOrder Result { get; set; }
    }
}
