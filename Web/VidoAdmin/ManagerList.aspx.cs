using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.BLL;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class ManagerList : BasePage
    {
        BLL.Administrator bllAdministrator = new BLL.Administrator();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtTemp = bllAdministrator.GetList("").Tables[0];
            if (dtTemp.Rows.Count < 1)
            {
                lblNoData.Visible = true;
            }
            else
            {
                lblNoData.Visible = false;
            }

            rptList.DataSource = dtTemp;
            rptList.DataBind();

            dtTemp.Clear();
            dtTemp.Dispose();
        }
    }
}