using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class Config
    {
        #region 得到一个对象实体，根据指定的项目名称
        /// <summary>
        /// 得到一个对象实体，根据指定的项目名称
        /// </summary>
        public Maticsoft.Model.Config ExGetModel(string ConfigKey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,GUID,ConfigKey,ConfigValue from Config ");
            strSql.Append(" where ConfigKey=@ConfigKey ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigKey", SqlDbType.VarChar)
            };
            parameters[0].Value = ConfigKey;

            Maticsoft.Model.Config model = new Maticsoft.Model.Config();
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
