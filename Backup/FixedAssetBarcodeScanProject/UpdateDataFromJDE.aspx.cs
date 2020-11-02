using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCT.DAL;
using CCT.Model;
using System.Data;
using System.Data.OleDb;

namespace FixedAssetBarcodeScanProject
{
    public partial class UpdateDataFromJDE : System.Web.UI.Page
    {
        BaseOperation baseoperation = new BaseOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");
            this.btnRefresh.Attributes.Add("onclick", "javascript:return FrmRefresh();");
            this.btnUpload.Attributes.Add("onclick", "javascript:return FrmUpload();");
            this.btnSaveResult.Attributes.Add("onclick", "javascript:return FrmSavedResult();");
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }

        protected void BtnRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            btnRefresh.Enabled = false;
            
            if (baseoperation.RefreshDataFromJDE())
            {
                Log.WriteLog("", Session["username"] + "从JDE系统更新数据成功。");
                baseoperation.ShowErrorMessage(this.Page, "从JDE系统更新数据成功");
            }
            btnRefresh.Enabled = true;
        }

        protected void BtnSaveResult_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SCANRESULTDal resultDal = new SCANRESULTDal();
            resultDal.StopScanResult();
            baseoperation.ShowErrorMessage(this.Page, "封存盘点结果成功");
        }

        protected void BtnUpload_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string filepath = Server.MapPath("./"); //当前路径
            string fileName = FileUpload1.FileName;
            if (fileName.Length > 0)
            {
                filepath += fileName;
                FileUpload1.SaveAs(filepath);

                try
                {
                    string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filepath + ";" + "Extended Properties=\"Excel 8.0;\"";
                    OleDbConnection conn = new OleDbConnection(strConn);
                    conn.Open();
                    string strExcel = "";
                    OleDbDataAdapter myCommand = null;
                    DataSet ds = null;
                    strExcel = "select * from [sheet1$]";
                    myCommand = new OleDbDataAdapter(strExcel, strConn);
                    ds = new DataSet();
                    myCommand.Fill(ds, "table1");
                    conn.Close();
                    conn.Dispose();
                    int count = 0;
                    //不存在的资产编码
                    string noexitCode = "";
                    //已经导入条码的资产编码
                    string existCode = "";
                    //不存在的资产分类
                    string noexistClassify = "";
                    //条形码长度不等于9
                    string lengtherror = "";
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        FIXEDASSETINFODal assetDal = new FIXEDASSETINFODal();
                        FIXEDASSETINFOModel assetModel = new FIXEDASSETINFOModel();
                        BARCODESETTINGDal setDal = new BARCODESETTINGDal();
                        BARCODESETTINGModel setModel = new BARCODESETTINGModel();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];
                            assetModel = assetDal.GetModel(dr[0].ToString().Trim());
                            if (assetModel != null)
                            {
                                string barcode = dr[1].ToString().Trim();
                                if (barcode.Length == 9)
                                {
                                    setModel = setDal.GetModelDueCode(barcode.Substring(0, 3));
                                    if (setModel != null)
                                    {
                                        if (assetModel.BARCODE != null && assetModel.BARCODE.Length > 0
                                            && assetModel.ADMINDEPT != null && assetModel.ADMINDEPT.Length > 0
                                            && (!assetModel.ADMINDEPT.Equals(setModel.DEPTCODE)))
                                        {
                                            if (existCode.Length > 0)
                                            {
                                                existCode = existCode + "," + dr[0].ToString().Trim();
                                            }
                                            else
                                            {
                                                existCode = dr[0].ToString().Trim();
                                            }
                                        }
                                        else
                                        {
                                            assetModel.BARCODE = barcode;
                                            if (setModel != null)
                                            {
                                                assetModel.ADMINDEPT = setModel.DEPTCODE;
                                                assetModel.ASSETCLASSIFY = setModel.ASSETCLASSIFY;
                                            }
                                            assetDal.Update(assetModel);

                                            int maxcode = int.Parse(barcode.Substring(3));
                                            if (setModel.MAXCODE < maxcode)
                                            {
                                                setModel.MAXCODE = maxcode;
                                                setDal.Update(setModel);
                                            }
                                            count++;
                                        }
                                    }
                                    else
                                    {
                                        if (noexistClassify.Length > 0)
                                        {
                                            noexistClassify = noexistClassify + "," + dr[0].ToString().Trim();
                                        }
                                        else
                                        {
                                            noexistClassify = dr[0].ToString().Trim();
                                        }
                                    }
                                }
                                else
                                {
                                    if (lengtherror.Length > 0)
                                    {
                                        lengtherror = lengtherror + "," + dr[0].ToString().Trim();
                                    }
                                    else
                                    {
                                        lengtherror = dr[0].ToString().Trim();
                                    }
                                }
                            }
                            else
                            {
                                if (noexitCode.Length > 0)
                                {
                                    noexitCode = noexitCode + "," + dr[0].ToString().Trim();
                                }
                                else
                                {
                                    noexitCode = dr[0].ToString().Trim();
                                }
                            }
                        }
                        string strMsg = "";
                        if (noexitCode.Length > 0)
                        {
                            strMsg = strMsg + @"系统中不存在资产编码[" + noexitCode + "]。";
                        }
                        if (lengtherror.Length > 0)
                        {
                            if (strMsg.Length > 0)
                            {
                                strMsg = strMsg + @"\n\n";
                            }
                            strMsg = strMsg + @"资产编码[" + lengtherror + "]的条形码长度不是9，所以不能导入。";
                        }
                        if (existCode.Length > 0)
                        {
                            if (strMsg.Length > 0)
                            {
                                strMsg = strMsg + @"\n\n";
                            }
                            strMsg = strMsg + @"资产编码[" + existCode + "]已经存在条形码，且资产管理部门为其他部门，所以不能导入。";
                        }
                        if (noexistClassify.Length > 0)
                        {
                            if (strMsg.Length > 0)
                            {
                                strMsg = strMsg + @"\n\n";
                            }
                            strMsg = strMsg + @"资产编码[" + noexistClassify + "]对应的资产分类不存在，请在条形码设置画面添加分类后再进行导入操作。";
                        }
                        if (strMsg.Length > 0)
                        {
                            strMsg = strMsg + @"\n\n";
                        }
                        strMsg = strMsg + @"共有" + count + "个资产的条形码信息成功导入。";
                        baseoperation.ShowErrorMessage(this.Page, @strMsg);
                    }
                    else
                    {
                        baseoperation.ShowErrorMessage(this.Page, "该文件为空，没有进行资产的条形码信息更新。");
                    }
                }
                catch (Exception ee) {
                    Log.WriteLog("", ee.ToString());
                    baseoperation.ShowErrorMessage(this.Page, "上传条形码信息出错，请重新操作。");
                }
                
            }
            else
            {
                baseoperation.ShowErrorMessage(this.Page, "请选择上传文件。");
            }
            
        }
    }
}