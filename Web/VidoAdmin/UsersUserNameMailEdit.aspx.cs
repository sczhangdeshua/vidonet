using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class UsersUserNameMailEdit : BasePage
    {
        string GUID;
        public string Name { get; set; }
        BLL.Users bllUsers = new Users();
        Model.Users modelUsers = new Model.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            GUID = Request["GUID"];
            modelUsers = bllUsers.ExGetModelGUID(GUID);
            Name = modelUsers.UserName;
        }
    }
}