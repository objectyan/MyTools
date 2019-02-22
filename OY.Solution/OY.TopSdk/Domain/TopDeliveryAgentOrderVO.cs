using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TopDeliveryAgentOrderVO Data Structure.
    /// </summary>
    [Serializable]
    public class TopDeliveryAgentOrderVO : TopObject
    {
        /// <summary>
        /// 买家地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 买家姓名
        /// </summary>
        [XmlElement("buyer_name")]
        public string BuyerName { get; set; }

        /// <summary>
        /// 买家手机号码
        /// </summary>
        [XmlElement("buyer_phone")]
        public string BuyerPhone { get; set; }

        /// <summary>
        /// 买家坐标
        /// </summary>
        [XmlElement("buyer_pos")]
        public string BuyerPos { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 结束配送时间
        /// </summary>
        [XmlElement("end_delivery_time")]
        public string EndDeliveryTime { get; set; }

        /// <summary>
        /// 用户留言
        /// </summary>
        [XmlElement("note")]
        public string Note { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        [XmlElement("order_id")]
        public long OrderId { get; set; }

        /// <summary>
        /// 1:创建订单  2:买家支付订单  4:买家申请退款  6:卖家拒绝退款  12:卖家确认发货  20:订单关闭  21:交易成功  22:订单关闭未付款
        /// </summary>
        [XmlElement("order_status")]
        public long OrderStatus { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        [XmlElement("shop_id")]
        public long ShopId { get; set; }

        /// <summary>
        /// 店铺坐标
        /// </summary>
        [XmlElement("shop_pos")]
        public string ShopPos { get; set; }

        /// <summary>
        /// 开始配送时间
        /// </summary>
        [XmlElement("start_delivery_time")]
        public string StartDeliveryTime { get; set; }

        /// <summary>
        /// 店铺地址
        /// </summary>
        [XmlElement("store_address")]
        public string StoreAddress { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        [XmlElement("store_name")]
        public string StoreName { get; set; }

        /// <summary>
        /// 店铺电话号码
        /// </summary>
        [XmlElement("store_phone")]
        public string StorePhone { get; set; }
    }
}
