using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.waimai.agent.orderlist.get
    /// </summary>
    public class WaimaiAgentOrderlistGetRequest : ITopRequest<WaimaiAgentOrderlistGetResponse>
    {
        /// <summary>
        /// 结束时间，格式: yyyy-mm-dd hh:mm:ss
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// 页数，默认第一页
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页数，最大不超过30
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public Nullable<long> ShopId { get; set; }

        /// <summary>
        /// 开始时间，格式：yyyy-mm-dd hh:mm:ss
        /// </summary>
        public string StartTime { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.waimai.agent.orderlist.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_time", this.EndTime);
            parameters.Add("order_status", this.OrderStatus);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("shop_id", this.ShopId);
            parameters.Add("start_time", this.StartTime);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("page_no", this.PageNo);
            RequestValidator.ValidateRequired("page_size", this.PageSize);
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
