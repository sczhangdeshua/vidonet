using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// VideoAttribConfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VideoAttribConfig
    {
        public VideoAttribConfig()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _videocategoryguid;
        private string _videoattribconfigname;
        private string _videoattribconfigdescribe;
        private int _videoattribconfigorder;
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
        public string VideoCategoryGUID
        {
            set { _videocategoryguid = value; }
            get { return _videocategoryguid; }
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string VideoAttribConfigName
        {
            set { _videoattribconfigname = value; }
            get { return _videoattribconfigname; }
        }
        /// <summary>
        /// 属性说明
        /// </summary>
        public string VideoAttribConfigDescribe
        {
            set { _videoattribconfigdescribe = value; }
            get { return _videoattribconfigdescribe; }
        }
        /// <summary>
        /// 排序号，数字越小越靠前
        /// </summary>
        public int VideoAttribConfigOrder
        {
            set { _videoattribconfigorder = value; }
            get { return _videoattribconfigorder; }
        }
        #endregion Model

    }
}

