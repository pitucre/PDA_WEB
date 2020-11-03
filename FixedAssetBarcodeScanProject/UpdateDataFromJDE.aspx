<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDataFromJDE.aspx.cs" Inherits="FixedAssetBarcodeScanProject.UpdateDataFromJDE" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>从JDE系统更新数据</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
        <script language="javascript">
            function FrmExit() {
                return confirm("您确定要退出吗?");
            }
            function FrmRefresh() {
                if (confirm("这可能需要花费几分钟时间，您确定要进行该操作吗?") == true) {
                    return true;
                }
                return false;
            }
            function FrmUpload() {
                if (confirm("您确定进行该操作吗？") == true) {
                    return true;
                }
                return false;
            }
            function FrmSavedResult() {
                if (confirm("封存本次盘点信息后，您将不能再查询盘点结果。您确定进行该操作吗？") == true) {
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
								<TD style="HEIGHT: 14px; width: 948px;" background="images/TrainAD.gif" bgColor="#e6e6e6">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;数据更新</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff" style="width: 948px; height: 467px;">
												<TABLE cellSpacing="10" cellPadding="0" width="757" border="0" style="WIDTH: 757px; HEIGHT: 325px">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4" style="height: 1px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td colspan = "4">
                                                            <asp:imagebutton id="btnRefresh" tabIndex="9" runat="server" ImageUrl="images/refreshdata3.jpg" OnClick="BtnRefresh_Click"></asp:imagebutton></td>
                                                        </td>
                                                    </tr>
													<TR>
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
                                                    <tr>
                                                        <td colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td><FONT face="宋体">更新资产对应的条形码信息（文件格式要求：.xls文件；sheet名为sheet1；第一列为资产编码；第二列为条形码）</font></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        文件：<asp:FileUpload 
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
