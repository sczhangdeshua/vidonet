using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public abstract class WebsiteBasePage:BasePage
    {
        public string BasePage_CurrentURL { get; set; }
        BLL.Config bllConfig = new Config();
        public string NetName { get; set; }
        protected override void OnInit(EventArgs e)
        {
            #region 获取当前程序页面地址
            BasePage_CurrentURL = Request.Url.AbsoluteUri;
            #endregion

            #region 获取网站状态以决定是否运行
            switch (bllConfig.ExGetConfigValue("网站状态"))
            {
                case "停止":
                    Response.Redirect(bllConfig.ExGetConfigValue("网站维护") + "/Error.aspx");
                    break;
                default:
                    NetName = bllConfig.ExGetConfigValue("网站名称");
                    break;
            }
         

        }//OnInit
            #endregion
    }
}
