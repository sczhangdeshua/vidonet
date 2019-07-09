using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web
{
    public partial class LookVideoParticulars : WebsiteBasePage
    {
        private BLL.Users bllUsers = new BLL.Users();
        private Model.Users modelUsers = new Model.Users();
        private Model.PlayRight modelPlayRight = new Model.PlayRight();
        private BLL.PlayRight bllPlayRight = new BLL.PlayRight();
        private Common.Common common = new Common.Common();
        BLL.VideoDetail bllVideoDetail = new VideoDetail();
        Model.VideoDetail modelVideoDetail = new Model.VideoDetail();
        string GUID;
        DataTable dtTemp;
        public DateTime? ExpireTime { get; set; }
        public string HeadPortrait { get; set; }
        public string WatchRecord { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Interface { get; set; }
        private string js { get; set; }
        private string Html { get; set; }
        private string Hid { get; set; }
        public string DXS { get; set; }
        public string NameVideo { get; set; }
        public string VideoConent { get; set; }
        string[] AtrrURL;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                    GUID = common.SQLFilter(Request["f"]);
                    modelVideoDetail = bllVideoDetail.ExGetModel(GUID);
                    dtTemp = bllVideoDetail.ExGetVideoAttribList(GUID, "");
                    Interface = bllVideoDetail.ExGetVideoAttribValue(dtTemp, "接口").Replace('＝', '=');
                    js = bllVideoDetail.ExGetVideoAttribValue(dtTemp, "视频URL").Replace('＝', '=');
                    NameVideo = modelVideoDetail.VideoDetailName;
                    VideoConent = modelVideoDetail.VideoDetailContent;
                    if (js.Contains("·"))
                    {
                        AtrrURL = js.Split('·');
                        Html = "<p>";
                        for (int i = 0; i < AtrrURL.Length; i++)
                        {
                            Html += "<button style=\"margin:5px 0px 5px 5px\" type=\"button\" class=\"btn btn-xs btn-default\" onclick=\"Bo('hid" + (i + 1) + "','" + GUID + "')\">第" + (i + 1) + "集</button>";
                            Hid += "<input type='hidden' id=\"hid" + (i + 1) + "\" value='" + Common.Common.Encrypt(AtrrURL[i]) + "'/ >";
                        }
                        DXS = AtrrURL[0];
                        Html += "</p>";
                    }
                    else
                    {
                        Html = "<p>";
                        Html += "<button style=\"margin:5px 0px 5px 5px\" type=\"button\" class=\"btn btn-xs btn-default text-center onclick=\"Bo('hid1','" + GUID + "') \">第1集</button>";
                        Hid += "<input type=\"hidden\" id=\"hid" + 1 + "\" value='p" + js + "e/>";
                        Html += "</p>";
                        DXS = js;
                    }
                    hd.InnerHtml = Hid;
                    J.InnerHtml = Html;
                    return;
                
            }
            catch (Exception ex)
            {

                //divVideo.InnerHtml = "无法播放";
            }
        }
    }
}