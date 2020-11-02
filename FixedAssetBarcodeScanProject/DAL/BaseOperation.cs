using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Text;
using System.Collections;

namespace CCT.DAL
{
    public class BaseOperation
    {
        public BaseOperation()
        {            
        }
        //数据库连接字符串(web.config来配置)，多数据库可使用DbHelperSQLP来实现.
        public static string connectionString = PubConstant.ConnectionString;
        public bool RefreshDataFromJDE()
        {
            bool flag = true;
            Hashtable ht = new Hashtable();
            CCT.DAL.ZICHANZHUANGTAIDal zcZT = new ZICHANZHUANGTAIDal();
            zcZT.Delete("");

            try
            {
                //更新员工信息表数据
                String deleteEmploy = "delete from EMPLOYEEINFO";
                DbHelperSQL.ExecuteSql(deleteEmploy);
                String EmployeeSql = "SELECT ABAN8,ABALPH,ABALKY FROM F0101 WHERE ABAT1='E'AND ABMCU like '%8190%' ORDER BY ABAN8";
                DataSet ds = new DataSet();
                ds = DbHelperSQL.OracleExecuteDataset(EmployeeSql, "F0101");
                for (int i = 0; i < ds.Tables["F0101"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["F0101"].Rows[i];
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into EMPLOYEEINFO(");
                    strSql.Append("EMPLOYEECODE,EMPLOYEENAME,CCTEMPLOYEECODE)");
                    strSql.Append(" values (");
                    strSql.Append("@EMPLOYEECODE,@EMPLOYEENAME,@CCTEMPLOYEECODE)");
                    SqlParameter[] parameters2 = {
                    new SqlParameter("@EMPLOYEECODE", SqlDbType.NVarChar,50),
                    new SqlParameter("@EMPLOYEENAME", SqlDbType.NVarChar,50),
                    new SqlParameter("@CCTEMPLOYEECODE", SqlDbType.NVarChar,50)};
                    parameters2[0].Value = dr["ABAN8"].ToString().Trim();
                    parameters2[1].Value = dr["ABALPH"].ToString();
                    parameters2[2].Value = dr["ABALKY"].ToString().Trim();
                    ht.Add(strSql, parameters2);
                }

                //更新部门信息表数据
                String deleteDept = "delete from DEPARTMENTINFO";
                DbHelperSQL.ExecuteSql(deleteDept);
                String DeptSql = "SELECT MCMCU,MCDC FROM F0006 WHERE MCCO like '%08190%'";
                ds = new DataSet();
                ds = DbHelperSQL.OracleExecuteDataset(DeptSql, "F0006");
                for (int i = 0; i < ds.Tables["F0006"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["F0006"].Rows[i];
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into DEPARTMENTINFO(");
                    strSql.Append("DEPTCODE,DEPTNAME)");
                    strSql.Append(" values (");
                    strSql.Append("@DEPTCODE,@DEPTNAME)");
                    SqlParameter[] parameters = {
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@DEPTNAME", SqlDbType.NVarChar)};
                    parameters[0].Value = dr["MCMCU"].ToString().Trim(); 
                    parameters[1].Value = dr["MCDC"].ToString(); 
                    ht.Add(strSql, parameters);
                }

                //更新会计类别数据
                String deleteKjLb = "delete from KUAIJILEIBIE";
                DbHelperSQL.ExecuteSql(deleteKjLb);
                String kjLbSql = "SELECT DRKY,DRDL01 FROM F0005 WHERE DRSY='12' AND DRRT='C1'";
                ds = new DataSet();
                ds = DbHelperSQL.OracleExecuteDataset(kjLbSql, "F0005");
                for (int i = 0; i < ds.Tables["F0005"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["F0005"].Rows[i];
                    if (dr["DRKY"].ToString().Trim().Equals(""))
                    {
                        continue;
                    }
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into KUAIJILEIBIE(");
                    strSql.Append("LEIBIEBIANMA,LEIBIEMINGCHENG)");
                    strSql.Append(" values (");
                    strSql.Append("@LEIBIEBIANMA,@LEIBIEMINGCHENG)");
                    SqlParameter[] parameters = {
                    new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50),
                    new SqlParameter("@LEIBIEMINGCHENG", SqlDbType.NVarChar)};
                    parameters[0].Value = dr["DRKY"].ToString().Trim(); 
                    parameters[1].Value = dr["DRDL01"].ToString(); 
                    ht.Add(strSql, parameters);
                }

                //更新设备类别数据
                String deleteSbLb = "delete from SHEBEILEIBIE";
                DbHelperSQL.ExecuteSql(deleteSbLb);
                String sbLbSql = "SELECT DRKY,DRDL01 FROM F0005 WHERE DRSY='12' AND DRRT='C2'";
                ds = new DataSet();
                ds = DbHelperSQL.OracleExecuteDataset(sbLbSql, "F0005");
                for (int i = 0; i < ds.Tables["F0005"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["F0005"].Rows[i];
                    if (dr["DRKY"].ToString().Trim().Equals(""))
                    {
                        continue;
                    }
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into SHEBEILEIBIE(");
                    strSql.Append("LEIBIEBIANMA,LEIBIEMINGCHENG)");
                    strSql.Append(" values (");
                    strSql.Append("@LEIBIEBIANMA,@LEIBIEMINGCHENG)");
                    SqlParameter[] parameters = {
                    new SqlParameter("@LEIBIEBIANMA", SqlDbType.NVarChar,50),
                    new SqlParameter("@LEIBIEMINGCHENG", SqlDbType.NVarChar)};
                    parameters[0].Value = dr["DRKY"].ToString().Trim(); 
                    parameters[1].Value = dr["DRDL01"].ToString(); 
                    ht.Add(strSql, parameters);
                }

                //更新资产状态数据
                String deleteZcZt = "delete from ZICHANZHUANGTAI";
                DbHelperSQL.ExecuteSql(deleteZcZt);
                String zcZtSql = "SELECT DRKY,DRDL01 FROM F0005 WHERE DRSY='12' AND DRRT='ES'";
                ds = new DataSet();
                ds = DbHelperSQL.OracleExecuteDataset(zcZtSql, "F0005");
                for (int i = 0; i < ds.Tables["F0005"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["F0005"].Rows[i];
                    if (dr["DRKY"].ToString().Trim().Equals(""))
                    {
                        continue;
                    }
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into ZICHANZHUANGTAI(");
                    strSql.Append("ZHUANGTAICODE,ZHUANGTAIMINGCHENG)");
                    strSql.Append(" values (");
                    strSql.Append("@ZHUANGTAICODE,@ZHUANGTAIMINGCHENG)");
                    SqlParameter[] parameters = {
                    new SqlParameter("@ZHUANGTAICODE", SqlDbType.NVarChar,50),
                    new SqlParameter("@ZHUANGTAIMINGCHENG", SqlDbType.NVarChar)};
                    parameters[0].Value = dr["DRKY"].ToString().Trim(); 
                    parameters[1].Value = dr["DRDL01"].ToString();
                    ht.Add(strSql, parameters);
                }

                //更新固定资产信息列表
                //String updateAssetInfo = "update FIXEDASSETINFO set DATAFLAG=-1";
                //DbHelperSQL.ExecuteSql(updateAssetInfo);
                CCT.DAL.FIXEDASSETINFODal assetDal = new FIXEDASSETINFODal();
                //String zcInfoSql = "SELECT FANUMB,FAAAID,FADL01,FAACL1,FAACL2,FAAN8,FAASID,FAEQST,FAKITL,FALOC,FAXMCU,FARMK,FARMK2,FAUPMJ,FAUPMT FROM F1201 WHERE FAEQST NOT IN('02','04') AND FACO='08190' ORDER BY FANUMB";
                String zcInfoSql = "SELECT FANUMB,FAAAID,FADL01,FAACL1,FAACL2,FAAN8,FAASID,FAEQST,FAKITL,FALOC,FAXMCU,FARMK,FARMK2,FAUPMJ,FAUPMT FROM F1201 WHERE FACO='08190' ORDER BY FANUMB";
                ds = new DataSet();
                ds = DbHelperSQL.OracleExecuteDataset(zcInfoSql, "F1201");
                for (int i = 0; i < ds.Tables["F1201"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["F1201"].Rows[i];

                    CCT.Model.FIXEDASSETINFOModel assetModel = assetDal.GetModel(dr["FANUMB"].ToString().Trim());
                    //判断是否为新增资产
                    if (assetModel == null)
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
                        parameters[0].Value = "";
                        parameters[1].Value = dr["FANUMB"].ToString().Trim();
                        parameters[2].Value = dr["FADL01"].ToString().Trim();
                        parameters[3].Value = dr["FAACL1"].ToString().Trim();
                        parameters[4].Value = dr["FAACL2"].ToString().Trim();
                        parameters[5].Value = dr["FARMK2"].ToString().Trim();
                        parameters[6].Value = dr["FAEQST"].ToString().Trim();
                        parameters[7].Value = dr["FALOC"].ToString().Trim();
                        parameters[8].Value = dr["FAXMCU"].ToString().Trim();
                        parameters[9].Value = dr["FAAN8"].ToString().Trim();
                        parameters[10].Value = dr["FAKITL"].ToString().Trim();
                        parameters[11].Value = "";
                        parameters[12].Value = dr["FAASID"].ToString().Trim();
                        parameters[13].Value = dr["FARMK"].ToString().Trim();
                        parameters[14].Value = "";
                        parameters[15].Value = "";
                        parameters[16].Value = dr["FAUPMJ"].ToString().Trim();
                        parameters[17].Value = dr["FAUPMT"].ToString().Trim();
                        //parameters[18].Value = 0;
                        string strZt = dr["FAEQST"].ToString().Trim();
                        if (strZt.Equals("02") || strZt.Equals("04"))
                        {
                            parameters[18].Value = -1;
                        }
                        else
                        {
                            parameters[18].Value = 0;
                        }
                        ht.Add(strSql, parameters);
                    }
                    else
                    {
                        //判断是否发生过资产变更
                        //if (!(dr["FAUPMJ"].ToString().Trim().Equals(assetModel.JDEUPDATEDATE)) && dr["FAUPMT"].ToString().Trim().Equals(assetModel.JDEUPDATETIME))
                        //{
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
                            parameters[0].Value = assetModel.BARCODE;
                            parameters[1].Value = assetModel.ASSETCODE;
                            parameters[2].Value = dr["FADL01"].ToString().Trim();
                            parameters[3].Value = dr["FAACL1"].ToString().Trim();
                            parameters[4].Value = dr["FAACL2"].ToString().Trim();
                            parameters[5].Value = dr["FARMK2"].ToString().Trim();
                            parameters[6].Value = dr["FAEQST"].ToString().Trim();
                            parameters[7].Value = dr["FALOC"].ToString().Trim();
                            parameters[8].Value = dr["FAXMCU"].ToString().Trim();
                            parameters[9].Value = dr["FAAN8"].ToString().Trim();
                            parameters[10].Value = dr["FAKITL"].ToString().Trim();
                            parameters[11].Value = assetModel.BEIZHU;
                            parameters[12].Value = dr["FAASID"].ToString().Trim();
                            parameters[13].Value = dr["FARMK"].ToString().Trim();
                            parameters[14].Value = assetModel.ADMINDEPT;
                            parameters[15].Value = assetModel.ASSETCLASSIFY;
                            parameters[16].Value = dr["FAUPMJ"].ToString().Trim();
                            parameters[17].Value = dr["FAUPMT"].ToString().Trim();
                            //parameters[18].Value = 0;
                            string strZt = dr["FAEQST"].ToString().Trim();
                            if (strZt.Equals("02") || strZt.Equals("04"))
                            {
                                parameters[18].Value = -1;
                            }
                            else
                            {
                                parameters[18].Value = 0;
                            }
                            
                            ht.Add(strSql, parameters);
                        //}
                    }
                }
                DbHelperSQL.ExecuteSqlTran(ht);
            }
            catch (Exception ee)
            {
                flag = false;
                Log.WriteLog("", ee.ToString());
                throw ee;
            }
            return flag;
        }
        public void ShowErrorMessage(Page page, string message)
        {
            page.Response.Write("<script languge='javascript'>alert('" + message + "');</script>");
        }

        public string newPW(string OldPW, string PasswordFormat)
        {
            string str = "";
            if (!OldPW.Equals(""))
            {
                if (PasswordFormat == "SHA1")
                {
                    str = FormsAuthentication.HashPasswordForStoringInConfigFile(OldPW, "SHA1");
                }
                else if (PasswordFormat == "MD5")
                {
                    str = FormsAuthentication.HashPasswordForStoringInConfigFile(OldPW, "MD5");
                }
                else
                {
                    str = "";
                }
            }
            if (OldPW.Equals(""))
            {
                str = "";
            }
            return str;
        }

        public string GetPCRUserId(string inputNo)
        {
            string str;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            string srcTable = "t_StaffsInfo";
            string selectCommandText = "select max(StaffCode) as StaffCode from t_StaffsInfo where StaffCaption=@StaffCaption";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@StaffCaption", SqlDbType.VarChar)
                {
                    Value = inputNo
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, srcTable);
                str = dataSet.Tables[0].Rows[0]["StaffCode"].ToString();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return str;
        }

        public bool ComparePassWord(string inputNo, string inputPW)
        {
            bool flag;
            string srcTable = "t_StaffsInfo";
            string selectCommandText = "select StaffCode,PassWord from t_StaffsInfo where StaffCode=@StaffCode";
            string str3 = "";

            using (SqlConnection selectConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                    {
                        SelectCommand = { CommandType = CommandType.Text }
                    };
                    SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                    {
                        Value = inputNo
                    };
                    adapter.SelectCommand.Parameters.Add(parameter);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, srcTable);
                    str3 = dataSet.Tables["t_StaffsInfo"].Rows[0]["PassWord"].ToString();
                    if (inputPW.Equals(str3))
                    {
                        return true;
                    }
                    flag = false;
                }
                catch (Exception exception)
                {
                    Log.WriteLog("", "异常：" + exception.ToString());
                    throw exception;
                }
                finally
                {
                    if (selectConnection.State == ConnectionState.Open)
                    {
                        selectConnection.Close();
                    }
                }
            }
            return flag;
        }

        public DataSet GetStaffFuncSetCanAccess(string StaffCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string str = "select distinct c.FunCode,c.FunName,c.FormTitle,c.FunLzouName,c.FormLzouTitle ";
                SqlDataAdapter adapter = new SqlDataAdapter(str + "from t_StaffActor a,t_SysFunction c,t_SysRightFunc d where d.IsAccess='1' and a.ActorCode=d.ActorCode and d.FunCode=c.FunCode and a.StaffCode=@StaffCode", selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_PurviewSet");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public DataSet GetCsubFromTid(string StaffCode, string FunCodeLike)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            string srcTable = "t_SysRightFunc";
            string str2 = "'" + FunCodeLike + "'";
            string selectCommandText = "select distinct c.FunCode,c.FunName,c.FormTitle,c.FunLzouName,c.FormLzouTitle ";
            selectCommandText = selectCommandText + "from t_StaffActor a,t_SysFunction c,t_SysRightFunc d where d.IsAccess='1'and a.ActorCode=d.ActorCode and d.FunCode=c.FunCode  and a.StaffCode=@StaffCode and c.FunCode like " + str2;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                string str4 = selectCommandText;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, srcTable);
                string str5 = selectCommandText;
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public DataSet GetCCsubFromCid(string UpFunCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            string srcTable = "t_SysFunction";
            string str2 = "'" + UpFunCode + "__'";
            string selectCommandText = "select FunCode,FunName,FormTitle,FunLzouName,FormLzouTitle from t_SysFunction ";
            selectCommandText = selectCommandText + " where FunCode like " + str2;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@UpFunCode", SqlDbType.VarChar)
                {
                    Value = UpFunCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, srcTable);
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public DataSet GetActorDataSet()
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select ActorCode,ActorCaption,ActorType from t_SysActors";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysActors");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public DataSet GetStaffDataSet(string StaffCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = string.Empty;
                if (StaffCode.Length == 0)
                {
                    selectCommandText = "select StaffCode,StaffCaption,StaffType,StaffTypeName = case StaffType when '0' then '本公司'when '1' then '供应商'when '2' then '客户'else '本公司'end,ReMark from t_StaffsInfo";
                }
                else
                {
                    selectCommandText = "select StaffCode,StaffCaption,StaffType,StaffTypeName = case StaffType when '0' then '本公司'when '1' then '供应商'when '2' then '客户'else '本公司'end,ReMark from t_StaffsInfo where 1 = 1 and StaffCode = " + StaffCode;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_StaffsInfo");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public DataSet GetStaffInfoDataSet(string StaffCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = string.Empty;
                if (StaffCode.Length == 0)
                {
                    selectCommandText = "select StaffCode,StaffCaption,Password,StaffType,StaffTypeName = case StaffType when '0' then '本公司'when '1' then '供应商'when '2' then '客户'else '本公司'end,ReMark from t_StaffsInfo";
                }
                else
                {
                    selectCommandText = "select StaffCode,StaffCaption,Password,StaffType,StaffTypeName = case StaffType when '0' then '本公司'when '1' then '供应商'when '2' then '客户'else '本公司'end,ReMark from t_StaffsInfo where 1 = 1 and StaffCode = " + StaffCode;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_StaffsInfo");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public int GetTableMaxColumnValue(string strTableName, string strColumnName)
        {
            int num;
            int num2 = 1;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select max(" + strColumnName + ") from " + strTableName, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, strTableName);
                if (dataSet.Tables[0].Rows[0][0].ToString().Length == 0)
                {
                    return num2;
                }
                if (dataSet.Tables[0].Rows[0][0].ToString().Length > 0)
                {
                    return (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1);
                }
                num = 1;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return num;
        }



        public string InserStaffInfo(string StaffCaption, string PassWord, string ReMark, string StaffType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = string.Empty;
            string str2 = string.Empty;
            cmdText = "insert into t_StaffsInfo(StaffCode,StaffCaption,PassWord,ReMark,StaffType) values (@StaffCode,@StaffCaption,@PassWord,@ReMark,@StaffType)";
            try
            {
                connection.Open();
                str2 = GetTableMaxColumnValue("t_StaffsInfo", "StaffCode").ToString();
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = str2
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@StaffCaption", SqlDbType.VarChar)
                {
                    Value = StaffCaption
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@PassWord", SqlDbType.VarChar)
                {
                    Value = PassWord
                };
                command.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@ReMark", SqlDbType.VarChar)
                {
                    Value = ReMark
                };
                command.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@StaffType", SqlDbType.VarChar)
                {
                    Value = StaffType
                };
                command.Parameters.Add(parameter5);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return str2;
        }

        public void InsertActorByStaff(string StaffCode, string ActorCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string cmdText = "insert into t_StaffActor(StaffCode,ActorCode) values(@StaffCode,@ActorCode)";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                command.Parameters.Add(parameter2);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdateStaffInfo(string StaffCode, string StaffCaption, string PassWord, string ReMark, int StaffType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            if (StaffType == 0)
            {
                string cmdText = "update t_StaffsInfo set StaffCaption=@StaffCaption,PassWord=@PassWord,ReMark=@ReMark,StaffType=@StaffType where StaffCode=@StaffCode";
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(cmdText, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                    {
                        Value = StaffCode
                    };
                    command.Parameters.Add(parameter);
                    SqlParameter parameter2 = new SqlParameter("@StaffCaption", SqlDbType.VarChar)
                    {
                        Value = StaffCaption
                    };
                    command.Parameters.Add(parameter2);
                    SqlParameter parameter3 = new SqlParameter("@PassWord", SqlDbType.VarChar)
                    {
                        Value = PassWord
                    };
                    command.Parameters.Add(parameter3);
                    SqlParameter parameter4 = new SqlParameter("@ReMark", SqlDbType.VarChar)
                    {
                        Value = ReMark
                    };
                    command.Parameters.Add(parameter4);
                    SqlParameter parameter5 = new SqlParameter("@StaffType", SqlDbType.Int)
                    {
                        Value = StaffType
                    };
                    command.Parameters.Add(parameter5);
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Log.WriteLog("", "异常：" + exception.ToString());
                    throw exception;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void DeleteActorByStaff(string StaffCode, string ActorCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command;
                string str;
                SqlParameter parameter;
                if (ActorCode.Length == 0)
                {
                    str = " delete t_StaffActor where StaffCode=@StaffCode ";
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    command = new SqlCommand(str, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                    {
                        Value = StaffCode
                    };
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                }
                else
                {
                    str = "delete t_StaffActor where StaffCode=@StaffCode and ActorCode=@ActorCode";
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    command = new SqlCommand(str, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                    {
                        Value = StaffCode
                    };
                    command.Parameters.Add(parameter);
                    SqlParameter parameter2 = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                    {
                        Value = ActorCode
                    };
                    command.Parameters.Add(parameter2);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteStaffInfo(string StaffCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string cmdText = "delete t_StaffsInfo where StaffCode=@StaffCode";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetStaffActorSet(string StaffCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string str = "select a.StaffCode,a.ActorCode,b.ActorCaption,b.ActorType ";
                SqlDataAdapter adapter = new SqlDataAdapter(str + "from t_StaffActor a,t_SysActors b where a.ActorCode=b.ActorCode and a.StaffCode=@StaffCode", selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_StaffActor");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public bool StaffCodeIsInSysStaff(string StaffCode, string StaffCaption)
        {
            bool flag;
            bool flag2 = false;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select max(StaffCode) from t_StaffsInfo where StaffCode=@StaffCode or StaffCaption=@StaffCaption";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@StaffCaption", SqlDbType.VarChar)
                {
                    Value = StaffCaption
                };
                adapter.SelectCommand.Parameters.Add(parameter2);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_StaffsInfo");
                if (dataSet.Tables[0].Rows[0][0].ToString().Length > 0)
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
                flag = flag2;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return flag;
        }

        public string InserActorInfo(string ActorCaption, string ActorType)
        {
            string str;
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "insert into t_SysActors(ActorCode,ActorCaption,ActorType) values (@ActorCode,@ActorCaption,@ActorType)";
            try
            {
                connection.Open();
                string str3 = this.GetTableMaxColumnValue("t_SysActors", "ActorCode").ToString();
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = str3
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@ActorCaption", SqlDbType.VarChar)
                {
                    Value = ActorCaption
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@ActorType", SqlDbType.VarChar)
                {
                    Value = ActorType
                };
                command.Parameters.Add(parameter3);
                command.ExecuteNonQuery();
                str = str3;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return str;
        }

        public void UpdateActorInfo(string ActorCode, string ActorCaption, string ActorType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "update t_SysActors set ActorCaption=@ActorCaption,ActorType=@ActorType where ActorCode=@ActorCode";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@ActorCaption", SqlDbType.VarChar)
                {
                    Value = ActorCaption
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@ActorType", SqlDbType.VarChar)
                {
                    Value = ActorType
                };
                command.Parameters.Add(parameter3);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteActorInfo(string ActorCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string cmdText = "delete t_SysActors where ActorCode=@ActorCode";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public bool ActorCodeIsInSysActor(string ActorCode)
        {
            bool flag;
            bool flag2 = false;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select max(ActorCode) from t_SysActors where ActorCode=@ActorCode";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_Sys_Actors");
                if (dataSet.Tables[0].Rows[0][0].ToString().Length > 0)
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
                flag = flag2;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return flag;
        }

        public DataSet GetFunctionDataSet()
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select FunCode,FunName,FormTitle,ReMark from t_SysFunction";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysFunction");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public void InserFunctionInfo(string FunCode, string FunName, string FormTitle, string ReMark)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "insert into t_SysFunction(FunCode,FunName,FormTitle,ReMark) values (@FunCode,@FunName,@FormTitle,@ReMark)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@FunCode", SqlDbType.VarChar)
                {
                    Value = FunCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@FunName", SqlDbType.VarChar)
                {
                    Value = FunName
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@FormTitle", SqlDbType.VarChar)
                {
                    Value = FormTitle
                };
                command.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@ReMark", SqlDbType.VarChar)
                {
                    Value = ReMark
                };
                command.Parameters.Add(parameter4);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdateFunctionInfo(string FunCode, string FunName, string FormTitle, string ReMark)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "update t_SysFunction set FunName=@FunName,FormTitle=@FormTitle,ReMark=@ReMark where FunCode=@FunCode";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@FunCode", SqlDbType.VarChar)
                {
                    Value = FunCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@FunName", SqlDbType.VarChar)
                {
                    Value = FunName
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@FormTitle", SqlDbType.VarChar)
                {
                    Value = FormTitle
                };
                command.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@ReMark", SqlDbType.VarChar)
                {
                    Value = ReMark
                };
                command.Parameters.Add(parameter4);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteFunctionInfo(string FunCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string cmdText = "delete t_SysFunction where FunCode=@FunCode";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@FunCode", SqlDbType.VarChar)
                {
                    Value = FunCode
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public bool FunctionCodeIsInSysFunction(string FunCode)
        {
            bool flag;
            bool flag2 = false;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select max(FunCode) from t_SysFunction where FunCode=@FunCode";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@FunCode", SqlDbType.VarChar)
                {
                    Value = FunCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysFunction");
                if (dataSet.Tables[0].Rows[0][0].ToString().Length > 0)
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
                flag = flag2;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return flag;
        }

        public DataSet GetSysActorsInfo()
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select ActorCode,ActorCaption from t_SysActors ";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysActors");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public bool StaffCodeIsInStaffActorSet(string StaffCode)
        {
            bool flag;
            bool flag2 = false;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select max(StaffCode) from t_StaffActor where StaffCode=@StaffCode";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_StaffActor");
                if (dataSet.Tables[0].Rows[0][0].ToString().Length > 0)
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
                flag = flag2;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return flag;
        }

        public string GetActorCodeFromActorCaption(string ActorCaption)
        {
            string str;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select ActorCode from t_SysActors where ActorCaption=@ActorCaption";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@ActorCaption", SqlDbType.VarChar)
                {
                    Value = ActorCaption
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysActors");
                str = dataSet.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return str;
        }

        public void InsertStaffActorSet(string StaffCode, string ActorCaption)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string actorCodeFromActorCaption = this.GetActorCodeFromActorCaption(ActorCaption);
                string cmdText = "insert into t_StaffActor(StaffCode,ActorCode) values(@StaffCode,@ActorCode)";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = actorCodeFromActorCaption
                };
                command.Parameters.Add(parameter2);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteStaffActorSet(string StaffCode, string ActorCaption)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string actorCodeFromActorCaption = this.GetActorCodeFromActorCaption(ActorCaption);
                string cmdText = "delete t_StaffActor where StaffCode=@StaffCode and ActorCode=@ActorCode";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = actorCodeFromActorCaption
                };
                command.Parameters.Add(parameter2);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetSysFunction()
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select FunCode,FunName,FormTitle from t_SysFunction order by FunCode";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysFunction");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public DataSet GetRigntFuncSet(string ActorCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string str = "select a.ActorCode,a.ActorCaption,b.FunCode,b.FunName,b.FormTitle,c.IsAccess,c.Remark ";
                SqlDataAdapter adapter = new SqlDataAdapter(str + "from t_SysActors a,t_SysFunction b,t_SysRightFunc c where a.ActorCode=c.ActorCode and b.FunCode=c.FunCode and a.ActorCode=@ActorCode order by b.FunCode", selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysRightFunc");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public bool ActorCodeIsInRightFuncSet(string ActorCode)
        {
            bool flag;
            bool flag2 = false;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string selectCommandText = "select max(ActorCode) from t_SysRightFunc where ActorCode=@ActorCode";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysRightFunc");
                if (dataSet.Tables[0].Rows[0][0].ToString().Length > 0)
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
                flag = flag2;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return flag;
        }

        public DataSet GetNewFormInsertSysRightFunc(string ActorCode)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string str = " select FunCode,FunName from t_SysFunction ";
                SqlDataAdapter adapter = new SqlDataAdapter(str + " where t_SysFunction.FunCode NOT IN  (select FunCode from t_SysRightFunc where t_SysRightFunc.ActorCode = @ActorCode) ", selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysFunction");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public void InsertRightFuncSet(string ActorCode)
        {
            bool flag = this.ActorCodeIsInRightFuncSet(ActorCode);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command;
                int num;
                SqlParameter parameter;
                SqlParameter parameter2;
                SqlParameter parameter3;
                SqlParameter parameter4;
                if (!flag)
                {
                    DataSet sysFunction = this.GetSysFunction();
                    for (num = 0; num < sysFunction.Tables[0].Rows.Count; num++)
                    {
                        string cmdText = "insert into t_SysRightFunc(ActorCode,FunCode,IsAccess,Remark) values(@ActorCode,@FunCode,@IsAccess,@Remark)";
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        command = new SqlCommand(cmdText, connection)
                        {
                            CommandType = CommandType.Text
                        };
                        parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                        {
                            Value = ActorCode
                        };
                        command.Parameters.Add(parameter);
                        parameter2 = new SqlParameter("@FunCode", SqlDbType.VarChar)
                        {
                            Value = sysFunction.Tables[0].Rows[num]["FunCode"].ToString()
                        };
                        command.Parameters.Add(parameter2);
                        parameter3 = new SqlParameter("@IsAccess", SqlDbType.Int)
                        {
                            Value = 0
                        };
                        command.Parameters.Add(parameter3);
                        parameter4 = new SqlParameter("@Remark", SqlDbType.VarChar)
                        {
                            Value = ""
                        };
                        command.Parameters.Add(parameter4);
                        command.ExecuteNonQuery();
                    }
                }
                if (flag)
                {
                    int count = this.GetSysFunction().Tables[0].Rows.Count;
                    int num3 = this.GetRigntFuncSet(ActorCode).Tables[0].Rows.Count;
                    if (!count.Equals(num3))
                    {
                        DataSet newFormInsertSysRightFunc = new DataSet();
                        newFormInsertSysRightFunc = this.GetNewFormInsertSysRightFunc(ActorCode);
                        for (num = 0; num < newFormInsertSysRightFunc.Tables[0].Rows.Count; num++)
                        {
                            string str2 = "insert into t_SysRightFunc(ActorCode,FunCode,IsAccess,Remark) values(@ActorCode,@FunCode,@IsAccess,@Remark)";
                            if (connection.State == ConnectionState.Closed)
                            {
                                connection.Open();
                            }
                            command = new SqlCommand(str2, connection)
                            {
                                CommandType = CommandType.Text
                            };
                            parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                            {
                                Value = ActorCode
                            };
                            command.Parameters.Add(parameter);
                            parameter2 = new SqlParameter("@FunCode", SqlDbType.VarChar)
                            {
                                Value = newFormInsertSysRightFunc.Tables[0].Rows[num]["FunCode"].ToString()
                            };
                            command.Parameters.Add(parameter2);
                            parameter3 = new SqlParameter("@IsAccess", SqlDbType.Int)
                            {
                                Value = 0
                            };
                            command.Parameters.Add(parameter3);
                            parameter4 = new SqlParameter("@Remark", SqlDbType.VarChar)
                            {
                                Value = ""
                            };
                            command.Parameters.Add(parameter4);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetNewFormCode(string ActorCode, string FormTitle)
        {
            DataSet set;
            SqlConnection selectConnection = new SqlConnection(connectionString);
            try
            {
                string str = "select a.ActorCode,a.FunCode,a.IsAccess,b.FunName,b.FormTitle ";
                SqlDataAdapter adapter = new SqlDataAdapter(str + "from t_SysRightFunc a,t_SysFunction b where a.FunCode=b.FunCode and b.FormTitle=@FormTitle and a.ActorCode=@ActorCode", selectConnection)
                {
                    SelectCommand = { CommandType = CommandType.Text }
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                adapter.SelectCommand.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@FormTitle", SqlDbType.VarChar)
                {
                    Value = FormTitle
                };
                adapter.SelectCommand.Parameters.Add(parameter2);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "t_SysRightFunc");
                set = dataSet;
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                }
            }
            return set;
        }

        public void UpdateRightFuncSet(string ActorCode, string FormTitle, int intIsAccess)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                DataSet newFormCode = this.GetNewFormCode(ActorCode, FormTitle);
                string cmdText = "update t_SysRightFunc set IsAccess=@IsAccess where (select FunCode from t_SysFunction where FormTitle=@FormTitle)=t_SysRightFunc.FunCode and t_SysRightFunc.FunCode=@FunCode and t_SysRightFunc.ActorCode=@ActorCode";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@ActorCode", SqlDbType.VarChar)
                {
                    Value = ActorCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@FormTitle", SqlDbType.VarChar)
                {
                    Value = FormTitle
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@FunCode", SqlDbType.VarChar)
                {
                    Value = newFormCode.Tables[0].Rows[0]["FunCode"].ToString()
                };
                command.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@IsAccess", SqlDbType.Int)
                {
                    Value = intIsAccess
                };
                command.Parameters.Add(parameter4);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdatePassWord(string StaffCode, string PassWord)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "update t_StaffsInfo set PassWord=@PassWord where StaffCode=@StaffCode";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmdText, connection)
                {
                    CommandType = CommandType.Text
                };
                SqlParameter parameter = new SqlParameter("@StaffCode", SqlDbType.VarChar)
                {
                    Value = StaffCode
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@PassWord", SqlDbType.VarChar)
                {
                    Value = PassWord
                };
                command.Parameters.Add(parameter2);
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log.WriteLog("", "异常：" + exception.ToString());
                throw exception;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}