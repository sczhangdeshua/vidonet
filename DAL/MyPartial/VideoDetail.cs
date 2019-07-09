using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class VideoDetail
    {
        DAL.VideoAttribValue dalVideoAttribValue = new VideoAttribValue();
        #region 获取当前分类和下级分类中的产品数据，根据指定的分类GUID和排序字段、排序方式
        /// <summary>
        /// 
        /// </summary>
        /// <param name="VideoCategoryGUID">所在分类的GUID</param>
        /// <param name="Field">字段名</param>
        /// <param name="Order">排序方式</param>
        /// <param name="SearchKeyVideoDetailName">产品名称关键词</param>
        /// <param name="SearchKeyVideoDetailContent">产品详情关键词</param>
        /// <returns></returns>
        public DataTable ExGetVideoDetailList(string VideoCategoryGUID, string Field, string Order, string SearchKeyVideoDetailName, string SearchKeyVideoDetailContent)
        {
            DataTable result = new DataTable();
            SqlParameter[] parameters = {
                    new SqlParameter("@VideoCategoryGUID", SqlDbType.VarChar),
                    };
            parameters[0].Value = VideoCategoryGUID;
            string WhereVideoCategoryGUID = "";
            if (parameters[0].Value.ToString() != "")
            {
                WhereVideoCategoryGUID = " VideoCategorGUID IN (SELECT GUID FROM VideoCategory WHERE VideoCategorGUID=@VideoCategoryGUID OR GUID=@VideoCategoryGUID) ";
            }
            else
            {
                WhereVideoCategoryGUID = " 1=1 ";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM VideoDetail ");
            strSql.Append(" WHERE ");
            strSql.Append(WhereVideoCategoryGUID);
            strSql.Append(SearchKeyVideoDetailName + SearchKeyVideoDetailContent);
            strSql.Append(" ORDER BY " + Field + " " + Order);
            result = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
            return result;
        }
        #endregion
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoDetail ExGetModel(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,VideoCategorGUID,VideoDetailName,VideoDetailImgeURL,VideoDetailContent,VideoDetailAddDate,VideoDetailSource,VideoDetailBrowseCount,VideoDetailVisible,VideoDetailSequel,HotSearch from VideoDetail ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar)
			};
            parameters[0].Value = GUID;

            Maticsoft.Model.VideoDetail model = new Maticsoft.Model.VideoDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        } 
        #endregion
        #region 设置影视上下映
        /// <summary>
        /// 设置影视上下架
        /// </summary>
        /// <param name="GUIDList">影视GUID列表，如：111,222,333</param>
        /// <param name="VideoDetailVisible">状态，1上架，0下架</param>
        /// <returns></returns>
        public void ExSetVideoDetailVisible(string GUIDList, int VideoDetailVisible)
        {
            string[] arrGUID = GUIDList.Split(',');
            StringBuilder strSql = new StringBuilder();
            string tempStr = "";
            strSql.Append("UPDATE VideoDetail SET VideoDetailVisible=" + VideoDetailVisible + " WHERE GUID IN (");
            for (int i = 0; i < arrGUID.Length; i++)
            {
                tempStr += "'" + arrGUID[i] + "',";
            }
            tempStr = tempStr.TrimEnd(',');
            strSql.Append(tempStr);
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion
        #region 根据指定条件返回搜索结果
        /// <summary>
        /// 根据指定条件返回搜索结果
        /// </summary>
        /// <param name="key">影视名称/param>
        /// <param name="VideoDetailAddDateStart">发布时间_起始</param>
        /// <param name="VideoDetailAddDateEnd">发布时间_终止</param>
        /// <param name="VideoDetailVisible">1显示所有内容、0仅显示下映内容</param>
        /// <returns></returns>
        public DataTable ExGetVideoSearch(string key, string VideoDetailAddDateStart, string VideoDetailAddDateEnd, string VideoDetailVisible)
        {
            DataTable result = new DataTable();
            StringBuilder strWhere = new StringBuilder();
            //处理搜索关键词的条件
            strWhere.Append("(VideoDetailName LIKE '%" + key + "%') ");

            //处理搜索影视发布时间段的条件
            if (VideoDetailAddDateStart != "" && VideoDetailAddDateEnd != "")
            {
                strWhere.Append(" AND VideoDetailAddDate BETWEEN '" + VideoDetailAddDateStart + " 00:00:00' AND '" + VideoDetailAddDateEnd + " 23:59:59' ");
            }
            else if (VideoDetailAddDateStart != "" && VideoDetailAddDateEnd == "")
            {
                strWhere.Append(" AND VideoDetailAddDate >= '" + VideoDetailAddDateStart + " 00:00:00' ");
            }
            else if (VideoDetailAddDateStart == "" && VideoDetailAddDateEnd != "")
            {
                strWhere.Append(" AND VideoDetailAddDate <= '" + VideoDetailAddDateEnd + " 23:59:59' ");
            }

            //处理显示全部或下映影视的条件
            if (VideoDetailVisible == "0")
            {
                strWhere.Append(" AND VideoDetailVisible=0 ");
            }
            //result = GetList(strWhere.ToString()).Tables[0];
            result = DbHelperSQL.Query("SELECT VideoDetail.GUID AS VideoDetailGUID ,* FROM VideoDetail LEFT JOIN VideoCategory ON VideoDetail.VideoCategorGUID=VideoCategory.GUID WHERE " + strWhere.ToString()).Tables[0];
            return result;
        }
        #endregion
        #region 批量删除数据
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool ExDeleteList(string GUIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VideoDetail ");
            strSql.Append(" where GUID in (" + GUIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                string[] arrTemp = GUIDlist.Split(',');
                for (int i = 0; i < arrTemp.Length; i++)
                {
                    if (arrTemp[i].Length > 1)
                    {
                        dalVideoAttribValue.ExDeleteVideoAttribValue(arrTemp[i]);//删除当前产品对应的动态属性值
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //---------------------------------------------------------------WebUI
        public DataTable ExWebVideoDetail(string GUID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  GUID, VideoCategorGUID, VideoDetailName, VideoDetailImgeURL, VideoDetailContent, VideoDetailSource,VideoDetailAddDate from VideoDetail ");
            sb.Append("where ");
            sb.Append("VideoCategorGUID=@GUID  AND VideoDetailVisible=1  order by VideoDetailAddDate DESC ");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar)
			};
            parameters[0].Value = GUID;
            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }
        #region 获取影视的动态属性数据
        /// <summary>
        /// 获取影视的动态属性数据
        /// </summary>
        /// <param name="strWhere">查询条件，由BLL.ExGetVideoAttribList()指定</param>
        /// <returns></returns>
        public DataTable ExGetVideoAttribList(string strWhere)
        {
            DataTable result = new DataTable();
            string strSql = "";
            strSql += " SELECT VideoDetailName,VideoAttribConfigName,VideoAttribValueValue FROM ";
            strSql += " VideoAttribValue LEFT JOIN VideoAttribConfig ON VideoAttribValue.VideoAttribConfigGUID=VideoAttribConfig.GUID ";
            strSql += " LEFT JOIN VideoDetail ON VideoDetail.GUID=VideoAttribValue.VideoDetailGUID ";
            strSql += " WHERE 1=1 ";
            if (strWhere != "")
            {
                strSql += " AND " + strWhere;
            }
            try
            {
                result = DbHelperSQL.Query(strSql).Tables[0];
            }
            catch (Exception ex)
            {
                result = null;
                throw ex;
            }
            return result;
        }
        #endregion
        #region 根据指定条件返回搜索结果
        /// <summary>
        /// 根据指定条件返回搜索结果
        /// </summary>
        /// <param name="VideoDetailName">影视名称/param>
        /// <returns></returns>
        public Maticsoft.Model.VideoDetail ExGetVideoSearchA(string VideoDetailName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,VideoCategorGUID,VideoDetailName,VideoDetailImgeURL,VideoDetailContent,VideoDetailAddDate,VideoDetailSource,VideoDetailBrowseCount,VideoDetailVisible,VideoDetailSequel,HotSearch from VideoDetail ");
            strSql.Append(" where VideoDetailName=@VideoDetailName AND VideoDetailVisible=1");
            SqlParameter[] parameters = {
					new SqlParameter("@VideoDetailName", SqlDbType.NVarChar)
			};
            parameters[0].Value = VideoDetailName;

            Maticsoft.Model.VideoDetail model = new Maticsoft.Model.VideoDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
