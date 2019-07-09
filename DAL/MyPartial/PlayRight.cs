using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class PlayRight
    {
        public Maticsoft.Model.PlayRight GetModel(string UserAccount)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,UserAccount,ExpireTime,HeadPortrait,WatchRecord from PlayRight ");
            strSql.Append(" where UserAccount=@UserAccount");
            SqlParameter[] parameters = {
					new SqlParameter("@UserAccount", SqlDbType.NVarChar)
			};
            parameters[0].Value = UserAccount;

            Maticsoft.Model.PlayRight model = new Maticsoft.Model.PlayRight();
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
        public bool ExDelete(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PlayRight ");
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
    }
}
