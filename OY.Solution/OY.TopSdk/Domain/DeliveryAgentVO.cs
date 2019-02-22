using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// DeliveryAgentVO Data Structure.
    /// </summary>
    [Serializable]
    public class DeliveryAgentVO : TopObject
    {
        /// <summary>
        /// 代送商ID
        /// </summary>
        [XmlElement("agent_id")]
        public long AgentId { get; set; }

        /// <summary>
        /// 代送商名称
        /// </summary>
        [XmlElement("agent_name")]
        public string AgentName { get; set; }

        /// <summary>
        /// 代送商userId
        /// </summary>
        [XmlElement("agent_user_id")]
        public long AgentUserId { get; set; }
    }
}
