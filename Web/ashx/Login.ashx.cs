using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Maticsoft.Web.ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        Common.Common common = new Common.Common();
        Model.Users modelUsers = new Model.Users();
        HttpCookie cookie = new HttpCookie("VideoNetcookieLogin");//创建COOKIE对象
        string Code = "", action = "";
        public void ProcessRequest(HttpContext context)
        {
            BLL.Users bllUser = new BLL.Users();
            Model.Users modelUsers = new Model.Users();
            string UserAccount = context.Request["UserAccount"];
            string UserPassWord = common.MD5(common.MD5(common.SQLFilter(context.Request["UserPassWord"])));
            action = context.Request["action"];
            switch (action)
            {
                case "xxx":
                    //此处没有在ajax中发送数据如需要用请在js中调用
                    int UserChckbox = Convert.ToInt32(context.Request["checkboxid"]);
                    Code = context.Session["vCode"] != null ? context.Session["vCode"].ToString() : "";
                    modelUsers = bllUser.GetModel(UserAccount);
                    if (Code == common.SQLFilter(context.Request["Code"]))
                    {
                        if (bllUser.CheckUserInfo(UserAccount, UserPassWord, out modelUsers))
                        {
                            if (modelUsers.UsersState == 1)
                            {
                                context.Session["userInfo"] = modelUsers;
                                if (UserChckbox == 1)
                                {
                                    //将登录的用户存在cookie中
                                    cookie.Expires = DateTime.Now.AddDays(7);
                                    cookie.Values.Add("UserAccount", UserAccount);
                                    cookie.Values.Add("UserPassWord", UserPassWord);
                                    context.Response.AppendCookie(cookie);
                                }
                                context.Response.Write("/HomePage.aspx");
                            }
                            else
                            {
                                context.Response.Write("no:用户被锁定和用户异常请联系站长QQ1300646029发送账号");
                            }
                        }
                        else
                        {
                            context.Response.Write("no:没有此用户和以注销请联系站长QQ1300646029发送我要账号附带邮箱");
                        }
                    }
                    else
                    {
                        context.Response.Write("no:请先输入正确的验证码和请点击验证码刷新验证码");
                    }
                    break;
                case "APP":
                    try
                    {
                        if (bllUser.CheckUserInfo(UserAccount, UserPassWord, out modelUsers))
                        {
                            if (modelUsers.UsersState == 1)
                            {
                                Model.PlayRight modelPlayRight = new Model.PlayRight();
                                BLL.PlayRight bllPlayRight = new BLL.PlayRight();
                                modelPlayRight = bllPlayRight.GetModel(modelUsers.UserAccount);
                                context.Response.Write(fastJSON.JSON.Instance.ToJSON(modelUsers.UserName + "," + modelUsers.UserAccount + "," + modelPlayRight.HeadPortrait));
                            }
                            else
                            {
                                context.Response.Write("0");
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        context.Response.Write("0");
                    }
                    break;
                case "NetName":
                    try
                    {
                        BLL.Config bllConfig = new BLL.Config();
                        context.Response.Write(fastJSON.JSON.Instance.ToJSON(bllConfig.ExGetConfigValue("网站名称")));
                    }
                    catch (Exception ex)
                    {

                        context.Response.Write("0");
                    }
                    break;
                default:
                    context.Response.Write("0");
                    break;

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