using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoAttribConfigList : BasePage
    {
        public Common.Common common = new Common.Common();
        BLL.VideoAttribConfig bllVideoAttribConfig = new BLL.VideoAttribConfig();
        string VideoCategoryGUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            VideoCategoryGUID = common.SQLFilter(Request["VideoCategoryGUID"]);

            rptList.DataSource = bllVideoAttribConfig.GetList(0, "VideoCategoryGUID='" + VideoCategoryGUID + "'", "VideoAttribConfigOrder ASC");
            rptList.DataBind();
        }
    }
}