using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoList : BasePage
    {
        public Common.Common common = new Common.Common();
        public BLL.VideoDetail bllVideoDetail = new VideoDetail();
        BLL.VideoCategory bllVideoCategory=new BLL.VideoCategory();
        string VideoCategoryGUID;
        public Pager Pager;
        protected void Page_Load(object sender, EventArgs e)
        {
            VideoCategoryGUID = common.SQLFilter(Request["VideoCategoryGUID"]);
            string VideoCategoryDescribe = bllVideoCategory.ExGetModel(VideoCategoryGUID).VideoCategoryDescribe;
            if (VideoCategoryDescribe != "")
            {
                tbVideoCategoryDescribe.Visible = true;
                tdVideoCategoryDescribe.InnerText = VideoCategoryDescribe;
            }
            else
            {
                tbVideoCategoryDescribe.Visible = false;
            }
            Session["VideoDetailField"] = common.SQLFilter((Session["VideoDetailField"] == null) ? (Request["VideoDetailField"] ?? "VideoDetailAddDate") : (Request["VideoDetailField"] ?? Session["VideoDetailField"].ToString()));
            Session["VideoDetailOrder"] = common.SQLFilter((Session["VideoDetailOrder"] == null) ? (Request["VideoDetailOrder"] ?? "DESC") : (Request["VideoDetailOrder"] ?? Session["VideoDetailOrder"].ToString()));
            Session["VideoDetailSequel"] = common.SQLFilter((Session["VideoDetailSequel"] == null) ? (Request["VideoDetailSequel"] ?? "2") : (Request["VideoDetailSequel"] ?? Session["VideoDetailSequel"].ToString()));
            Session["HotSearch"] = common.SQLFilter((Session["HotSearch"] == null) ? (Request["HotSearch"] ?? "2") : (Request["HotSearch"] ?? Session["HotSearch"].ToString()));
            Session["PagePosition"] = Request["PagePosition"] ?? "";
            Session["PageCurrent"] = (Session["PageCurrent"] == null || Request["Clear"] == "Clear") ? ("1") : (Session["PageCurrent"].ToString());
            DataTable dtTemp = bllVideoDetail.ExGetVideoDetailList(VideoCategoryGUID, Session["VideoDetailField"].ToString(), Session["VideoDetailOrder"].ToString(), Session["VideoDetailSequel"].ToString(), Session["HotSearch"].ToString());
            Pager = new Pager(Convert.ToInt32(Session["PageCurrent"]), 5, dtTemp);

            switch (Request["PagePosition"])
            {
                case "FP":
                    rptList.DataSource = Pager.GetFirstPage();
                    Session["PageCurrent"] = Pager.PageCurrent;
                    break;
                case "PP":
                    rptList.DataSource = Pager.GetPreviousPage();
                    Session["PageCurrent"] = Pager.PageCurrent;
                    break;
                case "NP":
                    rptList.DataSource = Pager.GetNextPage();
                    Session["PageCurrent"] = Pager.PageCurrent;
                    break;
                case "LP":
                    rptList.DataSource = Pager.GetLastPage();
                    Session["PageCurrent"] = Pager.PageCurrent;
                    break;
                default:
                    rptList.DataSource = Pager.GetXPage(Convert.ToInt32(Session["PageCurrent"]));
                    break;
            }
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