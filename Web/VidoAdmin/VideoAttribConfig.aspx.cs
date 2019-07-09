using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoAttribConfig : System.Web.UI.Page
    {
        BLL.VideoAttribConfig bllVideoAttribConfig = new BLL.VideoAttribConfig();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptList.DataSource = bllVideoAttribConfig.ExGetVideoCategoryListWithHaveVideoAttribConfig();
            rptList.DataBind();
        }
    }
}