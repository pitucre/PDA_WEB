<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPart.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AddPart" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE角色管理窗口</TITLE>
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
		        var tempstr1 = Trim(doc.t_ActorCaption.value);

		        if (tempstr1 == "") {
		            alert("角色名称不能为空!!");
		            doc.t_ActorCaption.focus();
		            return false
		        }
		        else {
		            return confirm("你确定要进行操作吗？");
		        }
		    }
		    function FrmExit() {
		        return confirm("您确定要退出吗?");
		    }	
		//-->
		</script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0" onload="javascript:FrmAddPart.t_ActorCaption.focus()">
		<form id="FrmAddPart" name="FrmAddPart" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0">
				<TR vAlign="top">
					<TD>
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 13px" background="images/TrainAD.gif" bgColor="#e6e6e6" height="13">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;角色管理</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff">
									<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
										<tr>
											<td colSpan="4">
												<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR vAlign="top">
														<TD style="WIDTH: 84px" vAlign="top" colSpan="4"><FONT face="宋体"><asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																	Font-Name="Verdana" BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" Width="648px" onselectedindexchanged="MyDataGrid_SelectedIndexChanged">
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
                                                    <tr>
                                                        <td align="left" colspan="4" style="height: 84px">
                                                            <table>
                                                                <tr>
                                                                    <td align="right" style="width: 103px">
                                                                        <asp:label id="lblDescription" runat="server">角色编号</asp:label></td>
                                                                    <td style="width: 150px">
                                                                        <INPUT id="t_ActorCode" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
																	readOnly type="text" maxLength="10" size="33" name="t_ActorCode" runat="server"></td>
                                                                    <td align="right" style="width: 124px">
                                                                        <asp:label id="Label7" runat="server">角色名称</asp:label></td>
                                                                    <td style="width: 150px">
                                                                        <INPUT id="t_ActorCaption" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
																	type="text" maxLength="30" size="33" name="t_ActorCaption" runat="server"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="width: 103px; height: 17px">
                                                                        <asp:label id="Label8" runat="server">角色类型</asp:label></td>
                                                                    <td style="width: 150px; height: 17px">
                                                                        <INPUT id="t_ActorType" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
																	type="text" maxLength="2" size="33" name="t_ActorType" runat="server"></td>
                                                                    <td style="width: 124px; height: 17px">
                                                                    </td>
                                                                    <td style="width: 150px; height: 17px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 103px">
                                                                    </td>
                                                                    <td style="width: 150px">
                                                                    </td>
                                                                    <td style="width: 124px">
                                                                    </td>
                                                                    <td style="width: 150px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="4">
                                                            <asp:imagebutton id="BtnAdd" tabIndex="5" runat="server" ImageUrl="images/DH_ADD.GIF" OnClick="BtnAdd_Click"></asp:imagebutton>&nbsp;
                                                            <asp:imagebutton id="BtnSave" tabIndex="6" runat="server" Width="64px" ImageUrl="images/DH_SAVE.GIF" OnClick="BtnSave_Click"></asp:imagebutton>&nbsp;
                                                            <asp:imagebutton id="BtnDel" tabIndex="7" runat="server" ImageUrl="images/DH_DEL.GIF" OnClick="BtnDel_Click"></asp:imagebutton>&nbsp;
                                                            <asp:imagebutton id="BtnExit" tabIndex="7" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton></td>
                                                    </tr>
												</TABLE>
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
