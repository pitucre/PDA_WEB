using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCT.DAL;
using System.Data;

namespace FixedAssetBarcodeScanProject
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        CCT.DAL.EMPLOYEEINFODal dal = new EMPLOYEEINFODal();
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

                this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");

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
            String strDept = txtcode.Text.ToString().Trim();
            String strName = txtname.Text.ToString().Trim();
            if (!strDept.Equals(""))
            {
                strWhere = strWhere + " AND EMPLOYEECODE like '%" + strDept + "%'";
            }
            if (!strName.Equals(""))
            {
                strWhere = strWhere + " AND EMPLOYEENAME like '%" + strName + "%'";
            }
            BindGrid(strWhere);
            ShowStats();
        }
    }
}