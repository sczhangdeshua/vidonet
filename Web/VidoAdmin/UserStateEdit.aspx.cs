using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class UserStateEdit : BasePage
    {
        string GUID;
        BLL.Users bllUsers = new Users();
        Model.Users modelUsers = new Model.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            GUID = Request["GUID"];
            modelUsers = bllUsers.ExGetModelGUID(GUID);
            if (modelUsers.UsersState > 1)
            {
                ddlUsersDatailState.Items.Insert(2, "异常");
                ddlUsersDatailState.SelectedIndex = 2;
            }
            if (modelUsers.UsersState == 1)
            {
                ddlUsersDatailState.SelectedIndex = 0;
            }
            if (modelUsers.UsersState == 0)
            {
                ddlUsersDatailState.SelectedIndex = 1;
            }


        }
    }
}