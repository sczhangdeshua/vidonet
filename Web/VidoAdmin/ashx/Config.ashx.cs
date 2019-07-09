using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.VidoAdmin.aspx
{
    /// <summary>
    /// Config 的摘要说明
    /// </summary>
    public class Config : IHttpHandler
    {
        string action;
        BLL.Config bllConfig = new BLL.Config();
        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            switch(action)
            {
                case "GetConfigValueList":
                    #region 获取各项系统设置的数据值清单
                    try
                    {
                        context.Response.Write(bllConfig.ExGetConfigValueList(context.Request["ConfigKeyList"]));
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！05187");
                    }
                    break;
                    #endregion
                case "SaveConfig"://保存各项系统设置
                    #region 保存各项系统设置
                    try
                    {
                        bllConfig.ExSaveConfig(context.Request["ConfigValue"]);
                        context.Response.Write("操作成功！");
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！05897");
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