using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace CCT.DAL
{
    public class SCANRESULTDal
    {
        public SCANRESULTDal()
        { }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BARCODE,ASSETCODE,RESULT,COMMENTS,SCANPERSON,SCANTIME,DATAFLAG ");
            strSql.Append(" FROM SCANRESULT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public bool StopScanResult()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SCANRESULT set ");
            strSql.Append(" DATAFLAG=-1 ");
            strSql.Append(" WHERE DATAFLAG=0");
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
    }
}