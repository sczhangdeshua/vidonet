using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.BLL
{
    public partial class Administrator
    {
        DataTable dt = new DataTable();
        Model.Administrator modleAdministrator = new Model.Administrator();
        #region 管理员登录判断，登录成功返回true，否则返回false
        /// <summary>
        /// 管理员登录判断，登录成功返回true，否则返回false
        /// </summary>
        /// <param name="ManagerName">用户名</param>
        /// <param name="ManagerPassword">密码</param>
        public bool ExLogin(string ManagerName, string ManagerPassword)
        {
            bool result = false;//初始化返回值 
            dt = dal.GetList("AdminAccount='" + ManagerName + "' AND AdminPasswrod='" + ManagerPassword + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                modleAdministrator.ID= (int)dt.Rows[0]["ID"];//将OBJECT类型强转为INT数据类型
                modleAdministrator.GUID = (string)dt.Rows[0]["GUID"];
                modleAdministrator.AdminUser = (string)dt.Rows[0]["AdminUser"];
                modleAdministrator.AdminAccount = (string)dt.Rows[0]["AdminAccount"];
                modleAdministrator.AdminPasswrod = (string)dt.Rows[0]["AdminPasswrod"];
                modleAdministrator.AdminLoginDate = DateTime.Now;
                modleAdministrator.RegisterTime = (DateTime)dt.Rows[0]["RegisterTime"];
                dal.Update(modleAdministrator);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;//结束方法，回传值到调用程序
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Administrator ExGetModel(string GUID)
        {

            return dal.ExGetModel(GUID);
        }
        #endregion

        #region GUID删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ExDelete(string GUID)
        {

            return dal.ExDelete(GUID);
        } 
        #endregion
    }
}
