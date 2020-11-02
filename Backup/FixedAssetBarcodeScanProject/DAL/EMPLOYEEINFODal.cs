using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
namespace CCT.DAL
{
	/// <summary>
	/// 数据访问类:EMPLOYEEINFO
	/// </summary>
	public partial class EMPLOYEEINFODal
	{
		public EMPLOYEEINFODal()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CCT.Model.EMPLOYEEINFOModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EMPLOYEEINFO(");
			strSql.Append("EMPLOYEECODE,EMPLOYEENAME,CCTEMPLOYEECODE)");
			strSql.Append(" values (");
			strSql.Append("@EMPLOYEECODE,@EMPLOYEENAME,@CCTEMPLOYEECODE)");
			SqlParameter[] parameters = {
					new SqlParameter("@EMPLOYEECODE", SqlDbType.NVarChar,50),
					new SqlParameter("@EMPLOYEENAME", SqlDbType.NVarChar,50),
					new SqlParameter("@CCTEMPLOYEECODE", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.EMPLOYEECODE;
			parameters[1].Value = model.EMPLOYEENAME;
			parameters[2].Value = model.CCTEMPLOYEECODE;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CCT.Model.EMPLOYEEINFOModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EMPLOYEEINFO set ");
			strSql.Append("EMPLOYEECODE=@EMPLOYEECODE,");
			strSql.Append("EMPLOYEENAME=@EMPLOYEENAME,");
			strSql.Append("CCTEMPLOYEECODE=@CCTEMPLOYEECODE");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@EMPLOYEECODE", SqlDbType.NVarChar,50),
					new SqlParameter("@EMPLOYEENAME", SqlDbType.NVarChar,50),
					new SqlParameter("@CCTEMPLOYEECODE", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.EMPLOYEECODE;
			parameters[1].Value = model.EMPLOYEENAME;
			parameters[2].Value = model.CCTEMPLOYEECODE;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EMPLOYEEINFO ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 删除表中所有数据
        /// </summary>
        public bool DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EMPLOYEEINFO ");
            
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
		public CCT.Model.EMPLOYEEINFOModel GetModel(String employeecode)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EMPLOYEECODE,EMPLOYEENAME,CCTEMPLOYEECODE from EMPLOYEEINFO ");
            strSql.Append(" where EMPLOYEECODE=@EMPLOYEECODE ");
			SqlParameter[] parameters = {
                                        new SqlParameter("@EMPLOYEECODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = employeecode;
			CCT.Model.EMPLOYEEINFOModel model=new CCT.Model.EMPLOYEEINFOModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["EMPLOYEECODE"]!=null && ds.Tables[0].Rows[0]["EMPLOYEECODE"].ToString()!="")
				{
					model.EMPLOYEECODE=ds.Tables[0].Rows[0]["EMPLOYEECODE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EMPLOYEENAME"]!=null && ds.Tables[0].Rows[0]["EMPLOYEENAME"].ToString()!="")
				{
					model.EMPLOYEENAME=ds.Tables[0].Rows[0]["EMPLOYEENAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CCTEMPLOYEECODE"]!=null && ds.Tables[0].Rows[0]["CCTEMPLOYEECODE"].ToString()!="")
				{
					model.CCTEMPLOYEECODE=ds.Tables[0].Rows[0]["CCTEMPLOYEECODE"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EMPLOYEECODE,EMPLOYEENAME,CCTEMPLOYEECODE ");
            strSql.Append(" FROM EMPLOYEEINFO");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append("  ORDER BY EMPLOYEECODE");
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表的哈希表
        /// </summary>
        public Hashtable GetHashTable(string strWhere)
        {
            Hashtable ht = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EMPLOYEECODE,EMPLOYEENAME,CCTEMPLOYEECODE ");
            strSql.Append(" FROM EMPLOYEEINFO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("  ORDER BY EMPLOYEECODE");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ht.Add(dr["EMPLOYEECODE"].ToString().Trim(), dr["EMPLOYEENAME"].ToString());
            }
            return ht;
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" EMPLOYEECODE,EMPLOYEENAME,CCTEMPLOYEECODE ");
			strSql.Append(" FROM EMPLOYEEINFO ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "EMPLOYEEINFO";
			parameters[1].Value = "";
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

