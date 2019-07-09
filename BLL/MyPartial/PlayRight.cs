using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public partial class PlayRight
    {
        public Maticsoft.Model.PlayRight GetModel(string UserAccount)
        {

            return dal.GetModel(UserAccount);
        } 
        public bool ExDelete(string GUID)
        {

            return dal.ExDelete(GUID);
        }
    }
}
