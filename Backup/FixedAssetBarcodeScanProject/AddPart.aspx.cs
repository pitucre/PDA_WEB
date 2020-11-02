using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CCT.DAL;

namespace FixedAssetBarcodeScanProject
{
    public partial class AddPart : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面

            btnFirst.Text = "最首页";
            btnPrev.Text = "前一页";
            btnNext.Text = "下一页";
            btnLast.Text = "最后页";

            //			if((bool)Session["IfLogin"]==false)
            //			{
            //				Response.Redirect("login.aspx");
            //			}
            // 在此处放置用户代码以初始化页面
            if (!IsPostBack)
            {
                BindGrid();
            }

            this.BtnAdd.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
            this.BtnSave.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
            this.BtnDel.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
            this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");
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
            BindGrid();
            ShowStats();
        }
        public void BindGrid()
        {
            DataSet ds = new DataSet();
            ds = baseOperation.GetActorDataSet();

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

            BindGrid();
            ShowStats();
        }

        protected void MyDataGrid_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;
            t_ActorCode.Value = MyDataGrid.Items[X].Cells[0].Text;
            t_ActorCaption.Value = MyDataGrid.Items[X].Cells[1].Text;
            t_ActorType.Value = MyDataGrid.Items[X].Cells[2].Text;
            //t_Remark.Value = MyDataGrid.Items[X].Cells[3].Text;
        }

        protected void BtnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            bool IsIn = CodeIsIn();

            if (IsIn == false)
            {
                baseOperation.InserActorInfo(t_ActorCaption.Value.Trim(), t_ActorType.Value.Trim());
                Log.WriteLog("", Session["username"] + "：增加角色编号" + t_ActorCaption.Value.Trim());
                ClearText();
            }

            if (IsIn == true)
            {
                baseOperation.ShowErrorMessage(this.Page, "数据库中已经有此数据编号！");
            }
        }

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            bool IsIn = CodeIsIn();

            if (IsIn == true)
            {
                baseOperation.UpdateActorInfo(t_ActorCode.Value.Trim(), t_ActorCaption.Value.Trim(), t_ActorType.Value.Trim());
                Log.WriteLog("", Session["username"] + "：修改角色编号" + t_ActorCaption.Value.Trim());
                ClearText();
            }

            if (IsIn == false)
            {
                baseOperation.ShowErrorMessage(this.Page, "数据库中没有此角色编号，不能进行修改操作！");
            }
        }

        protected void BtnDel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            bool IsIn = CodeIsIn();

            if (IsIn == true)
            {
                baseOperation.DeleteActorInfo(t_ActorCode.Value.Trim());
                Log.WriteLog("", Session["username"] + "：删除角色编号" + t_ActorCaption.Value.Trim());
                ClearText();
            }

            if (IsIn == false)
            {
                baseOperation.ShowErrorMessage(this.Page, "数据库中没有此角色编号，不能进行删除操作！");
            }
        }

        private void ClearText()
        {
            t_ActorCode.Value = "";
            t_ActorCaption.Value = "";
            t_ActorType.Value = "";
            //t_Remark.Value ="";

            BindGrid();
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }

        private bool CodeIsIn()
        {
            bool IsIn = baseOperation.ActorCodeIsInSysActor(t_ActorCode.Value.Trim().ToString());
            return IsIn;
        }		
    }
}