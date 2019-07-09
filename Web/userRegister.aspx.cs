using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web
{
    public partial class userRegister : WebsiteBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            inputUserName.Value = "";
            inputAccount.Value = "";
            inputPassWord.Value = "";
            inputCode.Value = "";
        }
    }
}