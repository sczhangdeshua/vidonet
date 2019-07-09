using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.BLL
{
    public partial class VideoAttribConfig
    {
        Model.VideoAttribConfig modelVideoAttribConfig = new Model.VideoAttribConfig();
        DataTable dtTemp;
        DataRow drTemp, drTemp2;
        #region 获取含有产品动态属性的产品分类
        /// <summary>
        /// 获取含有影视动态属性的产品分类
        /// </summary>
        /// <returns></returns>
        public DataTable ExGetVideoCategoryListWithHaveVideoAttribConfig()
        {
            DataTable result = new DataTable();
            result = dal.ExGetVideoCategoryListWithHaveVideoAttribConfig();
            return result;
        }
        #endregion
        #region 批量复制动态属性，并返回复制成功的个数
        /// <summary>
        /// 批量复制动态属性，并返回复制成功的个数
        /// 说明：如果返回的个数为零，代表源属性与目标属性全部重名，并不代表操作失败
        /// 操作失败时返回-1
        /// </summary>
        /// <param name="SourceVideoAttribConfigGUIDList">动态属性列表，如guid1,guid2....</param>
        /// <param name="TargetVideoCategoryGUID">动态属性所在的目标产品分类GUID</param>
        /// <returns></returns>
        public int ExCopyVideoAttribConfig(string SourceVideoAttribConfigGUIDList, string TargetVideoCategoryGUID)
        {
            int result = 0;
            string[] ArrVideoAttribConfigGUIDList = SourceVideoAttribConfigGUIDList.Split(',');
            if (ArrVideoAttribConfigGUIDList.Length < 1)
            {
                result = -1;
                return result;
            }
            for (int i = 0; i < ArrVideoAttribConfigGUIDList.Length; i++)
            {
                try
                {
                    modelVideoAttribConfig = dal.ExGetModel(ArrVideoAttribConfigGUIDList[i]);
                    modelVideoAttribConfig.VideoCategoryGUID = TargetVideoCategoryGUID;
                    modelVideoAttribConfig.GUID = Guid.NewGuid().ToString();
                    if (dal.ExAdd(modelVideoAttribConfig) > 0)
                    {
                        result++;//现有动态属性的属性名称不能和新复制的属性名称重复
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            if (result >= 0)
            {
            }
            return result;
        }
        #endregion
        #region 对动态属性进行排序
        /// <summary>
        /// 对动态属性进行排序
        /// </summary>
        /// <param name="GUID">要移动的属性的GUID</param>
        /// <param name="Direction">移动方向，例如：UP向上，DOWN向下</param>
        public void ExSetVideoAttribConfigOrder(string GUID, string Direction)
        {
            switch (Direction)
            {
                case "UP"://向上移动
                    modelVideoAttribConfig = ExGetModel(GUID);
                    dtTemp = GetList("VideoCategoryGUID='" + modelVideoAttribConfig.VideoCategoryGUID + "'").Tables[0];
                    drTemp = dtTemp.Select("GUID='" + GUID + "'")[0];
                    try
                    {
                        drTemp2 = dtTemp.Select("VideoAttribConfigOrder<" + drTemp["VideoAttribConfigOrder"].ToString() + " AND VideoCategoryGUID='" + (string)drTemp["VideoCategoryGUID"] + "'", "VideoAttribConfigOrder DESC")[0];
                        int Order1, Order2, Order3;
                        Order1 = (int)drTemp["VideoAttribConfigOrder"];
                        Order2 = (int)drTemp2["VideoAttribConfigOrder"];
                        Order3 = Order1;
                        Order1 = Order2;
                        Order2 = Order3;
                        drTemp["VideoAttribConfigOrder"] = Order1;
                        drTemp2["VideoAttribConfigOrder"] = Order2;
                        modelVideoAttribConfig = dal.DataRowToModel(drTemp);
                        if (!Update(modelVideoAttribConfig))
                        {
                            break;
                        }
                        modelVideoAttribConfig = dal.DataRowToModel(drTemp2);
                        if (!Update(modelVideoAttribConfig))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                case "DOWN"://向下移动
                    modelVideoAttribConfig = ExGetModel(GUID);
                    dtTemp = GetList("VideoCategoryGUID='" + modelVideoAttribConfig.VideoCategoryGUID + "'").Tables[0];
                    drTemp = dtTemp.Select("GUID='" + GUID + "'")[0];
                    try
                    {
                        drTemp2 = dtTemp.Select("VideoAttribConfigOrder>" + drTemp["VideoAttribConfigOrder"].ToString() + " AND VideoCategoryGUID='" + (string)drTemp["VideoCategoryGUID"] + "'", "VideoAttribConfigOrder ASC")[0];
                        int Order1, Order2, Order3;
                        Order1 = (int)drTemp["VideoAttribConfigOrder"];
                        Order2 = (int)drTemp2["VideoAttribConfigOrder"];
                        Order3 = Order1;
                        Order1 = Order2;
                        Order2 = Order3;
                        drTemp["VideoAttribConfigOrder"] = Order1;
                        drTemp2["VideoAttribConfigOrder"] = Order2;
                        modelVideoAttribConfig = dal.DataRowToModel(drTemp);
                        if (!Update(modelVideoAttribConfig))
                        {
                            break;
                        }
                        modelVideoAttribConfig = dal.DataRowToModel(drTemp2);
                        if (!Update(modelVideoAttribConfig))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
            }
        }
        #endregion
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoAttribConfig ExGetModel(string GUID)
        {

            return dal.ExGetModel(GUID);
        }
        #endregion
        #region 更新一条数据，如果属性名称重复，则不更新
        /// <summary>
        /// 更新一条数据，如果属性名称重复，则不更新
        /// </summary>
        public bool ExUpdate(Maticsoft.Model.VideoAttribConfig model, Maticsoft.Model.VideoAttribConfig modelOld)
        {
            return dal.ExUpdate(model, modelOld);
        }
        #endregion
        #region 获取指定分类中的动态属性中的最大一个排序号
        /// <summary>
        /// 获取指定分类中的动态属性中的最大一个排序号
        /// </summary>
        /// <param name="VideoCategoryGUID">所在分类的GUID</param>
        /// <returns></returns>
        public int ExGetMaxOrder(string VideoCategoryGUID)
        {
            int result = 0;
            result = dal.ExGetMaxOrder(VideoCategoryGUID);
            return result;
        }
        #endregion
        #region 增加一条数据，如果属性名称重复，则不增加
        /// <summary>
        /// 增加一条数据，如果属性名称重复，则不增加
        /// </summary>
        public int ExAdd(Maticsoft.Model.VideoAttribConfig model)
        {
            return dal.ExAdd(model);
        }
        #endregion
        #region 获取指定属性关系的影视详情数量
        public int ExGetVideoAttribCountInVideoDetail(string VideoAttribConfigGUID)
        {
            int result = 0;
            result = dal.ExGetVideoAttribCountInVideoDetail(VideoAttribConfigGUID);
            return result;
        }
        #endregion
        #region 删除一条数据，根据自身GUID
        /// <summary>
        /// 删除一条数据，根据自身GUID
        /// </summary>
        public bool ExDelete(string GUID)
        {

            return dal.ExDelete(GUID);
        }
        #endregion
        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet ExGetList(int Top, string strWhere, string filedOrder)
        {
            return dal.ExGetList(Top, strWhere, filedOrder);
        } 
        #endregion
        #region 根据指定的影视GUID，获取影视对应分类中的动态属性列表及属性值
        /// <summary>
        /// 根据指定的影视GUID，获取影视对应分类中的动态属性列表及属性值
        /// </summary>
        /// <param name="VideoDetailGUID">影视GUID</param>
        /// <returns></returns>
        public DataTable ExGetVideoAttribConfigAndValue(string VideoDetailGUID)
        {
            DataTable result = new DataTable();
            result = dal.ExGetVideoAttribConfigAndValue(VideoDetailGUID);
            return result;
        }
        #endregion
    }
}
