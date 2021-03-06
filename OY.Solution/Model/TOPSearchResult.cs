using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// TOPSearchResult Data Structure.
    /// </summary>
    [Serializable]
    public class TOPSearchResult 
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        [XmlElement("paginator")]
        public TOPPaginator Paginator { get; set; }

        /// <summary>
        /// 视频列表
        /// </summary>
        [XmlArray("video_items")]
        [XmlArrayItem("video_item")]
        public List<VideoItem> VideoItems { get; set; }
    }
}
