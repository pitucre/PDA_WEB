using System;
namespace CCT.Model
{
    /// <summary>
    /// FIXEDASSETINFOModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class FIXEDASSETINFOModel
    {
        public FIXEDASSETINFOModel()
        { }
        #region Model
        private string _barcode;
        private string _assetcode;
        private string _assetname;
        private string _kuaijileibie;
        private string _kuaijileibiename;
        private string _shebeileibie;
        private string _shebeileibiename;
        private string _guigexinghao;
        private string _zichanzhuangtai;
        private string _zichanzhuangtainame;
        private string _cunfangdidian;
        private string _cunfangdidianname;
        private string _shiyongbumen;
        private string _shiyongbumenname;
        private string _guyuanbianhao;
        private string _guyuanbianhaoname;
        private string _zichanshibeima;
        private string _beizhu;
        private string _xuliehao;
        private string _supplier;
        private string _admindept;
        private string _assetclassify;
        private string _jdeupdatedate;
        private string _jdeupdatetime;
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
        /// 资产编码（资产号）
        /// </summary>
        public string ASSETCODE
        {
            set { _assetcode = value; }
            get { return _assetcode; }
        }
        /// <summary>
        /// 资产名称（资产说明）
        /// </summary>
        public string ASSETNAME
        {
            set { _assetname = value; }
            get { return _assetname; }
        }
        /// <summary>
        /// 会计类别（会计类）
        /// </summary>
        public string KUAIJILEIBIE
        {
            set { _kuaijileibie = value; }
            get { return _kuaijileibie; }
        }
        /// <summary>
        /// 会计类别名称
        /// </summary>
        public string KUAIJILEIBIENAME
        {
            set { _kuaijileibiename = value; }
            get { return _kuaijileibiename; }
        }
        /// <summary>
        /// 设备类别（设备类）
        /// </summary>
        public string SHEBEILEIBIE
        {
            set { _shebeileibie = value; }
            get { return _shebeileibie; }
        }
        /// <summary>
        /// 设备类别名称
        /// </summary>
        public string SHEBEILEIBIENAME
        {
            set { _shebeileibiename = value; }
            get { return _shebeileibiename; }
        }
        /// <summary>
        /// 规格型号（注释行2）
        /// </summary>
        public string GUIGEXINGHAO
        {
            set { _guigexinghao = value; }
            get { return _guigexinghao; }
        }
        /// <summary>
        /// 资产状态（状态）
        /// </summary>
        public string ZICHANZHUANGTAI
        {
            set { _zichanzhuangtai = value; }
            get { return _zichanzhuangtai; }
        }
        /// <summary>
        /// 资产状态名称
        /// </summary>
        public string ZICHANZHUANGTAINAME
        {
            set { _zichanzhuangtainame = value; }
            get { return _zichanzhuangtainame; }
        }
        /// <summary>
        /// 存放地点（地点）
        /// </summary>
        public string CUNFANGDIDIAN
        {
            set { _cunfangdidian = value; }
            get { return _cunfangdidian; }
        }
        /// <summary>
        /// 存放地点名称
        /// </summary>
        public string CUNFANGDIDIANNAME
        {
            set { _cunfangdidianname = value; }
            get { return _cunfangdidianname; }
        }
        /// <summary>
        /// 使用部门（经营单位）
        /// </summary>
        public string SHIYONGBUMEN
        {
            set { _shiyongbumen = value; }
            get { return _shiyongbumen; }
        }
        /// <summary>
        /// 使用部门名称
        /// </summary>
        public string SHIYONGBUMENNAME
        {
            set { _shiyongbumenname = value; }
            get { return _shiyongbumenname; }
        }
        /// <summary>
        /// 雇员编号（地址号）
        /// </summary>
        public string GUYUANBIANHAO
        {
            set { _guyuanbianhao = value; }
            get { return _guyuanbianhao; }
        }
        /// <summary>
        /// 雇员编号名称
        /// </summary>
        public string GUYUANBIANHAONAME
        {
            set { _guyuanbianhaoname = value; }
            get { return _guyuanbianhaoname; }
        }
        /// <summary>
        /// 资产识别码（第二项目号）
        /// </summary>
        public string ZICHANSHIBEIMA
        {
            set { _zichanshibeima = value; }
            get { return _zichanshibeima; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string BEIZHU
        {
            set { _beizhu = value; }
            get { return _beizhu; }
        }
        /// <summary>
        /// 序列号
        /// </summary>
        public string XULIEHAO
        {
            set { _xuliehao = value; }
            get { return _xuliehao; }
        }
        /// <summary>
        /// 供应商(注释）
        /// </summary>
        public string SUPPLIER
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 管理部门
        /// </summary>
        public string ADMINDEPT
        {
            set { _admindept = value; }
            get { return _admindept; }
        }
        /// <summary>
        /// 资产分类
        /// </summary>
        public string ASSETCLASSIFY
        {
            set { _assetclassify = value; }
            get { return _assetclassify; }
        }
        /// <summary>
        /// JDE系统中记录的更新日期
        /// </summary>
        public string JDEUPDATEDATE
        {
            set { _jdeupdatedate = value; }
            get { return _jdeupdatedate; }
        }
        /// <summary>
        /// JDE系统中记录的更新时间
        /// </summary>
        public string JDEUPDATETIME
        {
            set { _jdeupdatetime = value; }
            get { return _jdeupdatetime; }
        }

        /// <summary>
        /// 删除标记：0未删除 -1已删除
        /// </summary>
        public int DATAFLAG
        {
            set { _dataflag = value; }
            get { return _dataflag; }
        }
        #endregion Model

    }
}

