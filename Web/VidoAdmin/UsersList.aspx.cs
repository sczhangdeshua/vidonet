using Maticsoft.BLL;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class UsersList : BasePage
    {
        public BLL.Users bllUsers = new BLL.Users();
        Common.Common common = new Common.Common();
        public Pager Pager;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = common.SQLFilter((Session["UserName"] == null) ? "" : (Request["UserName"] ?? Session["UserName"].ToString()));
            Session["UserAccount"] = common.SQLFilter((Session["UserAccount"] == null) ? "" : (Request["UserAccount"] ?? Session["UserAccount"].ToString()));
            Session["UserMail"] = common.SQLFilter((Session["UserMail"] == null) ? "" : (Request["UserMail"] ?? Session["UserMail"].ToString()));
            Session["UsersState"] = common.SQLFilter((Session["UsersState"] == null) ? "" : (Request["UsersState"] ?? Session["UsersState"].ToString()));
            if (Session["UsersState"]!=null)
            {
                switch(Session["UsersState"].ToString())
                {
                    case "1":
                        ddlUsersDatailState.SelectedIndex = 1;
                        break;
                    case "0":
                        ddlUsersDatailState.SelectedIndex = 2;
                        break;
                    default:
                        ddlUsersDatailState.SelectedIndex = 0;
                        break;
                }
            }
            Session["PagePosition"] = Request["PagePosition"] ?? "";
            Session["PageCurrent"] = (Session["PageCurrent"] == null || Request["Clear"] == "Clear") ? ("1") : (Session["PageCurrent"].ToString());
            DataTable dtTemp = bllUsers.ExGetUsersList(Session["UserName"].ToString(), Session["UserAccount"].ToString(), Session["UserMail"].ToString(), Session["UsersState"].ToString());
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
            rptList.DataBind();


        }
    }
}