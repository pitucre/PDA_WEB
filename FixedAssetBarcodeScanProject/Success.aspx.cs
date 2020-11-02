using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FixedAssetBarcodeScanProject
{
    public partial class Success : System.Web.UI.Page
    {
        string BackUrl
        {
            get { return ViewState["backUrl"] + string.Empty; }
            set { ViewState["backUrl"] = value; }
        }

        string ErorMessage
        {
            get { return ViewState["erorMessage"] + string.Empty; }
            set { ViewState["erorMessage"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BackUrl = Request.QueryString["backUrl"];
            this.ErorMessage = Request.QueryString["erorMessage"];

            if (this.ErorMessage.Length > 0)
            {
                lblErrorMessage.Text = "<ul><li>" + ErorMessage + "</li></ul>";//"您提交的数据已经成功保存";
            }
            else
            {
                lblErrorMessage.Text = "<ul><li>您提交的数据已经成功保存!</li></ul>";//"您提交的数据已经成功保存";
            }
        }

        protected void BtnReturn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (this.BackUrl.Length == 0)
            {
                this.BackUrl = "Main.aspx";
            }

            Response.Redirect(this.BackUrl);//main.aspx

        }

        protected void BtnMain_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");//main.aspx
        }
    }
}