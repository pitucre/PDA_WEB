using System;
namespace CCT.Model
{
    /// <summary>
    /// SHEBEILEIBIEModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SHEBEILEIBIEModel
    {
        public SHEBEILEIBIEModel()
        { }
        #region Model
        private string _leibiebianma;
        private string _leibiemingcheng;
        /// <summary>
        /// 类别编码
        /// </summary>
        public string LEIBIEBIANMA
        {
            set { _leibiebianma = value; }
            get { return _leibiebianma; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string LEIBIEMINGCHENG
        {
            set { _leibiemingcheng = value; }
            get { return _leibiemingcheng; }
        }
        #endregion Model

    }
}

