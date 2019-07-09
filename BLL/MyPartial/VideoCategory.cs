using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.BLL
{
    public partial class VideoCategory
    {
        Common.Common commom = new Common.Common();
        BLL.VideoDetail bllVideoDetail = new VideoDetail();
        DataTable dtTemp;
        DAL.VideoAttribConfig dalVideoAttribConfig = new DAL.VideoAttribConfig();
        DataRow drTemp, drTemp2;
        Model.VideoCategory modelVideoCategory = new Model.VideoCategory();
        #region 根据指定的外键，获取相关分类的列表
        /// <summary>
        /// 根据指定的外键，获取相关分类的列表
        /// <param name="FKGUID">外键，对应上级分类的主键。注意：顶级分类的外键为0</param>
        /// </summary>
        /// <returns></returns>
        public DataTable ExGetCategoryListByFK(string FKGUID)
        {
            DataTable result = new DataTable();
            result = dal.GetList(0, "VideoCategorGUID='" + FKGUID + "'", "VideoCategoryOrder ASC").Tables[0];
            return result;
        }
        #endregion
        #region 获取指定分类所包含的数据量
        /// <summary>
        /// 获取指定分类所包含的数据量
        /// </summary>
        /// <param name="VideoCategoryGUID">分类的GUID</param>
        /// <returns></returns>
        public int ExGetVideoDetailCount(string VideoCategorGUID)
        {
            int result = 0;
            VideoCategorGUID = commom.SQLFilter(VideoCategorGUID);
            result = bllVideoDetail.GetRecordCount("VideoCategorGUID='" + VideoCategorGUID + "'");
            return result;
        }
        #endregion
        #region 获取指定分类中的最大一个排序号
        /// <summary>
        /// 获取指定分类中的最大一个排序号
        /// </summary>
        /// <param name="VideoCategoryGUID">所在分类的GUID，如果是顶层分类则为0</param>
        /// <returns></returns>
        public int ExGetMaxOrder(string VideoctCategoryGUID)
        {
            int result = 0;
            result = dal.ExGetMaxOrder(VideoctCategoryGUID);
            return result;
        }
        #endregion
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.VideoCategory ExGetModel(string GUID)
        {
            return dal.ExGetModel(GUID);
        }
        #endregion
        #region 删除指定的分类，如果此分类包含下级分类或数据，则不能删除
        /// <summary>
        /// 删除指定的分类，如果此分类包含下级分类或数据，则不能删除
        /// </summary>
        /// <param name="GUID">分类GUID</param>
        /// <returns></returns>
        public bool ExDeleteVideoCategory(string GUID)
        {
            bool result = false;
            try
            {
                dtTemp = GetList("VideoCategorGUID='" + GUID + "'").Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    result = false;
                }
                else
                {
                    dtTemp = bllVideoDetail.GetList("VideoCategorGUID='" + GUID + "'").Tables[0];
                    if (dtTemp.Rows.Count > 0)
                    {
                        result = false;
                    }
                    else
                    {
                        string temp = ExGetModel(GUID).VideoCategorName;
                        result = ExDelete(GUID);//删除产品分类数据自身
                        //删除关联的产品分类动态属性
                        dalVideoAttribConfig.ExDeleteByVideoCategoryGUID(GUID);
                    }
                }
            }
            catch (Exception ex)
            {
                string temp = ExGetModel(GUID).VideoCategorName;
            }
            return result;
        }
        #endregion
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ExDelete(string GUID)
        {
            return dal.ExDelete(GUID);
        }

        #endregion
        #region 对分类菜单进行排序
        /// <summary>
        /// 对分类菜单进行排序
        /// </summary>
        /// <param name="GUID">要移动的分类的GUID</param>
        /// <param name="Direction">移动方向，例如：UP向上，DOWN向下</param>
        public void ExSetCategoryOrder(string GUID, string Direction)
        {
            switch (Direction)
            {
                case "UP"://向上移动
                    modelVideoCategory = ExGetModel(GUID);
                    dtTemp = ExGetCategoryListByFK(modelVideoCategory.VideoCategorGUID);
                    drTemp = dtTemp.Select("GUID='" + GUID + "'")[0];
                    try
                    {
                        drTemp2 = dtTemp.Select("VideoCategoryOrder<" + drTemp["VideoCategoryOrder"].ToString() + " AND VideoCategorGUID='" + (string)drTemp["VideoCategorGUID"] + "'", "VideoCategoryOrder DESC")[0];
                        int Order1, Order2, Order3;
                        Order1 = (int)drTemp["VideoCategoryOrder"];
                        Order2 = (int)drTemp2["VideoCategoryOrder"];
                        Order3 = Order1;
                        Order1 = Order2;
                        Order2 = Order3;
                        drTemp["VideoCategoryOrder"] = Order1;
                        drTemp2["VideoCategoryOrder"] = Order2;
                        modelVideoCategory = dal.DataRowToModel(drTemp);
                        if (!Update(modelVideoCategory))
                        {
                            break;
                        }
                        modelVideoCategory = dal.DataRowToModel(drTemp2);
                        if (!Update(modelVideoCategory))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                case "DOWN"://向下移动
                    modelVideoCategory = ExGetModel(GUID);
                    dtTemp = ExGetCategoryListByFK(modelVideoCategory.VideoCategorGUID);
                    drTemp = dtTemp.Select("GUID='" + GUID + "'")[0];
                    try
                    {
                        drTemp2 = dtTemp.Select("VideoCategoryOrder>" + drTemp["VideoCategoryOrder"].ToString() + " AND VideoCategorGUID='" + (string)drTemp["VideoCategorGUID"] + "'", "VideoCategoryOrder ASC")[0];
                        int Order1, Order2, Order3;
                        Order1 = (int)drTemp["VideoCategoryOrder"];
                        Order2 = (int)drTemp2["VideoCategoryOrder"];
                        Order3 = Order1;
                        Order1 = Order2;
                        Order2 = Order3;
                        drTemp["VideoCategoryOrder"] = Order1;
                        drTemp2["VideoCategoryOrder"] = Order2;
                        modelVideoCategory = dal.DataRowToModel(drTemp);
                        if (!Update(modelVideoCategory))
                        {
                            break;
                        }
                        modelVideoCategory = dal.DataRowToModel(drTemp2);
                        if (!Update(modelVideoCategory))
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

    }
}
