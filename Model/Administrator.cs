using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Administrator:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Administrator
    {
        public Administrator()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _adminuser;
        private string _adminaccount;
        private string _adminpasswrod;
        private DateTime _adminlogindate;
        private DateTime _registertime;
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
        /// 管理者昵称
        /// </summary>
        public string AdminUser
        {
            set { _adminuser = value; }
            get { return _adminuser; }
        }
        /// <summary>
        /// 管理者账户
        /// </summary>
        public string AdminAccount
        {
            set { _adminaccount = value; }
            get { return _adminaccount; }
        }
        /// <summary>
        /// 管理者密码
        /// </summary>
        public string AdminPasswrod
        {
            set { _adminpasswrod = value; }
            get { return _adminpasswrod; }
        }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime AdminLoginDate
        {
            set { _adminlogindate = value; }
            get { return _adminlogindate; }
        }
        /// <summary>
        /// 管理者注册时间
        /// </summary>
        public DateTime RegisterTime
        {
            set { _registertime = value; }
            get { return _registertime; }
        }
        #endregion Model

    }
}

