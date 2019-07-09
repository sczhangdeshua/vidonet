using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoSearchList : BasePage
    {
        public Common.Common common = new Common.Common();
        public BLL.VideoDetail bllVideoDetail = new VideoDetail();
        string key, VideoDetailAddDateStart, VideoDetailAddDateEnd, VideoDetailVisible;
        protected void Page_Load(object sender, EventArgs e)
        {
            key = common.SQLFilter(Request["key"]);
            VideoDetailAddDateStart = common.SQLFilter(Request["VideoDetailAddDateStart"]);
            VideoDetailAddDateEnd = common.SQLFilter(Request["VideoDetailAddDateEnd"]);
            VideoDetailVisible = common.SQLFilter(Request["VideoDetailVisible"]);
            DataTable dtTemp = bllVideoDetail.ExGetVideoSearch(key, VideoDetailAddDateStart, VideoDetailAddDateEnd, VideoDetailVisible);
            rptList.DataSource = dtTemp;
            rptList.DataBind();
            if (dtTemp.Rows.Count > 0)
            {
                rptList.DataBind();
                lblNoData.Visible = false;
            }
            else
            {
                lblNoData.Visible = true;
            }
        }
    }
}