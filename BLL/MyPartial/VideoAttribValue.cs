using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Maticsoft.BLL
{
    public partial class VideoAttribValue
    {
        Model.VideoAttribValue modelVideoAttribValue = new Model.VideoAttribValue();
        #region 插入动态属性值，插入之前先删除影视GUID对应的所有旧属性值
        /// <summary>
        /// 插入动态属性值，插入之前先删除影视GUID对应的所有旧属性值
        /// </summary>
        /// <param name="VideoDetailGUID">影视详情GUID</param>
        /// <param name="VideoAttribConfigGUIDList">动态属性GUID列表，如GUID1,GUID2,...</param>
        /// <param name="VideoAttribValueValueList">动态属性值列表，如value1,value2,...</param>
        /// <returns></returns>
        public bool ExAdd(string VideoDetailGUID, string VideoAttribConfigGUIDList, string VideoAttribValueValueList)
        {
            bool result = true;
            dal.ExDeleteVideoAttribValue(VideoDetailGUID);
            try
            {
                string[] arrVideoAttribConfigGUID = VideoAttribConfigGUIDList.Split(',');
                string[] arrVideoAttribValueValue = VideoAttribValueValueList.Split(',');
                for (int i = 0; i < arrVideoAttribConfigGUID.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arrVideoAttribValueValue[i]))
                    {
                        modelVideoAttribValue.GUID = Guid.NewGuid().ToString();
                        modelVideoAttribValue.VideoDetailGUID = VideoDetailGUID;
                        modelVideoAttribValue.VideoAttribConfigGUID = arrVideoAttribConfigGUID[i];
                        modelVideoAttribValue.VideoAttribValueValue = arrVideoAttribValueValue[i];
                        dal.Add(modelVideoAttribValue);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        #endregion
       
    }
}

