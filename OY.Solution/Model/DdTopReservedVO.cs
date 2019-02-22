using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// DdTopReservedVO Data Structure.
    /// </summary>
    [Serializable]
    public class DdTopReservedVO 
    {
        /// <summary>
        /// 桌台类型：1.散座|2.包厢
        /// </summary>
        [XmlElement("auction_position")]
        public long AuctionPosition { get; set; }

        /// <summary>
        /// 桌子容纳的最大人数
        /// </summary>
        [XmlElement("auction_serve_max")]
        public long AuctionServeMax { get; set; }

        /// <summary>
        /// 桌位容纳的最小人数
        /// </summary>
        [XmlElement("auction_serve_min")]
        public long AuctionServeMin { get; set; }

        /// <summary>
        /// 买家昵称
        /// </summary>
        [XmlElement("buyer_nick")]
        public string BuyerNick { get; set; }

        /// <summary>
        /// 核销时间
        /// </summary>
        [XmlElement("check_time")]
        public string CheckTime { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [XmlElement("city")]
        public long City { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 订金，以分为单位
        /// </summary>
        [XmlElement("deposit")]
        public long Deposit { get; set; }

        /// <summary>
        /// 淘点点预定单id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 是否打印，true表示已经打印
        /// </summary>
        [XmlElement("is_print")]
        public bool IsPrint { get; set; }

        /// <summary>
        /// 点菜单订单id
        /// </summary>
        [XmlElement("menu_order_id")]
        public string MenuOrderId { get; set; }

        /// <summary>
        /// 当天的预定编号
        /// </summary>
        [XmlElement("num")]
        public long Num { get; set; }

        /// <summary>
        /// 预定金付款时间
        /// </summary>
        [XmlElement("paid_time")]
        public string PaidTime { get; set; }

        /// <summary>
        /// 预定人数
        /// </summary>
        [XmlElement("people_count")]
        public long PeopleCount { get; set; }

        /// <summary>
        /// 退款截止时间
        /// </summary>
        [XmlElement("refund_deadline")]
        public string RefundDeadline { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        [XmlElement("reserve_time")]
        public string ReserveTime { get; set; }

        /// <summary>
        /// 卖家标注
        /// </summary>
        [XmlElement("seller_mark")]
        public long SellerMark { get; set; }

        /// <summary>
        /// 卖家备注
        /// </summary>
        [XmlElement("seller_memo")]
        public string SellerMemo { get; set; }

        /// <summary>
        /// 预订单状态:1-新建,101-结账订单建立,2-用户已付款，12-生成现金券，21-现金券核销，22-付款超时，20-订单过期，301-退款，500-创建订单失败
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 淘点点商户编码
        /// </summary>
        [XmlElement("store_id")]
        public string StoreId { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        [XmlElement("store_name")]
        public string StoreName { get; set; }

        /// <summary>
        /// 淘宝订单号
        /// </summary>
        [XmlElement("taobao_order_id")]
        public string TaobaoOrderId { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        [XmlElement("user_memo")]
        public string UserMemo { get; set; }

        /// <summary>
        /// 联系人称呼
        /// </summary>
        [XmlElement("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户电话
        /// </summary>
        [XmlElement("user_phone")]
        public string UserPhone { get; set; }
    }
}
