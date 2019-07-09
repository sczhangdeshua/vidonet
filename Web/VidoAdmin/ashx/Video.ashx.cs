using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.VidoAdmin.ashx
{
    /// <summary>
    /// Video 的摘要说明
    /// </summary>
    public class Video : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        string action, VideoCategoryName, VideoCategoryDescribe, VideoCategoryGUID, GUID, Direction, tempString, VideoAttribConfigName, VideoAttribConfigDescribe, VideoAttribConfigGUID;
        string VideoDetailName, VideoDetailImgeURL, VideoDetailContent, VideoDetailSource, VideoAttribValueValue;
        string VideoDetailField, VideoDetailOrder;
        string[] arrStringTemp;
        string PagePosition, Table;
        string key, VideoDetailAddDateStart, VideoDetailAddDateEnd;
        DateTime VideoDetailAddDate;
        int VideoDetailBrowseCount, VideoDetailVisible, VideoDetailSequel, HotSearch;
        Common.Common common = new Common.Common();
        Model.VideoCategory modelVideoCategory = new Model.VideoCategory();
        Model.VideoDetail modelVideoDetail = new Model.VideoDetail();
        BLL.VideoCategory bllVideoCategory = new BLL.VideoCategory();
        BLL.VideoDetail bllVideoDetail = new BLL.VideoDetail();
        BLL.VideoAttribValue bllVideoAttribValue = new BLL.VideoAttribValue();
        BLL.VideoAttribConfig bllVideoAttribConfig = new BLL.VideoAttribConfig();
        Model.VideoAttribConfig modelVideoAttribConfig = new Model.VideoAttribConfig();
        public void ProcessRequest(HttpContext context)
        {
            action = context.Request["action"];
           switch(action)
           {
               case "CreateVideoCategory"://创建影视分类
                   #region 创建影视分类
                   try
                   {
                       VideoCategoryName = common.SQLFilter(context.Request["VideoCategoryName"]);
                       VideoCategoryDescribe = common.SQLFilter(context.Request["VideoCategoryDescribe"]);
                       VideoCategoryGUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                       modelVideoCategory.GUID = Guid.NewGuid().ToString();
                       modelVideoCategory.VideoCategorGUID = VideoCategoryGUID;
                       modelVideoCategory.VideoCategorName = VideoCategoryName;
                       modelVideoCategory.VideoCategoryDescribe = VideoCategoryDescribe;
                       modelVideoCategory.VideoCategoryOrder = bllVideoCategory.ExGetMaxOrder(VideoCategoryGUID) + 1;
                       if (bllVideoCategory.Add(modelVideoCategory) > 0)
                       {
                           context.Response.Write("操作成功！");
                       }
                       else
                       {
                           context.Response.Write("服务器错误，请重试！5009");
                       }
                   }
                   catch (Exception ex)
                   {
                       context.Response.Write("服务器错误，请重试！0010");
                   }
                   break;
                   #endregion
               case "VideoCategoryMenuOrder"://设置影视分类菜单排序
                   #region 设置影视分类菜单排序
                   GUID = common.SQLFilter(context.Request["GUID"]);
                   Direction = context.Request["Direction"];
                   bllVideoCategory.ExSetCategoryOrder(GUID, Direction);
                   context.Response.Write("VideoCategory.aspx");
                   break;
                   #endregion
               case "DeleteVideoCategory":
                   #region 删除影视分类
                   GUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                    if (bllVideoCategory.ExDeleteVideoCategory(GUID))
                    {
                        context.Response.Write("操作成功！");
                    }
                    else
                    {
                        context.Response.Write("删除失败！请检查是否包含数据或下级分类");
                    }
                    break;
                    #endregion
               case "EditVideoCategory":
                   #region 修改影视分类
                    try
                    {
                        VideoCategoryName = common.SQLFilter(context.Request["VideoCategoryName"]);
                        VideoCategoryDescribe = common.SQLFilter(context.Request["VideoCategoryDescribe"]);
                        VideoCategoryGUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                        modelVideoCategory = bllVideoCategory.ExGetModel(VideoCategoryGUID);
                        tempString = modelVideoCategory.VideoCategorName;
                        modelVideoCategory.VideoCategorName = VideoCategoryName;
                        modelVideoCategory.VideoCategoryDescribe = VideoCategoryDescribe;
                        if (bllVideoCategory.Update(modelVideoCategory))
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("服务器错误，请重试！5011");
                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！5012");
                    }
                    break;
                    #endregion
               case "CopyVideoAttribConfig":
                    #region 复制选中的影视动态属性
                    context.Response.Write(bllVideoAttribConfig.ExCopyVideoAttribConfig(context.Request["GUID"], context.Request["VideoCategoryGUID"]) + "个动态属性复制成功！");
                    break;
                    #endregion
               case "VideoAttribConfigOrder":
                   #region 设置动态属性的排序号
                    GUID = common.SQLFilter(context.Request["GUID"]);
                    Direction = context.Request["Direction"];
                    bllVideoAttribConfig.ExSetVideoAttribConfigOrder(GUID, Direction);
                    break;
                    #endregion
               case "EditVideoAttribConfig":
                   #region 修改影视动态属性
                    try
                    {
                        VideoAttribConfigName = common.SQLFilter(context.Request["VideoAttribConfigName"]);
                        VideoAttribConfigDescribe = common.SQLFilter(context.Request["VideoAttribConfigDescribe"]);
                        VideoAttribConfigGUID = common.SQLFilter(context.Request["VideoAttribConfigGUID"]);
                        modelVideoAttribConfig = bllVideoAttribConfig.ExGetModel(VideoAttribConfigGUID);
                        Model.VideoAttribConfig modelVideoAttribConfigOld = bllVideoAttribConfig.ExGetModel(VideoAttribConfigGUID);
                        modelVideoAttribConfig.VideoAttribConfigName = VideoAttribConfigName;
                        modelVideoAttribConfig.VideoAttribConfigDescribe = VideoAttribConfigDescribe;
                        if (bllVideoAttribConfig.ExUpdate(modelVideoAttribConfig, modelVideoAttribConfigOld))
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("操作失败，请检查属性名称是否已存在！");
                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！5212");
                    }
                    break;
                    #endregion
               case "CreateVideoAttribConfig":
                    #region 新建影视动态属性
                    try
                    {
                        VideoAttribConfigName = common.SQLFilter(context.Request["VideoAttribConfigName"]);
                        VideoAttribConfigDescribe = common.SQLFilter(context.Request["VideoAttribConfigDescribe"]);
                        VideoCategoryGUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                        modelVideoAttribConfig.GUID = Guid.NewGuid().ToString();
                        modelVideoAttribConfig.VideoCategoryGUID = VideoCategoryGUID;
                        modelVideoAttribConfig.VideoAttribConfigName = VideoAttribConfigName;
                        modelVideoAttribConfig.VideoAttribConfigDescribe = VideoAttribConfigDescribe;
                        modelVideoAttribConfig.VideoAttribConfigOrder = bllVideoAttribConfig.ExGetMaxOrder(VideoCategoryGUID) + 1;
                        if (bllVideoAttribConfig.ExAdd(modelVideoAttribConfig) > 0)
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("操作失败，请检查属性名称是否已存在！");
                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！5510");
                    }
                    break;
                    #endregion
               case "GetVideoAttribCountInVideoDetail":
                   #region 在弹出确定删除对话框之前，先对被删除属性的关联数据进行一次查询统计
                    context.Response.Write(bllVideoAttribConfig.ExGetVideoAttribCountInVideoDetail(common.SQLFilter(context.Request["VideoAttribConfigGUID"])));
                    break;
                    #endregion
               case "DeleteVideoAttribConfig":
                   #region 删除影视动态属性
                    try
                    {
                        tempString = bllVideoAttribConfig.ExGetModel(context.Request["VideoAttribConfigGUID"]).VideoAttribConfigName;
                        if (bllVideoAttribConfig.ExDelete(context.Request["VideoAttribConfigGUID"]))
                        {
                            context.Response.Write("操作成功！");
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                    #endregion
               case "CreateVideoDetail":
                    #region 创建影视详情
                    try
                    {
                        VideoCategoryGUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                        VideoDetailName = common.SQLFilter(context.Request["VideoDetailName"]);
                        VideoDetailContent = context.Request["VideoDetailContent"];
                        VideoDetailAddDate = DateTime.Now;
                        VideoDetailBrowseCount = Convert.ToInt32(context.Request["VideoDetailBrowseCount"]);
                        VideoDetailImgeURL =context.Request["VideoDetailImgeURL"];
                        VideoDetailVisible = Convert.ToInt32(context.Request["VideoDetailVisible"]);
                        VideoDetailSource = context.Request["VideoDetailSource"];
                        VideoAttribConfigGUID = common.SQLFilter(context.Request["VideoAttribConfigGUID"]);
                        VideoAttribValueValue = common.SQLFilter(context.Request["VideoAttribValueValue"]);
                        VideoDetailBrowseCount = Convert.ToInt32(context.Request["VideoDetailBrowseCount"]);
                        VideoDetailSequel = Convert.ToInt32(context.Request["VideoDetailSequel"]);
                        HotSearch = Convert.ToInt32(context.Request["HotSearch"]);
                        modelVideoDetail.GUID = Guid.NewGuid().ToString();
                        modelVideoDetail.VideoCategorGUID = VideoCategoryGUID;
                        modelVideoDetail.VideoDetailName = VideoDetailName;
                        modelVideoDetail.VideoDetailContent = VideoDetailContent;
                        modelVideoDetail.VideoDetailAddDate = VideoDetailAddDate;
                        modelVideoDetail.VideoDetailSource = VideoDetailSource;
                        modelVideoDetail.VideoDetailBrowseCount = VideoDetailBrowseCount;
                        modelVideoDetail.VideoDetailImgeURL = VideoDetailImgeURL;
                        modelVideoDetail.VideoDetailVisible = VideoDetailVisible;
                        modelVideoDetail.VideoDetailVisible = VideoDetailVisible;
                        modelVideoDetail.VideoDetailSequel = VideoDetailSequel;
                        modelVideoDetail.HotSearch = HotSearch;
                        if (bllVideoDetail.Add(modelVideoDetail) > 0 && bllVideoAttribValue.ExAdd(modelVideoDetail.GUID, VideoAttribConfigGUID, VideoAttribValueValue))
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("服务器错误，请重试！5922");
                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！5710");
                    }
                    break;
                    #endregion
               case "EditVideoDetail":
                    #region 修改影视详情
                    try
                    {
                        GUID = common.SQLFilter(context.Request["GUID"]);
                        modelVideoDetail = bllVideoDetail.ExGetModel(GUID);
                        VideoDetailName = common.SQLFilter(context.Request["VideoDetailName"]);
                        VideoDetailContent = context.Request["VideoDetailContent"];
                        VideoDetailAddDate = DateTime.Now;
                        VideoDetailBrowseCount = Convert.ToInt32(context.Request["VideoDetailBrowseCount"]);
                        VideoDetailImgeURL = context.Request["VideoDetailImgeURL"];
                        VideoDetailVisible = Convert.ToInt32(context.Request["VideoDetailVisible"]);
                        VideoDetailSource = context.Request["VideoDetailSource"];
                        VideoAttribConfigGUID = common.SQLFilter(context.Request["VideoAttribConfigGUID"]);
                        VideoAttribValueValue = common.SQLFilter(context.Request["VideoAttribValueValue"]);
                        VideoDetailBrowseCount = Convert.ToInt32(context.Request["VideoDetailBrowseCount"]);
                        VideoDetailSequel = Convert.ToInt32(context.Request["VideoDetailSequel"]);
                        HotSearch = Convert.ToInt32(context.Request["HotSearch"]);
                        modelVideoDetail.VideoDetailName = VideoDetailName;
                        modelVideoDetail.VideoDetailContent = VideoDetailContent;
                        modelVideoDetail.VideoDetailAddDate = VideoDetailAddDate;
                        modelVideoDetail.VideoDetailSource = VideoDetailSource;
                        modelVideoDetail.VideoDetailBrowseCount = VideoDetailBrowseCount;
                        modelVideoDetail.VideoDetailImgeURL = VideoDetailImgeURL;
                        modelVideoDetail.VideoDetailVisible = VideoDetailVisible;
                        modelVideoDetail.VideoDetailVisible = VideoDetailVisible;
                        modelVideoDetail.VideoDetailSequel = VideoDetailSequel;
                        modelVideoDetail.HotSearch = HotSearch;
                        if (bllVideoDetail.Update(modelVideoDetail) && bllVideoAttribValue.ExAdd(modelVideoDetail.GUID, VideoAttribConfigGUID, VideoAttribValueValue))
                        {
                            context.Response.Write("操作成功！");
                        }
                        else
                        {
                            context.Response.Write("服务器错误，请重试！5329");
                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！5312");
                    }
                    break;
                    #endregion
               case "SetVideoDetailListOrder":
                   #region 设置影视列表的显示排序
                    VideoDetailField = common.SQLFilter(context.Request["VideoDetailField"]);
                    VideoDetailOrder = common.SQLFilter(context.Request["VideoDetailOrder"]);
                    VideoCategoryGUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                   // context.Session["PageCurrent"] = 1;//设置排序后，强制回到第1页
                    context.Response.Redirect("/VidoAdmin/VideoList.aspx?VideoDetailField=" + VideoDetailField + "&VideoDetailOrder=" + VideoDetailOrder + "&VideoCategoryGUID=" + VideoCategoryGUID);
                    break;
                    #endregion
               case "SetVideoDetailVisible":
                   #region 设置影视的显示和隐藏（上下映）
                    try
                    {
                        GUID = common.SQLFilter(context.Request["GUID"]);
                        arrStringTemp = GUID.Split(',');
                        tempString = bllVideoDetail.ExGetModel(arrStringTemp[0]).VideoDetailName;
                        VideoDetailVisible = Convert.ToInt32(context.Request["VideoDetailVisible"]);
                        bllVideoDetail.ExSetVideoDetailVisible(GUID, VideoDetailVisible);
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                    #endregion
               case "GetVideoDetailListSearch":
                    #region 获取影视搜索列表
                    if(!int.TryParse(common.SQLFilter(context.Request["VideoDetailSequel"]), out VideoDetailSequel))
                    {
                        VideoDetailSequel = 2;
                    }

                    if(int.TryParse(common.SQLFilter(context.Request["HotSearch"]),out HotSearch))
                    {
                        HotSearch = 2;
                    }
                    VideoCategoryGUID = common.SQLFilter(context.Request["VideoCategoryGUID"]);
                    context.Response.Redirect("/VidoAdmin/VideoList.aspx?Clear=" + context.Request["Clear"] + "&VideoDetailSequel=" + VideoDetailSequel + "&HotSearch=" + HotSearch + "&VideoCategoryGUID=" + VideoCategoryGUID);
                    break;
                    #endregion
               case "GotoPage":
                   #region 对列表进行分页
                    PagePosition = context.Request["PagePosition"];
                    Table = common.SQLFilter(context.Request["Table"]);
                    switch (Table)
                    {
                        case "Video":
                            context.Response.Redirect("/VidoAdmin/"+Table + "List.aspx?PagePosition=" + PagePosition);
                            break;
                        case "TV":
                            context.Response.Redirect("/VidoAdmin/" + Table + "List.aspx?PagePosition=" + PagePosition);
                            break;
                        case "Link":
                            context.Response.Redirect("/VidoAdmin/" + Table + "List.aspx?PagePosition=" + PagePosition);
                            break;
                        case "Users":
                            context.Response.Redirect("/VidoAdmin/" + Table + "List.aspx?PagePosition=" + PagePosition);
                            break;
                        default:
                            context.Response.Write("未指定分页输出对象，请完善System.ashx中的GotoPage分支");
                            break;
                    }
                    break;
                    #endregion
               case "GetVideoSearch":
                    #region 获取产品搜索列表，在产品搜索页面中调用
                    key = common.SQLFilter(context.Request["key"]);
                    try
                    {
                        VideoDetailAddDateStart = common.SQLFilter(context.Request["VideoDetailAddDateStart"]);
                        VideoDetailAddDateEnd = common.SQLFilter(context.Request["VideoDetailAddDateEnd"]);
                        VideoDetailVisible = Convert.ToInt32(context.Request["VideoDetailVisible"]);//如果值为1,表示搜索全部,值为0表示仅搜索下映影视
                        context.Response.Redirect("/VidoAdmin/VideoSearchList.aspx?key=" + key+ "&VideoDetailAddDateStart=" + VideoDetailAddDateStart + "&VideoDetailAddDateEnd=" + VideoDetailAddDateEnd + "&VideoDetailVisible=" + VideoDetailVisible.ToString());
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("服务器错误，请重试！5957");
                    }
                    break;
                    #endregion
               case"DeleteVideoDetail":
                   #region 删除影视详情及对应相关文件
                    try
                    {
                        GUID = common.SQLFilter(context.Request["GUID"]);
                        arrStringTemp = GUID.Split(',');
                        tempString = bllVideoDetail.ExGetModel(arrStringTemp[0]).VideoDetailName;
                        if (bllVideoDetail.ExDeleteList(GUID))
                        {
                            context.Response.Write("删除成功！");
                        }
                        else
                        {
                            context.Response.Write("删除失败！");
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("删除产品出错！");
                    }
                    break;
                    #endregion
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
