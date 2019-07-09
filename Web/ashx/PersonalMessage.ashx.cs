using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.ashx
{
    /// <summary>
    /// PersonalMessage 的摘要说明
    /// </summary>
    public class PersonalMessage : IHttpHandler
    {
        private BLL.Users bllUsers = new BLL.Users();
        private BLL.SensitiveLexicon bllSensitiveLexicon = new BLL.SensitiveLexicon();
        private Model.Users modelUsers = new Model.Users();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                case "newUserName":
                    #region 修改名称
                    if (string.IsNullOrEmpty(context.Request["newNickName"].Trim()))
                    {
                        context.Response.Write("no:不能为空");
                        return;
                    }
                    if (bllUsers.GetModel(context.Request["newNickName"].Trim()) != null)
                    {
                        context.Response.Write("no:昵称已被占用");
                        return;
                    }
                    if (bllSensitiveLexicon.WordPattern(context.Request["newNickName"].Trim()))
                    {
                        context.Response.Write("no:敏感词");
                        return;
                    }
                    modelUsers = bllUsers.ExGetModel(context.Request["pastNickname"].Trim());
                    modelUsers.UserName = context.Request["newNickName"];
                    if (bllUsers.Update(modelUsers))
                    {
                        context.Response.Write("ok:完成");
                    }
                    else
                    {
                        context.Response.Write("no:更改失败");
                    }
                    break;
                    #endregion
                case "APPUserName":
                    if (string.IsNullOrEmpty(context.Request["newNickName"].Trim()))
                    {
                        context.Response.Write("0");
                        return;
                    }
                    if (bllUsers.GetModel(context.Request["newNickName"].Trim()) != null)
                    {
                        context.Response.Write("0");
                        return;
                    }
                    if (bllSensitiveLexicon.WordPattern(context.Request["newNickName"].Trim()))
                    {
                        context.Response.Write("0");
                        return;
                    }
                    modelUsers = bllUsers.ExGetModel(context.Request["pastNickname"].Trim());
                    modelUsers.UserName = context.Request["newNickName"];
                    if (bllUsers.Update(modelUsers))
                    {
                        context.Response.Write("1");
                    }
                    else
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
                    context.Response.Write("错误!13");
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