using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public partial class VideoDetail
    {
        #region 获取影视是否上映状态
        /// <summary>
        /// 获取影视是否上映状态
        /// </summary>
        /// <param name="VideoDetailVisible">影视是否上映状态，1上架，0下架</param>
        /// <returns></returns>
        public string ExGetVideoDetailVisible(int VideoDetailVisible)
        {
            string result = "";
            switch (VideoDetailVisible)
            {
                case 1:
                    result = "<span style='color:#f00;'>上映</span>";
                    break;
                case 0:
                    result = "下映";
                    break;
                default:
                    result = "<span style='color:#ffde00;'>异常</span>";
                    break;
            }
            return result;
        }
        #endregion
        #region 获取影视是否有续集
        /// <summary>
        /// 获取影视是否有续集
        /// </summary>
        /// <param name="VideoDetailSequel">影视是否有续集，1有续集，0已完结</param>
        /// <returns></returns>
        public string ExGetVideoDetailSequel(int VideoDetailSequel)
        {
            string result = "";
            switch (VideoDetailSequel)
            {
                case 1:
                    result = "<span style='color:#f00;'>有续集</span>";
                    break;
                case 0:
                    result = "已完结";
                    break;
                default:
                    result = "<span style='color:#ffde00;'>异常</span>";
                    break;
            }
            return result;
        }
        #endregion
        #region 获取影视是否热门
        /// <summary>
        /// 获取影视是否热门
        /// </summary>
        /// <param name="HotSearch">影视是否热门，1热门，0不热门</param>
        /// <returns></returns>
        public string ExGetHotSearch(int HotSearch)
        {
            string result = "";
            switch (HotSearch)
            {
                case 1:
                    result = "<span style='color:#f00;'>热门</span>";
                    break;
                case 0:
                    result = "不热门";
                    break;
                default:
                    result = "<span style='color:#ffde00;'>异常</span>";
                    break;
            }
            return result;
        }
        #endregion
        #region 获取当前分类和下级分类中的影视数据，根据指定的分类GUID和排序字段、排序方式
        /// <summary>
        /// 获取当前分类和下级分类中的影视数据，根据指定的分类GUID和排序字段、排序方式
        /// </summary>
        /// <param name="VideoCategoryGUID">所在分类的GUID</param>
        /// <param name="Field">字段名</param>
        /// <param name="Order">排序方式</param>
        /// <param name="VideoDetailSequel">影视名是否完结</param>
        /// <param name="HotSearch">影视是否热门</param>
        /// <returns></returns>
        public DataTable ExGetVideoDetailList(string VideoCategoryGUID, string Field, string Order, string VideoDetailSequel, string HotSearch)
        {
            DataTable result = new DataTable();
            string stringVideoDetailSequel="", stringHotSearch="";
            if (Convert.ToInt32(VideoDetailSequel) < 2)
            {
                stringVideoDetailSequel = " AND VideoDetailSequel=" + Convert.ToInt32(VideoDetailSequel);
            }
            if (Convert.ToInt32(HotSearch)<2)
            {
                stringHotSearch = " AND HotSearch=" + Convert.ToInt32(HotSearch) + " ";
            }
            result = dal.ExGetVideoDetailList(VideoCategoryGUID, Field, Order, stringVideoDetailSequel, stringHotSearch);
            return result;
        }
        #endregion
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoDetail ExGetModel(string GUID)
        {

            return dal.ExGetModel(GUID);
        }
        #endregion
        #region 设置影视上下映
        /// <summary>
        /// 设置影视上下架
        /// </summary>
        /// <param name="GUIDList">影视GUID列表，如：111,222,333</param>
        /// <param name="VideoDetailVisible">状态，1上架，0下架</param>
        /// <returns></returns>
        public string ExSetVideoDetailVisible(string GUIDList, int VideoDetailVisible)
        {
            string result = "";
            try
            {
                dal.ExSetVideoDetailVisible(GUIDList, VideoDetailVisible);
                result = "操作成功！";
            }
            catch (Exception ex)
            {
                result = "服务器错误，请重试！52015";
            }
            return result;
        }
        #endregion
        #region 根据指定条件返回搜索结果
        /// <summary>
        /// 根据指定条件返回搜索结果
        /// </summary>
        /// <param name="key">影视名称</param>
        /// <param name="VideoDetailAddDateStart">发布时间_起始</param>
        /// <param name="VideoDetailAddDateEnd">发布时间_终止</param>
        /// <param name="VideoDetailVisible">1显示所有内容、0仅显示下映内容</param>
        /// <returns></returns>
        public DataTable ExGetVideoSearch(string key, string VideoDetailAddDateStart, string VideoDetailAddDateEnd, string VideoDetailVisible)
        {
            DataTable result = new DataTable();
            result = dal.ExGetVideoSearch(key, VideoDetailAddDateStart, VideoDetailAddDateEnd, VideoDetailVisible);
            return result;
        }
        #endregion
        #region 批量删除数据
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="GUIDList">产品GUID列表，如：111,222,333</param>
        public bool ExDeleteList(string GUIDlist)
        {
            string[] ArrGUIDlist = GUIDlist.Split(',');
            GUIDlist = "";
            if (ArrGUIDlist.Length < 1)
            {
                return false;
            }
            for (int i = 0; i < ArrGUIDlist.Length; i++)
            {
                ArrGUIDlist[i] = "'" + ArrGUIDlist[i] + "'";
                GUIDlist += ArrGUIDlist[i] + ",";
            }
            GUIDlist = GUIDlist.TrimEnd(',');
            return dal.ExDeleteList(GUIDlist);
        }
        #endregion
        //---------------------------------------------------------------WebUI
        #region 获取影视
        /// <summary>
        /// 获取影视
        /// </summary>
        /// <param name="GUID">本身GUID</param>
        /// <returns></returns>
        public DataTable ExWebVideoDetail(string GUID)
        {
            return dal.ExWebVideoDetail(GUID);
        } 
        #endregion
        #region 获取影视的动态属性数据
        /// <summary>
        /// 获取影视的动态属性数据
        /// </summary>
        /// <param name="VideoDetailGUID">影视GUID，如不指定则传入空串""</param>
        /// <param name="VideoAttribConfigGUID">动态属性GUID，如不指定则传入空串""</param>
        /// <returns></returns>
        public DataTable ExGetVideoAttribList(string VideoDetailGUID, string VideoAttribConfigGUID)
        {
            DataTable result = new DataTable();
            string strWhere = "";
            //根据指定影视GUID和动态属性GUID查询
            if (VideoDetailGUID != "" && VideoAttribConfigGUID != "")
            {
                strWhere += " VideoAttribValue.VideoDetailGUID='" + VideoDetailGUID + "' AND VideoAttribValue.VideoAttribConfigGUID='" + VideoAttribConfigGUID + "' ";
            }
            //查询全部影视的全部动态属性
            if (VideoDetailGUID == "" && VideoAttribConfigGUID == "")
            {
                strWhere = "";
            }
            //根据指定影视GUID查询全部动态属性
            if (VideoDetailGUID != "" && VideoAttribConfigGUID == "")
            {
                strWhere += " VideoAttribValue.VideoDetailGUID='" + VideoDetailGUID + "' ";
            }
            //根据指定动态属性GUID查询全部影视
            if (VideoDetailGUID == "" && VideoAttribConfigGUID != "")
            {
                strWhere += " VideoAttribValue.VideoAttribConfigGUID='" + VideoAttribConfigGUID + "' ";
            }

            try
            {
                result = dal.ExGetVideoAttribList(strWhere);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        #endregion
        #region 获取动态属性列表中的指定值
        /// <summary>
        /// 获取动态属性列表中的指定值
        /// </summary>
        /// <param name="dtVideoAttribList">动态属性列表数据源</param>
        /// <param name="VideoAttribConfigName">动态属性名称</param>
        /// <returns></returns>
        public string ExGetVideoAttribValue(DataTable dtVideoAttribList, string VideoAttribConfigName)
        {
            string result = "";
            DataRow[] drTemp = null;
            try
            {
                drTemp = dtVideoAttribList.Select("VideoAttribConfigName='" + VideoAttribConfigName + "'");
                if (drTemp.Length > 0)
                {
                    result = drTemp[0]["VideoAttribValueValue"].ToString();
                }
                else
                {
                    result = "";
                }
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        }
        #endregion
        #region 根据指定条件返回搜索结果
        /// <summary>
        /// 根据指定条件返回搜索结果
        /// </summary>
        /// <param name="key">影视名称</param>
        /// <returns></returns>
        public Maticsoft.Model.VideoDetail ExGetVideoSearchA(string VideoDetailName)
        {
            return dal.ExGetVideoSearchA(VideoDetailName);
        }
        #endregion
        public int ExVideoDetailCount(string GUID)
        {
            return dal.GetRecordCount("VideoDetailVisible=1 AND VideoCategorGUID='" + GUID+"'" );
        }
    }

}
