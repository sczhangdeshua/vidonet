using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public partial class Information
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Information ExGetModel(string GUID)
        {

            return dal.ExGetModel(GUID);
        }
    }
}
