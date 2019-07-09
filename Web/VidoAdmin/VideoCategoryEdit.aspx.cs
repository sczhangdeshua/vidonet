using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoCategoryEdit : BasePage
    {
        Common.Common common = new Common.Common();
        BLL.VideoCategory bllVideoCategory = new BLL.VideoCategory();
        Model.VideoCategory modelVideoCategory = new Model.VideoCategory();
        string VideoCategoryGUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["ActionMethod"])
            {
                case "OpenCreate":
                    break;
                case "OpenEdit":
                    VideoCategoryGUID = common.SQLFilter(Request["VideoCategoryGUID"]);
                    modelVideoCategory = bllVideoCategory.ExGetModel(VideoCategoryGUID);
                    txtVideoCategoryName.Value = modelVideoCategory.VideoCategorName;
                    txtVideoCategoryDescribe.Value = modelVideoCategory.VideoCategoryDescribe;
                    break;
                default:
                    common.MsgAndClose("服务器错误，请重试！0016", this);
                    break;
            }
        }
    }
}