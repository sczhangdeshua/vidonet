using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial  class Administrator
    {
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Administrator ExGetModel(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,AdminUser,AdminAccount,AdminPasswrod,AdminLoginDate,RegisterTime from Administrator ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar)
			};
            parameters[0].Value = GUID;

            Maticsoft.Model.Administrator model = new Maticsoft.Model.Administrator();
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

        #region GUID删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ExDelete(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Administrator ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar)
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
