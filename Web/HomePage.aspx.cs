using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web
{
    public partial class HomePage :WebsiteBasePage
    {
        private BLL.Users bllUsers = new BLL.Users();
        private Model.Users modelUsers = new Model.Users();
        private Model.PlayRight modelPlayRight = new Model.PlayRight();
        private BLL.PlayRight bllPlayRight = new BLL.PlayRight();
        private HttpCookie cookie = new HttpCookie("Account");

        public DateTime? ExpireTime { get; set; }
        public string HeadPortrait { get; set; }
        public string WatchRecord { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
    }
}