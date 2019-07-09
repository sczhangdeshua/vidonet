using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.BLL
{
    public partial class Config
    {
        Common.Common common = new Common.Common();
        Model.Config modelConfig = new Model.Config();
        DataTable dtTemp;
        #region 获取各项系统设置的数据值清单，根据指定的项目名称清单
        /// <summary>
        /// 获取各项系统设置的数据值清单，根据指定的项目名称清单
        /// </summary>
        /// <param name="ConfigKeyList">项目名称清单，如 网站名称,PC端首页网址,...</param>
        /// <returns>返回数据值清单，如 网站名称@百度,PC端首页网址@http://www.baidu.com,...</returns>
        public string ExGetConfigValueList(string ConfigKeyList)
        {
            string Result = "";
            ConfigKeyList = common.SQLFilter(ConfigKeyList);
            ConfigKeyList = "'" + ConfigKeyList.Replace(",", "','") + "'";
            dtTemp = GetList("ConfigKey IN (" + ConfigKeyList + ")").Tables[0];
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                Result += dtTemp.Rows[i]["ConfigKey"].ToString() + "@" + dtTemp.Rows[i]["ConfigValue"].ToString() + ",";
            }
            if (Result.Length > 1)
            {
                Result = Result.Substring(0, Result.Length - 1);
            }
            return Result;
        }
        #endregion

        #region 保存各项系统设置
        /// <summary>
        /// 保存各项系统设置
        /// </summary>
        /// <param name="ConfigValue">项目名称和数据值的组合，格式ConfigKey@ConfigValue,...，如 网站名称@百度,PC端网址@http://www.baidu.com,...</param>
        public void ExSaveConfig(string ConfigValue)
        {
            try
            {
                string[] ArrTemp = ConfigValue.Split(',');
                string[] ArrTemp2;
                for (int i = 0; i < ArrTemp.Length; i++)
                {
                    ArrTemp2 = ArrTemp[i].Split('@');
                    modelConfig = ExGetModel(ArrTemp2[0]);
                    if (modelConfig != null)
                    {
                        //数据库中已有当前项目名称，则仅修改数据值
                        modelConfig.ConfigValue = "";
                        for (int j = 1; j < ArrTemp2.Length; j++)
                        {
                            modelConfig.ConfigValue += ArrTemp2[j] + "@";
                        }
                        modelConfig.ConfigValue = modelConfig.ConfigValue.Substring(0, modelConfig.ConfigValue.Length - 1);
                        dal.Update(modelConfig);
                    }
                    else
                    {
                        //数据库中无当前项目名称，则新建项目名称和对应的数据值
                        modelConfig = new Model.Config();
                        modelConfig.GUID = Guid.NewGuid().ToString();
                        modelConfig.ConfigKey = ArrTemp2[0];
                        modelConfig.ConfigValue = ArrTemp2[1];
                        dal.Add(modelConfig);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region 得到一个对象实体，根据指定的项目名称
        /// <summary>
        /// 得到一个对象实体，根据指定的项目名称
        /// </summary>
        public Maticsoft.Model.Config ExGetModel(string ConfigKey)
        {

            return dal.ExGetModel(ConfigKey);
        }
        #endregion
        #region 获取指定配置项的数据值，如果未找到数据值则返回空串
        /// <summary>
        /// 获取指定配置项的数据值，如果未找到数据值则返回空串
        /// </summary>
        /// <param name="ConfigKey">项目名称</param>
        /// <returns></returns>
        public string ExGetConfigValue(string ConfigKey)
        {
            string result = "";
            try
            {
                result = dal.GetList("ConfigKey='" + ConfigKey + "'").Tables[0].Rows[0]["ConfigValue"].ToString();
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        }
        #endregion
    }
}
