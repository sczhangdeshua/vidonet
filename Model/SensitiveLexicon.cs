using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// SensitiveLexicon:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SensitiveLexicon
    {
        public SensitiveLexicon()
        { }
        #region Model
        private int _id;
        private string _wordpattern;
        private bool _isforbid;
        private bool _ismod;
        private string _replaceword;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 词
        /// </summary>
        public string WordPattern
        {
            set { _wordpattern = value; }
            get { return _wordpattern; }
        }
        /// <summary>
        /// 判断是否是禁用词
        /// </summary>
        public bool IsForbid
        {
            set { _isforbid = value; }
            get { return _isforbid; }
        }
        /// <summary>
        /// 1.审查词，2.替换词
        /// </summary>
        public bool IsMod
        {
            set { _ismod = value; }
            get { return _ismod; }
        }
        /// <summary>
        /// 要替换词
        /// </summary>
        public string ReplaceWord
        {
            set { _replaceword = value; }
            get { return _replaceword; }
        }
        #endregion Model

    }
}

