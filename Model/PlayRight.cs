using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// PlayRight:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PlayRight
    {
        public PlayRight()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _useraccount;
        private DateTime? _expiretime;
        private string _headportrait;
        private string _watchrecord;
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
        /// 用户账户
        /// </summary>
        public string UserAccount
        {
            set { _useraccount = value; }
            get { return _useraccount; }
        }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? ExpireTime
        {
            set { _expiretime = value; }
            get { return _expiretime; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadPortrait
        {
            set { _headportrait = value; }
            get { return _headportrait; }
        }
        /// <summary>
        /// 观看记录
        /// </summary>
        public string WatchRecord
        {
            set { _watchrecord = value; }
            get { return _watchrecord; }
        }
        #endregion Model

    }
}

