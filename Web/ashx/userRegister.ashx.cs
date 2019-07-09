using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Maticsoft.Web.ashx
{
    /// <summary>
    /// userRegister 的摘要说明
    /// </summary>
    public class userRegister : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private string action { get; set; }//公用字段
        private BLL.Users bllUser = new BLL.Users();
        private Model.Users modelUsers = new Model.Users();
        private BLL.PlayRight bllPlayRight = new BLL.PlayRight();
        private Model.PlayRight modelPlayRight = new Model.PlayRight();
        private Common.Common common = new Common.Common();
        private BLL.SensitiveLexicon bllSensitiveLexicon = new BLL.SensitiveLexicon();
        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            string reg = @"^[A-Za-z\d]+([-_.][A-Za-zd]+)*@([A-Za-z\d]+[-_.])+[A-Za-z\d]{2,5}$";                   
            string regString = @"^[A-Za-z0-9]+$";
            
            switch (action)
            {
                case "spanMail":
                    #region 邮箱判断
                    if (!bllUser.ExMail(context.Request["UserMail"]))
                    {
                        context.Response.Write("ok:*可用");//可以此处需要成功的图片
                    }
                    else
                    {
                        context.Response.Write("on:*邮箱已被注册");//可以此处需要成功的图片
                    }
                    #endregion
                    break;
                case "spanUserName":
                    #region 判断用户名
                    //判断用户名
                    string userName = context.Request["UserName"].Trim();
                    if (!string.IsNullOrEmpty(userName)&&!bllSensitiveLexicon.WordPattern(userName))
                    {
                            if (!bllUser.Exists(context.Request["UserName"]))
                            {
                                context.Response.Write("ok:*可用");//可以此处需要成功的图片
                            }
                            else
                            {
                                context.Response.Write("on:*用户名称以存在");
                            }
                    }
                    else
                    {
                        context.Response.Write("on:*敏感词");
                    }
                    #endregion
                    break;
                case "spanAccount":
                    #region 判断账号
                    //判断账号
                    if (!bllUser.ExAccount(context.Request["UserAccount"]))
                    {
                        if (Regex.IsMatch(context.Request["UserAccount"], regString))
                        {
                            context.Response.Write("ok:*可用");
                        }
                        else
                        {
                            context.Response.Write("on:*账户输入有误");
                        }
                    }
                    else
                    {
                        context.Response.Write("on:*账户以存在");
                    }
                    #endregion
                    break;
                case "Register":
                    #region 注册
                    if (context.Session["vCode"].ToString() == context.Request["Code"])
                    {
                        #region 昵称判断
                        //昵称判断
                        if (!string.IsNullOrEmpty(context.Request["UserName"].Trim()))
                        {
                            if (bllUser.Exists(context.Request["UserName"]))
                            {
                                context.Response.Write("onName:*用户名称以存在"); ;//可以此处需要成功的图片
                                return;
                            }
                            if (bllSensitiveLexicon.WordPattern(context.Request["UserName"].Trim()))
                            {
                                context.Response.Write("onName:*敏感词");
                                return;
                            }
                        }
                        else
                        {
                            context.Response.Write("onName:*不能为空");
                            return;
                        } 
                        #endregion
                        #region 账户判断
                        //账户判断
                        if (context.Request["UserAccount"] != "")
                        {
                            if (bllUser.ExAccount(context.Request["UserAccount"]))
                            {
                                context.Response.Write("onAccount:*账户以存在"); ;//可以此处需要成功的图片
                                return;
                            }
                            if (!Regex.IsMatch(context.Request["UserAccount"], regString))
                            {
                                context.Response.Write("onAccount:*账户输入有误");
                                return;
                            }
                        }
                        else
                        {
                            context.Response.Write("onAccount:*不能为空");
                            return;
                        } 
                        #endregion
                        #region 密码判断
                        //密码判断
                        var PassWord = context.Request["UserPassWord"].Trim();
                        if (string.IsNullOrEmpty(PassWord))
                        {
                            context.Response.Write("onPassWord:*敏感字符");
                            return;
                        }
                        if (!bllUser.ExPassWord(PassWord))
                        {
                            context.Response.Write("onPassWord:*敏感字符");
                            return;
                        }
                        #endregion
                        #region 邮箱判断（此处需要好点的正则表达式）
                        //邮箱判断
                        if (context.Request["UserMail"] != "")
                        {
                            if (!Regex.IsMatch(context.Request["UserMail"], reg))
                            {
                                context.Response.Write("onMail:*请填写有效的邮箱");
                                return;
                            }
                            if (bllUser.ExMail(context.Request["UserMail"]))
                            {
                                context.Response.Write("onMail:邮箱已被注册");
                                return;
                            }
                        }
                        else
                        {
                            context.Response.Write("onMail:*不能为空");
                            return;
                        } 
                        #endregion

                        modelUsers.GUID = Guid.NewGuid().ToString();
                        modelUsers.UserName = context.Request["UserName"];
                        modelUsers.UserAccount = context.Request["UserAccount"];
                        modelUsers.UserPassWord = common.MD5(common.MD5(context.Request["UserPassWord"]));
                        modelUsers.UserMail = context.Request["UserMail"];
                        modelUsers.RegisterTime = DateTime.Now;
                        modelUsers.LoginTime = DateTime.Now;
                        if (bllUser.Add(modelUsers) > 0)
                        {
                            #region 添加播放权利
                            modelPlayRight.GUID = Guid.NewGuid().ToString();
                            modelPlayRight.UserAccount = context.Request["UserAccount"];
                            modelPlayRight.ExpireTime = DateTime.Now;
                            modelPlayRight.WatchRecord = "暂无信息";
                            modelPlayRight.HeadPortrait = "b614d3bf0d897dd651f1b937b957ac8a.jpg";
                            bllPlayRight.Add(modelPlayRight);
                            #endregion
                            context.Response.Write("okRegister:Login.aspx");

                        }
                        else
                        {
                            context.Response.Write("onRegister:注册失败");
                        }
                    }
                    else
                    {
                        context.Response.Write("onCode:验证码错误");
                    }
                    break;
                default:
                    context.Response.Write("onErron:/Error.aspx?webPage=忘记密码");
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