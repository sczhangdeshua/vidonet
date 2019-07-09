using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web
{
    public partial class Login :WebsiteBasePage
    {
        private BLL.Users bllUser = new BLL.Users();
        private Model.Users modelUser = new Model.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["VideoNetcookieLogin"] != null)
            {
                if (bllUser.CheckUserInfo(Request.Cookies["VideoNetcookieLogin"]["UserAccount"], Request.Cookies["VideoNetcookieLogin"]["UserPassWord"], out modelUser))
                {
                    Session["userInfo"] = modelUser;
                    Response.Redirect("HomePage.aspx");
                }
                Response.Cookies["VideoNetcookieLogin"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}