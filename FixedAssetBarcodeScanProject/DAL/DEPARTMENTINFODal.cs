using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
namespace CCT.DAL
{
    /// <summary>
    /// 数据访问类:DEPARTMENTINFODal
    /// </summary>
    public partial class DEPARTMENTINFODal
    {
        public DEPARTMENTINFODal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DEPTCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DEPARTMENTINFO");
            strSql.Append(" where DEPTCODE=@DEPTCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = DEPTCODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CCT.Model.DEPARTMENTINFOModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DEPARTMENTINFO(");
            strSql.Append("DEPTCODE,DEPTNAME)");
            strSql.Append(" values (");
            strSql.Append("@DEPTCODE,@DEPTNAME)");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@DEPTNAME", SqlDbType.NVarChar)};
            parameters[0].Value = model.DEPTCODE;
            parameters[1].Value = model.DEPTNAME;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CCT.Model.DEPARTMENTINFOModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DEPARTMENTINFO set ");
            strSql.Append("DEPTCODE=@DEPTCODE,");
            strSql.Append("DEPTNAME=@DEPTNAME");
            strSql.Append(" where DEPTCODE=@DEPTCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@DEPTNAME", SqlDbType.NVarChar)};
            parameters[0].Value = model.DEPTCODE;
            parameters[1].Value = model.DEPTNAME;

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
        public bool Delete(string DEPTCODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DEPARTMENTINFO ");
            strSql.Append(" where DEPTCODE=@DEPTCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = DEPTCODE;

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
        public bool DeleteList(string DEPTCODElist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DEPARTMENTINFO ");
            strSql.Append(" where DEPTCODE in (" + DEPTCODElist + ")  ");
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
        public CCT.Model.DEPARTMENTINFOModel GetModel(string DEPTCODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DEPTCODE,DEPTNAME from DEPARTMENTINFO ");
            strSql.Append(" where DEPTCODE=@DEPTCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = DEPTCODE;

            CCT.Model.DEPARTMENTINFOModel model = new CCT.Model.DEPARTMENTINFOModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["DEPTCODE"] != null && ds.Tables[0].Rows[0]["DEPTCODE"].ToString() != "")
                {
                    model.DEPTCODE = ds.Tables[0].Rows[0]["DEPTCODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DEPTNAME"] != null && ds.Tables[0].Rows[0]["DEPTNAME"].ToString() != "")
                {
                    model.DEPTNAME = ds.Tables[0].Rows[0]["DEPTNAME"].ToString();
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
            strSql.Append("select DEPTCODE,DEPTNAME ");
            strSql.Append(" FROM DEPARTMENTINFO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY DEPTCODE");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表的哈希表
        /// </summary>
        public Hashtable GetHashTable(string strWhere)
        {
            Hashtable ht = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DEPTCODE,DEPTNAME ");
            strSql.Append(" FROM DEPARTMENTINFO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY DEPTCODE");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ht.Add(dr["DEPTCODE"].ToString().Trim(), dr["DEPTNAME"].ToString());
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
            strSql.Append(" DEPTCODE,DEPTNAME ");
            strSql.Append(" FROM DEPARTMENTINFO ");
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
            parameters[0].Value = "DEPARTMENTINFO";
            parameters[1].Value = "DEPTCODE";
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

