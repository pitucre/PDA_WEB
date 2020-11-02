using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using CCT.DAL;

namespace FixedAssetBarcodeScanProject
{
    public partial class AddUser : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        public string StaffCode//登录用户编号
        {
            get { return ViewState["staffCode"] + string.Empty; }
            set { ViewState["staffCode"] = value; }
        }

        public string ActorCode//角色编号
        {
            get { return ViewState["actorCode"] + string.Empty; }
            set { ViewState["actorCode"] = value; }
        }

        public string PassWord//密码
        {
            get { return ViewState["passWord"] + string.Empty; }
            set { ViewState["passWord"] = value; }
        }

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
                this.BtnSave.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
                this.BtnDel.Attributes.Add("onclick", "javascript:return ValueIfEmptyDel();");
                this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");

                DataSet ActorList = new DataSet();
                ActorList = baseOperation.GetActorDataSet();

                ddlActorList.Items.Add("");

                for (int i = 0; i < ActorList.Tables[0].Rows.Count; i++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = ActorList.Tables[0].Rows[i]["ActorCode"].ToString();
                    listItem.Text = ActorList.Tables[0].Rows[i]["ActorCaption"].ToString();
                    ddlActorList.Items.Add(listItem);
                }

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

        protected void BtnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            bool IsIn = this.NameIsIn();

            if (t_PassWd.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "密码不能为空！");
            }
            else if (t_PassWd.Value.Trim().Length < 6)
            {
                baseOperation.ShowErrorMessage(this.Page, "密码长度不能小于6位！");
            }
            else if (IsIn == true)
            {
                baseOperation.ShowErrorMessage(this.Page, "用户姓名重复！");
            }
            else
            {
                string newPW = baseOperation.newPW(t_PassWd.Value.Trim(), "MD5");


                this.StaffCode = baseOperation.InserStaffInfo(t_StaffCaption.Value.Trim(), newPW, t_Remark.Value.Trim(), ddl_usertype.SelectedItem.Value);



                //如果所属角色不为空,则进行添加用户角色操作,只添加一个!
                if (ddlActorList.SelectedItem.Value.Length > 0)
                {
                    baseOperation.InsertActorByStaff(this.StaffCode, ddlActorList.SelectedItem.Value);
                }

                string url;
                url = "Success.aspx?backUrl=AddUser.aspx&erorMessage=编号为:" + this.StaffCode + "的用户成功新增!";
                Log.WriteLog("", Session["username"] + "：增加用户" + StaffCode);
                Response.Redirect(url);

                //				ClearText();
            }
        }

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            bool IsIn = this.CodeIsIn();

            if (IsIn == true)
            {
                if (t_PassWd.Value.Trim().Length == 0)
                {
                    baseOperation.ShowErrorMessage(this.Page, "密码不能为空！");
                }
                else if (t_PassWd.Value.Trim().Length < 6)
                {
                    baseOperation.ShowErrorMessage(this.Page, "密码长度不能小于6位！");
                }
                else
                {
                    string newPW = baseOperation.newPW(t_PassWd.Value.Trim(), "MD5");

                    //----------------------------------------------------------------------------------------------------
                    baseOperation.UpdateStaffInfo(this.StaffCode, t_StaffCaption.Value.Trim(), newPW, t_Remark.Value.Trim(), Convert.ToInt32(ddl_usertype.SelectedItem.Value));

                    //如果所属角色不为空,则进行添加用户角色操作,只添加一个!
                    if (ddlActorList.SelectedItem.Value.Length > 0)
                    {
                        //						//对角色进行更新操作
                        if (this.ActorCode.Equals(ddlActorList.SelectedItem.Value))
                        {
                            //							return;
                        }
                        else
                        {
                            //							DataS.DeleteActorByStaff(this.StaffCode,this.ActorCode,"Fed");//把用户对应角色删除
                            baseOperation.DeleteActorByStaff(this.StaffCode, "");//把用户对应所有角色删除
                            baseOperation.InsertActorByStaff(this.StaffCode, ddlActorList.SelectedItem.Value);
                        }
                    }

                    string url;
                    url = "Success.aspx?backUrl=AddUser.aspx&erorMessage=编号为:" + this.StaffCode + "的用户成功修改!";
                    Log.WriteLog("", Session["username"] + "：修改用户" + StaffCode);
                    Response.Redirect(url);

                    //					ClearText();
                }
            }

            if (IsIn == false)
            {
                baseOperation.ShowErrorMessage(this.Page, "数据库中没有此用户编号或用户姓名，不能进行修改操作！");
            }
        }

        protected void BtnDel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            bool IsIn = this.CodeIsIn();

            if (IsIn == true)
            {
                baseOperation.DeleteStaffInfo(this.StaffCode);
                baseOperation.DeleteActorByStaff(this.StaffCode, "");//把用户对应所有角色删除
                //				ClearText();
                string url;
                url = "Success.aspx?backUrl=AddUser.aspx&erorMessage=编号为:" + this.StaffCode + "的用户成功删除!";
                Log.WriteLog("", Session["username"] + "：删除用户" + StaffCode);
                Response.Redirect(url);
            }

            if (IsIn == false)
            {
                baseOperation.ShowErrorMessage(this.Page, "没有选择相应的用户进行操作，不能进行删除操作！");
            }
        }

        private void ClearText()
        {
            t_StaffCode.Value = "";
            t_StaffCaption.Value = "";
            t_PassWd.Value = "";
            ddlActorList.SelectedIndex = -1;
            t_Remark.Value = "";
            this.StaffCode = string.Empty;

            BindGrid();
        }

        protected void MyDataGrid_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            int X = MyDataGrid.SelectedIndex;

            t_StaffCode.Value = MyDataGrid.Items[X].Cells[0].Text;
            this.StaffCode = t_StaffCode.Value.Trim();
            t_StaffCaption.Value = MyDataGrid.Items[X].Cells[1].Text;

            //----------------------------------------------------------------------------
            string stafftype = MyDataGrid.Items[X].Cells[3].Text;

            if (stafftype.Equals("0"))
            {
                ddl_usertype.SelectedValue = "0";


                string employeecode = MyDataGrid.Items[X].Cells[5].Text.Trim();

            }
            else if (stafftype.Equals("1"))
            {
                ddl_usertype.SelectedValue = "1";



            }
            else if (stafftype.Equals("2"))
            {
                ddl_usertype.SelectedValue = "2";

            }
            //----------------------------------------------------------------------------

            DataSet actorCode = new DataSet();
            actorCode = baseOperation.GetStaffActorSet(this.StaffCode);
            if (actorCode.Tables[0].Rows.Count > 0)
            {
                this.ActorCode = actorCode.Tables[0].Rows[0]["ActorCode"].ToString();
                if (this.ActorCode.Length == 0)
                {
                    ddlActorList.SelectedIndex = -1;
                }
                else
                {
                    ddlActorList.SelectedValue = this.ActorCode;
                }
            }

            t_Remark.Value = MyDataGrid.Items[X].Cells[2].Text;
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }

        private bool CodeIsIn()
        {
            bool IsIn = baseOperation.StaffCodeIsInSysStaff(this.StaffCode, t_StaffCaption.Value.Trim());
            return IsIn;
        }

        private bool NameIsIn()
        {
            bool IsIn = baseOperation.StaffCodeIsInSysStaff("", t_StaffCaption.Value.Trim());
            return IsIn;
        }

        protected void ddlActorList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void ddl_usertype_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void BtnExport_Click(object sender, ImageClickEventArgs e)
        {
            //创建固定资产信息列表文件
            string exePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string oPath = exePath + @"\UserInfo.txt";   //-"+DateTime.Today+".txt";
            try
            {
                StreamWriter sw = new StreamWriter(oPath);
                DataSet userDs = baseOperation.GetStaffInfoDataSet("");
                if (userDs != null)
                {
                    DataTable userDt = userDs.Tables[0];
                    for (int i = 0; i < userDt.Rows.Count; i++)
                    {
                        DataRow userDr = userDt.Rows[i];
                        sw.WriteLine(userDr["StaffCaption"].ToString().Trim() + "|" + userDr["Password"].ToString());
                    }
                }
                sw.Close();

                String fileName = "UserPasswordInfo.txt";
                FileStream fs = null;
                fs = System.IO.File.Open(oPath, System.IO.FileMode.Open);
                byte[] btFile = new byte[fs.Length];
                fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                Response.Clear();
                Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(btFile);
                Response.Flush();
                Response.Close();
            }
            catch (Exception ee) {
                Log.WriteLog("", "导出异常："+ee.ToString());
            }
        }
    }
}