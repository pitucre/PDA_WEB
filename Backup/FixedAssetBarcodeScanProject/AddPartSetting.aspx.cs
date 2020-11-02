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
    public partial class AddPartSetting : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面ListStaffsInfo//
            //			if((bool)Session["IfLogin"]==false)
            //			{
            //				Response.Redirect("login.aspx");
            //			}
            // 在此处放置用户代码以初始化页面
            btnFirst.Text = "最首页";
            btnPrev.Text = "前一页";
            btnNext.Text = "下一页";
            btnLast.Text = "最后页";

            this.BtnSave.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
            this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");

            if (!IsPostBack)
            {
                //增加角色列表
                DataSet SysActor = new DataSet();
                SysActor = baseOperation.GetSysActorsInfo();

                ListItemCollection listBoxData = new ListItemCollection();
                //listBoxData.Add("请选择");
                for (int i = 0; i < SysActor.Tables[0].Rows.Count; i++)
                {
                    listBoxData.Add(SysActor.Tables[0].Rows[i][1].ToString());
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
            ds = baseOperation.GetStaffDataSet("");
            MyDataGrid.DataSource = ds.Tables[0].DefaultView;
            MyDataGrid.DataBind();
            ShowStats();
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
            string strStaffCode = MyDataGrid.Items[X].Cells[0].Text.Trim();
            string strStaffCaption = MyDataGrid.Items[X].Cells[1].Text.Trim();
            bool IsIn;

            DataSet dsStaffActor = new DataSet();

            try
            {
                foreach (ListItem li in CBoxSysActors.Items)
                {
                    li.Selected = false;
                }

                IsIn = baseOperation.StaffCodeIsInStaffActorSet(strStaffCode);
                if (IsIn == true)
                {
                    dsStaffActor = baseOperation.GetStaffActorSet(strStaffCode);//该用户对应的相应角色列表

                    for (int i = 0; i < CBoxSysActors.Items.Count; i++)
                    {
                        string strCBox = CBoxSysActors.Items[i].Text.Trim();
                        for (int j = 0; j < dsStaffActor.Tables[0].Rows.Count; j++)
                        {
                            string strSelect = dsStaffActor.Tables[0].Rows[j]["ActorCaption"].ToString().Trim();

                            if (strCBox.Equals(strSelect))
                            {
                                CBoxSysActors.Items[i].Selected = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    baseOperation.ShowErrorMessage(this.Page, "注意：此用户没有任何权限！");
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

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;

            if (Convert.ToString(X).Equals("-1"))
            {
                baseOperation.ShowErrorMessage(this.Page, "请选择用户后再进行相应操作！");
            }

            if (!Convert.ToString(X).Equals("-1"))
            {
                string strStaffCode = MyDataGrid.Items[X].Cells[0].Text.Trim();
                string strStaffCaption = MyDataGrid.Items[X].Cells[1].Text.Trim();
                bool IsInStaffActor = false;

                DataSet dsStaffActor = new DataSet();

                try
                {
                    dsStaffActor = baseOperation.GetStaffActorSet(strStaffCode);//该用户对应的相应角色列表

                    for (int i = 0; i < CBoxSysActors.Items.Count; i++)
                    {
                        if (CBoxSysActors.Items[i].Selected == true)//如果此用户拥有此角色的访问权
                        {
                            //检查此角色是否在此用户的用户角色对应表中
                            string strCBox = CBoxSysActors.Items[i].Text.Trim();//角色名称
                            for (int j = 0; j < dsStaffActor.Tables[0].Rows.Count; j++)
                            {
                                string strSelect = dsStaffActor.Tables[0].Rows[j]["ActorCaption"].ToString().Trim();
                                string strSelectCode = dsStaffActor.Tables[0].Rows[j]["ActorCode"].ToString().Trim();

                                if (strCBox.Equals(strSelect))//如果用户角色表中有此用户权限对应
                                {
                                    IsInStaffActor = true;
                                    break;
                                }

                                if (!strCBox.Equals(strSelect))//如果用户角色表中没有此用户权限对应则增加
                                {
                                    IsInStaffActor = false;
                                }
                            }

                            if (IsInStaffActor == false)
                            {
                                baseOperation.InsertStaffActorSet(strStaffCode, strCBox);
                            }

                        }

                        if (CBoxSysActors.Items[i].Selected == false)//如果此用户没有此角色的访问权
                        {
                            //检查此角色是否在此用户的用户角色对应表中
                            string strCBox = CBoxSysActors.Items[i].Text.Trim();//角色名称
                            for (int j = 0; j < dsStaffActor.Tables[0].Rows.Count; j++)
                            {
                                string strSelect = dsStaffActor.Tables[0].Rows[j]["ActorCaption"].ToString().Trim();
                                string strSelectCode = dsStaffActor.Tables[0].Rows[j]["ActorCode"].ToString().Trim();

                                if (strCBox.Equals(strSelect))//如果用户角色表中有此用户权限对应则删除
                                {
                                    IsInStaffActor = true;
                                    break;
                                }

                                if (!strCBox.Equals(strSelect))//如果用户角色表中没有此用户权限对应
                                {
                                    IsInStaffActor = false;
                                }
                            }

                            if (IsInStaffActor == true)
                            {
                                baseOperation.DeleteStaffActorSet(strStaffCode, strCBox);
                            }
                        }
                        Log.WriteLog("", Session["username"] + "：修改用户[" + strStaffCode + "]的角色");
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
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }
    }
}