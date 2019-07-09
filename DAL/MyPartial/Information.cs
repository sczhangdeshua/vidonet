using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class Information
    {
        public Maticsoft.Model.Information ExGetModel(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GUID,FromAccton,Credentials,EailSuffix from Information ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar,-1)
                                        };
            parameters[0].Value = GUID;
            Maticsoft.Model.Information model = new Maticsoft.Model.Information();
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
    }
}
