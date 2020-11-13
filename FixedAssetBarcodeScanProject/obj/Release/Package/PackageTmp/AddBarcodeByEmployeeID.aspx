<%@ page language="C#" autoeventwireup="true" codebehind="AddBarcodeByEmployeeID.aspx.cs" inherits="FixedAssetBarcodeScanProject.AddBarcodeByEmployeeID" %>

<!DOCTYPE html>

<html>
<head>
    <title>�����������</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="CSS/css.css" type="text/css" rel="stylesheet">
    <style type="text/css">
        .style7 {
            FONT-SIZE: 12px;
            FONT-FAMILY: "����"
        }
    </style>
    <script type="text/jscript" language="javascript">
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
		            alert("�ʲ����಻��Ϊ��!");
		            doc.assetclassify.focus();
		            return false
		        }
		        if (tempstr2 == "") {
		            alert("�̶����벻��Ϊ��!");
		            doc.fixedbarcode.focus();
		            return false
		        }
		        else if (tempstr2.length != 3) {
		            alert("�̶����볤�ȱ���Ϊ3��");
		            doc.fixedbarcode.focus();
		            return false
                }
		        else {
		            return confirm("��ȷ��Ҫ���в�����");
		        }
		    }

		    function ValueIfEmptyDel() {
		        var doc = document.forms[0];
		        var tempstr1 = Trim(doc.maxcode.value);

		        if (parseInt(tempstr1,0)>0) {
		            alert("���ʲ������Ѿ���ʹ�ã�����ɾ����");
		            return false
		        }
		        else {
		            return confirm("��ȷ��Ҫ���в�����");
		        }
		    }

		    function FrmExit() {
		        return confirm("��ȷ��Ҫ�˳���?");
		    }

		//-->
    </script>
</head>
<body leftmargin="0" topmargin="0" onload="">
    <form id="Form1" name="Form1" runat="server">
        <table cellspacing="8" cellpadding="0" border="0" style="height: 509px">
            <tr valign="top">
                <td style="height: 226px; width: 616px;" valign="top">
                    <table cellspacing="1" cellpadding="0" width="100%" bgcolor="#c7bebc" border="0">
                        <tr>
                            <td style="height: 14px; width: 948px;" background="images/TrainAD.gif" bgcolor="#e6e6e6">&nbsp;&nbsp;<img height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><font style="color: #ff6666">&nbsp;���������</font></td>
                        </tr>
                        <tr id="taskDiv" valign="top">
                            <td valign="top" bgcolor="#ffffff" style="width: 948px; height: 467px;">
                                <table cellspacing="10" cellpadding="0" width="757" border="0" style="width: 757px; height: 325px">
                                    <tr valign="top">
                                        <td bgcolor="#ff9900" colspan="4" style="height: 1px">
                                            <img height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="labAdmindept" runat="server" Text="�����ţ�"></asp:Label>
                                            <asp:DropDownList ID="dropSearchAdmindept" runat="server" AutoPostBack="True" Enabled="true">
                                                <%--<asp:ListItem Value="ȫ��">ȫ��</asp:ListItem>--%>
                                                <asp:ListItem Value="�豸��">�豸��</asp:ListItem>
                                                <asp:ListItem Value="��������">��������</asp:ListItem>
                                                <asp:ListItem Value="���̲�">���̲�</asp:ListItem>
                                                <asp:ListItem Value="��Ϣ������">��Ϣ������</asp:ListItem>
                                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="Button1" runat="server" Text="��ѯ" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td style="width: 84px; height: 130px;" colspan="4"><font face="����"><asp:datagrid id="MyDataGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" Font-Names="Verdana"
																	BorderColor="#CBD7FF" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="MyDataGrid_Page"
																	CellPadding="4" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" HorizontalAlign="Center" Width="734px" onselectedindexchanged="MyDataGrid_SelectedIndexChanged_1" Height="145px">
																	<SelectedItemStyle BackColor="DodgerBlue"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CBD7FF"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="BarCodeID" HeaderText="��¼ID" Visible="False">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>

																		<asp:BoundColumn DataField="DeptCode" HeaderText="������">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
				
																		<asp:BoundColumn DataField="AssetClassify" HeaderText="�ʲ�����">
																			<HeaderStyle Width="400px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FixedBarcode" HeaderText="�̶�����">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="MaxCode" HeaderText="���ֵ" ReadOnly="True">
																			<HeaderStyle Width="100px"></HeaderStyle>
																		</asp:BoundColumn>																		
																		<asp:BoundColumn DataField="Comments" HeaderText="��ע">
                                                                            <HeaderStyle Width="400px" />
                                                                        </asp:BoundColumn>
                                                                        																		<asp:BoundColumn DataField="PlantID" HeaderText="����">
																			<HeaderStyle Width="100px" />
																		</asp:BoundColumn>
                                                                        														<asp:BoundColumn DataField="EmployeeID" HeaderText="����Ա��">
																			<HeaderStyle Width="150px"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:ButtonColumn Text="ѡ��" HeaderText="ѡ��" CommandName="Select">
																			<HeaderStyle Width="60px"></HeaderStyle>
																		</asp:ButtonColumn>
																	</Columns>
																	<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></font></td>
                                        <tr>
                                            <td align="center" width="100%" colspan="4" style="height: 16px">
                                                <asp:Label ID="lblPageCount" runat="server"></asp:Label>
                                                <asp:Label ID="lblCurrentIndex" runat="server"></asp:Label>
                                                &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="btnFirst" OnClick="PagerButtonClick" runat="server" ForeColor="navy"
                                                    CommandArgument="0" Font-Size="8pt"></asp:LinkButton>
                                                <asp:LinkButton ID="btnPrev" OnClick="PagerButtonClick" runat="server" ForeColor="navy"
                                                    CommandArgument="prev" Font-Size="8pt"></asp:LinkButton>
                                                <asp:LinkButton ID="btnNext" OnClick="PagerButtonClick" runat="server" ForeColor="navy"
                                                    CommandArgument="next" Font-Size="8pt"></asp:LinkButton>
                                                <asp:LinkButton ID="btnLast" OnClick="PagerButtonClick" runat="server" ForeColor="navy"
                                                    CommandArgument="last" Font-Size="8pt"></asp:LinkButton></td>
                                        </tr>
                                    <tr>
                                        <td bgcolor="#ff9900" colspan="4">
                                            <img height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="4" valign="top">
                                            <table>
                                                <tr>
                                                    <td align="right" style="width: 150px; height: 17px">
                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        <asp:Label ID="Label1" runat="server">����</asp:Label></td>
                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <asp:DropDownList ID="ddPlant" runat="server"></asp:DropDownList></td>
                                                    <td align="right" style="width: 150px; height: 17px">
                                                        <asp:HiddenField ID="hdBarcodeId" runat="server" />
                                                        <asp:Label ID="lblDept" runat="server">������</asp:Label></td>
                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <asp:DropDownList ID="dropAdmindept" runat="server"></asp:DropDownList></td>

                                                </tr>
                                                <tr>

                                                    <td align="right" style="width: 150px; height: 17px">
                                                        <asp:HiddenField ID="HiddenField3" runat="server" />
                                                        <asp:Label ID="Label3" runat="server">����Ա��</asp:Label></td>
                                                    <%--                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <asp:DropDownList ID="ddEmployee" runat="server" ></asp:DropDownList></td>--%>
                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <%--  <input id="txtEmployee" style="border-right: lightgrey 1px solid; border-top: lightgrey 1px solid; border-left: lightgrey 1px solid; width: 200px; border-bottom: lightgrey 1px solid; height: 18px"
                                                            tabindex="1" type="text" maxlength="30" size="24" name="maxcode" runat="server" >--%>
                                                        <asp:TextBox runat="server" ID="txtEmployee" ToolTip="���á�;����������û�" Style="border-right: lightgrey 1px solid; border-top: lightgrey 1px solid; border-left: lightgrey 1px solid; width: 200px; border-bottom: lightgrey 1px solid; height: 18px"
                                                            type="text" MaxLength="30" size="24" name="maxcode" Text="���á�;����������û�"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="width: 150px; height: 17px">
                                                        <asp:Label ID="Label7" runat="server">�ʲ�����</asp:Label></td>
                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <input id="assetclassify" style="border-right: lightgrey 1px solid; border-top: lightgrey 1px solid; border-left: lightgrey 1px solid; width: 200px; border-bottom: lightgrey 1px solid; height: 18px"
                                                            tabindex="1" type="text" maxlength="30" size="24" name="assetclassify" runat="server"></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 150px; height: 17px">
                                                        <asp:Label ID="Label5" runat="server">�̶�����</asp:Label></td>
                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <input id="fixedbarcode" style="border-right: lightgrey 1px solid; border-top: lightgrey 1px solid; border-left: lightgrey 1px solid; width: 200px; border-bottom: lightgrey 1px solid; height: 18px; background-color: #ffffff"
                                                            type="text" maxlength="10" size="25" name="fixedbarcode" runat="server"></td>
                                                    <td align="right" style="width: 150px; height: 17px">
                                                        <asp:Label ID="Label6" runat="server">�������ֵ</asp:Label></td>
                                                    <td align="left" style="width: 150px; height: 17px">
                                                        <input id="maxcode" style="border-right: lightgrey 1px solid; border-top: lightgrey 1px solid; border-left: lightgrey 1px solid; width: 200px; border-bottom: lightgrey 1px solid; height: 18px"
                                                            tabindex="1" type="text" maxlength="30" size="24" name="maxcode" runat="server" readonly></td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label8" runat="server">��ע</asp:Label></td>
                                                    <td align="left" style="width: 150px" colspan="3">
                                                        <input id="comments" style="border: 1px solid lightgrey; width: 557px; height: 18px"
                                                            tabindex="2" maxlength="100" size="50" name="comments" runat="server"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td bgcolor="#ff9900" colspan="4" style="height: 1px">
                                            <img height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4" valign="top">
                                            <asp:ImageButton ID="BtnAdd" TabIndex="5" runat="server" ImageUrl="images/DH_ADD.GIF" OnClick="BtnAdd_Click"></asp:ImageButton>
                                            <asp:ImageButton ID="BtnDel" TabIndex="7" runat="server" ImageUrl="images/DH_DEL.GIF" OnClick="BtnDel_Click"></asp:ImageButton>
                                            <asp:ImageButton ID="BtnSave" TabIndex="8" runat="server" ImageUrl="images/DH_SAVE.GIF" OnClick="BtnSave_Click"></asp:ImageButton>
                                            <asp:ImageButton ID="BtnExit" TabIndex="9" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:ImageButton></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
