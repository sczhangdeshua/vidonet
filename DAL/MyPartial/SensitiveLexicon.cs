using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class SensitiveLexicon
    {
        /// <summary>
        /// 判断用户是否用不能用的词
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public List<string> WordPattern()
        {
            string sql = "select WordPattern from SensitiveLexicon";
            List<string> list = null;
            using(SqlDataReader dr=DbHelperSQL.ExecuteReader(sql))
            {
                if(dr.HasRows)
                {
                    list = new List<string>();
                    while(dr.Read())
                    {
                        list.Add(dr["WordPattern"].ToString());
                    }
                }
            }
            return list;
            
        }
    }
}
