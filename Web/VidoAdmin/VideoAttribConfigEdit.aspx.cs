using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoAttribConfigEdit : System.Web.UI.Page
    {
        Model.VideoAttribConfig modelVideoAttribConfig = new Model.VideoAttribConfig();
        BLL.VideoAttribConfig bllVideoAttribConfig = new BLL.VideoAttribConfig();
        Common.Common common = new Common.Common();
        string VideoAttribConfigGUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["ActionMethod"])
            {
                case "OpenCreate":
                    break;
                case "OpenEdit":
                    VideoAttribConfigGUID = common.SQLFilter(Request["VideoAttribConfigGUID"]);
                    modelVideoAttribConfig = bllVideoAttribConfig.ExGetModel(VideoAttribConfigGUID);
                    txtVideoAttribConfigName.Value = modelVideoAttribConfig.VideoAttribConfigName;
                    txtVideoAttribConfigDescribe.Value = modelVideoAttribConfig.VideoAttribConfigDescribe;
                    break;
                default:
                    common.MsgAndClose("服务器错误，请重试！5316", this);
                    break;
            }
        }
    }
}