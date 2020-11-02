<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZichanZhuangtaiList.aspx.cs" Inherits="FixedAssetBarcodeScanProject.ZichanZhuangtaiList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>资产状态信息</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
	</head>
	<body leftMargin="0" topMargin="0" onload="">
		<form id="Form1" name="Form1" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0" style="height: 509px">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px; width: 616px;" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;资产状态信息</FONT></TD>
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
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" Width="734px" Height="145px">
																	<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ZHUANGTAICODE" HeaderText="资产编号">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ZHUANGTAIMINGCHENG" HeaderText="资产名称">
																			<HeaderStyle Width="400px"></HeaderStyle>
																		</asp:BoundColumn>
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
                                                    <TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="4" valign="top">
								                            <asp:imagebutton id="BtnExit" tabIndex="8" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton></td>
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
