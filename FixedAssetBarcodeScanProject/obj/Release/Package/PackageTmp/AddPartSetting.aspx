<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPartSetting.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AddPartSetting" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>角色分配管理窗口</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
		<script language="javascript">
		    function ValueIfEmpty() {
		        return confirm("你确定要进行操作吗？");
		    }
		    function FrmExit() {
		        return confirm("您确定要退出吗?");
		    }	
		</script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0">
		<form id="FrmAddUser" name="FrmAddUser" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0">
				<TR vAlign="top">
					<TD>
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 13px" background="images/TrainAD.gif" bgColor="#e6e6e6" height="13">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;角色分配管理</FONT></TD>
							</TR>
							<TR id="taskDiv">
								<td bgColor="#ffffff">
												<TABLE cellSpacing="10" cellPadding="0" border="0">
													<TR>
														<TD bgColor="#ff9900" colSpan="4" style="width: 920px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD colSpan="4"><FONT face="宋体"><asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																	Font-Name="Verdana" BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" onselectedindexchanged="MyDataGrid_SelectedIndexChanged">
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
																		<asp:ButtonColumn Text="选择" HeaderText="选择" CommandName="Select">
																			<HeaderStyle Width="30px"></HeaderStyle>
																		</asp:ButtonColumn>
																	</Columns>
																	<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></FONT></TD>
													<TR>
														<TD align="center" colSpan="4"><asp:label id="lblPageCount" runat="server"></asp:label><asp:label id="lblCurrentIndex" runat="server"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="0" Font-size="8pt"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="prev" Font-size="8pt"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="next" Font-size="8pt"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" Font-Name="verdana" ForeColor="navy"
																CommandArgument="last" Font-size="8pt"></asp:linkbutton></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="4">
                                                        </td>
                                                    </tr>
													<TR>
														<TD bgColor="#ff9900" colSpan="4" style="width: 920px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 62px" align="right"><FONT face="宋体"><asp:label id="Label7" runat="server">访问角色</asp:label></FONT></TD>
														<TD><FONT face="宋体"><asp:checkboxlist id="CBoxSysActors" runat="server" Height="73px" Width="320px"></asp:checkboxlist></FONT></TD>
														<TD align="right"><FONT face="宋体"></FONT></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="3" style="height: 25px">
                                                            <asp:imagebutton id="BtnSave" runat="server" Width="65px" ImageUrl="images/DH_SAVE.GIF" OnClick="BtnSave_Click"></asp:imagebutton>&nbsp; &nbsp;<asp:imagebutton id="BtnExit" tabIndex="7" runat="server" Width="64px" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton>
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
