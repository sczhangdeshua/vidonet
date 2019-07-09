using System;
using System.Data;

namespace Maticsoft.Common
{
    /// <summary>
    /// 分页控制类
    /// </summary>
    public class Pager
    {
        #region 公共属性
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageCurrent { get; set; }

        /// <summary>
        /// 页总数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 数据总数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 首页码
        /// </summary>
        public int FirstPage { get; set; }

        /// <summary>
        /// 上一页码
        /// </summary>
        public int PreviousPage { get; set; }

        /// <summary>
        /// 下一页码
        /// </summary>
        public int NextPage { get; set; }

        /// <summary>
        /// 尾页码
        /// </summary>
        public int LastPage { get; set; }

        /// <summary>
        /// 将要用于分页的数据源
        /// </summary>
        public DataTable DataSource { get; set; }

        #endregion 公共属性

        #region 内部属性

        private int RowNumberStart;
        private int RowNumberEnd;
        private DataTable dtTemp;
        private DataRow drTemp;

        #endregion 内部属性

        #region 公共方法

        #region 初始化分页对象
        /// <summary>
        /// 初始化分页对象
        /// </summary>
        /// <param name="PageCurrent">当前页码</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="DataSource">将要用于分页的数据源</param>
        public Pager(int PageCurrent, int PageSize, DataTable DataSource)
        {
            this.PageSize = PageSize;
            this.PageCurrent = PageCurrent;
            if (DataSource == null || DataSource.Rows.Count < 1)
            {
                this.DataSource = null;
                this.RecordCount = 0;
                this.PageCount = 0;
            }
            else
            {
                this.DataSource = DataSource;
                this.RecordCount = this.DataSource.Rows.Count;
                this.PageCount = ((double)this.RecordCount / this.PageSize == Convert.ToInt32(this.RecordCount / this.PageSize)) ? (this.RecordCount / this.PageSize) : (Convert.ToInt32(this.RecordCount / this.PageSize) + 1);
            }
        }
        #endregion

        #region 获取第一页数据
        /// <summary>
        /// 获取第一页数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetFirstPage()
        {
            this.PageCurrent = 1;
            return GetPagedDataSource();
        }
        #endregion

        #region 获取上一页数据
        /// <summary>
        /// 获取上一页数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetPreviousPage()
        {
            DataTable result = new DataTable();
            this.PageCurrent--;
            if (this.PageCurrent < 1)
            {
                this.PageCurrent = 1;
            }
            result = GetPagedDataSource();
            return result;
        }
        #endregion

        #region 获取下一页数据
        /// <summary>
        /// 获取下一页数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetNextPage()
        {
            this.PageCurrent++;
            if (this.PageCurrent >= this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            return GetPagedDataSource();
        }
        #endregion

        #region 获取最后一页数据
        /// <summary>
        /// 获取最后一页数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetLastPage()
        {
            this.PageCurrent = this.PageCount;
            return GetPagedDataSource();
        }
        #endregion

        #region 获取指定页码的数据
        /// <summary>
        /// 获取指定页码的数据
        /// </summary>
        /// <param name="PageNumber">指定的页码</param>
        /// <returns></returns>
        public DataTable GetXPage(int PageNumber)
        {
            if (PageNumber>1)
            {
                PageNumber = 1;
            }
            this.PageCurrent = PageNumber;
            if (this.PageCurrent >= this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            return GetPagedDataSource();
        }
        #endregion

        #endregion 公共方法

        #region 内部方法

        #region 获取分页行号的起始值和终止值，元素为：[0]行号起始值，[1]行号终止值
        /// <summary>
        /// 获取分页行号的起始值和终止值，元素为：[0]行号起始值，[1]行号终止值
        /// </summary>
        /// <returns></returns>
        private int[] GetRowNumber()
        {
            int[] result = { 0, 0 };
            this.RowNumberStart = this.PageCurrent * this.PageSize - this.PageSize + 1;
            this.RowNumberEnd = this.PageCurrent * this.PageSize;
            result[0] = this.RowNumberStart;
            result[1] = this.RowNumberEnd;
            return result;
        }
        #endregion

        #region 获取数据源的副本，根据指定的行号起始值与终止值
        /// <summary>
        /// 获取数据源的副本，根据指定的行号起始值与终止值
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataSource()
        {
            if (this.DataSource == null || this.DataSource.Rows.Count < 1)
            {
                return null;
            }
            DataTable result = this.DataSource.Clone();
            GetRowNumber();
            for (int i = this.RowNumberStart - 1; i <= this.RowNumberEnd - 1 && i < this.RecordCount; i++)
            {
                try
                {
                    result.Rows.Add(this.DataSource.Rows[i].ItemArray);
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }
        #endregion

        #endregion 内部方法
    }//class
}
