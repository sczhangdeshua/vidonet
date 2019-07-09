using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class Users
    {
        #region 根据账户得到一个对象实体
        /// <summary>
        /// 根据账户得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Users GetModel(string UserAccount)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState from Users ");
            strSql.Append(" where UserAccount=@UserAccount");
            SqlParameter[] parameters = {
					new SqlParameter("@UserAccount", SqlDbType.NVarChar)
			};
            parameters[0].Value = UserAccount;

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
        #endregion
        
        #region  根据用户名称是否存在该记录
        /// <summary>
        /// 根据用户名称是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar)
			};
            parameters[0].Value = UserName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        
        #endregion

        #region 根据账户是否存在该记录
        /// <summary>
        /// 根据账户是否存在该记录
        /// </summary>
        public bool ExAccount(string UserAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where UserAccount=@UserAccount");
            SqlParameter[] parameters = {
					new SqlParameter("@UserAccount", SqlDbType.NVarChar)
			};
            parameters[0].Value = UserAccount;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion

        #region 查看邮箱是否被人注册
        /// <summary>
        /// 查看邮箱是否被人注册
        /// </summary>
        public bool ExMail(string UserMail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where UserMail=@UserMail");
            SqlParameter[] parameters = {
					new SqlParameter("@UserMail", SqlDbType.NVarChar)
			};
            parameters[0].Value = UserMail;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 根据昵称得到一个对象实体
        /// <summary>
        /// 根据昵称得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Users ExGetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState from Users ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar)
			};
            parameters[0].Value = UserName;

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
        #endregion

        #region 根据得到一个对象实体
        /// <summary>
        /// 根据得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Users ExGetModelGUID(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GUID,UserName,UserAccount,UserPassWord,UserMail,RegisterTime,LoginTime,UsersState,UsersState  from Users ");
            strSql.Append(" where GUID=@GUID");
            SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.NVarChar)
			};
            parameters[0].Value = GUID;

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
        #endregion

        #region 设置多个用户状态
        /// <summary>
        /// 设置多个用户状态
        /// </summary>
        /// <param name="GUIDList">影视GUID列表，如：111,222,333</param>
        /// <param name="VideoDetailVisible">状态，1正常，0锁定</param>
        /// <returns></returns>
        public void ExEditUsersStateAttr(string GUIDList, int UsersState)
        {
            string[] arrGUID = GUIDList.Split(',');
            StringBuilder strSql = new StringBuilder();
            string tempStr = "";
            strSql.Append("UPDATE Users SET UsersState=" + UsersState + " WHERE GUID IN (");
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
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ExDelete(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
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
        #region 获取第一次加载的和分页时保留状态
        /// <summary>
        /// 获取第一次加载的和分页时保留状态
        /// </summary>
        /// <param name="UserName">字段名</param>
        /// <param name="UserAccount">用户名</param>
        /// <param name="UserMail">邮箱</param>
        /// <param name="UsersState">用户状态</param>
        /// <returns></returns>
        public DataTable ExGetUsersList(string UserName, string UserAccount, string UserMail, string UsersState)
        {
            DataTable result = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM Users ");
            strSql.Append(" WHERE 1=1 ");
            strSql.Append(UserName + UserAccount + UserMail + UsersState);
            result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }
        #endregion
    }
}
