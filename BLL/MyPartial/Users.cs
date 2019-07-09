using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;


namespace Maticsoft.BLL
{
    public partial class Users
    {
        BLL.Information bll = new Information();
        Model.Information modelInformation = new Model.Information();
        #region 判断密码中是否有空值
        /// <summary>
        /// 判断密码中是否有空值
        /// </summary>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public bool ExPassWord(string Pwd)
        {
            int i = 0;
            while (i < Pwd.Length)
            {
                if (string.IsNullOrEmpty(Pwd[i].ToString()) || Pwd[i].ToString() == " ")
                {
                    return false;
                }
                i++;
            }
            return true;
        } 
        #endregion

        #region 判断用户是否登录成功
        /// <summary>
        /// 判断用户是否登录成功
        /// </summary>
        /// <param name="UserAccount"></param>
        /// <param name="userPwd"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUserInfo(string UserAccount, string userPwd, out Model.Users user)
        {
            user = dal.GetModel(UserAccount);
            bool isBool = false;
            if (user != null)
            {
                if (userPwd == user.UserPassWord)
                {
                    user.LoginTime = DateTime.Now;
                    dal.Update(user);
                    isBool = true;
                }
                else
                {
                    isBool = false;
                }
            }
            else
            {
                isBool = false;
            }
            return isBool;
        }
        #endregion

        #region 根据用户名称是否存在该记录
        /// <summary>
        /// 根据用户名称是否存在该记录
        /// </summary>
        public bool Exists(string UserNmae)
        {
            return dal.Exists(UserNmae);
        }
        #endregion

        #region 根据账户是否存在该记录
        /// <summary>
        /// 根据账户是否存在该记录
        /// </summary>
        public bool ExAccount(string UserAccount)
        {
            return dal.ExAccount(UserAccount);
        }
        #endregion

        #region 查看邮箱是否被人注册
        /// <summary>
        /// 查看邮箱是否被人注册
        /// </summary>
        public bool ExMail(string UserAccount)
        {
            return dal.ExMail(UserAccount);
        }
        #endregion

        #region 邮箱验证码发送
        /// <summary>
        /// 邮箱验证码发送
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="context">由ashx传过来保存验证码的值</param>
        /// <returns></returns>
        public bool SendCode(string email, string number)
        {
            
            modelInformation= bll.ExGetModel("21b95a0f90138767b0fd324e6be3457b");
            string[] SpiltEmail = email.Split('@');
            try
            {
                MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
                mailMsg.From = new MailAddress(modelInformation.FromAccton + modelInformation.EailSuffix);//源邮件地址 
                mailMsg.To.Add(new MailAddress(email));//目的邮件地址。可以有多个收件人
                mailMsg.Subject = "系统提示！！！";//发送邮件的标题 
                mailMsg.SubjectEncoding = Encoding.UTF8;
                StringBuilder sb = new StringBuilder();
                sb.Append("二十分钟会失效，请尽快使用");
                sb.Append("验证码:" + number);
                mailMsg.Body = sb.ToString();//发送邮件的内容 
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.IsBodyHtml = false;//是否发送网页到邮箱
                mailMsg.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp." + SpiltEmail[1];//smtp.163.com，smtp.qq.com，smpt.126.com
                client.Port = 587;
                client.Credentials = new NetworkCredential(modelInformation.FromAccton,modelInformation.Credentials);//特别注意qq密码需要到邮箱中去账户中去弄授权码
                client.DeliveryMethod = SmtpDeliveryMethod.Network;//设置优先级
                client.EnableSsl = true;//是否安全传输
                client.Send(mailMsg);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        } 
        #endregion

        #region 根据账户得到一个对象实体
        /// <summary>
        /// 根据账户得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Users GetModel(string UserAccount)
        {
            return dal.GetModel(UserAccount);
        } 
        #endregion

        #region 根据昵称得到一个对象实体
        /// <summary>
        /// 根据昵称得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Users ExGetModel(string UserName)
        {

            return dal.ExGetModel(UserName);
        }
        #endregion

        #region 用户状态
        /// <summary>
        /// 用户状态
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public string GetState(int State)
        {
            string reslt = "";
            switch (State)
            {
                case 1:
                    reslt = "正常";
                    break;
                case 0:
                    reslt = "锁定";
                    break;
                default:
                    reslt = "异常";
                    break;
            }
            return reslt;
        } 
        #endregion

        #region 根据得到一个对象实体
        /// <summary>
        /// 根据得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Users ExGetModelGUID(string GUID)
        {

            return dal.ExGetModelGUID(GUID);
        }
        #endregion
        #region 设置多个影视数据状态
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GUIDList">多个影视</param>
        /// <param name="UsersState">影视状态</param>
        /// <returns></returns>
        public string ExEditUsersStateAttr(string GUIDList, int UsersState)
        {
            string result = "";
            try
            {
                dal.ExEditUsersStateAttr(GUIDList, UsersState);
                result = "操作成功！";
            }
            catch (Exception ex)
            {
                result = "服务器错误，请重试！52015";
            }
            return result;
        } 
        #endregion
        #region 删除用户
        public bool ExDelete(string GUID)
        {
            return dal.ExDelete(GUID);
        } 
        #endregion
        #region 获取第一次加载的和分页时保留状态
        /// <summary>
        /// 获取第一次加载的和分页时保留状态
        /// </summary>
        /// <param name="UserName">字段名</param>
        /// <param name="UserAccount">用户名</param>
        /// <param name="UserMail">邮箱</param>
        /// <param name="UsersState">用户状态</param>
        /// <returns></returns>
        public DataTable ExGetUsersList(string UserName, string UserAccount, string UserMail, string UsersState)
        {
            DataTable result = new DataTable();
            if (UserName != "")
            {
                UserName = " AND UserName LIKE '%" + UserName + "%' ";
            }
            if (UserAccount != "")
            {
                UserAccount = " AND UserAccount ='" + UserAccount + "' ";
            }
            if (UserMail != "")
            {
                UserMail = " AND UserMail LIKE '%" + UserMail + "%' ";
            }
            if (UsersState != "" && Convert.ToInt32(UsersState)<2)
            {
                UsersState = " AND UsersState=" + UsersState + " ";
            }else
            {
                UsersState = "";
            }
            result = dal.ExGetUsersList(UserName, UserAccount, UserMail, UsersState);
            return result;
        }
        #endregion

    }
}
