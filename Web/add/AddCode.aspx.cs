using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web
{
    public partial class AddCode : System.Web.UI.Page
    {
        private BLL.SensitiveLexicon bllSensitiveLexicon = new BLL.SensitiveLexicon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string msg = Request["txtMsg"];
                if (msg != "")
                {
                    Response.Write("不能为空");
                }
                msg = msg.Trim();
                string[] words = msg.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    string[] w = word.Split('=');
                    Model.SensitiveLexicon WordsModel = new Model.SensitiveLexicon();
                    WordsModel.WordPattern = w[0];
                    if (w[1] == "{BANNED}")
                    {
                        WordsModel.IsForbid = true;
                    }
                    else if (w[1] == "{MOD}")
                    {
                        WordsModel.IsMod = true;
                    }
                    else
                    {
                        WordsModel.ReplaceWord = w[1];
                    }
                    if (bllSensitiveLexicon.Add(WordsModel)>0)
                    {
                        Response.Write("添加成功");
                    }
                    else
                    {
                        Response.Write("添加失败");
                    }
                }
            }
        }
    }
}