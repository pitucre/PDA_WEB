using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CCT.Model;

namespace CCT.DAL
{
    public partial class BARCODESETTINGDal
    {
        public BARCODESETTINGDal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BARCODEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BARCODESETTING");
            strSql.Append(" where BARCODEID=@BARCODEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODEID", SqlDbType.Int,4)};
            parameters[0].Value = BARCODEID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CCT.Model.BARCODESETTINGModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BARCODESETTING(");
            strSql.Append("BARCODEID,DEPTCODE,ASSETCLASSIFY,FIXEDBARCODE,MAXCODE,COMMENTS)");
            strSql.Append(" values (");
            strSql.Append("@BARCODEID,@DEPTCODE,@ASSETCLASSIFY,@FIXEDBARCODE,@MAXCODE,@COMMENTS)");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODEID", SqlDbType.Int,4),
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETCLASSIFY", SqlDbType.NVarChar),
					new SqlParameter("@FIXEDBARCODE", SqlDbType.NVarChar,10),
					new SqlParameter("@MAXCODE", SqlDbType.Int,4),
                    new SqlParameter("@COMMENTS", SqlDbType.NVarChar)};
            parameters[0].Value = model.BARCODEID;
            parameters[1].Value = model.DEPTCODE;
            parameters[2].Value = model.ASSETCLASSIFY;
            parameters[3].Value = model.FIXEDBARCODE;
            parameters[4].Value = model.MAXCODE;
            parameters[5].Value = model.COMMENTS;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CCT.Model.BARCODESETTINGModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BARCODESETTING set ");
            strSql.Append("BARCODEID=@BARCODEID,");
            strSql.Append("DEPTCODE=@DEPTCODE,");
            strSql.Append("ASSETCLASSIFY=@ASSETCLASSIFY,");
            strSql.Append("FIXEDBARCODE=@FIXEDBARCODE,");
            strSql.Append("MAXCODE=@MAXCODE,");
            strSql.Append("COMMENTS=@COMMENTS");
            strSql.Append(" where BARCODEID=@BARCODEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODEID", SqlDbType.Int,4),
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ASSETCLASSIFY", SqlDbType.NVarChar),
					new SqlParameter("@FIXEDBARCODE", SqlDbType.NVarChar,10),
					new SqlParameter("@MAXCODE", SqlDbType.Int,4),
                    new SqlParameter("@COMMENTS", SqlDbType.NVarChar)};
            parameters[0].Value = model.BARCODEID;
            parameters[1].Value = model.DEPTCODE;
            parameters[2].Value = model.ASSETCLASSIFY;
            parameters[3].Value = model.FIXEDBARCODE;
            parameters[4].Value = model.MAXCODE;
            parameters[5].Value = model.COMMENTS;

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
        public bool Delete(int BARCODEID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BARCODESETTING ");
            strSql.Append(" where BARCODEID=@BARCODEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODEID", SqlDbType.Int,4)};
            parameters[0].Value = BARCODEID;

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
        public bool DeleteList(string BARCODEIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BARCODESETTING ");
            strSql.Append(" where BARCODEID in (" + BARCODEIDlist + ")  ");
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
        public CCT.Model.BARCODESETTINGModel GetModel(int BARCODEID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BARCODEID,DEPTCODE,ASSETCLASSIFY,FIXEDBARCODE,MAXCODE,COMMENTS from BARCODESETTING ");
            strSql.Append(" where BARCODEID=@BARCODEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODEID", SqlDbType.Int,4)};
            parameters[0].Value = BARCODEID;

            CCT.Model.BARCODESETTINGModel model = new CCT.Model.BARCODESETTINGModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BARCODEID"] != null && ds.Tables[0].Rows[0]["BARCODEID"].ToString() != "")
                {
                    model.BARCODEID = int.Parse(ds.Tables[0].Rows[0]["BARCODEID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DEPTCODE"] != null && ds.Tables[0].Rows[0]["DEPTCODE"].ToString() != "")
                {
                    model.DEPTCODE = ds.Tables[0].Rows[0]["DEPTCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ASSETCLASSIFY"] != null && ds.Tables[0].Rows[0]["ASSETCLASSIFY"].ToString() != "")
                {
                    model.ASSETCLASSIFY = ds.Tables[0].Rows[0]["ASSETCLASSIFY"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FIXEDBARCODE"] != null && ds.Tables[0].Rows[0]["FIXEDBARCODE"].ToString() != "")
                {
                    model.FIXEDBARCODE = ds.Tables[0].Rows[0]["FIXEDBARCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MAXCODE"] != null && ds.Tables[0].Rows[0]["MAXCODE"].ToString() != "")
                {
                    model.MAXCODE =  int.Parse(ds.Tables[0].Rows[0]["MAXCODE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COMMENTS"] != null && ds.Tables[0].Rows[0]["COMMENTS"].ToString() != "")
                {
                    model.COMMENTS = ds.Tables[0].Rows[0]["COMMENTS"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据固定条码 得到一个对象实体
        /// </summary>
        public CCT.Model.BARCODESETTINGModel GetModelDueCode(string fixedCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BARCODEID,DEPTCODE,ASSETCLASSIFY,FIXEDBARCODE,MAXCODE,COMMENTS from BARCODESETTING ");
            strSql.Append(" where FIXEDBARCODE=@FIXEDBARCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@FIXEDBARCODE", SqlDbType.VarChar,10)};
            parameters[0].Value = fixedCode;

            CCT.Model.BARCODESETTINGModel model = new CCT.Model.BARCODESETTINGModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BARCODEID"] != null && ds.Tables[0].Rows[0]["BARCODEID"].ToString() != "")
                {
                    model.BARCODEID = int.Parse(ds.Tables[0].Rows[0]["BARCODEID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DEPTCODE"] != null && ds.Tables[0].Rows[0]["DEPTCODE"].ToString() != "")
                {
                    model.DEPTCODE = ds.Tables[0].Rows[0]["DEPTCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ASSETCLASSIFY"] != null && ds.Tables[0].Rows[0]["ASSETCLASSIFY"].ToString() != "")
                {
                    model.ASSETCLASSIFY = ds.Tables[0].Rows[0]["ASSETCLASSIFY"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FIXEDBARCODE"] != null && ds.Tables[0].Rows[0]["FIXEDBARCODE"].ToString() != "")
                {
                    model.FIXEDBARCODE = ds.Tables[0].Rows[0]["FIXEDBARCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MAXCODE"] != null && ds.Tables[0].Rows[0]["MAXCODE"].ToString() != "")
                {
                    model.MAXCODE = int.Parse(ds.Tables[0].Rows[0]["MAXCODE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COMMENTS"] != null && ds.Tables[0].Rows[0]["COMMENTS"].ToString() != "")
                {
                    model.COMMENTS = ds.Tables[0].Rows[0]["COMMENTS"].ToString();
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
            strSql.Append("select BARCODEID,DEPTCODE,ASSETCLASSIFY,FIXEDBARCODE,MAXCODE,COMMENTS ");
            strSql.Append(" FROM BARCODESETTING ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" BARCODEID,DEPTCODE,ASSETCLASSIFY,FIXEDBARCODE,MAXCODE,COMMENTS ");
            strSql.Append(" FROM BARCODESETTING ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得部门列表
        /// </summary>
        public DataSet GetDeptList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(DEPTCODE) from BARCODESETTING order by DEPTCODE");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 取得分类列表
        /// </summary>
        public DataSet GetAssetclassifyList(String deptCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(ASSETCLASSIFY) from BARCODESETTING WHERE DEPTCODE='" + deptCode + "' order by ASSETCLASSIFY");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 根据管理部门和资产分类取得条码
        /// </summary>
        public String GetBarcode(String deptCode, String assetclassify)
        {
            String barcode = "";
            int maxcode = 1;
            DataSet ds = GetList(" DEPTCODE='" + deptCode + "' AND ASSETCLASSIFY='" + assetclassify + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                maxcode = int.Parse(dr["MAXCODE"].ToString().Trim()) + 1;
                int len = maxcode.ToString().Length;
                String zero = "";
                for (int i = 0; i < 6 - len; i++)
                {
                    zero = zero + "0";
                }
                barcode = dr["FIXEDBARCODE"].ToString().Trim() + zero + maxcode.ToString();
            }
            return barcode;
        }

        /// <summary>
        /// 根据管理部门和资产分类，最大值加1
        /// </summary>
        public bool AddMaxCode(String deptCode, String assetclassify)
        {
            int maxcode = 1;
            DataSet ds = GetList(" DEPTCODE='" + deptCode + "' AND ASSETCLASSIFY='" + assetclassify + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                String barcodeId = dr["BARCODEID"].ToString().Trim();
                maxcode = int.Parse(dr["MAXCODE"].ToString().Trim()) + 1;

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update BARCODESETTING set ");
                strSql.Append("MAXCODE=@MAXCODE");
                strSql.Append(" where BARCODEID=@BARCODEID ");
                SqlParameter[] parameters = {
					new SqlParameter("@BARCODEID", SqlDbType.Int,4),
					new SqlParameter("@MAXCODE", SqlDbType.Int,4)};
                parameters[0].Value = barcodeId;
                parameters[1].Value = maxcode;

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
            return false;
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
            parameters[0].Value = "BARCODESETTING";
            parameters[1].Value = "BARCODEID";
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