using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Maticsoft.Web.ashx
{
    /// <summary>
    /// ForgetPassWord 的摘要说明
    /// </summary>
    public class ForgetPassWord : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        private string action { get; set; }
        private BLL.Users bllUsers = new BLL.Users();
        private Model.Users modelUsers = new Model.Users();
        private Common.Common common = new Common.Common();
        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            string reg = @"^[A-Za-z\d]+([-_.][A-Za-zd]+)*@([A-Za-z\d]+[-_.])+[A-Za-z\d]{2,5}$";  
            switch (action)
            {
                case "OKVerify":
                    if (string.IsNullOrEmpty(context.Request["UserAccount"].Trim()))
                    {
                        context.Response.Write("onAccount:*账户不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(context.Request["UserMail"].Trim()))
                    {
                        context.Response.Write("onMail:*邮箱不能为空");
                        return;
                    }
                    if (!Regex.IsMatch(context.Request["UserMail"].Trim(),reg))
                    {
                        context.Response.Write("onMail:*输入有效的邮箱");
                        return;
                    }
                    if (string.IsNullOrEmpty(context.Request["Code"].Trim()))
                    {
                        context.Response.Write("onCode:*验证不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(context.Request["ResetUserPassWord"].Trim()))
                    {
                        context.Response.Write("onWord:*密码不能为空");
                        return;
                    }
                    if ((string)context.Session["numberCode"] != common.MD5(common.MD5(context.Request["Code"])))
                    {
                        context.Response.Write("onCode:*验证码不正确");
                        return;
                    }
                    if (!bllUsers.ExAccount(context.Request["UserAccount"]))
                    {
                        context.Response.Write("onAccount:*没有次用户");
                        return;
                    }
                    modelUsers = bllUsers.GetModel(context.Request["UserAccount"]);
                    modelUsers.UserPassWord = common.MD5(common.MD5(context.Request["ResetUserPassWord"]));
                    if( bllUsers.Update(modelUsers))
                    {
                        context.Response.Write("okUrl:/Login.aspx");
                    }
                    
                    break;
                case "APPwrod":
                    try
                    {
                        if (!Regex.IsMatch(context.Request["UserMail"].Trim(), reg))
                        {
                            context.Response.Write("0");
                            return;
                        }
                        if (!bllUsers.ExAccount(context.Request["UserAccount"]))
                        {
                            context.Response.Write("2");
                            return;
                        }
                        modelUsers = bllUsers.GetModel(context.Request["UserAccount"]);
                        modelUsers.UserPassWord = common.MD5(common.MD5(context.Request["ResetUserPassWord"]));
                        if (bllUsers.Update(modelUsers))
                        {
                            context.Response.Write("1");
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
                        context.Response.Write(JsonConvert.SerializeObject(bllConfig.ExGetConfigValue("网站名称")));
                    }
                    catch (Exception ex)
                    {

                        context.Response.Write("0");
                    }
                    break;
                case "sendCode":
                    #region 邮箱发送
                    string number = "";
                    System.Random random = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        number += (random.Next() % 10);
                    }
                    context.Session["numberCode"] =common.MD5(common.MD5(number));
                    if (bllUsers.SendCode(context.Request["UserMail"], number))
                    {
                        context.Response.Write("ok");
                    }
                    else
                    {
                        context.Response.Write("on");
                    }
                    break; 
                    #endregion
                default:
                    context.Response.Redirect("/Error.aspx?webPage=忘记页");
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