using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class VideoAttribValue
    {
        #region 删除指定影视GUID的所有动态属性值
        /// <summary>
        /// 删除指定影视GUID的所有动态属性值
        /// </summary>
        /// <param name="VideoDetailGUID">影视GUID</param>
        public void ExDeleteVideoAttribValue(string VideoDetailGUID)
        {
            DbHelperSQL.ExecuteSql("DELETE FROM VideoAttribValue WHERE VideoDetailGUID ='" + VideoDetailGUID.Trim('\'') + "'");
        }
        #endregion
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet ExGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select VideoAttribValueValue ");
            strSql.Append(" FROM VideoAttribValue ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
