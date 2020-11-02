<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPurviewSetting.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AddPurviewSetting" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>权限分配管理窗口</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
		<SCRIPT language="JavaScript">
		    function FrmExit() {
		        return confirm("您确定要退出吗?");
		    }	
		</SCRIPT>
	</HEAD>
	<BODY leftMargin="0" topMargin="0">
		<form id="FrmAddUser" name="FrmAddUser" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0">
				<TR vAlign="top">
					<TD>
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 13px" background="images/TrainAD.gif" bgColor="#e6e6e6" height="13">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;权限分配管理</FONT></TD>
							</TR>
							<TR id="taskDiv">
								<td bgColor="#ffffff" style="height: 550px">
												<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 84px" colSpan="4" align="center"><FONT face="宋体"><asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																	Font-Name="Verdana" BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" Width="703px" onselectedindexchanged="MyDataGrid_SelectedIndexChanged">
																	<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ActorCode" HeaderText="角色编号">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ActorCaption" HeaderText="角色名称">
																			<HeaderStyle Width="400px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ActorType" HeaderText="角色类型">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:ButtonColumn Text="选择" HeaderText="选择" CommandName="Select">
																			<HeaderStyle Width="30px"></HeaderStyle>
																		</asp:ButtonColumn>
																	</Columns>
																	<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></FONT></TD>
													<TR>
														<TD align="center" width="100%" colSpan="4"><asp:label id="lblPageCount" runat="server"></asp:label><asp:label id="lblCurrentIndex" runat="server"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="0" Font-size="8pt"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="prev" Font-size="8pt"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="next" Font-size="8pt"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="last" Font-size="8pt"></asp:linkbutton></TD>
													</TR>
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD align="left" width="100%" colSpan="4">
															<asp:CheckBox id="chkAllSelect" runat="server" Text="全部选择" AutoPostBack="True" oncheckedchanged="chkAllSelect_CheckedChanged"></asp:CheckBox><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:CheckBox id="chkAllElse" runat="server" Text="选择反选" AutoPostBack="True" oncheckedchanged="chkAllElse_CheckedChanged"></asp:CheckBox>
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:CheckBox id="chkAllKill" runat="server" Text="全部取消" AutoPostBack="True" oncheckedchanged="chkAllKill_CheckedChanged"></asp:CheckBox></FONT></TD>
													</TR>
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD align="right"><asp:label id="Label1" runat="server">访问页面设定</asp:label></TD>
														<TD><FONT face="宋体"><asp:checkboxlist id="CBoxSysActors" runat="server" Height="73px" Width="394px"></asp:checkboxlist></FONT></TD>
														<TD style="WIDTH: 53px" align="right"><FONT face="宋体"></FONT></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="3" style="height: 25px">
                                                            <asp:imagebutton id="ImageButton1" runat="server" ImageUrl="images/DH_SAVE.GIF" OnClick="ImageButton1_Click"></asp:imagebutton><asp:imagebutton id="BtnExit" tabIndex="7" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton>
                                                        </td>
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
