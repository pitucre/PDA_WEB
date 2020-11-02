using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using CCT.DAL;

namespace FixedAssetBarcodeScanProject
{
    public partial class NotScanAssetList : System.Web.UI.Page
    {
        DataTable showData = new DataTable();
        public static String strWhere = "";
        FIXEDASSETINFODal dal = new FIXEDASSETINFODal();
        DEPARTMENTINFODal deptDal = new DEPARTMENTINFODal();
        EMPLOYEEINFODal emplDal = new EMPLOYEEINFODal();
        ZICHANZHUANGTAIDal ztDal = new ZICHANZHUANGTAIDal();
        KUAIJILEIBIEDal kjDal = new KUAIJILEIBIEDal();
        SHEBEILEIBIEDal sbDal = new SHEBEILEIBIEDal();

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
                DeptDropDownListInit();
                strWhere = " 1=1";
                //strWhere = strWhere + " AND (BARCODE IS NULL OR BARCODE NOT IN (SELECT BARCODE FROM SCANRESULT WHERE DATAFLAG != -1))";
                strWhere = strWhere + " AND (BARCODE IS NULL OR not exists (select 1 from  SCANRESULT   WHERE DATAFLAG != -1 and BARCODE=FS.BARCODE))";//2020-11-02 优化代码 原先的查询语句太慢

                BindGrid(strWhere);
            }
        }

        //数据初始化
        public void BindGrid(String strWhere)
        {
            DataSet ds = new DataSet();

            ds = dal.GetList(strWhere);
            if (ds != null && (ds.Tables[0].Columns.Count > 0))
            {
                createDataTable();
                DataTable dt = ds.Tables[0];
                Hashtable ztHt = ztDal.GetHashTable("");
                Hashtable deptHt = deptDal.GetHashTable("");
                Hashtable emplHt = emplDal.GetHashTable("");
                Hashtable kjHt = kjDal.GetHashtable("");
                Hashtable sbHt = sbDal.GetHashTable("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    DataRow drnew = showData.NewRow();
                    drnew["BARCODE"] = dr["BARCODE"];
                    drnew["ASSETCODE"] = dr["ASSETCODE"];
                    drnew["ASSETNAME"] = dr["ASSETNAME"];
                    drnew["KUAIJILEIBIE"] = dr["KUAIJILEIBIE"];
                    drnew["KUAIJILEIBIENAME"] = kjHt == null ? "" : kjHt[dr["KUAIJILEIBIE"].ToString().Trim()];
                    drnew["SHEBEILEIBIE"] = dr["SHEBEILEIBIE"];
                    drnew["SHEBEILEIBIENAME"] = sbHt == null ? "" : sbHt[dr["SHEBEILEIBIE"].ToString().Trim()];
                    drnew["GUIGEXINGHAO"] = dr["GUIGEXINGHAO"];
                    drnew["ZICHANZHUANGTAI"] = dr["ZICHANZHUANGTAI"];
                    drnew["ZICHANZHUANGTAINAME"] = ztHt == null ? "" : ztHt[dr["ZICHANZHUANGTAI"].ToString().Trim()];
                    drnew["CUNFANGDIDIAN"] = dr["CUNFANGDIDIAN"];
                    drnew["CUNFANGDIDIANNAME"] = deptHt == null ? "" : deptHt[dr["CUNFANGDIDIAN"].ToString().Trim()];
                    drnew["SHIYONGBUMEN"] = dr["SHIYONGBUMEN"];
                    drnew["SHIYONGBUMENNAME"] = deptHt == null ? "" : deptHt[dr["SHIYONGBUMEN"].ToString().Trim()];
                    drnew["GUYUANBIANHAO"] = dr["GUYUANBIANHAO"];
                    drnew["GUYUANBIANHAONAME"] = emplHt == null ? "" : emplHt[dr["GUYUANBIANHAO"].ToString().Trim()];
                    drnew["ZICHANSHIBEIMA"] = dr["ZICHANSHIBEIMA"];
                    drnew["BEIZHU"] = dr["BEIZHU"];
                    drnew["XULIEHAO"] = dr["XULIEHAO"];
                    drnew["SUPPLIER"] = dr["SUPPLIER"];
                    drnew["ADMINDEPT"] = dr["ADMINDEPT"];
                    drnew["ASSETCLASSIFY"] = dr["ASSETCLASSIFY"];
                    showData.Rows.Add(drnew);
                }
            }

            MyDataGrid.DataSource = new DataView(showData);
            MyDataGrid.DataBind();
            ShowStats();
        }

        public void createDataTable()
        {
            showData = new DataTable("ShowData");
            showData.Columns.Add(new DataColumn("BARCODE"));
            showData.Columns.Add(new DataColumn("ASSETCODE"));
            showData.Columns.Add(new DataColumn("ASSETNAME"));
            showData.Columns.Add(new DataColumn("KUAIJILEIBIE"));
            showData.Columns.Add(new DataColumn("KUAIJILEIBIENAME"));
            showData.Columns.Add(new DataColumn("SHEBEILEIBIE"));
            showData.Columns.Add(new DataColumn("SHEBEILEIBIENAME"));
            showData.Columns.Add(new DataColumn("GUIGEXINGHAO"));
            showData.Columns.Add(new DataColumn("ZICHANZHUANGTAI"));
            showData.Columns.Add(new DataColumn("ZICHANZHUANGTAINAME"));
            showData.Columns.Add(new DataColumn("CUNFANGDIDIAN"));
            showData.Columns.Add(new DataColumn("CUNFANGDIDIANNAME"));
            showData.Columns.Add(new DataColumn("SHIYONGBUMEN"));
            showData.Columns.Add(new DataColumn("SHIYONGBUMENNAME"));
            showData.Columns.Add(new DataColumn("GUYUANBIANHAO"));
            showData.Columns.Add(new DataColumn("GUYUANBIANHAONAME"));
            showData.Columns.Add(new DataColumn("ZICHANSHIBEIMA"));
            showData.Columns.Add(new DataColumn("BEIZHU"));
            showData.Columns.Add(new DataColumn("XULIEHAO"));
            showData.Columns.Add(new DataColumn("SUPPLIER"));
            showData.Columns.Add(new DataColumn("ADMINDEPT"));
            showData.Columns.Add(new DataColumn("ASSETCLASSIFY"));
        }

        public void MyDataGrid_Page(object sender, DataGridPageChangedEventArgs e)
        {
            int startIndex;
            startIndex = MyDataGrid.CurrentPageIndex * MyDataGrid.PageSize;
            MyDataGrid.CurrentPageIndex = e.NewPageIndex;

            BindGrid(strWhere);
            ShowStats();
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
            strWhere = strWhere + " AND BARCODE NOT IN (SELECT BARCODE FROM SCANRESULT WHERE DATAFLAG != -1)";
            String strDept = dropDept.SelectedValue;
            String strAdminDept = dropAdminDept.SelectedValue.ToString();
            if (!strDept.Equals("-1"))
            {
                strWhere = strWhere + " AND SHIYONGBUMEN = '" + strDept + "'";
            }
            if (!strAdminDept.Equals("全部"))
            {
                strWhere = strWhere + " AND ADMINDEPT = '" + strAdminDept + "'";
            }
            BindGrid(strWhere);
            ShowStats();
        }

        //查询条件[使用部门]初始化
        public void DeptDropDownListInit()
        {
            dropDept.Items.Add(new ListItem("全部", "-1"));
            DataSet ds = dal.GetDeptList();
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    dropDept.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString().Trim()));
                }
            }
            dropDept.DataBind();
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable EmptyTable = new DataTable();
            EmptyTable.Columns.Add(new DataColumn("序号", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("条形码", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产编码", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产名称", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产状态", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("使用部门", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("使用者", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("规格型号", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产设备码", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("序列号", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("管理部门", typeof(string)));
            EmptyTable.Columns.Add(new DataColumn("资产分类", typeof(string)));

            //循环导出盘点结果
            DataSet userDs = dal.GetList(strWhere);
            DataTable dt = userDs.Tables[0];
            Hashtable ztHt = ztDal.GetHashTable("");
            Hashtable deptHt = deptDal.GetHashTable("");
            Hashtable emplHt = emplDal.GetHashTable("");
            Hashtable kjHt = kjDal.GetHashtable("");
            Hashtable sbHt = sbDal.GetHashTable("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataRow drNew = EmptyTable.NewRow();
                drNew[0] = i + 1 + "";
                drNew[1] = dr["BARCODE"];
                drNew[2] = dr["ASSETCODE"];
                drNew[3] = dr["ASSETNAME"];
                if (dr["ZICHANZHUANGTAI"] != null && dr["ZICHANZHUANGTAI"].ToString().Length > 0 && ztHt[dr["ZICHANZHUANGTAI"].ToString()] != null)
                {
                    drNew[4] = (ztHt[dr["ZICHANZHUANGTAI"].ToString()] == null ? "" : ztHt[dr["ZICHANZHUANGTAI"].ToString()].ToString().Trim());
                }
                else
                {
                    drNew[4] = "";
                }
                if (dr["SHIYONGBUMEN"] != null && dr["SHIYONGBUMEN"].ToString().Length > 0 && deptHt[dr["SHIYONGBUMEN"].ToString()] != null)
                {
                    drNew[5] = (deptHt[dr["SHIYONGBUMEN"].ToString()] == null ? "" : deptHt[dr["SHIYONGBUMEN"].ToString()].ToString().Trim());
                }
                else
                {
                    drNew[5] = "";
                }
                if (dr["GUYUANBIANHAO"] != null && dr["GUYUANBIANHAO"].ToString().Length > 0 && emplHt[dr["GUYUANBIANHAO"].ToString()] != null)
                {
                    drNew[6] = (emplHt[dr["GUYUANBIANHAO"].ToString()] == null ? "" : emplHt[dr["GUYUANBIANHAO"].ToString()].ToString().Trim());
                }
                else
                {
                    drNew[6] = "";
                }
                drNew[7] = dr["GUIGEXINGHAO"];
                drNew[8] = dr["ZICHANSHIBEIMA"];
                drNew[9] = dr["XULIEHAO"];
                drNew[10] = dr["ADMINDEPT"];
                drNew[11] = dr["ASSETCLASSIFY"];
                EmptyTable.Rows.Add(drNew);
            }
            this.TableExportExcel(EmptyTable, "NotScanList");
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
    }
}