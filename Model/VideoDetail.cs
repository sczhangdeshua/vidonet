using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// VideoDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VideoDetail
    {
        public VideoDetail()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _videocategorguid;
        private string _videodetailname;
        private string _videodetailimgeurl;
        private string _videodetailcontent;
        private DateTime _videodetailadddate;
        private string _videodetailsource;
        private int _videodetailbrowsecount;
        private int _videodetailvisible;
        private int _videodetailsequel;
        private int _hotsearch;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 外键
        /// </summary>
        public string VideoCategorGUID
        {
            set { _videocategorguid = value; }
            get { return _videocategorguid; }
        }
        /// <summary>
        /// 影视名称
        /// </summary>
        public string VideoDetailName
        {
            set { _videodetailname = value; }
            get { return _videodetailname; }
        }
        /// <summary>
        /// 图片来源URL
        /// </summary>
        public string VideoDetailImgeURL
        {
            set { _videodetailimgeurl = value; }
            get { return _videodetailimgeurl; }
        }
        /// <summary>
        /// 影视详情
        /// </summary>
        public string VideoDetailContent
        {
            set { _videodetailcontent = value; }
            get { return _videodetailcontent; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime VideoDetailAddDate
        {
            set { _videodetailadddate = value; }
            get { return _videodetailadddate; }
        }
        /// <summary>
        /// 播放地址来源
        /// </summary>
        public string VideoDetailSource
        {
            set { _videodetailsource = value; }
            get { return _videodetailsource; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int VideoDetailBrowseCount
        {
            set { _videodetailbrowsecount = value; }
            get { return _videodetailbrowsecount; }
        }
        /// <summary>
        /// 影视是否上映，1上映，0下映
        /// </summary>
        public int VideoDetailVisible
        {
            set { _videodetailvisible = value; }
            get { return _videodetailvisible; }
        }
        /// <summary>
        /// 影视是否有续集，1有续集，0已完结
        /// </summary>
        public int VideoDetailSequel
        {
            set { _videodetailsequel = value; }
            get { return _videodetailsequel; }
        }
        /// <summary>
        /// 是否热门，1热门，0不热门
        /// </summary>
        public int HotSearch
        {
            set { _hotsearch = value; }
            get { return _hotsearch; }
        }
        #endregion Model

    }
}

