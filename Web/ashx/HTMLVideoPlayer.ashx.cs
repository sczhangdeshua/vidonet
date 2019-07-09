using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;

namespace Maticsoft.Web.ashx
{
    /// <summary>
    /// HTMLVideoPlayer 的摘要说明
    /// </summary>
    public class HTMLVideoPlayer : IHttpHandler
    {
        string action = "";
        BLL.VideoAttribValue bllVideoAttribValue = new BLL.VideoAttribValue();
        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
            switch (action)
            {
                case "HTML":
                    try
                    {
                   
                        string[] temp, T;
                        string TempString = "", html, tempString;
                        DataTable dt = bllVideoAttribValue.GetList(" VideoDetailGUID='" + context.Request["ID"] + "'").Tables[0];
                        StringBuilder sb = new StringBuilder();
                        foreach (DataRow dr in dt.Rows)
                        {
                            sb.Append(dr["VideoAttribValueValue"].ToString() + ",");
                        }
                        temp = sb.ToString().Split(',');
                        for (int i = 1; i < temp.Length - 1; i++)
                        {
                            TempString += temp[i] + ",";
                        }
                        T = TempString.Split(',');
                        tempString = T[1] + T[0];

                        html = "<iframe width='100%' height='100%' src='" + tempString + "'></iframe>";
                        html = html.Replace("\uFF1D", "=");
                        context.Response.Write(fastJSON.JSON.Instance.ToJSON(html));
                    }
                    catch (Exception ex)
                    {

                        context.Response.Write("0");
                    }
                    break;
            }
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