using System;
namespace CCT.Model
{
    /// <summary>
    /// DEPARTMENTINFOModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DEPARTMENTINFOModel
    {
        public DEPARTMENTINFOModel()
        { }
        #region Model
        private string _deptcode;
        private string _deptname;
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DEPTCODE
        {
            set { _deptcode = value; }
            get { return _deptcode; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEPTNAME
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        #endregion Model

    }
}

