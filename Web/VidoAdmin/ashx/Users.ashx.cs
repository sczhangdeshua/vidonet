using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.VidoAdmin.ashx
{
    /// <summary>
    /// Users 的摘要说明
    /// </summary>
    public class Users : IHttpHandler
    {
        string action;
        string UserName, UserAccount, UserPassWord, UserMail, UsersState,GUID;
        string UsersGUIDList;
        Model.Users modelUsers = new Model.Users();
        BLL.Users bllUsers = new BLL.Users();
        Common.Common common = new Common.Common();
        Model.PlayRight modelPlayRight = new Model.PlayRight();
        BLL.PlayRight bllPlayRight = new BLL.PlayRight();
        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            switch (action)
            {
                case "CreateUsersDetail":
                    #region 创建会员
                    try
                    {
                        UserName = common.SQLFilter(context.Request["UserName"]);
                        UserAccount = common.SQLFilter(context.Request["UserAccount"]);
                        UserPassWord = common.MD5(common.MD5(common.SQLFilter(context.Request["UserPassWord"])));
                        UserMail = common.SQLFilter(context.Request["UserMail"]);
                        UsersState = common.SQLFilter(context.Request["UsersState"]);
                        modelUsers.GUID = Guid.NewGuid().ToString();
                        modelUsers.UserName = UserName;
                        modelUsers.UserAccount = UserAccount;
                        modelUsers.UserMail = UserMail;
                        modelUsers.UserPassWord = UserPassWord;
                        modelUsers.UsersState = Convert.ToInt32(UsersState);
                        modelUsers.LoginTime = DateTime.Now;
                        modelUsers.RegisterTime = DateTime.Now;
                        if (bllUsers.Add(modelUsers) > 0)
                        {
                            modelPlayRight.GUID = modelUsers.GUID;
                            modelPlayRight.UserAccount = context.Request["UserAccount"];
                            modelPlayRight.ExpireTime = DateTime.Now;
                            modelPlayRight.WatchRecord = "暂无信息";
                            modelPlayRight.HeadPortrait = "b614d3bf0d897dd651f1b937b957ac8a.jpg";
                            bllPlayRight.Add(modelPlayRight);
                            context.Response.Write("添加成功");
                        }
                        else
                        {
                            context.Response.Write("添加失败");
                        }
                    }
                    catch (Exception)
                    {

                        context.Response.Write("错误：02");
                    }
                    break; 
                    #endregion
                case "UsersPasswordEdit":
                    #region 修改密码
                    GUID = context.Request["GUID"];
                    UserPassWord = common.MD5(common.MD5(common.SQLFilter(context.Request["UserPassWord"])));
                    modelUsers = bllUsers.ExGetModelGUID(GUID);
                    modelUsers.UserPassWord = UserPassWord;
                    if (bllUsers.Update(modelUsers))
                    {
                        context.Response.Write("操作成功");
                    }
                    else
                    {
                        context.Response.Write("错误：03");
                    }
                    break; 
                    #endregion
                case "UsersUserNameMailEdit":
                    #region 修改昵称和邮箱
                    GUID = context.Request["GUID"];
                    modelUsers = bllUsers.ExGetModelGUID(GUID);
                    if (context.Request["UsersName"] != null && context.Request["UsersName"] != "")
                    {
                        modelUsers.UserName = common.SQLFilter(context.Request["UsersName"]);
                    }
                    if (context.Request["UsersMail"] != null && context.Request["UsersMail"] != "")
                    {
                        modelUsers.UserMail = common.SQLFilter(context.Request["UsersMail"]);
                    }
                    if (bllUsers.Update(modelUsers))
                    {
                        context.Response.Write("操作成功");
                    }
                    else
                    {
                        context.Response.Write("操作失败");
                    }
                    break; 
                    #endregion
                case "UsersStateEdit":
                    #region 修改用户状态
                    GUID = context.Request["GUID"];
                    UsersState = context.Request["UsersState"];
                    modelUsers = bllUsers.ExGetModelGUID(GUID);
                    modelUsers.UsersState = Convert.ToInt32(UsersState);
                    if (bllUsers.Update(modelUsers))
                    {
                        context.Response.Write("操作成功");
                    }
                    else
                    {
                        context.Response.Write("操作失败");
                    }
                    break; 
                    #endregion
                case "EditUsersStateAttr":
                    #region 修改多个用户状态
                    try
                    {
                        UsersGUIDList = common.SQLFilter(context.Request["GUID"]);
                        UsersState = context.Request["UserState"];
                        context.Response.Write(bllUsers.ExEditUsersStateAttr(UsersGUIDList, Convert.ToInt32(UsersState)));
                    }
                    catch (Exception)
                    {

                        context.Response.Write("错误：08");
                    }
                    break; 
                    #endregion
                case "DeleteUsers":
                    #region 删除用户
                    try
                    {
                        GUID =common.SQLFilter(context.Request["GUID"]);
                        if (bllUsers.ExDelete(GUID))
                        {
                            bllPlayRight.ExDelete(GUID);
                            context.Response.Write("操作成功");
                        }
                        else
                        {
                            context.Response.Write("操作失败");
                        }
                    }
                    catch (Exception ex)
                    {

                        context.Response.Write("错误：03");
                    }
                    break; 
                    #endregion
                case "GetUsersListSearch":
                    #region 获取用户搜索列表
                    UserName = common.SQLFilter(context.Request["UserName"]);
                    UserAccount = common.SQLFilter(context.Request["UserAccount"]);
                    UserMail = common.SQLFilter(context.Request["UserMail"]);
                    UsersState = common.SQLFilter(context.Request["UserState"]);
                    context.Response.Redirect("/VidoAdmin/UsersList.aspx?Clear=" + context.Request["Clear"] + "&UserName=" + UserName + "&UserAccount=" + UserAccount + "&UserMail=" + UserMail + "&UsersState=" + UsersState);
                    break;
                    #endregion
                default:
                    context.Response.Write("错误：01");
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