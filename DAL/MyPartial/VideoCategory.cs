using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class VideoCategory
    {
        #region 获取指定分类中的最大一个排序号
        /// <summary>
        /// 获取指定分类中的最大一个排序号
        /// </summary>
        /// <param name="ProductCategoryGUID">所在分类的GUID，如果是顶层分类则为0</param>
        /// <returns></returns>
        public int ExGetMaxOrder(string VideoCategoryGUID)
        {
            int result = 0;
            //执行自定义SQL命令流程
            //第一步：定义SQL命令主体字符串
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(VideoCategoryOrder) AS RESULT FROM VideoCategory");
            strSql.Append(" WHERE VideoCategorGUID=@VideoCategoryGUID ");
            //第二步：定义SQL参数传递
            SqlParameter[] parameters = {
					new SqlParameter("@VideoCategoryGUID", SqlDbType.NVarChar)
			};
            parameters[0].Value = VideoCategoryGUID;
            //第三步：调用DBUtility类库中的相关数据底层类最终执行SQL命令
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
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoCategory ExGetModel(string GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,VideoCategorGUID,VideoCategorName,VideoCategoryDescribe,VideoCategoryOrder from VideoCategory ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar)
			};
            parameters[0].Value = GUID;

            Maticsoft.Model.VideoCategory model = new Maticsoft.Model.VideoCategory();
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
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ExDelete(string GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VideoCategory ");
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
    }
}
