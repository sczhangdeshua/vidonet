using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Config:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Config
    {
        public Config()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _configkey;
        private string _configvalue;
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
        /// 项目名称
        /// </summary>
        public string ConfigKey
        {
            set { _configkey = value; }
            get { return _configkey; }
        }
        /// <summary>
        /// 数据值
        /// </summary>
        public string ConfigValue
        {
            set { _configvalue = value; }
            get { return _configvalue; }
        }
        #endregion Model

    }
}

