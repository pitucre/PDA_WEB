<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDataFromJDE.aspx.cs" Inherits="FixedAssetBarcodeScanProject.UpdateDataFromJDE" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>��SAPϵͳ��������</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "����" }
		</style>
        <script type="text/javascript" language="javascript">
            function FrmExit() {
                return confirm("��ȷ��Ҫ�˳���?");
            }
            function FrmRefresh() {
                if (confirm("�������Ҫ���Ѽ�����ʱ�䣬��ȷ��Ҫ���иò�����?") == true) {
                    return true;
                }
                return false;
            }
            function FrmUpload() {
                if (confirm("��ȷ�����иò�����") == true) {
                    return true;
                }
                return false;
            }
            function FrmSavedResult() {
                if (confirm("��汾���̵���Ϣ�����������ٲ�ѯ�̵�������ȷ�����иò�����") == true) {
                    return true;
                }
                return false;
            }
		</script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0" onload="">
		<form id="Form1" name="Form1" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" border="0" style="height: 509px">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px; width: 616px;" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;���ݸ���</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff" style="width: 948px; height: 467px;">
												<TABLE cellSpacing="10" cellPadding="0" width="757" border="0" style="WIDTH: 757px; HEIGHT: 325px">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td colspan = "4">
                                                            <asp:imagebutton id="btnRefresh" tabIndex="9" runat="server" ImageUrl="images/refreshdata3_new.jpg" OnClick="BtnRefresh_Click"></asp:imagebutton></td>
                                                        </td>
                                                    </tr>
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td><FONT face="����">�����ʲ���Ӧ����������Ϣ���ļ���ʽҪ��.xls�ļ���sheet��Ϊsheet1����һ��Ϊ�ʲ����룻�ڶ���Ϊ�����룩</font></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        �ļ���<asp:FileUpload 
                                                                            ID="FileUpload1" runat="server" Width="400px" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:imagebutton id="btnUpload" tabIndex="9" runat="server" ImageUrl="images/upload.jpg" OnClick="BtnUpload_Click"></asp:imagebutton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td colspan = "4">
                                                            <asp:imagebutton id="btnSaveResult" tabIndex="9" runat="server" ImageUrl="images/saveScanResult.png" OnClick="BtnSaveResult_Click"></asp:imagebutton></td>
                                                        </td>
                                                    </tr>
                                                    <TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td align="center" colspan="4" valign="top">
								<asp:imagebutton id="BtnExit" tabIndex="9" runat="server" ImageUrl="images/exit2.jpg" OnClick="BtnExit_Click"></asp:imagebutton></td>
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
