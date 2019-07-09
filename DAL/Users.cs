using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:Users
    /// </summary>
    public partial class Users
    {
        public Users()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
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
        public int Add(Maticsoft.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState)");
            strSql.Append(" values (");
            strSql.Append("@GUID,@UserName,@UserAccount,@UserPassWord,@UserMail,@RegisterTime,@LoginTime,@UsersState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserAccount", SqlDbType.NVarChar,20),
					new SqlParameter("@UserPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@UserMail", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@UsersState", SqlDbType.Int,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserAccount;
            parameters[3].Value = model.UserPassWord;
            parameters[4].Value = model.UserMail;
            parameters[5].Value = model.RegisterTime;
            parameters[6].Value = model.LoginTime;
            parameters[7].Value = model.UsersState;

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
        public bool Update(Maticsoft.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("GUID=@GUID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserAccount=@UserAccount,");
            strSql.Append("UserPassWord=@UserPassWord,");
            strSql.Append("UserMail=@UserMail,");
            strSql.Append("RegisterTime=@RegisterTime,");
            strSql.Append("LoginTime=@LoginTime,");
            strSql.Append("UsersState=@UsersState");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserAccount", SqlDbType.NVarChar,20),
					new SqlParameter("@UserPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@UserMail", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@UsersState", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserAccount;
            parameters[3].Value = model.UserPassWord;
            parameters[4].Value = model.UserMail;
            parameters[5].Value = model.RegisterTime;
            parameters[6].Value = model.LoginTime;
            parameters[7].Value = model.UsersState;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from Users ");
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
            strSql.Append("delete from Users ");
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
        public Maticsoft.Model.Users GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState from Users ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.Users model = new Maticsoft.Model.Users();
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
        public Maticsoft.Model.Users DataRowToModel(DataRow row)
        {
            Maticsoft.Model.Users model = new Maticsoft.Model.Users();
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
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserAccount"] != null)
                {
                    model.UserAccount = row["UserAccount"].ToString();
                }
                if (row["UserPassWord"] != null)
                {
                    model.UserPassWord = row["UserPassWord"].ToString();
                }
                if (row["UserMail"] != null)
                {
                    model.UserMail = row["UserMail"].ToString();
                }
                if (row["RegisterTime"] != null && row["RegisterTime"].ToString() != "")
                {
                    model.RegisterTime = DateTime.Parse(row["RegisterTime"].ToString());
                }
                if (row["LoginTime"] != null && row["LoginTime"].ToString() != "")
                {
                    model.LoginTime = DateTime.Parse(row["LoginTime"].ToString());
                }
                if (row["UsersState"] != null && row["UsersState"].ToString() != "")
                {
                    model.UsersState = int.Parse(row["UsersState"].ToString());
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
            strSql.Append("select ID,GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState ");
            strSql.Append(" FROM Users ");
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
            strSql.Append(" ID,GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState ");
            strSql.Append(" FROM Users ");
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
            strSql.Append("select count(1) FROM Users ");
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
            strSql.Append(")AS Row, T.*  from Users T ");
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
            parameters[0].Value = "Users";
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

