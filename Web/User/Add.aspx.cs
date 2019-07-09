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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.User
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtGUID.Text.Trim().Length==0)
			{
				strErr+="GUID不能为空！\\n";	
			}
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtUserAccount.Text.Trim().Length==0)
			{
				strErr+="UserAccount不能为空！\\n";	
			}
			if(this.txtUserPassWord.Text.Trim().Length==0)
			{
				strErr+="UserPassWord不能为空！\\n";	
			}
			if(this.txtUserMail.Text.Trim().Length==0)
			{
				strErr+="UserMail不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string GUID=this.txtGUID.Text;
			string UserName=this.txtUserName.Text;
			string UserAccount=this.txtUserAccount.Text;
			string UserPassWord=this.txtUserPassWord.Text;
			string UserMail=this.txtUserMail.Text;

			Maticsoft.Model.User model=new Maticsoft.Model.User();
			model.GUID=GUID;
			model.UserName=UserName;
			model.UserAccount=UserAccount;
			model.UserPassWord=UserPassWord;
			model.UserMail=UserMail;

			Maticsoft.BLL.User bll=new Maticsoft.BLL.User();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
