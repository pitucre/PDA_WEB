using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace CCT.DAL
{
    /// <summary>
    /// 数据访问类:FIXEDASSETINFODal
    /// </summary>
    public partial class FIXEDASSETINFODal
    {
        public FIXEDASSETINFODal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ASSETCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FIXEDASSETINFO");
            strSql.Append(" where ASSETCODE=@ASSETCODE");
            SqlParameter[] parameters = {
					new SqlParameter("@ASSETCODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ASSETCODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CCT.Model.FIXEDASSETINFOModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FIXEDASSETINFO(");
            strSql.Append("BARCODE,ASSETCODE,ASSETNAME,KUAIJILEIBIE,SHEBEILEIBIE,GUIGEXINGHAO,ZICHANZHUANGTAI,CUNFANGDIDIAN,SHIYONGBUMEN,GUYUANBIANHAO,ZICHANSHIBEIMA,BEIZHU,XULIEHAO,SUPPLIER,ADMINDEPT,ASSETCLASSIFY,JDEUPDATEDATE,JDEUPDATETIME,DATAFLAG)");
            strSql.Append(" values (");
            strSql.Append("@BARCODE,@ASSETCODE,@ASSETNAME,@KUAIJILEIBIE,@SHEBEILEIBIE,@GUIGEXINGHAO,@ZICHANZHUANGTAI,@CUNFANGDIDIAN,@SHIYONGBUMEN,@GUYUANBIANHAO,@ZICHANSHIBEIMA,@BEIZHU,@XULIEHAO,@SUPPLIER,@ADMINDEPT,@ASSETCLASSIFY,@JDEUPDATEDATE,@JDEUPDATETIME,@DATAFLAG)");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETNAME", SqlDbType.NVarChar),
					new SqlParameter("@KUAIJILEIBIE", SqlDbType.NVarChar,50),
					new SqlParameter("@SHEBEILEIBIE", SqlDbType.NVarChar,50),
					new SqlParameter("@GUIGEXINGHAO", SqlDbType.NVarChar),
					new SqlParameter("@ZICHANZHUANGTAI", SqlDbType.NVarChar,50),
					new SqlParameter("@CUNFANGDIDIAN", SqlDbType.NVarChar,50),
					new SqlParameter("@SHIYONGBUMEN", SqlDbType.NVarChar,50),
					new SqlParameter("@GUYUANBIANHAO", SqlDbType.NVarChar,50),
					new SqlParameter("@ZICHANSHIBEIMA", SqlDbType.NVarChar),
					new SqlParameter("@BEIZHU", SqlDbType.NVarChar),
					new SqlParameter("@XULIEHAO", SqlDbType.NVarChar),
					new SqlParameter("@SUPPLIER", SqlDbType.NVarChar),
                    new SqlParameter("@ADMINDEPT", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETCLASSIFY", SqlDbType.NVarChar),
                    new SqlParameter("@JDEUPDATEDATE", SqlDbType.NVarChar,50),
                    new SqlParameter("@JDEUPDATETIME", SqlDbType.NVarChar,50),
                    new SqlParameter("@DATAFLAG", SqlDbType.Int,4)};
            parameters[0].Value = model.BARCODE;
            parameters[1].Value = model.ASSETCODE;
            parameters[2].Value = model.ASSETNAME;
            parameters[3].Value = model.KUAIJILEIBIE;
            parameters[4].Value = model.SHEBEILEIBIE;
            parameters[5].Value = model.GUIGEXINGHAO;
            parameters[6].Value = model.ZICHANZHUANGTAI;
            parameters[7].Value = model.CUNFANGDIDIAN;
            parameters[8].Value = model.SHIYONGBUMEN;
            parameters[9].Value = model.GUYUANBIANHAO;
            parameters[10].Value = model.ZICHANSHIBEIMA;
            parameters[11].Value = model.BEIZHU;
            parameters[12].Value = model.XULIEHAO;
            parameters[13].Value = model.SUPPLIER;
            parameters[14].Value = model.ADMINDEPT;
            parameters[15].Value = model.ASSETCLASSIFY;
            parameters[16].Value = model.JDEUPDATEDATE;
            parameters[17].Value = model.JDEUPDATETIME;
            parameters[18].Value = model.DATAFLAG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CCT.Model.FIXEDASSETINFOModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FIXEDASSETINFO set ");
            strSql.Append("BARCODE=@BARCODE,");
            strSql.Append("ASSETCODE=@ASSETCODE,");
            strSql.Append("ASSETNAME=@ASSETNAME,");
            strSql.Append("KUAIJILEIBIE=@KUAIJILEIBIE,");
            strSql.Append("SHEBEILEIBIE=@SHEBEILEIBIE,");
            strSql.Append("GUIGEXINGHAO=@GUIGEXINGHAO,");
            strSql.Append("ZICHANZHUANGTAI=@ZICHANZHUANGTAI,");
            strSql.Append("CUNFANGDIDIAN=@CUNFANGDIDIAN,");
            strSql.Append("SHIYONGBUMEN=@SHIYONGBUMEN,");
            strSql.Append("GUYUANBIANHAO=@GUYUANBIANHAO,");
            strSql.Append("ZICHANSHIBEIMA=@ZICHANSHIBEIMA,");
            strSql.Append("BEIZHU=@BEIZHU,");
            strSql.Append("XULIEHAO=@XULIEHAO,");
            strSql.Append("SUPPLIER=@SUPPLIER,");
            strSql.Append("ADMINDEPT=@ADMINDEPT,");
            strSql.Append("ASSETCLASSIFY=@ASSETCLASSIFY,");
            strSql.Append("JDEUPDATEDATE=@JDEUPDATEDATE,");
            strSql.Append("JDEUPDATETIME=@JDEUPDATETIME,");
            strSql.Append("DATAFLAG=@DATAFLAG");
            strSql.Append(" where ASSETCODE=@ASSETCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETNAME", SqlDbType.NVarChar),
					new SqlParameter("@KUAIJILEIBIE", SqlDbType.NVarChar,50),
					new SqlParameter("@SHEBEILEIBIE", SqlDbType.NVarChar,50),
					new SqlParameter("@GUIGEXINGHAO", SqlDbType.NVarChar),
					new SqlParameter("@ZICHANZHUANGTAI", SqlDbType.NVarChar,50),
					new SqlParameter("@CUNFANGDIDIAN", SqlDbType.NVarChar,50),
					new SqlParameter("@SHIYONGBUMEN", SqlDbType.NVarChar,50),
					new SqlParameter("@GUYUANBIANHAO", SqlDbType.NVarChar,50),
					new SqlParameter("@ZICHANSHIBEIMA", SqlDbType.NVarChar),
					new SqlParameter("@BEIZHU", SqlDbType.NVarChar),
					new SqlParameter("@XULIEHAO", SqlDbType.NVarChar),
					new SqlParameter("@SUPPLIER", SqlDbType.NVarChar),
                    new SqlParameter("@ADMINDEPT", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETCLASSIFY", SqlDbType.NVarChar),
                    new SqlParameter("@JDEUPDATEDATE", SqlDbType.NVarChar,50),
                    new SqlParameter("@JDEUPDATETIME", SqlDbType.NVarChar,50),
                    new SqlParameter("@DATAFLAG", SqlDbType.Int,4)};
            parameters[0].Value = model.BARCODE;
            parameters[1].Value = model.ASSETCODE;
            parameters[2].Value = model.ASSETNAME;
            parameters[3].Value = model.KUAIJILEIBIE;
            parameters[4].Value = model.SHEBEILEIBIE;
            parameters[5].Value = model.GUIGEXINGHAO;
            parameters[6].Value = model.ZICHANZHUANGTAI;
            parameters[7].Value = model.CUNFANGDIDIAN;
            parameters[8].Value = model.SHIYONGBUMEN;
            parameters[9].Value = model.GUYUANBIANHAO;
            parameters[10].Value = model.ZICHANSHIBEIMA;
            parameters[11].Value = model.BEIZHU;
            parameters[12].Value = model.XULIEHAO;
            parameters[13].Value = model.SUPPLIER;
            parameters[14].Value = model.ADMINDEPT;
            parameters[15].Value = model.ASSETCLASSIFY;
            parameters[16].Value = model.JDEUPDATEDATE;
            parameters[17].Value = model.JDEUPDATETIME;
            parameters[18].Value = model.DATAFLAG;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBarcode(String barcode, String assetcode, String admindept, String assetclassify)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FIXEDASSETINFO set ");
            strSql.Append("BARCODE=@BARCODE,");
            strSql.Append("ADMINDEPT=@ADMINDEPT,");
            strSql.Append("ASSETCLASSIFY=@ASSETCLASSIFY");
            strSql.Append(" where ASSETCODE=@ASSETCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,50),
                    new SqlParameter("@ASSETCODE", SqlDbType.NVarChar,50),
                                        new SqlParameter("@ADMINDEPT", SqlDbType.NVarChar,50),
                                        new SqlParameter("@ASSETCLASSIFY", SqlDbType.NVarChar)};
            parameters[0].Value = barcode;
            parameters[1].Value = assetcode;
            parameters[2].Value = admindept;
            parameters[3].Value = assetclassify;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ASSETCODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FIXEDASSETINFO ");
            strSql.Append(" where ASSETCODE=@ASSETCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ASSETCODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ASSETCODE;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ASSETCODElist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FIXEDASSETINFO ");
            strSql.Append(" where ASSETCODE in (" + ASSETCODElist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CCT.Model.FIXEDASSETINFOModel GetModel(string ASSETCODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BARCODE,ASSETCODE,ASSETNAME,KUAIJILEIBIE,SHEBEILEIBIE,GUIGEXINGHAO,ZICHANZHUANGTAI,CUNFANGDIDIAN,SHIYONGBUMEN,GUYUANBIANHAO,ZICHANSHIBEIMA,BEIZHU,XULIEHAO,SUPPLIER,ADMINDEPT,ASSETCLASSIFY,JDEUPDATEDATE,JDEUPDATETIME,DATAFLAG from FIXEDASSETINFO ");
            strSql.Append(" where ASSETCODE=@ASSETCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ASSETCODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ASSETCODE;

            CCT.Model.FIXEDASSETINFOModel model = new CCT.Model.FIXEDASSETINFOModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BARCODE"] != null && ds.Tables[0].Rows[0]["BARCODE"].ToString() != "")
                {
                    model.BARCODE = ds.Tables[0].Rows[0]["BARCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ASSETCODE"] != null && ds.Tables[0].Rows[0]["ASSETCODE"].ToString() != "")
                {
                    model.ASSETCODE = ds.Tables[0].Rows[0]["ASSETCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ASSETNAME"] != null && ds.Tables[0].Rows[0]["ASSETNAME"].ToString() != "")
                {
                    model.ASSETNAME = ds.Tables[0].Rows[0]["ASSETNAME"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KUAIJILEIBIE"] != null && ds.Tables[0].Rows[0]["KUAIJILEIBIE"].ToString() != "")
                {
                    model.KUAIJILEIBIE = ds.Tables[0].Rows[0]["KUAIJILEIBIE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SHEBEILEIBIE"] != null && ds.Tables[0].Rows[0]["SHEBEILEIBIE"].ToString() != "")
                {
                    model.SHEBEILEIBIE = ds.Tables[0].Rows[0]["SHEBEILEIBIE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GUIGEXINGHAO"] != null && ds.Tables[0].Rows[0]["GUIGEXINGHAO"].ToString() != "")
                {
                    model.GUIGEXINGHAO = ds.Tables[0].Rows[0]["GUIGEXINGHAO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZICHANZHUANGTAI"] != null && ds.Tables[0].Rows[0]["ZICHANZHUANGTAI"].ToString() != "")
                {
                    model.ZICHANZHUANGTAI = ds.Tables[0].Rows[0]["ZICHANZHUANGTAI"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CUNFANGDIDIAN"] != null && ds.Tables[0].Rows[0]["CUNFANGDIDIAN"].ToString() != "")
                {
                    model.CUNFANGDIDIAN = ds.Tables[0].Rows[0]["CUNFANGDIDIAN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SHIYONGBUMEN"] != null && ds.Tables[0].Rows[0]["SHIYONGBUMEN"].ToString() != "")
                {
                    model.SHIYONGBUMEN = ds.Tables[0].Rows[0]["SHIYONGBUMEN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GUYUANBIANHAO"] != null && ds.Tables[0].Rows[0]["GUYUANBIANHAO"].ToString() != "")
                {
                    model.GUYUANBIANHAO = ds.Tables[0].Rows[0]["GUYUANBIANHAO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZICHANSHIBEIMA"] != null && ds.Tables[0].Rows[0]["ZICHANSHIBEIMA"].ToString() != "")
                {
                    model.ZICHANSHIBEIMA = ds.Tables[0].Rows[0]["ZICHANSHIBEIMA"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BEIZHU"] != null && ds.Tables[0].Rows[0]["BEIZHU"].ToString() != "")
                {
                    model.BEIZHU = ds.Tables[0].Rows[0]["BEIZHU"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XULIEHAO"] != null && ds.Tables[0].Rows[0]["XULIEHAO"].ToString() != "")
                {
                    model.XULIEHAO = ds.Tables[0].Rows[0]["XULIEHAO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SUPPLIER"] != null && ds.Tables[0].Rows[0]["SUPPLIER"].ToString() != "")
                {
                    model.SUPPLIER = ds.Tables[0].Rows[0]["SUPPLIER"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ADMINDEPT"] != null && ds.Tables[0].Rows[0]["ADMINDEPT"].ToString() != "")
                {
                    model.ADMINDEPT = ds.Tables[0].Rows[0]["ADMINDEPT"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ASSETCLASSIFY"] != null && ds.Tables[0].Rows[0]["ASSETCLASSIFY"].ToString() != "")
                {
                    model.ASSETCLASSIFY = ds.Tables[0].Rows[0]["ASSETCLASSIFY"].ToString();
                }
                if (ds.Tables[0].Rows[0]["JDEUPDATEDATE"] != null && ds.Tables[0].Rows[0]["JDEUPDATEDATE"].ToString() != "")
                {
                    model.JDEUPDATEDATE = ds.Tables[0].Rows[0]["JDEUPDATEDATE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["JDEUPDATETIME"] != null && ds.Tables[0].Rows[0]["JDEUPDATETIME"].ToString() != "")
                {
                    model.JDEUPDATETIME = ds.Tables[0].Rows[0]["JDEUPDATETIME"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DATAFLAG"] != null && ds.Tables[0].Rows[0]["DATAFLAG"].ToString() != "")
                {
                    model.DATAFLAG = int.Parse(ds.Tables[0].Rows[0]["DATAFLAG"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select BARCODE,ASSETCODE,ASSETNAME,KUAIJILEIBIE,SHEBEILEIBIE,GUIGEXINGHAO,ZICHANZHUANGTAI,CUNFANGDIDIAN,SHIYONGBUMEN,GUYUANBIANHAO,ZICHANSHIBEIMA,BEIZHU,XULIEHAO,SUPPLIER ");
            strSql.Append("select * ");
            strSql.Append(" FROM FIXEDASSETINFO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" AND DATAFLAG=0 ");
            }
            else
            {
                strSql.Append(" where DATAFLAG=0 ");
            }
            strSql.Append("  ORDER BY ASSETCODE");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 获得部门列表
        /// </summary>
        public DataSet GetDeptList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(SHIYONGBUMEN), B.DEPTNAME from FIXEDASSETINFO A left join DEPARTMENTINFO B on A.SHIYONGBUMEN=B.DEPTCODE order by A.SHIYONGBUMEN");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" BARCODE,ASSETCODE,ASSETNAME,KUAIJILEIBIE,SHEBEILEIBIE,GUIGEXINGHAO,ZICHANZHUANGTAI,CUNFANGDIDIAN,SHIYONGBUMEN,GUYUANBIANHAO,ZICHANSHIBEIMA,BEIZHU,XULIEHAO,SUPPLIER,ADMINDEPT,ASSETCLASSIFY,JDEUPDATEDATE,JDEUPDATETIME ");
            strSql.Append(" FROM FIXEDASSETINFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" AND DATAFLAG=0 ");
            }
            else
            {
                strSql.Append(" where DATAFLAG=0 ");
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "FIXEDASSETINFO";
            parameters[1].Value = "ASSETCODE";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

