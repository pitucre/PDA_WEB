<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AddUser" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>用户管理窗口</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
		<script language="javascript">
		<!--
		    function Trim(str) {
		        if (str.charAt(0) == " ") {
		            str = str.slice(1);
		            str = Trim(str);
		        }
		        return str;
		    }

		    function ValueIfEmpty() {
		        var doc = document.forms[0];
		        var tempstr1 = Trim(doc.t_StaffCaption.value);
		        var tempstr2 = Trim(doc.t_PassWd.value);

		        if (tempstr1 == "") {
		            alert("用户姓名不能为空!");
		            doc.t_StaffCaption.focus();
		            return false
		        }
		        if (tempstr2 == "") {
		            alert("密码不能为空!");
		            doc.t_PassWd.focus();
		            return false
		        }
		        else {
		            return confirm("你确定要进行操作吗？");
		        }
		    }

		    function ValueIfEmptyDel() {
		        var doc = document.forms[0];
		        var tempstr1 = Trim(doc.t_StaffCaption.value);

		        if (tempstr1 == "") {
		            alert("用户姓名不能为空!");
		            doc.t_StaffCaption.focus();
		            return false
		        }
		        else {
		            return confirm("你确定要进行操作吗？");
		        }
		    }

		    function FrmExit() {
		        return confirm("您确定要退出吗?");
		    }

		    function openwinsupply() { window.open("Select/SelectSupply.aspx", "选择供应商信息", "width=750,height=480,,top=100,left=150,resizable=0,scrollbars=0") }
		    function openwincust() { window.open("Select/SelectCust.aspx", "选择客户信息", "width=750,height=480,,top=100,left=150,resizable=0,scrollbars=0") }
		
		//-->
		</script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0" onload="javascript:Form1.t_StaffCaption.focus()">
		<form id="Form1" name="Form1" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0" style="height: 509px">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px; width: 616px;" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;用户管理</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff" style="width: 948px; height: 467px;">
												<TABLE cellSpacing="10" cellPadding="0" width="757" border="0" style="WIDTH: 757px; HEIGHT: 325px">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR vAlign="top">
														<TD style="WIDTH: 84px; height: 130px;" colSpan="4"><FONT face="宋体"><asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																	BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" Width="734px" onselectedindexchanged="MyDataGrid_SelectedIndexChanged_1" Height="145px">
																	<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="StaffCode" HeaderText="用户编号">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="StaffCaption" HeaderText="用户姓名">
																			<HeaderStyle Width="400px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ReMark" HeaderText="备注">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="StaffType" HeaderText="用户类型编号" Visible="False">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="StaffTypeName" HeaderText="用户类型">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>																		
																		<asp:ButtonColumn Text="选择" HeaderText="选择" CommandName="Select">
																			<HeaderStyle Width="60px"></HeaderStyle>
																		</asp:ButtonColumn>
																	</Columns>
																	<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></FONT></TD>
													<TR>
														<TD align="center" width="100%" colSpan="4" style="height: 16px"><asp:label id="lblPageCount" runat="server"></asp:label>
                                                            <asp:label id="lblCurrentIndex" runat="server"></asp:label>
                                                            &nbsp;&nbsp; &nbsp;<asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" ForeColor="navy"
																CommandArgument="0" Font-size="8pt"></asp:linkbutton>
                                                            <asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server"  ForeColor="navy"
																CommandArgument="prev" Font-size="8pt"></asp:linkbutton>
                                                            <asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server"  ForeColor="navy"
																CommandArgument="next" Font-size="8pt"></asp:linkbutton>
                                                            <asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server"  ForeColor="navy"
																CommandArgument="last" Font-size="8pt"></asp:linkbutton></TD>
													</TR>
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="left" colspan="4" valign="top">
                                                            <table>
                                                                <tr>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="lblDescription" runat="server">用户编号</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <INPUT id="t_StaffCode" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; BACKGROUND-COLOR: #ffffff"
																	type="text" maxLength="10" size="25" name="t_StaffCode" runat="server" readOnly></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
																<asp:label id="Label7" runat="server">用户姓名</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <INPUT id="t_StaffCaption" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	tabIndex="1" type="text" maxLength="30" size="24" name="t_StaffCaption" runat="server"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="width: 150px">
																<asp:label id="Label8" runat="server">密码</asp:label></td>
                                                                    <td align="left" style="width: 150px">
                                                                        <INPUT id="t_PassWd" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	tabIndex="2" type="password" maxLength="50" size="25" name="t_PassWd" runat="server"></td>
                                                                    <td align="right" style="width: 150px">
															<asp:label id="Label1" runat="server">所属角色</asp:label></td>
                                                                    <td align="left" style="width: 150px">
																<asp:dropdownlist id="ddlActorList" tabIndex="3" runat="server" Width="200px" onselectedindexchanged="ddlActorList_SelectedIndexChanged"></asp:dropdownlist></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="width: 150px">
															<asp:label id="Label2" runat="server">用户类型</asp:label></td>
                                                                    <td align="left" style="width: 150px">
																<asp:dropdownlist id="ddl_usertype" tabIndex="3" runat="server" Width="200px" AutoPostBack="True"
																	onselectedindexchanged="ddl_usertype_SelectedIndexChanged">
																	<asp:ListItem Value="0">本公司</asp:ListItem>
																	<asp:ListItem Value="1">供应商</asp:ListItem>
																	<asp:ListItem Value="2">客户</asp:ListItem>
																</asp:dropdownlist></td>
                                                                    <td align="right" style="width: 150px">
															<asp:label id="Label9" runat="server">备注</asp:label></td>
                                                                    <td align="left" style="width: 150px">
                                                                        <INPUT id="t_Remark" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	tabIndex="4" type="text" maxLength="200" size="24" name="t_Remark" runat="server"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="4" valign="top">
								<asp:imagebutton id="BtnAdd" tabIndex="5" runat="server" ImageUrl="images/DH_ADD.GIF" OnClick="BtnAdd_Click"></asp:imagebutton>
								<asp:imagebutton id="BtnSave" tabIndex="6" runat="server" Width="64px" ImageUrl="images/DH_SAVE.GIF" OnClick="BtnSave_Click"></asp:imagebutton>
								<asp:imagebutton id="BtnDel" tabIndex="7" runat="server" ImageUrl="images/DH_DEL.GIF" OnClick="BtnDel_Click"></asp:imagebutton>
                                <asp:imagebutton id="BtnExport" tabIndex="8" runat="server" ImageUrl="images/dh_daochu.gif" OnClick="BtnExport_Click"></asp:imagebutton>
								<asp:imagebutton id="BtnExit" tabIndex="9" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton></td>
                                                    </tr>
													</TABLE>
									        
									       
								</td>								
							</TR>
						</TABLE>
						
					</TD>
				</TR>
			</TABLE>	
		</form>
	</BODY>
</HTML>
