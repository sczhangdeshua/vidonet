using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web
{
    public partial class VideoBoFangQi : WebsiteBasePage
    {
        BLL.VideoDetail bllVideoDetail = new VideoDetail();
        Common.Common common = new Common.Common();
        DataTable dtTemp;
        public string Interface="",GUID="",URL="";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GUID = common.SQLFilter(Request["GUID"]);
                dtTemp = bllVideoDetail.ExGetVideoAttribList(GUID, "");
                Interface =bllVideoDetail.ExGetVideoAttribValue(dtTemp, "接口").Replace('＝', '=');
                URL = Common.Common.Decrypt(common.SQLFilter(Request["VideoBo"]).Replace('＝', '='));
                URL = URL.Replace('＝', '=');
            }
            catch (Exception ex)
            {

                Ibody.InnerHtml = "";
            }
        }
    }
}