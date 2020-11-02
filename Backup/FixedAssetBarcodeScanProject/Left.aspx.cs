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
    public partial class Left : System.Web.UI.Page
    {
        BaseOperation baseOperation = new BaseOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------------------------根据权限设定动态添加菜单 ADD
            DataSet ProView = new DataSet();

            string StaffCode = Session["userid"].ToString();
            ProView = baseOperation.GetStaffFuncSetCanAccess(StaffCode);//得到用户可以访问的链接列表
            //------------------------------------------------------------------------------------------------------

            DataSet ds = new DataSet();
            ds = baseOperation.GetCsubFromTid(StaffCode, "____");

            //------------------------------------------------------------------------------------------------------
            Response.Write("<SCRIPT LANGUAGE='JavaScript' src='Scripts/showlayer.js'></SCRIPT>");
            Response.Write("<table width='200' height='96%' border='0'  cellpadding='0' cellspacing='0' >");

            Response.Write("<tr>");
            Response.Write("<td width='200' height='96%' align='center' valign='top' bgcolor='#edf4fc' class='text'>");
            Response.Write("<img src='images/LefttitleChinese.jpg' width='141'>");

            Response.Write("<div id='Layer1' style='Z-INDEX:1; LEFT:1px; VISIBILITY:visible; WIDTH:100px;HEIGHT:96%; POSITION:absolute; TOP:50px'>");
            //外table begin
            Response.Write("<div align='right' id='MFX0' style='Z-INDEX:2; LEFT:0px; VISIBILITY:hidden; WIDTH:100px; POSITION:absolute; TOP:0px; HEIGHT:28px'>");
            Response.Write("<table width='200' border='0' cellspacing='0' cellpadding='5' height='20'>");
            Response.Write("<tr>");
            Response.Write("<td valign='top' width='14'><img src='images/BG.GIF'>");
            //			Response.Write("<td width='14'><img src='image/node_nochild.gif'>");
            //			Response.Write("<td width='14'>");
            Response.Write("</td>");
            //			Response.Write("<td height='20'>");
            //			Response.Write("<a href='main.aspx' target='main' onClick='MFXrunMenu(0,20)'>欢迎使用</a></td>");
            //			Response.Write("<a href='main.aspx' target='main'>系统菜单</a></td>");
            //			Response.Write("<a  href='' target='main'>欢迎使用</a></td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("<div id='MFX1' align='right' style='BORDER-RIGHT:#000000 1px; BORDER-TOP:#000000 1px; Z-INDEX:1; LEFT:0px; VISIBILITY:hidden; BORDER-LEFT:#000000 1px; WIDTH:150px; BORDER-BOTTOM:#000000 1px; POSITION:absolute; TOP:25px; HEIGHT:10px'>");
            Response.Write("</div>");

            int k = 0;
            for (; k < ds.Tables[0].Rows.Count; k++)
            {
                //
                string title_name = ds.Tables[0].Rows[k]["FormTitle"].ToString();//标题:
                string formname = ds.Tables[0].Rows[k]["FunName"].ToString();//点击链接进入到的页面

                DataSet ds1 = new DataSet();//二层
                string xxx = ds.Tables[0].Rows[k][0].ToString();
                ds1 = baseOperation.GetCCsubFromCid(ds.Tables[0].Rows[k][0].ToString().Trim());

                //一层
                Response.Write("<div align='right' id='MFX" + (2 * (k + 1)) + "' style='Z-INDEX:2; LEFT:0px; VISIBILITY:hidden; WIDTH:150px; POSITION:absolute; TOP:0px; HEIGHT:28px'>");
                Response.Write("<table width='200' border='0' cellspacing='0' cellpadding='5' height='20'>");
                Response.Write("<tr>");
                //				Response.Write("<td width='14'><img src='image/index_titleblue.gif'>");
                Response.Write("<td width='14'><img src='images/ico_item.gif'>");
                Response.Write("</td>");
                Response.Write("<td height='20'  class='norepeat' valign='middle'>");
                if (formname == "")
                {
                    Response.Write("<a href='Main.aspx');' target='main'>" + title_name + "</a></td>");
                    //					Response.Write("<a href='main.aspx' onClick='MFXrunMenu("+(2*(k+1))+",20);' target='main'>"+title_name+"</a></td>");
                }
                else
                {
                    if (ds1.Tables[0].Rows.Count == 0)//如没有下级菜单，则不支持滑动菜单！
                    {
                        Response.Write("<a class='layer1' href='" + formname + "' target='main'>" + title_name + "</a></td>");
                    }
                    else
                    {
                        Response.Write("<a class='layer1' href='" + formname + "' onClick='MFXrunMenu(" + (2 * (k + 1)) + ",20);' target='main'>" + title_name + "</a></td>");
                    }
                }
                Response.Write("</tr>");
                Response.Write("</table>");
                Response.Write("</div>");
                //二层
                //??????????????
                //---------------
                int myheight = 0;
                for (int m = 0; m < ProView.Tables[0].Rows.Count; m++)//----
                {
                    string strProViewCompare = ProView.Tables[0].Rows[m]["FunName"].ToString();//------	

                    for (int n = 0; n < ds1.Tables[0].Rows.Count; n++)
                    {
                        string form_name;
                        form_name = ds1.Tables[0].Rows[n]["FunName"].ToString();

                        if (strProViewCompare.Equals(form_name))
                        {
                            myheight = myheight + 1;
                            break;
                        }
                    }

                }
                //---------------
                myheight = myheight * 25;
                Response.Write("<div id='MFX" + (1 + 2 * (k + 1)) + "' align='right' style='BORDER-RIGHT:#000000 1px; BORDER-TOP:#000000 1px; Z-INDEX:1; LEFT:0px; VISIBILITY:hidden; BORDER-LEFT:#000000 1px; WIDTH:150px; BORDER-BOTTOM:#000000 1px; POSITION:absolute; TOP:25px; HEIGHT:" + myheight + "'>");
                //---------------
                //				Response.Write("<table width='141'  border='0' cellspacing='0' background='image/INPUT.GIF'>");
                Response.Write("<table width='200'  border='0' cellspacing='0'>");

                for (int j = 0; j < ProView.Tables[0].Rows.Count; j++)//----
                {
                    string strProViewCompare = ProView.Tables[0].Rows[j]["FunName"].ToString();//------	

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        string form_name;

                        form_name = ds1.Tables[0].Rows[i]["FunName"].ToString();

                        if (strProViewCompare.Equals(form_name))
                        {
                            Response.Write("<tr>");
                            Response.Write("<td height='25' width='30'>&nbsp;</td>");
                            if (form_name == "")
                            {
                                //								Response.Write("<td class='norepeat'><img src='image/index_chititle.gif'>&nbsp;<a href='main.aspx' target='main'>");
                                Response.Write("<td class='norepeat'><img src='images/ico_arrow.gif'>&nbsp;<a class='layer2' href='main.aspx' target='main'>");
                            }
                            else
                            {
                                //								Response.Write("<td class='norepeat'><img src='image/index_chititle.gif'>&nbsp;<a href='"+form_name+"' target='main'>");
                                Response.Write("<td class='norepeat'><img src='images/ico_arrow.gif'>&nbsp;<a class='layer2' href='" + form_name + "' target='main'>");
                            }
                            Response.Write(ds1.Tables[0].Rows[i][2].ToString());
                            Response.Write("</a></td>");
                            Response.Write("</tr>");
                            break;
                        }
                    }

                }
                //
                Response.Write("</table>");
                Response.Write("</div>");
            }
            //外table end
            Response.Write("</div>");
            Response.Write("</td>");
            Response.Write("<td width='11' >&nbsp;</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("<script>allLayes=" + (1 + 2 * k) + "</script>");
        }
    }
}