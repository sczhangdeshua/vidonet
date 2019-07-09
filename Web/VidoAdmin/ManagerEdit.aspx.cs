using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class ManagerEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Administrator bllAdministrator = new BLL.Administrator();
            Model.Administrator modelAdministrator = new Model.Administrator();
            Common.Common common = new Common.Common();
            string ManagerGUID = "";
            switch (Request["ActionMethod"])
            {
                case "OpenCreate":
                    break;
                case "OpenEdit":
                    ManagerGUID = common.SQLFilter(Request["ManagerGUID"]);
                    modelAdministrator = bllAdministrator.ExGetModel(ManagerGUID);
                    txtManagerUserName.Value = modelAdministrator.AdminUser;
                    txtManagerName.Value = modelAdministrator.AdminAccount;
                    break;
                default:
                    common.MsgAndClose("服务器错误，请重试！7516", this);
                    break;
            }
        }
    }
}