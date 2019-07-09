using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin.Control
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string ManagerName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AdminVidocookieLogin"] != null)
            {
                ManagerName = Server.UrlDecode(Request.Cookies["AdminVidocookieLogin"]["ManagerName"]);
            }
            else
            {
                ManagerName = "未登录用户";
            }
        }
    }
}