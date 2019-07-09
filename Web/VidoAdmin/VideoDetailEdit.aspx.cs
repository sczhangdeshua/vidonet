using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoDetailEdit : BasePage
    {
        public Model.VideoDetail modelVideoDetail = new Model.VideoDetail();
        BLL.VideoAttribConfig bllVideoAttribConfig = new BLL.VideoAttribConfig();
        BLL.VideoDetail bllVideoDetail = new VideoDetail();
        Common.Common common = new Common.Common();
        DataTable dtTemp;
        string GUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["ActionMethod"])
            {
                case "OpenCreate":
                    modelVideoDetail.VideoDetailContent = "";
                    dtTemp = bllVideoAttribConfig.ExGetList(0, "VideoCategoryGUID='" + Request.Cookies["VideoCategoryGUID"].Value + "'", "VideoAttribConfigOrder ASC").Tables[0];
                    rptList.DataSource = dtTemp;
                    rptList.DataBind();
                    if (dtTemp.Rows.Count < 1)
                    {
                        divVideoAttribConfigList.Visible = false;
                    }
                    break;
                case "OpenEdit":
                    GUID = common.SQLFilter(Request["GUID"]);
                    modelVideoDetail = bllVideoDetail.ExGetModel(GUID);
                    txtVideoDetailName.Value = modelVideoDetail.VideoDetailName;
                    VideoDetailImgeURL.Value = modelVideoDetail.VideoDetailImgeURL;
                    txtVideoDetailSource.Value = modelVideoDetail.VideoDetailSource;
                    txtVideoDetailBrowseCount.Value = modelVideoDetail.VideoDetailBrowseCount.ToString();
                    if (modelVideoDetail.VideoDetailVisible == 1)
                    {
                        rdoVideoDetailVisible1.Checked = true;
                    }
                    else
                    {
                        rdoVideoDetailVisible0.Checked = true;
                    }
                    if (modelVideoDetail.VideoDetailSequel == 1)
                    {
                        rdoVideoDetailSequel1.Checked = true;
                    }
                    else
                    {
                        rdoVideoDetailSequel0.Checked = true;
                    }
                    if (modelVideoDetail.VideoDetailVisible == 1)
                    {
                        rdoHotSearch1.Checked = true;
                    }
                    else
                    {
                        rdoHotSearch0.Checked = true;
                    }
                    //加载动态属性列表
                    rptList.DataSource = bllVideoAttribConfig.ExGetVideoAttribConfigAndValue(modelVideoDetail.GUID);
                    rptList.DataBind();
                    break;
                default:
                    common.MsgAndClose("服务器错误，请重试！5887", this);
                    break;
            }
        }
    }
}