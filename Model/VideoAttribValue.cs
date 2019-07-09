using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// VideoAttribValue:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VideoAttribValue
    {
        public VideoAttribValue()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _videodetailguid;
        private string _videoattribconfigguid;
        private string _videoattribvaluevalue;
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
        public string VideoDetailGUID
        {
            set { _videodetailguid = value; }
            get { return _videodetailguid; }
        }
        /// <summary>
        /// 外键
        /// </summary>
        public string VideoAttribConfigGUID
        {
            set { _videoattribconfigguid = value; }
            get { return _videoattribconfigguid; }
        }
        /// <summary>
        /// 属性值
        /// </summary>
        public string VideoAttribValueValue
        {
            set { _videoattribvaluevalue = value; }
            get { return _videoattribvaluevalue; }
        }
        #endregion Model

    }
}

