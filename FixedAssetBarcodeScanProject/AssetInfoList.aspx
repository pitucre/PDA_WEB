<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetInfoList.aspx.cs" Inherits="FixedAssetBarcodeScanProject.AssetInfoList" EnableEventValidation="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>�̶��ʲ���Ϣ�б�</title>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "����" }
		</style>
	</head>
	<body leftMargin="0" topMargin="0" onload="">
		<form id="Form1" name="Form1" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0" style="height: 509px">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px;" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;�̶��ʲ���Ϣ�б�</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff" style="">
												<TABLE cellSpacing="10" cellPadding="0" border="0" style=" HEIGHT: 325px">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <TR vAlign="top">
														<TD colSpan="4" style="height: 1px">
                                                            <asp:Label ID="labDept" runat="server" Text="ʹ�ò��ţ�"></asp:Label>
                                                            <asp:DropDownList ID="dropDept" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="labName" runat="server" Text="�ʲ����ƣ�"></asp:Label>
                                                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="labAssetCode" runat="server" Text="�ʲ����룺"></asp:Label>
                                                            <asp:TextBox ID="txtAssetCode" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="labBarCode" runat="server" Text="�����룺"></asp:Label>
                                                            <asp:DropDownList ID="dropBarcode" runat="server">
                                                                <asp:ListItem Value="-1">����</asp:ListItem>
                                                                <asp:ListItem Value="0">������</asp:ListItem>
                                                                <asp:ListItem Value="1">������</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </TD>
													</TR>
                                                    <TR vAlign="top">
														<TD colSpan="4" style="height: 1px">
                                                            <asp:Label ID="labAdmindept" runat="server" Text="�����ţ�"></asp:Label>
                                                            <asp:DropDownList ID="dropSearchAdmindept" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="dropSearchAdmindept_SelectedIndexChanged">
                                                                <asp:ListItem Value="ȫ��">ȫ��</asp:ListItem>
                                                                <asp:ListItem Value="�豸��">�豸��</asp:ListItem>
                                                                <asp:ListItem Value="��������">��������</asp:ListItem>
                                                                <asp:ListItem Value="���̲�">���̲�</asp:ListItem>
                                                                <asp:ListItem Value="��Ϣ������">��Ϣ������</asp:ListItem>
                                                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="labClassify" runat="server" Text="�ʲ����ࣺ"></asp:Label>
                                                            <asp:DropDownList ID="dropClassify" runat="server"></asp:DropDownList>
                                                            <asp:Button ID="Button1" runat="server" Text="��ѯ" onclick="btnSearch_Click" />
                                                        </TD>
													</TR>
													<TR vAlign="top">
														<TD style="height: 130px;" colSpan="4"><FONT face="����">
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
																		<asp:BoundColumn DataField="BARCODE" HeaderText="������">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ASSETCODE" HeaderText="�ʲ���">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ASSETNAME" HeaderText="�ʲ�����">
																			<HeaderStyle Width="300px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="KUAIJILEIBIENAME" HeaderText="������" Visible="False">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="SHEBEILEIBIENAME" HeaderText="�豸���" Visible="False">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="ZICHANZHUANGTAINAME" HeaderText="�豸״̬">
																			<HeaderStyle Width="250px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="CUNFANGDIDIANNAME" HeaderText="�ص�" Visible="False">
																			<HeaderStyle Width="300px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="SHIYONGBUMENNAME" HeaderText="ʹ�ò���">
																			<HeaderStyle Width="300px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="GUYUANBIANHAONAME" HeaderText="ʹ����">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="GUIGEXINGHAO" HeaderText="����ͺ�">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="XULIEHAO" HeaderText="���к�">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="ZICHANSHIBEIMA" HeaderText="�ʲ�ʶ����">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="SUPPLIER" HeaderText="��Ӧ��">
																			<HeaderStyle Width="500px"></HeaderStyle>
																		</asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="ADMINDEPT" HeaderText="������">
                                                                            <HeaderStyle Width="250px" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="ASSETCLASSIFY" HeaderText="�ʲ�����">
                                                                            <HeaderStyle Width="250px" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="BEIZHU" HeaderText="��ע">
                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                        </asp:BoundColumn>
																	    <asp:ButtonColumn CommandName="Select" HeaderText="�༭������" Text="�༭" 
                                                                            ButtonType="PushButton">
                                                                            <HeaderStyle Width="200px" />
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
                                                    <TR>
														<TD colSpan="4">
                                                            <table>
                                                                <tr>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="Label1" runat="server">�ʲ���</asp:label></td>
                                                                        <td align="left" style="width: 150px; height: 17px">
                                                                            <asp:TextBox ID="txtAssetcode2" runat="server" ReadOnly></asp:TextBox></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
                                                                        <asp:label id="lblAdmindept" runat="server">������</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <asp:DropDownList ID="dropAdmindept" runat="server" 
                                                                            onselectedindexchanged="dropAdmindept_SelectedIndexChanged" 
                                                                            AutoPostBack="True"></asp:DropDownList></td>
                                                                    <td align="right" style="width: 150px; height: 17px">
																        <asp:label id="lblAssetclassify" runat="server">�ʲ�����</asp:label></td>
                                                                    <td align="left" style="width: 150px; height: 17px">
                                                                        <asp:DropDownList ID="dropAssetclassify" runat="server"></asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </TD>
													</TR>
                                                    <TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="4" valign="top">
								                            <asp:imagebutton id="BtnSave" tabIndex="6" runat="server" Width="64px" ImageUrl="images/DH_SAVE.GIF" OnClick="BtnSave_Click"></asp:imagebutton>
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
