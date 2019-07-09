using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Users
    {
        public Users()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _username;
        private string _useraccount;
        private string _userpassword;
        private string _usermail;
        private DateTime? _registertime;
        private DateTime? _logintime;
        private int _usersstate;
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
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 账户
        /// </summary>
        public string UserAccount
        {
            set { _useraccount = value; }
            get { return _useraccount; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPassWord
        {
            set { _userpassword = value; }
            get { return _userpassword; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string UserMail
        {
            set { _usermail = value; }
            get { return _usermail; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? RegisterTime
        {
            set { _registertime = value; }
            get { return _registertime; }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 用户状态：1正常|0锁定
        /// </summary>
        public int UsersState
        {
            set { _usersstate = value; }
            get { return _usersstate; }
        }
        #endregion Model

    }
}

