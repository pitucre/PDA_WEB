using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CCT.DAL;
using CCT.Model;
using System.Collections;

namespace FixedAssetBarcodeScanProject
{
    public partial class AssetInfoList : System.Web.UI.Page
    {
        FIXEDASSETINFODal dal = new FIXEDASSETINFODal();
        DEPARTMENTINFODal deptDal = new DEPARTMENTINFODal();
        EMPLOYEEINFODal emplDal = new EMPLOYEEINFODal();
        KUAIJILEIBIEDal kjDal = new KUAIJILEIBIEDal();
        SHEBEILEIBIEDal sbDal = new SHEBEILEIBIEDal();
        ZICHANZHUANGTAIDal ztDal = new ZICHANZHUANGTAIDal();
        BARCODESETTINGDal setDal = new BARCODESETTINGDal();
        DataTable showData = new DataTable();
        public string assetClassify = "";
        public static String strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!this.Page.IsPostBack)
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

                BindGrid(strWhere);

                DeptDropDownListInit();
                SearchAdminDeptDropDownListInit();
            }
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
                DataTable dt = ds.Tables[0];
                Hashtable kjHt = kjDal.GetHashtable("");
                Hashtable sbHt = sbDal.GetHashTable("");
                Hashtable ztHt = ztDal.GetHashTable("");
                Hashtable deptHt = deptDal.GetHashTable("");
                Hashtable emplHt = emplDal.GetHashTable("");
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
        //查询条件[使用部门]初始化
        public void DeptDropDownListInit()
        {
            dropDept.Items.Add(new ListItem("全部","-1"));
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
            String strDept = dropDept.SelectedValue;
            String strName = txtName.Text.ToString();
            String strAssetCode = txtAssetCode.Text.ToString();
            String strBarCode = dropBarcode.SelectedValue;
            if (!strDept.Equals("-1"))
            {
                strWhere =strWhere + " AND SHIYONGBUMEN = '" + strDept + "'";
            }
            if (!strName.Equals(""))
            {
                strWhere = strWhere + " AND ASSETNAME like '%" + strName + "%'";
            }
            if (!strAssetCode.Equals(""))
            {
                strWhere = strWhere + " AND ASSETCODE like '%" + strAssetCode + "%'";
            }
            if(!strBarCode.Equals("-1"))
            {
                if (strBarCode.Equals("0"))
                {
                    strWhere = strWhere + " AND (BARCODE IS NULL OR BARCODE = '')";
                }
                else if (strBarCode.Equals("1"))
                {
                    strWhere = strWhere + " AND (BARCODE IS NOT NULL AND BARCODE != '')";
                }
            }
            if (!dropSearchAdmindept.SelectedValue.Equals("全部"))
            {
                strWhere = strWhere + " AND ADMINDEPT = '" + dropSearchAdmindept.SelectedValue.ToString().Trim() + "'";
                string searchClssifyValue = dropClassify.SelectedValue.Trim();
                if (!(searchClssifyValue.Equals("全部") || searchClssifyValue.Equals("")))
                {
                    strWhere = strWhere + " AND ASSETCLASSIFY = '" + searchClssifyValue + "'";
                }
            }
            BindGrid(strWhere);
            ShowStats();
        }

        //选择数据
        protected void MyDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;
            txtAssetcode2.Text = MyDataGrid.Items[X].Cells[1].Text.Trim();
            //管理部门初始化
            AdminDeptDropDownListInit();
            String admindept = MyDataGrid.Items[X].Cells[13].Text.Trim();
            if (admindept != null && admindept.Length > 0 && (!admindept.Equals("&nbsp;")))
            {
                dropAdmindept.SelectedValue = admindept;
            }
            //资产分类初始化
            AssetClassifyDropDownListInit(dropAdmindept.SelectedValue);
            String assetclassify = MyDataGrid.Items[X].Cells[14].Text;
            if (assetclassify != null && assetclassify.Length > 0 && (!assetclassify.Equals("&nbsp;")))
            {
                dropAssetclassify.SelectedValue = assetclassify;
            }
            dropAdmindept.Focus();
        }

        //查询条件管理部门初始化
        public void SearchAdminDeptDropDownListInit()
        {
            dropSearchAdmindept.Items.Clear();
            dropSearchAdmindept.Items.Add(new ListItem("全部", "全部"));
            assetClassify = "全部,全部;";
            DataSet ds = setDal.GetDeptList();
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string admindept = dr[0].ToString().Trim();
                    dropSearchAdmindept.Items.Add(new ListItem(admindept, admindept));

                    assetClassify = assetClassify + admindept;
                    DataSet ds2 = setDal.GetAssetclassifyList(admindept);
                    DataTable dt2 = ds2.Tables[0];
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        DataRow dr2 = dt2.Rows[j];
                        assetClassify = assetClassify + "," + dr2[0].ToString().Trim();
                    }
                    assetClassify = assetClassify + ";";
                }
            }
            dropSearchAdmindept.DataBind();

            dropClassify.Items.Add(new ListItem("全部", "全部"));
            dropClassify.DataBind();
        }

        //查询条件管理部门初始化
        public void SearchClassifyDropDownListInit(String deptcode)
        {
            dropClassify.Items.Clear();
            dropClassify.Items.Add(new ListItem("全部", "全部"));
            DataSet ds = setDal.GetAssetclassifyList(deptcode);
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    dropClassify.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString().Trim()));
                }
            }
            dropClassify.DataBind();
        }

        //管理部门初始化
        public void AdminDeptDropDownListInit()
        {
            dropAdmindept.Items.Clear();
            dropAdmindept.Items.Add(new ListItem("", ""));
            DataSet ds = setDal.GetDeptList();
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    dropAdmindept.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString().Trim()));
                }
            }
            dropAdmindept.DataBind();
        }

        //资产分类初始化
        public void AssetClassifyDropDownListInit(String deptcode)
        {
            dropAssetclassify.Items.Clear();
            DataSet ds = setDal.GetAssetclassifyList(deptcode);
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    dropAssetclassify.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString().Trim()));
                }
            }
            dropAssetclassify.DataBind();
        }

        //保存
        protected void BtnSave_Click(object sender, ImageClickEventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;

            if (!(dropAdmindept.SelectedValue.ToString().Trim().Equals(MyDataGrid.Items[X].Cells[15].Text.Trim())
                && dropAssetclassify.SelectedValue.ToString().Trim().Equals(MyDataGrid.Items[X].Cells[16].Text.Trim())))
            {
                BARCODESETTINGDal setDal = new BARCODESETTINGDal();
                //根据管理部门，资产分类生成条码
                String barcode = setDal.GetBarcode(dropAdmindept.SelectedValue.ToString().Trim(), dropAssetclassify.SelectedValue.ToString().Trim());
                if (dal.UpdateBarcode(barcode, txtAssetcode2.Text.Trim(), 
                    dropAdmindept.SelectedValue.ToString().Trim(), dropAssetclassify.SelectedValue.ToString().Trim()))
                {
                    //修改条码设之中的最大值
                    setDal.AddMaxCode(dropAdmindept.SelectedValue.ToString().Trim(), dropAssetclassify.SelectedValue.ToString().Trim());

                    BindGrid(strWhere);
                    ShowStats();
                }
            }
        }

        //[管理部门]变化时，联动[资产分类]
        protected void dropAdmindept_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssetClassifyDropDownListInit(dropAdmindept.SelectedValue);
            dropAssetclassify.Focus();
        }

        protected void dropSearchAdmindept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchClassifyDropDownListInit(dropSearchAdmindept.SelectedValue);
        }
    }
}