using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace Maticsoft.Web.User
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		Maticsoft.BLL.User bll=new Maticsoft.BLL.User();
		Maticsoft.Model.User model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblGUID.Text=model.GUID;
		this.lblUserName.Text=model.UserName;
		this.lblUserAccount.Text=model.UserAccount;
		this.lblUserPassWord.Text=model.UserPassWord;
		this.lblUserMail.Text=model.UserMail;

	}


    }
}
