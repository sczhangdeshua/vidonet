using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Maticsoft.BLL
{
    public partial class SensitiveLexicon
    {
        #region 判断用户是否用不能用的词
        /// <summary>
        /// 判断用户是否用不能用的词
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool WordPattern(string UserName)
        {
            string ExUserName = "";
            int i = 0;
            while (i < UserName.Length)
            {
                ExUserName += UserName[i].ToString().Trim();
                i++;
            }
            List<string> list = dal.WordPattern();
            string rexger = string.Join("|", list.ToArray());
            rexger = rexger.Replace(@"\", @"\\").Replace("{2}", ".{0,2}");
            return Regex.IsMatch(ExUserName, rexger);
        } 
        #endregion
    }
}
