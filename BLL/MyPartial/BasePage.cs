using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public abstract class BasePage : System.Web.UI.Page
    {
        public string BasePage_ManagerName { get; set; }
        Common.Common common = new Common.Common();
        BLL.Administrator bllAdministrator = new Administrator();
          #region 初始化类时要执行的方法
        protected override void OnInit(EventArgs e)
        {
            #region 保存登录帐号相关信息
            if (Request.Cookies["AdminVidocookieLogin"] == null || string.IsNullOrEmpty(Request.Cookies["AdminVidocookieLogin"]["ManagerName"]))
            {
                common.Msg("请先登录系统！", "AdminLogin.aspx", this);
            }
            else
            {
                if (bllAdministrator.ExLogin(Server.UrlDecode(Request.Cookies["AdminVidocookieLogin"]["ManagerName"]), Request.Cookies["AdminVidocookieLogin"]["ManagerPassword"]) == false)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    BasePage_ManagerName = Server.UrlDecode(Request.Cookies["AdminVidocookieLogin"]["ManagerName"]);
                }
            }
            #endregion

        }
          #endregion
    }
}
