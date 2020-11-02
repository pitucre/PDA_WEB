using System;
namespace CCT.Model
{
    /// <summary>
    /// ZICHANZHUANGTAIModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ZICHANZHUANGTAIModel
    {
        public ZICHANZHUANGTAIModel()
        { }
        #region Model
        private string _zhuangtaicode;
        private string _zhuangtaimingcheng;
        /// <summary>
        /// 状态编码
        /// </summary>
        public string ZHUANGTAICODE
        {
            set { _zhuangtaicode = value; }
            get { return _zhuangtaicode; }
        }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string ZHUANGTAIMINGCHENG
        {
            set { _zhuangtaimingcheng = value; }
            get { return _zhuangtaimingcheng; }
        }
        #endregion Model

    }
}

