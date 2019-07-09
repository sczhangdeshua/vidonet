using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web
{
    public partial class PersonalMessage  :WebsiteBasePage
    {
        private BLL.Users bllUsers = new BLL.Users();
        private Model.Users modelUsers = new Model.Users();
        private Model.PlayRight modelPlayRight = new Model.PlayRight();
        private BLL.PlayRight bllPlayRight = new BLL.PlayRight();
        private Common.Common common = new Common.Common();
        public DateTime? ExpireTime { get; set; }
        public string HeadPortrait { get; set; }
        public string WatchRecord { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            #region 个人信息
            if (Request.Cookies["VideoNetcookieLogin"] != null)
            {
                modelUsers = bllUsers.GetModel(Request.Cookies["VideoNetcookieLogin"]["UserAccount"]);
                modelPlayRight = bllPlayRight.GetModel(modelUsers.UserAccount);
                Account = modelUsers.UserAccount;
                Name = modelUsers.UserName;
                ExpireTime = modelPlayRight.ExpireTime;
                WatchRecord = modelPlayRight.WatchRecord;
                HeadPortrait = modelPlayRight.HeadPortrait;
                hidAccount.Value = modelUsers.UserAccount;
                hidImg.Value = modelPlayRight.HeadPortrait;
                return;
            }
            if (Session["userInfo"] != null)
            {
                modelUsers = (Model.Users)Session["userInfo"];
                modelPlayRight = bllPlayRight.GetModel(modelUsers.UserAccount);
                Account = modelUsers.UserAccount;
                Name = modelUsers.UserName;
                ExpireTime = modelPlayRight.ExpireTime;
                WatchRecord = modelPlayRight.WatchRecord;
                HeadPortrait = modelPlayRight.HeadPortrait;
                hidImg.Value = modelPlayRight.HeadPortrait;
                hidAccount.Value = modelUsers.UserAccount;
                return;
            }
            Name = "未登录";
            Account = "未登录";
            ExpireTime = DateTime.Now;
            HeadPortrait = "b614d3bf0d897dd651f1b937b957ac8a.jpg";
            WatchRecord = null;
            hidAccount.Value = null; 
            #endregion

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            //判断用户是否登录
            if (!string.IsNullOrEmpty(hidAccount.Value)&&hidAccount.Value!="未登录")
            {
                string newFile = "";
                string fileExt = "";
                HttpPostedFile file = Request.Files[0];
                //判断上传图片的时候img里面有没有图片如果有
                if (string.IsNullOrEmpty(hidImg.Value))
                {
                    //首次上传图片不需要删除原有的

                    if (file.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                         fileExt = Path.GetExtension(fileName);
                        string[] suffix = { ".jpg", ".png" };
                        for (int i = 0; i < suffix.Length; i++)
                        {
                            if (fileExt == suffix[i])
                            {
                                //对上传文件重名命
                                newFile = Guid.NewGuid().ToString();
                                //将上传的文件放在不同的目录下
                                string dir = "/HeadPortraitImages/" + newFile;
                                string fullDir = dir + fileExt;//文件存放的完整路劲
                                file.SaveAs(Request.MapPath(fullDir));//将上传的文件保存在到HeadPortraitImages文件里
                            }
                        }
                    }
                }
                else
                {
                    if (file.ContentLength > 0)
                    {
                        //如果有则删除原有的
                        File.Delete(Server.MapPath("/HeadPortraitImages/" + hidImg.Value));
                        string fileName = Path.GetFileName(file.FileName);
                        fileExt = Path.GetExtension(fileName);
                        string[] suffix = { ".jpg", ".png" };
                        for (int i = 0; i < suffix.Length; i++)
                        {
                            if (fileExt == suffix[i])
                            {
                                //对上传文件重名命
                                newFile = Guid.NewGuid().ToString();
                                //将上传的文件放在不同的目录下
                                string dir = "/HeadPortraitImages/" + newFile;
                                string fullDir = dir + fileExt;//文件存放的完整路劲
                                hidImg.Value = fullDir;
                                file.SaveAs(Request.MapPath(fullDir));//将上传的文件保存在到HeadPortraitImages文件里
                            }
                        }
                    }
                    else
                    {
                        common.MsgTrans("请选择头像", this);
                        return;
                    }
                }
                modelPlayRight = bllPlayRight.GetModel(hidAccount.Value);//得到用户的播放信息
                modelPlayRight.HeadPortrait = newFile+fileExt;
                bllPlayRight.Update(modelPlayRight);
                Response.Redirect("PersonalMessage.aspx");
            }else
            {
                common.MsgTrans("请先登录了才能上传头像哦", this);
            }
        }
    }
}