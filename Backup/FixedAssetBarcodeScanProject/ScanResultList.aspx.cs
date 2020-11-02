using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCT.DAL;
using CCT.Model;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FixedAssetBarcodeScanProject
{
    public partial class ScanResultList : System.Web.UI.Page
    {
        SCANRESULTDal dal = new SCANRESULTDal();
        DEPARTMENTINFODal deptDal = new DEPARTMENTINFODal();
        EMPLOYEEINFODal emplDal = new EMPLOYEEINFODal();
        ZICHANZHUANGTAIDal ztDal = new ZICHANZHUANGTAIDal();
        System.Data.DataTable showData = new System.Data.DataTable();
        public static String strWhere = "";

        Hashtable ztHt = new Hashtable();
        Hashtable deptHt = new Hashtable();
        Hashtable emplHt = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (this.Page.IsPostBack == false)
            {
                //				if((bool)Session["IfLogin"]==false)
                //				{
                //					Response.Redirect("login.aspx");
                //				}

                btnFirst.Text = "最首页";
                btnPrev.Text = "前一页";
                btnNext.Text = "下一页";
                btnLast.Text = "最后页";//加载角色信息列表	

                this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");
                strWhere = " 1=1";
                strWhere = strWhere + " AND DATAFLAG != -1";
                BindGrid(strWhere);
            }
            ztHt = ztDal.GetHashTable("");
            deptHt = deptDal.GetHashTable("");
            emplHt = emplDal.GetHashTable("");
        }

        private void ShowStats()
        {
            lblCurrentIndex.Text = "第 " + (MyDataGrid.CurrentPageIndex + 1).ToString() + " 页";
            lblPageCount.Text = "总共 " + MyDataGrid.PageCount.ToString() + " 页";
        }

        public void PagerButtonClick(object sender, EventArgs e)
        {
            string arg = ((LinkButton)sender).CommandArgument.ToString();
            switch (arg)
            {
                case "next":
                    if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
                    {
                        MyDataGrid.CurrentPageIndex += 1;
                    }
                    break;
                case "prev":
                    if (MyDataGrid.CurrentPageIndex > 0)
                    {
                        MyDataGrid.CurrentPageIndex -= 1;
                    }
                    break;
                case "last":
                    MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
                    break;
                default:
                    MyDataGrid.CurrentPageIndex = System.Convert.ToInt32(arg);
                    break;
            }
            BindGrid(strWhere);
            ShowStats();
        }

        //数据初始化
        public void BindGrid(String strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal.GetList(strWhere);
            if (ds != null && (ds.Tables[0].Columns.Count > 0))
            {

                createDataTable();
                System.Data.DataTable dt = ds.Tables[0];
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    DataRow drnew = showData.NewRow();
                    drnew["BARCODE"] = dr["BARCODE"];
                    drnew["ASSETCODE"] = dr["ASSETCODE"];
                    drnew["RESULT"] = dr["RESULT"];
                    if(dr["RESULT"].ToString().Equals("-1"))
                    {
                        drnew["RESULTNAME"] = "资产不存在";
                    }
                    else if(dr["RESULT"].ToString().Equals("0"))
                    {
                        drnew["RESULTNAME"] = "资产信息有误";
                    }
                    else if (dr["RESULT"].ToString().Equals("1"))
                    {
                        drnew["RESULTNAME"] = "资产信息正确";
                    }
                    else{
                        drnew["RESULTNAME"] = "";
                    }
                    drnew["COMMENTS"] = dr["COMMENTS"];
                    drnew["SCANPERSON"] = dr["SCANPERSON"];
                    drnew["SCANTIME"] = dr["SCANTIME"];
                    showData.Rows.Add(drnew);
                }
            }
            MyDataGrid.DataSource = new DataView(showData);
            MyDataGrid.DataBind();
            ShowStats();
        }
        public void createDataTable()
        {
            showData = new System.Data.DataTable("ShowData");
            showData.Columns.Add(new DataColumn("BARCODE"));
            showData.Columns.Add(new DataColumn("ASSETCODE"));
            showData.Columns.Add(new DataColumn("RESULT"));
            showData.Columns.Add(new DataColumn("RESULTNAME"));
            showData.Columns.Add(new DataColumn("COMMENTS"));
            showData.Columns.Add(new DataColumn("SCANPERSON"));
            showData.Columns.Add(new DataColumn("SCANTIME"));
        }
        public void MyDataGrid_Page(object sender, DataGridPageChangedEventArgs e)
        {
            int startIndex;
            startIndex = MyDataGrid.CurrentPageIndex * MyDataGrid.PageSize;
            MyDataGrid.CurrentPageIndex = e.NewPageIndex;

            BindGrid(strWhere);
            ShowStats();
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MyDataGrid.CurrentPageIndex = 0;
            MyDataGrid.SelectedIndex = -1;
            strWhere = " 1=1";
            strWhere = strWhere + " AND DATAFLAG != -1";
            String strResult = dropResult.SelectedValue;
            String strAssetCode = txtAssetCode.Text.ToString();
            if (!strResult.Equals("-2"))
            {
                strWhere = strWhere + " AND Result = " + strResult + "";
            }
            if (!strAssetCode.Equals(""))
            {
                strWhere = strWhere + " AND ASSETCODE like '%" + strAssetCode + "%'";
            }
            strWhere = strWhere + " ORDER BY SCANTIME DESC";
            BindGrid(strWhere);
            ShowStats();
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable EmptyTable = new DataTable();
            EmptyTable.Columns.Add(new DataColumn("序号", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("条形码", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产编码", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("扫描结果", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("说明", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产名称", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产状态", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("使用部门", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("使用者", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("规格型号", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产设备码", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("序列号", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("管理部门", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产分类", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("扫描者", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("扫描时间", typeof(string)));

            //循环导出盘点结果
            DataSet userDs = dal.GetList(strWhere);
            DataTable dt = userDs.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataRow drNew = EmptyTable.NewRow();

                drNew[0] = i + 1 + "";
                drNew[1] = dr["BARCODE"].ToString();
                drNew[2] = dr["ASSETCODE"].ToString();
                if (dr["RESULT"].ToString().Equals("-1"))
                {
                    drNew[3] = "资产不存在";
                }
                else if (dr["RESULT"].ToString().Equals("0"))
                {
                    drNew[3] = "资产信息有误";
                }
                else if (dr["RESULT"].ToString().Equals("1"))
                {
                    drNew[3] = "资产信息正确";
                }
                else
                {
                    drNew[3] = "";
                }
                drNew[4] = dr["COMMENTS"].ToString();
                FIXEDASSETINFODal assetDal = new FIXEDASSETINFODal();
                String assetCode = dr["ASSETCODE"].ToString().Trim();
                FIXEDASSETINFOModel assetModel = assetDal.GetModel(assetCode);
                if (assetCode.Length > 0 && assetModel != null)
                {
                    drNew[5] = assetModel.ASSETNAME;
                    if (assetModel.ZICHANZHUANGTAI != null && assetModel.ZICHANZHUANGTAI.ToString().Length > 0 && ztHt[assetModel.ZICHANZHUANGTAI.ToString()] != null)
                    {
                        drNew[6] = (ztHt[assetModel.ZICHANZHUANGTAI.ToString()] == null ? "" : ztHt[assetModel.ZICHANZHUANGTAI.ToString()].ToString().Trim());
                    }
                    else
                    {
                        drNew[6] = "";
                    }
                    if (assetModel.SHIYONGBUMEN != null && assetModel.SHIYONGBUMEN.ToString().Length > 0 && deptHt[assetModel.SHIYONGBUMEN.ToString()] != null)
                    {
                        drNew[7] = (deptHt[assetModel.SHIYONGBUMEN.ToString()] == null ? "" : deptHt[assetModel.SHIYONGBUMEN.ToString()].ToString().Trim());
                    }
                    else
                    {
                        drNew[7] = "";
                    }
                    if (assetModel.GUYUANBIANHAO != null && assetModel.GUYUANBIANHAO.ToString().Length > 0 && emplHt[assetModel.GUYUANBIANHAO.ToString()] != null)
                    {
                        drNew[8] = (emplHt[assetModel.GUYUANBIANHAO.ToString()] == null ? "" : emplHt[assetModel.GUYUANBIANHAO.ToString()].ToString().Trim());
                    }
                    else
                    {
                        drNew[8] = "";
                    }
                    drNew[9] = assetModel.GUIGEXINGHAO;
                    drNew[10] = assetModel.ZICHANSHIBEIMA;
                    drNew[11] = assetModel.XULIEHAO;
                    drNew[12] = assetModel.ADMINDEPT;
                    drNew[13] = assetModel.ASSETCLASSIFY;
                }
                else
                {
                    drNew[5] = "";
                    drNew[6] = "";
                    drNew[7] = "";
                    drNew[8] = "";
                    drNew[9] = "";
                    drNew[10] = "";
                    drNew[11] = "";
                    drNew[12] = "";
                    drNew[13] = "";
                }
                drNew[14] = dr["SCANPERSON"].ToString();
                drNew[15] = dr["SCANTIME"].ToString();
                EmptyTable.Rows.Add(drNew);
            }
            this.TableExportExcel(EmptyTable, "ScanResultList");
        }

        public void TableExportExcel(DataTable pdDataGridTable, string psFileName)
        {
            System.Web.HttpResponse httpResponse = this.Page.Response;

            DataGridExport.DataSource = pdDataGridTable.DefaultView;
            DataGridExport.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "GB2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + psFileName + ".xls");
            //Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            this.EnableViewState = false;
            System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            DataGridExport.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        //protected void BtnExport_Click(object sender, EventArgs e)
        //{
        //    Excel.Application app = null;
        //    Excel.Workbook workbook = null; 
        //    Excel.Worksheet worksheet = null; 
        //    Excel.Range workSheet_range = null;

        //    //设置内容数据
        //    try
        //    {
        //        app = new Excel.Application();
        //        app.Visible = true;
        //        workbook = app.Workbooks.Add(1);//创建workbook 
        //        worksheet = (Excel.Worksheet)workbook.Sheets[1];//创建worksheet
        //        worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。
        //        int rows = 0;
        //        //第一行设置格式及内容
        //        Excel.Range workSheet_range2 = null;
        //        workSheet_range2 = worksheet.get_Range("A1", "I1");
        //        workSheet_range2.Merge();//合并单元格
        //        workSheet_range2.Font.Bold = true;//粗体
        //        workSheet_range2.Font.Size = 16;//字号
        //        workSheet_range2.Font.Color = (0 << 16) | (0 << 8) | 0;//字体颜色
        //        workSheet_range2.Interior.Color = (255 << 16) | (255 << 8) | 255;//背景色
        //        workSheet_range2.HorizontalAlignment = Excel.Constants.xlCenter;//居中
        //        workSheet_range2.RowHeight = 30;//行高
        //        workSheet_range2.Borders.Color = System.Drawing.Color.Black.ToArgb();//边框
        //        worksheet.Cells[1, 1] = "固定资产盘点结果";

        //        //第二标题行设置格式及内容
        //        worksheet.Cells[2, 1] = "序号";
        //        worksheet.Cells[2, 2] = "条形码";
        //        worksheet.Cells[2, 3] = "资产编码";
        //        worksheet.Cells[2, 4] = "扫描结果";
        //        worksheet.Cells[2, 5] = "说明";
        //        worksheet.Cells[2, 6] = "资产名称";
        //        worksheet.Cells[2, 7] = "资产状态";
        //        worksheet.Cells[2, 8] = "使用部门";
        //        worksheet.Cells[2, 9] = "使用者";
        //        Excel.Range workSheet_range3 = null;
        //        workSheet_range3 = worksheet.get_Range("A2", "I2");
        //        workSheet_range3.Font.Bold = true;//粗体
        //        workSheet_range3.Font.Size = 14;//字号
        //        workSheet_range3.Font.Color = (255 << 16) | (255 << 8) | 255;//字体颜色
        //        workSheet_range3.Interior.Color = (0 << 16) | (0 << 8) | 0;//背景色
        //        workSheet_range3.HorizontalAlignment = Excel.Constants.xlCenter;//居中
        //        workSheet_range3.Borders.Color = System.Drawing.Color.Black.ToArgb();//边框
        //        //设置列宽
        //        (worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 1])).ColumnWidth = 6;
        //        (worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[2, 2])).ColumnWidth = 10;
        //        (worksheet.get_Range(worksheet.Cells[2, 3], worksheet.Cells[2, 3])).ColumnWidth = 10;
        //        (worksheet.get_Range(worksheet.Cells[2, 4], worksheet.Cells[2, 4])).ColumnWidth = 15;
        //        (worksheet.get_Range(worksheet.Cells[2, 5], worksheet.Cells[2, 5])).ColumnWidth = 25;
        //        (worksheet.get_Range(worksheet.Cells[2, 6], worksheet.Cells[2, 6])).ColumnWidth = 25;
        //        (worksheet.get_Range(worksheet.Cells[2, 7], worksheet.Cells[2, 7])).ColumnWidth = 10;
        //        (worksheet.get_Range(worksheet.Cells[2, 8], worksheet.Cells[2, 8])).ColumnWidth = 15;
        //        (worksheet.get_Range(worksheet.Cells[2, 9], worksheet.Cells[2, 9])).ColumnWidth = 10;

        //        //循环导出盘点结果
        //        DataSet userDs = dal.GetList(strWhere);
        //        DataTable dt = userDs.Tables[0];
        //        rows = 2 + dt.Rows.Count;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            worksheet.Cells[2 + (i + 1), 1] = (i + 1)+"";
        //            DataRow dr = dt.Rows[i];
        //            worksheet.Cells[2 + (i + 1), 2] = dr["BARCODE"].ToString();
        //            worksheet.Cells[2 + (i + 1), 3] = dr["ASSETCODE"].ToString();
        //            if (dr["RESULT"].ToString().Equals("-1"))
        //            {
        //                worksheet.Cells[2 + (i + 1), 4] = "资产不存在";
        //            }
        //            else if (dr["RESULT"].ToString().Equals("0"))
        //            {
        //                worksheet.Cells[2 + (i + 1), 4] = "资产信息有误";
        //            }
        //            else if (dr["RESULT"].ToString().Equals("1"))
        //            {
        //                worksheet.Cells[2 + (i + 1), 4] = "资产信息正确";
        //            }
        //            else
        //            {
        //                worksheet.Cells[2 + (i + 1), 4] = "";
        //            }
        //            worksheet.Cells[2 + (i + 1), 5] = dr["COMMENTS"].ToString();
        //            FIXEDASSETINFODal assetDal = new FIXEDASSETINFODal();
        //            String assetCode = dr["ASSETCODE"].ToString().Trim();
        //            FIXEDASSETINFOModel assetModel = assetDal.GetModel(assetCode);
        //            if (assetCode.Length > 0 && assetModel != null)
        //            {
        //                worksheet.Cells[2 + (i + 1), 6] = assetModel.ASSETNAME;
        //                if (assetModel.ZICHANZHUANGTAI != null && assetModel.ZICHANZHUANGTAI.ToString().Length > 0 && ztHt[assetModel.ZICHANZHUANGTAI.ToString()] != null)
        //                {
        //                    worksheet.Cells[2 + (i + 1), 7] = (ztHt[assetModel.ZICHANZHUANGTAI.ToString()] == null ? "" : ztHt[assetModel.ZICHANZHUANGTAI.ToString()].ToString().Trim());
        //                }
        //                else
        //                {
        //                    worksheet.Cells[2 + (i + 1), 7] = "";
        //                }
        //                if (assetModel.SHIYONGBUMEN != null && assetModel.SHIYONGBUMEN.ToString().Length > 0 && deptHt[assetModel.SHIYONGBUMEN.ToString()] != null)
        //                {
        //                    worksheet.Cells[2 + (i + 1), 8] = (deptHt[assetModel.SHIYONGBUMEN.ToString()] == null ? "" : deptHt[assetModel.SHIYONGBUMEN.ToString()].ToString().Trim());
        //                }
        //                else
        //                {
        //                    worksheet.Cells[2 + (i + 1), 8] = "";
        //                }
        //                if (assetModel.GUYUANBIANHAO != null && assetModel.GUYUANBIANHAO.ToString().Length > 0 && emplHt[assetModel.GUYUANBIANHAO.ToString()] != null)
        //                {
        //                    worksheet.Cells[2 + (i + 1), 9] = (emplHt[assetModel.GUYUANBIANHAO.ToString()] == null ? "" : emplHt[assetModel.GUYUANBIANHAO.ToString()].ToString().Trim());
        //                }
        //                else
        //                {
        //                    worksheet.Cells[2 + (i + 1), 9] = "";
        //                }
        //            }
        //            else
        //            {
        //                worksheet.Cells[2 + (i + 1), 6] = "";
        //                worksheet.Cells[2 + (i + 1), 7] = "";
        //                worksheet.Cells[2 + (i + 1), 8] = "";
        //                worksheet.Cells[2 + (i + 1), 9] = "";
        //            }
        //        }
        //        workSheet_range = worksheet.get_Range("A3", "I" + rows);
        //        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

        //        workbook.SaveCopyAs(@"D:/aa.xls");
        //    }
        //    catch (Exception ee)
        //    {
        //        Log.WriteLog("", "导出异常："+ee.ToString());
        //        MessageBox.Show("盘点结果导出失败，请重新导出。","",MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
        //    }
        //    finally
        //    {
        //        app.Quit(); 
        //    } 
        //}

        //选择数据
        protected void MyDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;
            FIXEDASSETINFODal assetDal = new FIXEDASSETINFODal();
            String assetCode = MyDataGrid.Items[X].Cells[1].Text.Trim();
            if (MyDataGrid.Items[X].Cells[7].Text.Trim().Equals("-1"))
            {
                txtAssetcode2.Text = assetCode;
                txtAssetName.Text = "";
                txtZhuangtai.Text = "";
                txtDept.Text = "";
                txtEmployee.Text = "";
            }
            else
            {
                FIXEDASSETINFOModel assetModel = assetDal.GetModel(assetCode);
                txtAssetcode2.Text = assetCode;
                txtAssetName.Text = assetModel.ASSETNAME;
                if (assetModel.ZICHANZHUANGTAI != null && assetModel.ZICHANZHUANGTAI.ToString().Length > 0)
                {
                    txtZhuangtai.Text = ztHt[assetModel.ZICHANZHUANGTAI.ToString()] == null ? "" : ztHt[assetModel.ZICHANZHUANGTAI.ToString()].ToString();
                }
                else
                {
                    txtZhuangtai.Text = "";
                }
                if (assetModel.SHIYONGBUMEN != null && assetModel.SHIYONGBUMEN.ToString().Length > 0)
                {
                    txtDept.Text = deptHt[assetModel.SHIYONGBUMEN.ToString()] == null ? "" : deptHt[assetModel.SHIYONGBUMEN.ToString()].ToString();
                }
                else
                {
                    txtDept.Text = "";
                }
                if (assetModel.GUYUANBIANHAO != null && assetModel.GUYUANBIANHAO.ToString().Length > 0)
                {
                    txtEmployee.Text = emplHt[assetModel.GUYUANBIANHAO.ToString()] == null ? "" : emplHt[assetModel.GUYUANBIANHAO.ToString()].ToString();
                }
                else
                {
                    txtEmployee.Text = "";
                }
            }
        }
    }
}