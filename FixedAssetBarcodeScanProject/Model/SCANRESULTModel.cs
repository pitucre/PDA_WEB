using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCT.Model
{
    /// <summary>
    /// SCANRESULTModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SCANRESULTModel
    {
        public SCANRESULTModel()
        { }
        #region Model
        private string _barcode;
        private string _assetcode;
        private int? _result;
        private string _comments;
        private string _scanperson;
        private DateTime? _scantime;
        private int _dataflag;
        /// <summary>
        /// 条形码
        /// </summary>
        public string BARCODE
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 资产编码
        /// </summary>
        public string ASSETCODE
        {
            set { _assetcode = value; }
            get { return _assetcode; }
        }
        /// <summary>
        /// 盘点结果（1:正确 0:有误 -1:资产不存在）
        /// </summary>
        public int? RESULT
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string COMMENTS
        {
            set { _comments = value; }
            get { return _comments; }
        }
        /// <summary>
        /// 盘点人员
        /// </summary>
        public string SCANPERSON
        {
            set { _scanperson = value; }
            get { return _scanperson; }
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? SCANTIME
        {
            set { _scantime = value; }
            get { return _scantime; }
        }

        /// <summary>
        /// 标记扫描数据是否过期（0：未过期  -1：已过期）
        /// </summary>
        public int DATAFLAG
        {
            set { _dataflag = value; }
            get { return _dataflag; }
        }
        #endregion Model

    }
}