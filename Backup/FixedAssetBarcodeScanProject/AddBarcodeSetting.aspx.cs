using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCT.DAL;
using CCT.Model;
using System.Data;

namespace FixedAssetBarcodeScanProject
{
    public partial class AddBarcodeSetting : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        BARCODESETTINGDal dal = new BARCODESETTINGDal();
        public static string strWhere = "";
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

                this.BtnAdd.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");//ValueIfEmpty
                //this.BtnSave.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
                this.BtnDel.Attributes.Add("onclick", "javascript:return ValueIfEmptyDel();");
                this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");

                DeptDropDownListInit();
                BindGrid(strWhere);
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

        public void BindGrid(string where)
        {
            DataSet ds = new DataSet();
            ds = dal.GetList(where);
            if (!(ds.Tables[0].Columns.Count == 0))
            {
                MyDataGrid.DataSource = ds.Tables[0].DefaultView;
                MyDataGrid.DataBind();
                ShowStats();
            }
        }

        public void MyDataGrid_Page(object sender, DataGridPageChangedEventArgs e)
        {
            int startIndex;
            startIndex = MyDataGrid.CurrentPageIndex * MyDataGrid.PageSize;
            MyDataGrid.CurrentPageIndex = e.NewPageIndex;

            BindGrid(strWhere);
            ShowStats();
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MyDataGrid.CurrentPageIndex = 0;
            MyDataGrid.SelectedIndex = -1;
            strWhere = " 1=1";
            String strDept = dropSearchAdmindept.SelectedValue;

            if (!strDept.Equals("全部"))
            {
                strWhere = strWhere + " AND DEPTCODE = '" + strDept + "'";
            }
            BindGrid(strWhere);
            ShowStats();
        }

        public void DeptDropDownListInit()
        {
            dropAdmindept.Items.Add(new ListItem("设备部", "设备部"));
            dropAdmindept.Items.Add(new ListItem("行政事务部", "行政事务部"));
            dropAdmindept.Items.Add(new ListItem("信息技术部", "信息技术部"));
            dropAdmindept.Items.Add(new ListItem("工程部", "工程部"));
            dropAdmindept.DataBind();
        }

        protected void BtnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (assetclassify.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "资产分类不能为空！");
            }

            bool IsIn = this.NameIsIn(dropAdmindept.SelectedValue.Trim(), assetclassify.Value.Trim());
            bool codeIsIn = this.CodeIsIn(maxcode.Value.Trim());
            if (fixedbarcode.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "固定条码不能为空！");
            }
            else if (fixedbarcode.Value.Trim().Length < 3)
            {
                baseOperation.ShowErrorMessage(this.Page, "固定条码长度不能小于3位！");
            }
            else if (IsIn == true)
            {
                baseOperation.ShowErrorMessage(this.Page, "已经存在该管理部门和资产分类的条码设置！");
            }
            else if (codeIsIn == true)
            {
                baseOperation.ShowErrorMessage(this.Page, "已经存在该固定条码的设置！");
            }
            else
            {
                BARCODESETTINGModel model = new BARCODESETTINGModel();
                model.BARCODEID = baseOperation.GetTableMaxColumnValue("BARCODESETTING", "BARCODEID");
                model.DEPTCODE = dropAdmindept.SelectedValue;
                model.ASSETCLASSIFY = assetclassify.Value.Trim();
                model.FIXEDBARCODE = fixedbarcode.Value.Trim();
                model.MAXCODE = 0;
                model.COMMENTS = comments.Value.Trim();
                dal.Add(model);

                string url;
                url = "Success.aspx?backUrl=AddBarcodeSetting.aspx&erorMessage=条形码设置成功!";
                Log.WriteLog("", Session["username"] + "：条形码设置");
                Response.Redirect(url);
            }
        }

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (assetclassify.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "资产分类不能为空！");
            }

            bool IsIn = this.NameIsIn(dropAdmindept.SelectedValue.Trim(), assetclassify.Value.Trim());
            bool codeIsIn = this.CodeIsIn(maxcode.Value.Trim());
            if (fixedbarcode.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "固定条码不能为空！");
            }
            else if (fixedbarcode.Value.Trim().Length < 3)
            {
                baseOperation.ShowErrorMessage(this.Page, "固定条码长度不能小于3位！");
            }
            else if (IsIn == true)
            {
                baseOperation.ShowErrorMessage(this.Page, "已经存在该管理部门和资产分类的条码设置！");
            }
            else if (codeIsIn == true)
            {
                baseOperation.ShowErrorMessage(this.Page, "已经存在该固定条码的设置！");
            }
            else
            {
                BARCODESETTINGModel model = new BARCODESETTINGModel();
                model.BARCODEID = Int32.Parse(hdBarcodeId.Value.Trim());
                model.DEPTCODE = dropAdmindept.SelectedValue;
                model.ASSETCLASSIFY = assetclassify.Value.Trim();
                model.FIXEDBARCODE = fixedbarcode.Value.Trim();
                model.MAXCODE = Int32.Parse(maxcode.Value.Trim());
                model.COMMENTS = comments.Value.Trim();
                dal.Update(model);

                string url;
                url = "Success.aspx?backUrl=AddBarcodeSetting.aspx&erorMessage=条形码信息修改成功!";
                Log.WriteLog("", Session["username"] + "：条形码信息修改成功");
                Response.Redirect(url);
            }
        }
        private bool NameIsIn(String admindept, String assetclassify)
        {
            bool IsIn = false;
            DataSet ds = dal.GetList(" DEPTCODE='" + admindept + "' AND ASSETCLASSIFY='" + assetclassify + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                IsIn = true;
            }
            return IsIn;
        }

        private bool CodeIsIn(String fixedCode)
        {
            bool IsIn = false;
            DataSet ds = dal.GetList(" FIXEDBARCODE='" + fixedCode + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                IsIn = true;
            }
            return IsIn;
        }

        protected void BtnDel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (int.Parse(maxcode.Value.Trim()) > 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "该资产分类已经被使用，不能删除！");
            }

            dal.Delete(int.Parse(hdBarcodeId.Value.Trim()));
            string url;
            url = "Success.aspx?backUrl=AddBarcodeSetting.aspx&erorMessage=条形码设置成功删除!";
            Log.WriteLog("", Session["username"] + "：删除条形码设置");
            Response.Redirect(url);
        }

        protected void MyDataGrid_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;

            hdBarcodeId.Value = MyDataGrid.Items[X].Cells[0].Text;
            dropAdmindept.SelectedValue = MyDataGrid.Items[X].Cells[1].Text;
            assetclassify.Value = MyDataGrid.Items[X].Cells[2].Text;
            fixedbarcode.Value = MyDataGrid.Items[X].Cells[3].Text;
            maxcode.Value = MyDataGrid.Items[X].Cells[4].Text;
            comments.Value = MyDataGrid.Items[X].Cells[5].Text;

        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            hdBarcodeId.Value = "";
            assetclassify.Value = "";
            fixedbarcode.Value = "";
            maxcode.Value = "";
            comments.Value = "";
        }
    }
}