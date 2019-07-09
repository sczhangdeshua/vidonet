using Maticsoft.BLL;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web
{
    public partial class TvDatil : WebsiteBasePage
    {
        public string GUID { get; set; }
        Common.Common common = new Common.Common();
        BLL.VideoDetail bllVideoDetail = new VideoDetail();
        BLL.VideoAttribValue bllVideoAttribValue = new VideoAttribValue();
        public Pager Pager;
        DataTable dtTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            GUID = common.SQLFilter(Request["GUID"]) == null ? "" : common.SQLFilter(Request["GUID"]);
            Session["PagePosition"] = Request["PagePosition"] ?? "";
            Session["PageCurrent"] = Session["PageCurrent"] == null  ? ("1") : (Session["PageCurrent"].ToString());
            dtTemp=bllVideoDetail.ExWebVideoDetail(GUID);
            int tmpInt, tmpIntA=1;
            if (GUID!="")
            {
                tmpInt = bllVideoDetail.ExVideoDetailCount(GUID);
                DataColumn col = new DataColumn("FID", typeof(int));
                dtTemp.Columns.Add(col);
                DataRow newRow;
                newRow = dtTemp.NewRow();
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (tmpIntA <= tmpInt)
                    {
                        dr["FID"] = tmpIntA++;
                    }
                }
            }
            Pager = new Common.Pager(Convert.ToInt32(Session["PageCurrent"]), 60, dtTemp);
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
            if (dtTemp.Rows.Count>0)
            {
                rptList.DataBind();
                lblNoData.Visible = false;
                divPager.Visible = true;
            }
            else
            {
                lblNoData.Visible = true;
                divPager.Visible = false;
            }
        }
        protected void rptVideoList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblType = (Label)e.Item.FindControl("lblType");
            dtTemp = bllVideoDetail.ExGetVideoAttribList(drv["GUID"].ToString(), "");
            lblType.Text = common.GetSubString(bllVideoDetail.ExGetVideoAttribValue(dtTemp, "类型"), 4, "");
        }
    }
}