<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScanResultList.aspx.cs" Inherits="FixedAssetBarcodeScanProject.ScanResultList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>固定资产盘点结果</title>
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
					<TD style="HEIGHT: 226px;" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;固定资产盘点结果</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff" style="">
												<TABLE cellSpacing="10" cellPadding="0" border="0" style=" HEIGHT: 325px">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <TR vAlign="top">
														<TD colSpan="4" style="height: 1px">
                                                            <asp:Label ID="labAssetCode" runat="server" Text="资产编码："></asp:Label>
                                                            <asp:TextBox ID="txtAssetCode" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="labBarCode" runat="server" Text="扫描结果："></asp:Label>
                                                            <asp:DropDownList ID="dropResult" runat="server">
                                                                <asp:ListItem Value="-2">所有</asp:ListItem>
                                                                <asp:ListItem Value="-1">资产不存在</asp:ListItem>
                                                                <asp:ListItem Value="0">有误</asp:ListItem>
                                                                <asp:ListItem Value="1">正确</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="BtnExport" runat="server" Text="导出Excel" onclick="BtnExport_Click" />
                                                        </TD>
													</TR>
													<TR vAlign="top">
														<TD style="height: 130px;" colSpan="4"><FONT face="宋体">
                                                            <asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" 
                                                                BorderWidth="1px" Font-Names="Verdana"
																	BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" 
                                                                HorizontalAlign="Center" Height="145px" 
                                                                onselectedindexchanged="MyDataGrid_SelectedIndexChanged">
																	<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="BARCODE" HeaderText="条形码">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ASSETCODE" HeaderText="资产号">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="RESULTNAME" HeaderText="扫描结果">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="COMMENTS" HeaderText="说明">
																			<HeaderStyle Width="300px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="SCANPERSON" HeaderText="扫描者">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="SCANTIME" HeaderText="扫描时间">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
																	    <asp:ButtonColumn CommandName="Select" HeaderText="查看" Text="资产详细" 
                                                                            ButtonType="PushButton">
                                                                            <HeaderStyle Width="100px" />
                                                                        </asp:ButtonColumn>
																	    <asp:BoundColumn DataField="RESULT" HeaderText="扫描结果" Visible="False">
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
                                                    <TR>
														<TD colSpan="4">
                                                            <table>
                                                                <tr>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="Label1" runat="server">资产号</asp:label></td>
                                                                        <td align="left" style="width: 150px; height: 17px">
                                                                            <asp:TextBox ID="txtAssetcode2" runat="server" ReadOnly></asp:TextBox></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="lblAssetName" runat="server">资产名称</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                            <asp:TextBox ID="txtAssetName" runat="server" ReadOnly></asp:TextBox></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
																        <asp:label id="lblZhuangtai" runat="server">资产状态</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                            <asp:TextBox ID="txtZhuangtai" runat="server" ReadOnly></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="width: 150px; height: 17px">
																        <asp:label id="lblDept" runat="server">使用部门</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                            <asp:TextBox ID="txtDept" runat="server" ReadOnly></asp:TextBox></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="lblEmployee" runat="server">使用者</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                            <asp:TextBox ID="txtEmployee" runat="server" ReadOnly></asp:TextBox></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
																        &nbsp;</td>
                                                                    <td align="left" style="width: 150px; height: 17px">&nbsp;</asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </TD>
													</TR>
                                                    <TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="4" valign="top">
								                            <asp:imagebutton id="BtnExit" tabIndex="9" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton></td>
                                                    </tr>
													</TABLE>
								</td>								
							</TR>
						</TABLE>
						
					</TD>
				</TR>
			</TABLE>
            <asp:DataGrid ID="DataGridExport" runat="server">
            </asp:DataGrid>	
		</form>
	</BODY>
</HTML>
