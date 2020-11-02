﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
namespace CCT.DAL
{
    /// <summary>
    /// 数据访问类:SHEBEILEIBIEDal
    /// </summary>
    public partial class SHEBEILEIBIEDal
    {
        public SHEBEILEIBIEDal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LEIBIEBIANMA)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SHEBEILEIBIE");
            strSql.Append(" where LEIBIEBIANMA=@LEIBIEBIANMA ");
            SqlParameter[] parameters = {
					new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50)};
            parameters[0].Value = LEIBIEBIANMA;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CCT.Model.SHEBEILEIBIEModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SHEBEILEIBIE(");
            strSql.Append("LEIBIEBIANMA,LEIBIEMINGCHENG)");
            strSql.Append(" values (");
            strSql.Append("@LEIBIEBIANMA,@LEIBIEMINGCHENG)");
            SqlParameter[] parameters = {
					new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50),
					new SqlParameter("@LEIBIEMINGCHENG", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.LEIBIEBIANMA;
            parameters[1].Value = model.LEIBIEMINGCHENG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CCT.Model.SHEBEILEIBIEModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SHEBEILEIBIE set ");
            strSql.Append("LEIBIEBIANMA=@LEIBIEBIANMA,");
            strSql.Append("LEIBIEMINGCHENG=@LEIBIEMINGCHENG");
            strSql.Append(" where LEIBIEBIANMA=@LEIBIEBIANMA ");
            SqlParameter[] parameters = {
					new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50),
					new SqlParameter("@LEIBIEMINGCHENG", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.LEIBIEBIANMA;
            parameters[1].Value = model.LEIBIEMINGCHENG;

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
        public bool Delete(string LEIBIEBIANMA)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SHEBEILEIBIE ");
            strSql.Append(" where LEIBIEBIANMA=@LEIBIEBIANMA ");
            SqlParameter[] parameters = {
					new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50)};
            parameters[0].Value = LEIBIEBIANMA;

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
        public bool DeleteList(string LEIBIEBIANMAlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SHEBEILEIBIE ");
            strSql.Append(" where LEIBIEBIANMA in (" + LEIBIEBIANMAlist + ")  ");
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
        public CCT.Model.SHEBEILEIBIEModel GetModel(string LEIBIEBIANMA)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LEIBIEBIANMA,LEIBIEMINGCHENG from SHEBEILEIBIE ");
            strSql.Append(" where LEIBIEBIANMA=@LEIBIEBIANMA ");
            SqlParameter[] parameters = {
					new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50)};
            parameters[0].Value = LEIBIEBIANMA;

            CCT.Model.SHEBEILEIBIEModel model = new CCT.Model.SHEBEILEIBIEModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LEIBIEBIANMA"] != null && ds.Tables[0].Rows[0]["LEIBIEBIANMA"].ToString() != "")
                {
                    model.LEIBIEBIANMA = ds.Tables[0].Rows[0]["LEIBIEBIANMA"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LEIBIEMINGCHENG"] != null && ds.Tables[0].Rows[0]["LEIBIEMINGCHENG"].ToString() != "")
                {
                    model.LEIBIEMINGCHENG = ds.Tables[0].Rows[0]["LEIBIEMINGCHENG"].ToString();
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
            strSql.Append("select LEIBIEBIANMA,LEIBIEMINGCHENG ");
            strSql.Append(" FROM SHEBEILEIBIE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY LEIBIEBIANMA");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表的哈希表
        /// </summary>
        public Hashtable GetHashTable(string strWhere)
        {
            Hashtable ht = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LEIBIEBIANMA,LEIBIEMINGCHENG ");
            strSql.Append(" FROM SHEBEILEIBIE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY LEIBIEBIANMA");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ht.Add(dr["LEIBIEBIANMA"].ToString().Trim(), dr["LEIBIEMINGCHENG"].ToString());
            }
            return ht;
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
            strSql.Append(" LEIBIEBIANMA,LEIBIEMINGCHENG ");
            strSql.Append(" FROM SHEBEILEIBIE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "SHEBEILEIBIE";
            parameters[1].Value = "LEIBIEBIANMA";
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

