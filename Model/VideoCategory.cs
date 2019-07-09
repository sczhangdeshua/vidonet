using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// VideoCategory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VideoCategory
    {
        public VideoCategory()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _videocategorguid;
        private string _videocategorname;
        private string _videocategorydescribe;
        private int _videocategoryorder;
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
        /// 分类名称
        /// </summary>
        public string VideoCategorName
        {
            set { _videocategorname = value; }
            get { return _videocategorname; }
        }
        /// <summary>
        /// 分类介绍说明
        /// </summary>
        public string VideoCategoryDescribe
        {
            set { _videocategorydescribe = value; }
            get { return _videocategorydescribe; }
        }
        /// <summary>
        /// 排序号，数字越小越靠前
        /// </summary>
        public int VideoCategoryOrder
        {
            set { _videocategoryorder = value; }
            get { return _videocategoryorder; }
        }
        #endregion Model

    }
}

