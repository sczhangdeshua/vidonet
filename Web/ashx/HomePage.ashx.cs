using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Text;
namespace Maticsoft.Web.ashx
{
    /// <summary>
    /// HomePage 的摘要说明
    /// </summary>
    public class HomePage : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public Common.Common common = new Common.Common();
        string action, PagePosition, Table, GUID, SearchString,ModelTemp;
        Model.VideoDetail modelVideoDetail = new Model.VideoDetail();
        BLL.VideoDetail bllVideoDetail = new BLL.VideoDetail();
        BLL.Users bllUsers = new BLL.Users();
        Model.Users modelUsers = new Model.Users();

        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            switch (action)
            {
                case "exit":
                    context.Response.Cookies["VideoNetcookieLogin"].Expires = DateTime.Now.AddDays(-1);
                    context.Session["userInfo"] = null;
                    context.Response.Write("okexit:Login.aspx");
                    break;
                case "Register":
                    context.Response.Write("LookVideoParticulars.aspx?f="+common.SQLFilter(context.Request["GUID"]));
                    break;
                case "GotoPage"://对列表进行分页
                    #region 对列表进行分页
                    PagePosition = context.Request["PagePosition"];
                    Table = common.SQLFilter(context.Request["Table"]);
                    GUID = common.SQLFilter(context.Request["GUID"]);
                    switch (Table)
                    {
                        case "Tv":
                            context.Response.Redirect("../"+Table + "Datil.aspx?GUID=" + GUID + "&PagePosition=" + PagePosition);
                            break;
                        case "Article":
                            context.Response.Redirect(Table + "Datil.aspx?PagePosition=" + PagePosition);
                            break;
                        default:
                            context.Response.Write("未指定分页输出对象，请完善WebSystem.ashx中的GotoPage分支");
                            break;
                    }
                    break;
                    #endregion
                case "Search":
                    try
                    {
                        SearchString = common.SQLFilter(context.Request["SearchString"]);
                        modelVideoDetail = bllVideoDetail.ExGetVideoSearchA(SearchString);
                        ModelTemp = modelVideoDetail.GUID + ","+ modelVideoDetail.VideoDetailName + "," + modelVideoDetail.VideoDetailImgeURL;
                        context.Response.Write(ModelTemp);
                    }
                    catch (Exception ex)
                    {

                        context.Response.Write("错误!15");
                    }
                    break;
                case "APPHomePage":
                    try
                    {
                        DataTable dtTemp;
                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn("VideoID", typeof(string)));
                        dt.Columns.Add(new DataColumn("VideoName", typeof(string)));
                        dt.Columns.Add(new DataColumn("VideoCont", typeof(string)));
                        dt.Columns.Add(new DataColumn("VideoImageURL", typeof(string)));
                        dtTemp = bllVideoDetail.GetList(" VideoCategorGUID='" + context.Request["ID"] + "' ").Tables[0];
                        DataRow dr = null;
                        foreach (DataRow row in dtTemp.Rows)
                        {
                            dr = dt.NewRow();
                            dr[0] = row["GUID"];
                            dr[1] = row["VideoDetailName"];
                            dr[2] = row["VideoDetailContent"];
                            dr[3] = row["VideoDetailImgeURL"];
                            dt.Rows.Add(dr);
                        }
                        List<Entity> list = new List<Entity>();
                        list = (from DataRow dr1 in dt.Rows
                                select new Entity
                                {
                                    VideoID = dr1["VideoID"].ToString(),
                                    VideoName = dr1["VideoName"].ToString(),
                                    VideoCont = dr1["VideoCont"].ToString(),
                                    VideoImageURL = dr1["VideoImageURL"].ToString()
                                }).ToList();
                        context.Response.Write(Encoding.Default.GetString(Encoding.UTF8.GetBytes(fastJSON.JSON.Instance.ToJSON(list))));
                    }
                    catch (Exception ex)
                    {
                        
                        context.Response.Write("0");
                    } 
                    break;
                case "NetName":
                    try
                    {
                        BLL.Config bllConfig = new BLL.Config();
                        context.Response.Write(fastJSON.JSON.Instance.ToJSON(bllConfig.ExGetConfigValue("网站名称")));
                    }
                    catch (Exception ex)
                    {
                        
                        context.Response.Write("0");
                    }
                    break;
                default:
                    context.Response.Write("错误!12");
                    break;
            }
        }

        public class Entity
        {
            public string VideoID { get; set; }

            public string VideoName { get; set; }

            public string VideoCont { get; set; }

            public string VideoImageURL { get; set; }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}