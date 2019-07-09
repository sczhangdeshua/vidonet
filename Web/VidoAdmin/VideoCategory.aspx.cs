using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.VidoAdmin
{
    public partial class VideoCategory : BasePage
    {
       public BLL.VideoCategory bllVideoCategory = new BLL.VideoCategory();
        public Common.Common common = new Common.Common();

        protected void Page_Load(object sender, EventArgs e)
        {
            rptL1.DataSource = bllVideoCategory.ExGetCategoryListByFK("0");
            rptL1.DataBind();
        }
        #region 绑定二级分类数据
        protected void rptL1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //创建一级分类的行视图
            DataRowView drv = (DataRowView)e.Item.DataItem;
            //注册rptL2控件
            Repeater rptL2 = (Repeater)e.Item.FindControl("rptL2");
            //rptL2绑定分类数据
            rptL2.DataSource = bllVideoCategory.ExGetCategoryListByFK(drv["GUID"].ToString());
            rptL2.DataBind();
        }
        #endregion

        #region 绑定三级分类数据
        protected void rptL2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Repeater rptL3 = (Repeater)e.Item.FindControl("rptL3");
            rptL3.DataSource = bllVideoCategory.ExGetCategoryListByFK(drv["GUID"].ToString());
            rptL3.DataBind();
        }
        #endregion
    }
}