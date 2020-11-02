using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CCT.DAL;

namespace FixedAssetBarcodeScanProject
{
    public partial class AddPurviewSetting : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        public string ActorCode//角色编号
        {
            get { return ViewState["actorCode"] + string.Empty; }
            set { ViewState["actorCode"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //				if((bool)Session["IfLogin"]==false)
                //				{
                //					Response.Redirect("login.aspx");
                //				}

                this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");

                btnFirst.Text = "最首页";
                btnPrev.Text = "前一页";
                btnNext.Text = "下一页";
                btnLast.Text = "最后页";

                DataSet SysActor = new DataSet();
                SysActor = baseOperation.GetSysFunction();

                ListItemCollection listBoxData = new ListItemCollection();
                //listBoxData.Add("请选择");
                for (int i = 0; i < SysActor.Tables[0].Rows.Count; i++)
                {
                    listBoxData.Add(SysActor.Tables[0].Rows[i]["FormTitle"].ToString());
                }
                CBoxSysActors.DataSource = listBoxData;
                CBoxSysActors.DataBind();

                BindGrid();
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
            string strActorCode = MyDataGrid.Items[X].Cells[0].Text.Trim();
            this.ActorCode = strActorCode;
            string strActorCaption = MyDataGrid.Items[X].Cells[1].Text.Trim();

            DataSet dsStaff = new DataSet();

            try
            {
                foreach (ListItem li in CBoxSysActors.Items)
                {
                    li.Selected = false;
                }

                baseOperation.InsertRightFuncSet(strActorCode);
                dsStaff = baseOperation.GetRigntFuncSet(strActorCode);//该角色的相应权限列表

                for (int i = 0; i < dsStaff.Tables[0].Rows.Count; i++)
                {
                    string strCBox = CBoxSysActors.Items[i].Text.Trim();
                    string strSelect = dsStaff.Tables[0].Rows[i]["FormTitle"].ToString();

                    if (strCBox.Equals(strSelect))
                    {
                        string Compare = "1";

                        string xxx = dsStaff.Tables[0].Rows[i]["IsAccess"].ToString();
                        if (dsStaff.Tables[0].Rows[i]["IsAccess"].ToString() == Compare)
                        {
                            CBoxSysActors.Items[i].Selected = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;

            if (Convert.ToString(X).Equals("-1"))
            {
                baseOperation.ShowErrorMessage(this.Page, "请选择角色后再进行相应操作！");
            }

            if (!Convert.ToString(X).Equals("-1"))
            {

                string strActorCode = MyDataGrid.Items[X].Cells[0].Text.Trim();
                string strActorCaption = MyDataGrid.Items[X].Cells[1].Text.Trim();

                DataSet dsStaff = new DataSet();

                try
                {
                    dsStaff = baseOperation.GetRigntFuncSet(strActorCode);//该角色编号的相应权限设置

                    for (int i = 0; i < dsStaff.Tables[0].Rows.Count; i++)
                    {
                        string strCBox = CBoxSysActors.Items[i].Text.Trim().ToString();
                        string strSelect = dsStaff.Tables[0].Rows[i]["FormTitle"].ToString();
                        if (strCBox.Equals(strSelect))
                        {
                            if (CBoxSysActors.Items[i].Selected == true)
                            {
                                baseOperation.UpdateRightFuncSet(strActorCode, strSelect, 1);
                            }
                            if (CBoxSysActors.Items[i].Selected == false)
                            {
                                baseOperation.UpdateRightFuncSet(strActorCode, strSelect, 0);
                            }
                        }
                    }

                    string url;
                    url = "Success.aspx?backUrl=AddPurviewSetting.aspx&erorMessage=编号为:" + this.ActorCode + "的角色成功分配权限!";
                    Log.WriteLog("", Session["username"] + "：修改角色[" + strActorCode + "]的权限");
                    Response.Redirect(url);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    foreach (ListItem li in CBoxSysActors.Items)
                    {
                        li.Selected = false;
                    }

                }
            }
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }

        protected void chkAllSelect_CheckedChanged(object sender, System.EventArgs e)
        {
            chkAllSelect.Checked = true;
            chkAllKill.Checked = false;
            chkAllElse.Checked = false;

            foreach (ListItem li in CBoxSysActors.Items)
            {
                li.Selected = true;
            }
        }

        protected void chkAllKill_CheckedChanged(object sender, System.EventArgs e)
        {
            chkAllSelect.Checked = false;
            chkAllKill.Checked = true;
            chkAllElse.Checked = false;

            foreach (ListItem li in CBoxSysActors.Items)
            {
                li.Selected = false;
            }
        }

        protected void chkAllElse_CheckedChanged(object sender, System.EventArgs e)
        {
            chkAllSelect.Checked = false;
            chkAllKill.Checked = false;
            chkAllElse.Checked = true;

            foreach (ListItem li in CBoxSysActors.Items)
            {
                if (li.Selected == true)
                {
                    li.Selected = false;
                }
                else if (li.Selected == false)
                {
                    li.Selected = true;
                }

            }
        }
    }
}