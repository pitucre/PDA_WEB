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
    public partial class ChangePassword : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            //			if((bool)Session["IfLogin"]==false)
            //			{
            //				Response.Redirect("login.aspx");
            //			}

            this.BtnSave.Attributes.Add("onclick", "javascript:return ValueIfEmpty();");
            this.BtnExit.Attributes.Add("onclick", "javascript:return FrmExit();");

            //Session["username"] = "超级管理员";
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                //Response.Redirect("login.aspx");
                baseOperation.ShowErrorMessage(this.Page, "用户登录超时,请重新登录。");
                //this.Response.Redirect("login.aspx");
                this.Response.Write("<script language='javascript'>window.parent.close()</script>");
            }
            else
            {
                t_StaffCaption.Value = Session["username"].ToString();
            }
            
        }

        private bool IsPassValidate()
        {
            bool _ispassValidate = false;

            //if (t_PassWdOld.Value.Trim().Length == 0)
            //{
            //    baseclass.ShowErrorMessage(this.Page, "原密码不能为空,请重新进行输入");
            //}
            if (t_PassWdNew.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "新密码不能为空,请重新进行输入");
            }
            else if (t_PassWdNewCompare.Value.Trim().Length == 0)
            {
                baseOperation.ShowErrorMessage(this.Page, "确认新密码不能为空,请重新进行输入");
            }
            //else if (t_PassWdOld.Value.Trim().Length < 6)
            //{
            //    baseclass.ShowErrorMessage(this.Page, "原密码长度必须大于6位,请重新进行输入");
            //}
            else if (t_PassWdNew.Value.Trim().Length < 6)
            {
                baseOperation.ShowErrorMessage(this.Page, "新密码长度必须大于6位,请重新进行输入");
            }
            else if (t_PassWdNewCompare.Value.Trim().Length < 6)
            {
                baseOperation.ShowErrorMessage(this.Page, "确认新密码长度必须大于6位,请重新进行输入");
            }
            else if (IsRightUser() == false)
            {
                _ispassValidate = false;
            }
            else if (!t_PassWdNew.Value.Trim().Equals(t_PassWdNewCompare.Value.Trim()))//判断新密码与确认密码是否相同
            {
                _ispassValidate = false;
                baseOperation.ShowErrorMessage(this.Page, "新密码与确认新密码不同,请重新进行输入");
            }
            else
            {
                _ispassValidate = true;
            }
            return _ispassValidate;
        }

        private bool IsRightUser()//判断原密码是否正确
        {
            bool isRightUser = false;

            //Session["userid"] = "00";
            string UserCode = Session["userid"].ToString();
            string NewPW = baseOperation.newPW(t_PassWdOld.Value.Trim(), "MD5");

            if (baseOperation.ComparePassWord(UserCode, NewPW) == true)
            {
                isRightUser = true;
            }
            else
            {
                isRightUser = false;
                baseOperation.ShowErrorMessage(this.Page, "您输入的原密码不正确,请重新进行输入");
            }

            return isRightUser;
        }

        protected void BtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //Session["userid"] = "00";
            string UserCode = Session["userid"].ToString();
            string NewPW = baseOperation.newPW(t_PassWdNew.Value.Trim(), "MD5");

            if (IsPassValidate() == true)
            {
                baseOperation.UpdatePassWord(UserCode, NewPW);
                Log.WriteLog("", Session["username"] + "：修改密码。");
            }
        }

        protected void BtnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Server.Transfer("Main.aspx");
        }
    }
}