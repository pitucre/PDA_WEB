using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCT.Model
{
    public partial class BARCODESETTINGModel
    {
        public BARCODESETTINGModel()
        { }
        #region Model
        private int _barcodeid;
        private string _deptcode;
        private string _assetclassify;
        private string _fixedbarcode;
        private int _maxcode;
        private string _comments;
        /// <summary>
        /// 记录ID
        /// </summary>
        public int BARCODEID
        {
            set { _barcodeid = value; }
            get { return _barcodeid; }
        }
        /// <summary>
        /// 资产管理部门
        /// </summary>
        public string DEPTCODE
        {
            set { _deptcode = value; }
            get { return _deptcode; }
        }
        /// <summary>
        /// 资产种类
        /// </summary>
        public string ASSETCLASSIFY
        {
            set { _assetclassify = value; }
            get { return _assetclassify; }
        }
        /// <summary>
        /// 固定条码
        /// </summary>
        public string FIXEDBARCODE
        {
            set { _fixedbarcode = value; }
            get { return _fixedbarcode; }
        }
        /// <summary>
        /// 条码最大值
        /// </summary>
        public int MAXCODE
        {
            set { _maxcode = value; }
            get { return _maxcode; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string COMMENTS
        {
            set { _comments = value; }
            get { return _comments; }
        }
        #endregion Model
    }
}