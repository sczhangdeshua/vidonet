using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace Maticsoft.DAL
{
    public partial class VideoAttribConfig
    {
        #region 获取含有产品动态属性的产品分类
        /// <summary>
        /// 获取含有产品动态属性的产品分类
        /// </summary>
        /// <returns></returns>
        public DataTable ExGetVideoCategoryListWithHaveVideoAttribConfig()
        {
            DataTable result = new DataTable();
            result = DbHelperSQL.Query("SELECT DISTINCT VideoAttribConfig.VideoCategoryGUID,VideoCategorName,VideoCategoryOrder FROM VideoAttribConfig  LEFT JOIN VideoCategory ON VideoCategory.GUID=VideoAttribConfig.VideoCategoryGUID ORDER BY VideoCategoryOrder ASC").Tables[0];
            return result;
        }
        #endregion
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoAttribConfig ExGetModel(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,VideoCategoryGUID,VideoAttribConfigName,VideoAttribConfigDescribe,VideoAttribConfigOrder from VideoAttribConfig ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar)
			};
            parameters[0].Value = GUID;

            Maticsoft.Model.VideoAttribConfig model = new Maticsoft.Model.VideoAttribConfig();
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
        #region 增加一条数据，如果属性名称重复，则不增加
        /// <summary>
        /// 增加一条数据，如果属性名称重复，则不增加
        /// </summary>
        public int ExAdd(Maticsoft.Model.VideoAttribConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VideoAttribConfig(");
            strSql.Append("GUID,VideoCategoryGUID,VideoAttribConfigName,VideoAttribConfigDescribe,VideoAttribConfigOrder)");
            strSql.Append(" values (");
            strSql.Append("@GUID,@VideoCategoryGUID,@VideoAttribConfigName,@VideoAttribConfigDescribe,@VideoAttribConfigOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoCategoryGUID", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoAttribConfigName", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoAttribConfigDescribe", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoAttribConfigOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.VideoCategoryGUID;
            parameters[2].Value = model.VideoAttribConfigName;
            parameters[3].Value = model.VideoAttribConfigDescribe;
            parameters[4].Value = model.VideoAttribConfigOrder;

            if (DbHelperSQL.Query("SELECT id FROM VideoAttribConfig WHERE VideoCategoryGUID='" + model.VideoCategoryGUID + "' AND VideoAttribConfigName='" + model.VideoAttribConfigName + "'").Tables[0].Rows.Count < 1)
            {
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
            else
            {
                return 0;//属性名称重复，返回0
            }
        }
        #endregion
        #region 更新一条数据，如果属性名称重复，则不更新
        /// <summary>
        /// 更新一条数据，如果属性名称重复，则不更新
        /// </summary>
        public bool ExUpdate(Maticsoft.Model.VideoAttribConfig model, Maticsoft.Model.VideoAttribConfig modelOld)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VideoAttribConfig set ");
            strSql.Append("GUID=@GUID,");
            strSql.Append("VideoCategoryGUID=@VideoCategoryGUID,");
            strSql.Append("VideoAttribConfigName=@VideoAttribConfigName,");
            strSql.Append("VideoAttribConfigDescribe=@VideoAttribConfigDescribe,");
            strSql.Append("VideoAttribConfigOrder=@VideoAttribConfigOrder");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoCategoryGUID", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoAttribConfigName", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoAttribConfigDescribe", SqlDbType.VarChar,-1),
					new SqlParameter("@VideoAttribConfigOrder", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.VideoCategoryGUID;
            parameters[2].Value = model.VideoAttribConfigName;
            parameters[3].Value = model.VideoAttribConfigDescribe;
            parameters[4].Value = model.VideoAttribConfigOrder;
            parameters[5].Value = model.ID;

            if (DbHelperSQL.Query("SELECT id FROM VideoAttribConfig WHERE VideoCategoryGUID='" + model.VideoCategoryGUID + "' AND VideoAttribConfigName!='" + modelOld.VideoAttribConfigName + "' AND VideoAttribConfigName='" + model.VideoAttribConfigName + "'").Tables[0].Rows.Count < 1)
            {
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
            else
            {
                return false;
            }
        }
        #endregion
        #region 获取指定分类中的动态属性中的最大一个排序号
        /// <summary>
        /// 获取指定分类中的动态属性中的最大一个排序号
        /// </summary>
        /// <param name="VideoCategoryGUID">所在分类的GUID</param>
        /// <returns></returns>
        public int ExGetMaxOrder(string VideoCategoryGUID)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(VideoAttribConfigOrder) AS RESULT FROM VideoAttribConfig");
            strSql.Append(" WHERE VideoCategoryGUID=@VideoCategoryGUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@VideoCategoryGUID", SqlDbType.VarChar)
			};
            parameters[0].Value = VideoCategoryGUID;
            try
            {
                result = (int)(DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0]);
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        #endregion
        #region 获取指定属性关系的影视详情数量
        public int ExGetVideoAttribCountInVideoDetail(string VideoAttribConfigGUID)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) AS RESULT FROM VideoAttribValue ");
            strSql.Append("WHERE VideoAttribConfigGUID=@VideoAttribConfigGUID");
            SqlParameter[] parameters = {
					new SqlParameter("@VideoAttribConfigGUID", SqlDbType.VarChar)
			};
            parameters[0].Value = VideoAttribConfigGUID;
            result = (int)DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0]["RESULT"];
            return result;
        }
        #endregion
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ExDelete(string GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VideoAttribConfig ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar)
			};
            parameters[0].Value = GUID;

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
        #endregion
        #region 根据产品分类GUID删除所有关联动态属性
        /// <summary>
        /// 根据产品分类GUID删除所有关联动态属性
        /// </summary>
        /// <param name="VideoCategoryGUID">产品分类GUID</param>
        /// <returns></returns>
        public bool ExDeleteByVideoCategoryGUID(string VideoCategoryGUID)
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM VideoAttribConfig ");
            strSql.Append(" WHERE VideoCategoryGUID=@VideoCategoryGUID");
            SqlParameter[] parameters = {
					new SqlParameter("@VideoCategoryGUID", SqlDbType.VarChar)
			};
            parameters[0].Value = VideoCategoryGUID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        #endregion
        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet ExGetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" NULL AS VideoAttribValueValue , ID,GUID,VideoCategoryGUID,VideoAttribConfigName,VideoAttribConfigDescribe,VideoAttribConfigOrder ");
            strSql.Append(" FROM VideoAttribConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
        #region 根据指定的影视GUID，获取影视对应分类中的动态属性列表及属性值
        /// <summary>
        /// 根据指定的影视GUID，获取影视对应分类中的动态属性列表及属性值
        /// </summary>
        /// <param name="VideoDetailGUID">影视GUID</param>
        /// <returns></returns>
        public DataTable ExGetVideoAttribConfigAndValue(string VideoDetailGUID)
        {
            DataTable result = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM ");
            strSql.Append(" (SELECT GUID,VideoAttribConfigName,VideoAttribConfigDescribe,VideoAttribConfigOrder FROM VideoAttribConfig ");
            strSql.Append(" WHERE VideoCategoryGUID= ");
            strSql.Append(" (SELECT VideoCategorGUID FROM VideoDetail WHERE GUID=@VideoDetailGUID)) ");
            strSql.Append(" AS T1 LEFT JOIN ");
            strSql.Append(" (SELECT VideoAttribConfigGUID,VideoAttribValueValue FROM VideoAttribValue ");
            strSql.Append(" WHERE VideoDetailGUID=@VideoDetailGUID) ");
            strSql.Append(" AS T2 ON T1.GUID=T2.VideoAttribConfigGUID ");
            strSql.Append(" ORDER BY T1.VideoAttribConfigOrder ASC ");
            SqlParameter[] parameters = {
                    new SqlParameter("@VideoDetailGUID", SqlDbType.VarChar)
                    };
            parameters[0].Value = VideoDetailGUID;
            result = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
            return result;
        }
        #endregion
    }
}
