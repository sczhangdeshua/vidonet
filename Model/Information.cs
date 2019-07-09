using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Information:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Information
    {
        public Information()
        { }
        #region Model
        private string _guid;
        private string _fromaccton;
        private string _credentials;
        private string _eailsuffix;
        /// <summary>
        /// 
        /// </summary>
        public string GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 当前给人发送人账户
        /// </summary>
        public string FromAccton
        {
            set { _fromaccton = value; }
            get { return _fromaccton; }
        }
        /// <summary>
        /// 授权码
        /// </summary>
        public string Credentials
        {
            set { _credentials = value; }
            get { return _credentials; }
        }
        /// <summary>
        /// 发送是那个邮箱后缀
        /// </summary>
        public string EailSuffix
        {
            set { _eailsuffix = value; }
            get { return _eailsuffix; }
        }
        #endregion Model

    }
}

