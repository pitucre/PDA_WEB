using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
namespace CCT.DAL
{
    /// <summary>
    /// 数据访问类:ZICHANZHUANGTAIDal
    /// </summary>
    public partial class ZICHANZHUANGTAIDal
    {
        public ZICHANZHUANGTAIDal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ZHUANGTAICODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZICHANZHUANGTAI");
            strSql.Append(" where ZHUANGTAICODE=@ZHUANGTAICODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZHUANGTAICODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ZHUANGTAICODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(CCT.Model.ZICHANZHUANGTAIModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ZICHANZHUANGTAI(");
            strSql.Append("ZHUANGTAICODE,ZHUANGTAIMINGCHENG)");
            strSql.Append(" values (");
            strSql.Append("@ZHUANGTAICODE,@ZHUANGTAIMINGCHENG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ZHUANGTAICODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ZHUANGTAIMINGCHENG", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ZHUANGTAICODE;
            parameters[1].Value = model.ZHUANGTAIMINGCHENG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CCT.Model.ZICHANZHUANGTAIModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZICHANZHUANGTAI set ");
            strSql.Append("ZHUANGTAICODE=@ZHUANGTAICODE,");
            strSql.Append("ZHUANGTAIMINGCHENG=@ZHUANGTAIMINGCHENG");
            strSql.Append(" where ZHUANGTAICODE=@ZHUANGTAICODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZHUANGTAICODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ZHUANGTAIMINGCHENG", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ZHUANGTAICODE;
            parameters[1].Value = model.ZHUANGTAIMINGCHENG;

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
        public bool Delete(string ZHUANGTAICODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZICHANZHUANGTAI ");
            strSql.Append(" where ZHUANGTAICODE=@ZHUANGTAICODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZHUANGTAICODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ZHUANGTAICODE;

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
        public bool DeleteList(string ZHUANGTAICODElist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZICHANZHUANGTAI ");
            strSql.Append(" where ZHUANGTAICODE in (" + ZHUANGTAICODElist + ")  ");
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
        public CCT.Model.ZICHANZHUANGTAIModel GetModel(string ZHUANGTAICODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ZHUANGTAICODE,ZHUANGTAIMINGCHENG from ZICHANZHUANGTAI ");
            strSql.Append(" where ZHUANGTAICODE=@ZHUANGTAICODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@ZHUANGTAICODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ZHUANGTAICODE;

            CCT.Model.ZICHANZHUANGTAIModel model = new CCT.Model.ZICHANZHUANGTAIModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ZHUANGTAICODE"] != null && ds.Tables[0].Rows[0]["ZHUANGTAICODE"].ToString() != "")
                {
                    model.ZHUANGTAICODE = ds.Tables[0].Rows[0]["ZHUANGTAICODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZHUANGTAIMINGCHENG"] != null && ds.Tables[0].Rows[0]["ZHUANGTAIMINGCHENG"].ToString() != "")
                {
                    model.ZHUANGTAIMINGCHENG = ds.Tables[0].Rows[0]["ZHUANGTAIMINGCHENG"].ToString();
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
            strSql.Append("select ZHUANGTAICODE,ZHUANGTAIMINGCHENG ");
            strSql.Append(" FROM ZICHANZHUANGTAI");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY ZHUANGTAICODE");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表的哈希表
        /// </summary>
        public Hashtable GetHashTable(string strWhere)
        {
            Hashtable ht = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ZHUANGTAICODE,ZHUANGTAIMINGCHENG ");
            strSql.Append(" FROM ZICHANZHUANGTAI");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY ZHUANGTAICODE");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ht.Add(dr["ZHUANGTAICODE"].ToString().Trim(), dr["ZHUANGTAIMINGCHENG"].ToString());
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
            strSql.Append(" ZHUANGTAICODE,ZHUANGTAIMINGCHENG ");
            strSql.Append(" FROM ZICHANZHUANGTAI ");
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
            parameters[0].Value = "ZICHANZHUANGTAI";
            parameters[1].Value = "ZHUANGTAICODE";
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

