using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.VidoAdmin.aspx
{
    /// <summary>
    /// AdminSystem 的摘要说明
    /// </summary>
    public class AdminSystem : BasePage, IHttpHandler
    {
        HttpCookie cookie = new HttpCookie("AdminVidocookieLogin");
        string ManagerName, ManagerPassword, ManagerUserName, GUID, tempString;
        Common.Common common = new Common.Common();
        Model.Administrator modelAdministrator = new Model.Administrator();
        string action = "";

        BLL.Administrator bllAdministrator = new BLL.Administrator();

        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            switch (action)
            {
                case "ManagerLogin":
                    #region 管理员登录
                    try
                    {
                        ManagerName = context.Request["ManagerName"];
                        ManagerPassword = context.Request["ManagerPassword"];
                        ManagerName = common.SQLFilter(ManagerName);
                        ManagerPassword = common.MD5(common.MD5(ManagerPassword));
                        if (bllAdministrator.ExLogin(ManagerName, ManagerPassword))
                        {
                            cookie.Expires = Convert.ToDateTime("2050-12-30");//设置COOKIE的保存时间
                            cookie.Values.Add("ManagerName", Server.UrlEncode(ManagerName));
                            cookie.Values.Add("ManagerPassword", ManagerPassword);
                            cookie.Values.Add("ManagerLoginDate", DateTime.Now.ToString());//将当前系统时间保存到COOKIE，作为管理员的登录时间
                            context.Response.AppendCookie(cookie);//在系统中保存COOKIE数据
                            context.Response.Write("登录成功，正在进入主程序，请稍等！");
                        }
                        else
                        {
                            context.Response.Write("登录失败，请检查用户名和密码");
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("登录出错，请重试！00012");
                    }
                    #endregion
                    break;
                case "CreateManager":
                    #region 创建管理员帐户
                    try
                    {
                        ManagerName = common.SQLFilter(context.Request["ManagerAccount"]);
                        ManagerUserName = common.SQLFilter(context.Request["ManagerUserName"]);
                        ManagerPassword = common.MD5(common.MD5(context.Request["AdminPasswrod"]));
                        modelAdministrator.GUID = Guid.NewGuid().ToString();
                        modelAdministrator.AdminAccount = ManagerName;
                        modelAdministrator.AdminPasswrod = ManagerPassword;
                        modelAdministrator.AdminUser = ManagerUserName;
                        modelAdministrator.RegisterTime = DateTime.Now;
                        modelAdministrator.AdminLoginDate = DateTime.Now;
                        if (bllAdministrator.Add(modelAdministrator) > 0)
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("服务器错误，请重试！79009");

                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！79010");
                    }
                    #endregion
                    break;
                case "EditManager":
                    #region 修改管理员帐户
                    try
                    {
                        GUID = common.SQLFilter(context.Request["ManagerGUID"]);
                        ManagerName = common.SQLFilter(context.Request["ManagerUserName"]);
                        ManagerPassword = common.MD5(context.Request["AdminPasswrod"]);
                        modelAdministrator = bllAdministrator.ExGetModel(GUID);
                        modelAdministrator.AdminUser = ManagerName;
                        if (context.Request["AdminPasswrod"] != "")
                        {
                            modelAdministrator.AdminPasswrod = ManagerPassword;
                        }
                        if (bllAdministrator.Update(modelAdministrator))
                        {
                            context.Response.Write("操作成功！");

                        }
                        else
                        {
                            context.Response.Write("服务器错误，请重试！7111");

                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！73012");
                    }
                    #endregion
                    break;
                case "DeleteManager":
                    #region 删除管理员帐户
                    GUID = common.SQLFilter(context.Request["ManagerGUID"]);
                    try
                    {
                        if (bllAdministrator.ExDelete(GUID))
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("删除失败！79885");
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("删除失败！79815");
                    }
                    break;
                    #endregion
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}