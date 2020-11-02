<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFunction.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AddFunction" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>模块管理窗口</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
		<script language="javascript">
		    function Trim(str) {
		        if (str.charAt(0) == " ") {
		            str = str.slice(1);
		            str = Trim(str);
		        }
		        return str;
		    }

		    function ValueIfEmpty() {
		        var doc = document.forms[0];
		        var tempstr1 = Trim(doc.t_FunCode.value);
		        var tempstr2 = Trim(doc.t_FunName.value);
		        var tempstr3 = Trim(doc.t_FormTitle.value);

		        if (tempstr1 == "") {
		            alert("编号不能为空!!");
		            doc.t_FunCode.focus();
		            return false
		        }
		        if (tempstr2 == "") {
		            alert("窗体名称不能为空!!");
		            doc.t_FunCode.focus();
		            return false
		        }
		        if (tempstr3 == "") {
		            alert("窗体标题不能为空!!");
		            doc.t_FunCode.focus();
		            return false
		        }
		        else {
		            return confirm("你确定要进行操作吗？");
		        }
		    }

		    function FrmExit() {
		        return confirm("您确定要退出吗?");
		    }
		</script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0" onload="javascript:FrmAddFunction.t_FunName.focus()">
		<form id="FrmAddFunction" name="FrmAddFunction" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px; width: 591px;">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 13px" background="images/TrainAD.gif" bgColor="#e6e6e6" height="13">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;模块管理窗口</FONT></TD>
							</TR>
							<TR id="taskDiv">
								<td bgColor="#ffffff">
												<TABLE style="WIDTH: 672px; HEIGHT: 112px" cellSpacing="10" cellPadding="0" width="672"
													border="0">
													<TR>
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD style="height: 292px;" colSpan="4" valign="top">
															<asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																Font-Name="Verdana" BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages"
																PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page" CellPadding="4" Font-Size="8pt"
																HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" onselectedindexchanged="MyDataGrid_SelectedIndexChanged">
																<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField="FunCode" HeaderText="窗体编号">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="FunName" HeaderText="窗体名称">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="FormTitle" HeaderText="窗体标题">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="ReMark" HeaderText="备注">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:ButtonColumn Text="选择" HeaderText="选择" CommandName="Select">
																		<HeaderStyle Width="30px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
															</asp:datagrid>
														</TD>
													<TR>
														<TD align="center" width="100%" colSpan="4" style="height: 15px"><asp:label id="lblPageCount" runat="server"></asp:label><asp:label id="lblCurrentIndex" runat="server"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Name="verdana" Font-size="8pt"
																CommandArgument="0" ForeColor="navy"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" Font-Name="verdana" Font-size="8pt"
																CommandArgument="prev" ForeColor="navy"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" Font-Name="verdana" Font-size="8pt"
																CommandArgument="next" ForeColor="navy"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" Font-Name="verdana" Font-size="8pt"
																CommandArgument="last" ForeColor="navy"></asp:linkbutton></TD>
													</TR>
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="left" colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td align="right" style="width: 150px">
                                                                        <asp:label id="lblDescription" runat="server">窗体编号</asp:label></td>
                                                                    <td style="width: 150px">
                                                                        <INPUT id="t_FunCode" onblur="value=value.replace(/[^\d]/g,'')" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
																	type="text" maxLength="10" size="29" name="t_FunCode" runat="server"></td>
                                                                    <td align="right" style="width: 150px">
                                                                        <asp:label id="Label1" runat="server">窗体级别</asp:label></td>
                                                                    <td align="left" style="width: 302px">
																<asp:DropDownList id="LevelSelect" tabIndex="1" runat="server" Width="200px" AutoPostBack="True" onselectedindexchanged="LevelSelect_SelectedIndexChanged">
																	<asp:ListItem Selected="True">请选择</asp:ListItem>
																	<asp:ListItem Value="11">第一级</asp:ListItem>
																	<asp:ListItem Value="1101">第二级</asp:ListItem>
																</asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
																<asp:label id="Label7" runat="server">窗体名称</asp:label></td>
                                                                    <td>
                                                                        <INPUT id="t_FunName" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
																	type="text" maxLength="25" name="t_FunName" runat="server" tabIndex="2"></td>
                                                                    <td align="right" style="width: 150px">
															<asp:label id="Label8" runat="server">窗体标题</asp:label></td>
                                                                    <td align="left" style="width: 302px">
                                                                        <INPUT id="t_FormTitle" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
																	type="text" maxLength="25" name="t_FormTitle" runat="server" tabIndex="3"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
															<asp:label id="Label9" runat="server">备注</asp:label></td>
                                                                    <td align="left" colspan="3">
                                                                        <INPUT id="t_ReMark" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: lightgrey 1px solid; WIDTH: 508px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 17px; TEXT-ALIGN: left"
																	type="text" maxLength="125" name="t_ReMark" runat="server" tabIndex="4"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="4">
									<asp:imagebutton id="BtnAdd" tabIndex="5" runat="server" ImageUrl="images/DH_ADD.GIF" OnClick="BtnAdd_Click"></asp:imagebutton>
									<asp:imagebutton id="BtnSave" tabIndex="6" runat="server" Width="64px" ImageUrl="images/DH_SAVE.GIF" OnClick="BtnSave_Click"></asp:imagebutton>
									<asp:imagebutton id="BtnDel" tabIndex="7" runat="server" ImageUrl="images/DH_DEL.GIF" OnClick="BtnDel_Click"></asp:imagebutton>
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
