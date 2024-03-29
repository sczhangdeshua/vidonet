﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:VideoDetail
    /// </summary>
    public partial class VideoDetail
    {
        public VideoDetail()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VideoDetail");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.VideoDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VideoDetail(");
            strSql.Append("GUID,VideoCategorGUID,VideoDetailName,VideoDetailImgeURL,VideoDetailContent,VideoDetailAddDate,VideoDetailSource,VideoDetailBrowseCount,VideoDetailVisible,VideoDetailSequel,HotSearch)");
            strSql.Append(" values (");
            strSql.Append("@GUID,@VideoCategorGUID,@VideoDetailName,@VideoDetailImgeURL,@VideoDetailContent,@VideoDetailAddDate,@VideoDetailSource,@VideoDetailBrowseCount,@VideoDetailVisible,@VideoDetailSequel,@HotSearch)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoCategorGUID", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailName", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailImgeURL", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailContent", SqlDbType.Text),
					new SqlParameter("@VideoDetailAddDate", SqlDbType.DateTime),
					new SqlParameter("@VideoDetailSource", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailBrowseCount", SqlDbType.Int,4),
					new SqlParameter("@VideoDetailVisible", SqlDbType.Int,4),
					new SqlParameter("@VideoDetailSequel", SqlDbType.Int,4),
					new SqlParameter("@HotSearch", SqlDbType.Int,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.VideoCategorGUID;
            parameters[2].Value = model.VideoDetailName;
            parameters[3].Value = model.VideoDetailImgeURL;
            parameters[4].Value = model.VideoDetailContent;
            parameters[5].Value = model.VideoDetailAddDate;
            parameters[6].Value = model.VideoDetailSource;
            parameters[7].Value = model.VideoDetailBrowseCount;
            parameters[8].Value = model.VideoDetailVisible;
            parameters[9].Value = model.VideoDetailSequel;
            parameters[10].Value = model.HotSearch;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.VideoDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VideoDetail set ");
            strSql.Append("GUID=@GUID,");
            strSql.Append("VideoCategorGUID=@VideoCategorGUID,");
            strSql.Append("VideoDetailName=@VideoDetailName,");
            strSql.Append("VideoDetailImgeURL=@VideoDetailImgeURL,");
            strSql.Append("VideoDetailContent=@VideoDetailContent,");
            strSql.Append("VideoDetailAddDate=@VideoDetailAddDate,");
            strSql.Append("VideoDetailSource=@VideoDetailSource,");
            strSql.Append("VideoDetailBrowseCount=@VideoDetailBrowseCount,");
            strSql.Append("VideoDetailVisible=@VideoDetailVisible,");
            strSql.Append("VideoDetailSequel=@VideoDetailSequel,");
            strSql.Append("HotSearch=@HotSearch");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoCategorGUID", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailName", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailImgeURL", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailContent", SqlDbType.Text),
					new SqlParameter("@VideoDetailAddDate", SqlDbType.DateTime),
					new SqlParameter("@VideoDetailSource", SqlDbType.NVarChar,-1),
					new SqlParameter("@VideoDetailBrowseCount", SqlDbType.Int,4),
					new SqlParameter("@VideoDetailVisible", SqlDbType.Int,4),
					new SqlParameter("@VideoDetailSequel", SqlDbType.Int,4),
					new SqlParameter("@HotSearch", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.VideoCategorGUID;
            parameters[2].Value = model.VideoDetailName;
            parameters[3].Value = model.VideoDetailImgeURL;
            parameters[4].Value = model.VideoDetailContent;
            parameters[5].Value = model.VideoDetailAddDate;
            parameters[6].Value = model.VideoDetailSource;
            parameters[7].Value = model.VideoDetailBrowseCount;
            parameters[8].Value = model.VideoDetailVisible;
            parameters[9].Value = model.VideoDetailSequel;
            parameters[10].Value = model.HotSearch;
            parameters[11].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VideoDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VideoDetail ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoDetail GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,VideoCategorGUID,VideoDetailName,VideoDetailImgeURL,VideoDetailContent,VideoDetailAddDate,VideoDetailSource,VideoDetailBrowseCount,VideoDetailVisible,VideoDetailSequel,HotSearch from VideoDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoDetail DataRowToModel(DataRow row)
        {
            Maticsoft.Model.VideoDetail model = new Maticsoft.Model.VideoDetail();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["GUID"] != null)
                {
                    model.GUID = row["GUID"].ToString();
                }
                if (row["VideoCategorGUID"] != null)
                {
                    model.VideoCategorGUID = row["VideoCategorGUID"].ToString();
                }
                if (row["VideoDetailName"] != null)
                {
                    model.VideoDetailName = row["VideoDetailName"].ToString();
                }
                if (row["VideoDetailImgeURL"] != null)
                {
                    model.VideoDetailImgeURL = row["VideoDetailImgeURL"].ToString();
                }
                if (row["VideoDetailContent"] != null)
                {
                    model.VideoDetailContent = row["VideoDetailContent"].ToString();
                }
                if (row["VideoDetailAddDate"] != null && row["VideoDetailAddDate"].ToString() != "")
                {
                    model.VideoDetailAddDate = DateTime.Parse(row["VideoDetailAddDate"].ToString());
                }
                if (row["VideoDetailSource"] != null)
                {
                    model.VideoDetailSource = row["VideoDetailSource"].ToString();
                }
                if (row["VideoDetailBrowseCount"] != null && row["VideoDetailBrowseCount"].ToString() != "")
                {
                    model.VideoDetailBrowseCount = int.Parse(row["VideoDetailBrowseCount"].ToString());
                }
                if (row["VideoDetailVisible"] != null && row["VideoDetailVisible"].ToString() != "")
                {
                    model.VideoDetailVisible = int.Parse(row["VideoDetailVisible"].ToString());
                }
                if (row["VideoDetailSequel"] != null && row["VideoDetailSequel"].ToString() != "")
                {
                    model.VideoDetailSequel = int.Parse(row["VideoDetailSequel"].ToString());
                }
                if (row["HotSearch"] != null && row["HotSearch"].ToString() != "")
                {
                    model.HotSearch = int.Parse(row["HotSearch"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GUID,VideoCategorGUID,VideoDetailName,VideoDetailImgeURL,VideoDetailContent,VideoDetailAddDate,VideoDetailSource,VideoDetailBrowseCount,VideoDetailVisible,VideoDetailSequel,HotSearch ");
            strSql.Append(" FROM VideoDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,GUID,VideoCategorGUID,VideoDetailName,VideoDetailImgeURL,VideoDetailContent,VideoDetailAddDate,VideoDetailSource,VideoDetailBrowseCount,VideoDetailVisible,VideoDetailSequel,HotSearch ");
            strSql.Append(" FROM VideoDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM VideoDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from VideoDetail T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "VideoDetail";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

