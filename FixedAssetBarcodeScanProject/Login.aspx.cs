using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using CCT.DAL;

namespace FixedAssetBarcodeScanProject
{
    public partial class Login : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        public string SUerID//用户编号
        {
            get { return ViewState["mSUerID"] + string.Empty; }
            set { ViewState["mSUerID"] = value; }
        }

        public string SUerName//用户名称
        {
            get { return ViewState["mSUerName"] + string.Empty; }
            set { ViewState["mSUerName"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_quxiao_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>window.parent.close()</script>");
        }

        private bool IsUserIdentify()
        {
            bool isPass = false;
            string userName = txtUserName.Value.Trim();
            string passWord = txtPassWord.Value.Trim();

            string userCode = baseOperation.GetPCRUserId(userName);

            this.SUerID = userCode;
            this.SUerName = txtUserName.Value.Trim();

            if (!(userCode.Length == 0))
            {
                string NewPW = baseOperation.newPW(passWord, "MD5");
                if (baseOperation.ComparePassWord(userCode, NewPW) == true)
                {
                    Session["userid"] = userCode;
                    Session["username"] = userName;
                    Session["IfLogin"] = true;
                    isPass = true;
                }
                else
                {
                    isPass = false;
                }
            }
            return isPass;
        }

        private void ErroMessage(string ErrorMessage, string ErrorEnglishMessage, int IfShow)//IfShow : 0 show 1:hide
        {
            if (IfShow == 0)
            {
                lblErrorMessageTop.Visible = true;

                if (ErrorEnglishMessage.Length > 0)
                {
                    lblErrorMessageTop.Text = "<ul><li>" + ErrorEnglishMessage + "</li></ul>";//ErrorMessage;			
                }
                else
                {
                    lblErrorMessageTop.Text = "<ul><li>" + ErrorMessage + "</li></ul>";//ErrorMessage;			
                }
            }
            else if (IfShow == 1)
            {
                lblErrorMessageTop.Visible = false;

                lblErrorMessageTop.Text = string.Empty;
            }
            else
            {
                return;
            }
        }
        protected void btnDenglu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (IsUserIdentify())
                {
                    Log.WriteLog("", Session["username"] + "登录系统");
                    //if (baseOperation.RefreshDataFromJDE())
                    //{
                    //    Log.WriteLog("", Session["username"] + "从JDE系统更新数据成功。");
                    //}
                    Response.Redirect("Default.aspx");
                }
                else if (txtUserName.Value.Trim().Length == 0)
                {
                    this.ErroMessage("用户名不能为空！", "", 0);
                }
                else
                {
                    this.ErroMessage("用户名或密码错误！", "", 0);
                }
            }
        }
        protected void btnquxiao_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.parent.close()</script>");
        }
    }
}