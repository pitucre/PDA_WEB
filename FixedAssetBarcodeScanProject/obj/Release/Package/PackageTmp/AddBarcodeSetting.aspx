<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBarcodeSetting.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AddBarcodeSetting" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>条形码管理窗口</TITLE>
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
		        var tempstr1 = Trim(doc.assetclassify.value);
		        var tempstr2 = Trim(doc.fixedbarcode.value);

		        if (tempstr1 == "") {
		            alert("资产分类不能为空!");
		            doc.assetclassify.focus();
		            return false
		        }
		        if (tempstr2 == "") {
		            alert("固定条码不能为空!");
		            doc.fixedbarcode.focus();
		            return false
		        }
		        else if (tempstr2.length != 3) {
		            alert("固定条码长度必须为3。");
		            doc.fixedbarcode.focus();
		            return false
                }
		        else {
		            return confirm("你确定要进行操作吗？");
		        }
		    }

		    function ValueIfEmptyDel() {
		        var doc = document.forms[0];
		        var tempstr1 = Trim(doc.maxcode.value);

		        if (parseInt(tempstr1,0)>0) {
		            alert("该资产分类已经被使用，不能删除！");
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
	<BODY leftMargin="0" topMargin="0" onload="">
		<form id="Form1" name="Form1" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0" style="height: 509px">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px; width: 616px;" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;条形码管理</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff" style="width: 948px; height: 467px;">
												<TABLE cellSpacing="10" cellPadding="0" width="757" border="0" style="WIDTH: 757px; HEIGHT: 325px">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:Label ID="labAdmindept" runat="server" Text="管理部门："></asp:Label>
                                                            <asp:DropDownList ID="dropSearchAdmindept" runat="server" AutoPostBack="True">
                                                                <asp:ListItem Value="全部">全部</asp:ListItem>
                                                                <asp:ListItem Value="设备部">设备部</asp:ListItem>
                                                                <asp:ListItem Value="行政事务部">行政事务部</asp:ListItem>
                                                                <asp:ListItem Value="工程部">工程部</asp:ListItem>
                                                                <asp:ListItem Value="信息技术部">信息技术部</asp:ListItem>
                                                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="Button1" runat="server" Text="查询" onclick="btnSearch_Click" />
                                                        </td>
                                                    </tr>
													<TR vAlign="top">
														<TD style="WIDTH: 84px; height: 130px;" colSpan="4"><FONT face="宋体"><asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																	BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" Width="734px" onselectedindexchanged="MyDataGrid_SelectedIndexChanged_1" Height="145px">
																	<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="BarCodeID" HeaderText="记录ID" Visible="False">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DeptCode" HeaderText="管理部门">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="AssetClassify" HeaderText="资产分类">
																			<HeaderStyle Width="400px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FixedBarcode" HeaderText="固定条码">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="MaxCode" HeaderText="最大值" ReadOnly="True">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>																		
																		<asp:BoundColumn DataField="Comments" HeaderText="备注">
                                                                            <HeaderStyle Width="400px" />
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
                                                                        <asp:HiddenField ID="hdBarcodeId" runat="server" /><asp:label id="lblDept" runat="server">管理部门</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <asp:DropDownList ID="dropAdmindept" runat="server"></asp:DropDownList></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
																        <asp:label id="Label7" runat="server">资产分类</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <INPUT id="assetclassify" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	    tabIndex="1" type="text" maxLength="30" size="24" name="assetclassify" runat="server"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="Label5" runat="server">固定条码</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <INPUT id="fixedbarcode" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px; BACKGROUND-COLOR: #ffffff"
																	    type="text" maxLength="10" size="25" name="fixedbarcode" runat="server"></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
																        <asp:label id="Label6" runat="server">条码最大值</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <INPUT id="maxcode" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 200px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	    tabIndex="1" type="text" maxLength="30" size="24" name="maxcode" runat="server" readonly></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="width: 150px">
																<asp:label id="Label8" runat="server">备注</asp:label></td>
                                                                    <td align="left" style="width: 150px" colspan="3">
                                                                        <INPUT id="comments" style="border: 1px solid lightgrey; WIDTH: 557px; HEIGHT: 18px"
																	    tabIndex="2" maxLength="100" size="50" name="comments" runat="server"></td>
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
                                                            <asp:imagebutton id="BtnDel" tabIndex="7" runat="server" ImageUrl="images/DH_DEL.GIF" OnClick="BtnDel_Click"></asp:imagebutton>
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
