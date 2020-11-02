<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="FixedAssetBarcodeScanProject.Success" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>信息提示窗口</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.style7 { FONT-SIZE: 12px; FONT-FAMILY: "宋体" }
		</style>
	</HEAD>
	<BODY leftMargin="0" topMargin="0">
		<form id="FrmAddUser" name="FrmAddUser" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD style="HEIGHT: 226px" vAlign="top">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 13px" background="images/TrainAD.gif" bgColor="#e6e6e6" height="13">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;信息提示</FONT></TD>
							</TR>
							<TR id="taskDiv" vAlign="top">
								<td vAlign="top" bgColor="#ffffff">
									<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" colSpan="4" height="31">
												<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
													<TR vAlign="top">
														<TD bgColor="#ff9900" colSpan="4"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 5px" align="center" width="100%" colSpan="4">
															<asp:Label id="lblErrorMessage" runat="server" ForeColor="Red">Label</asp:Label>
														</TD>
													</TR>
													<TR>
														<TD align="center" width="100%" colSpan="4"><FONT face="宋体"><IMG height="121" src="images/ct1.jpg" width="161"></FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</td>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
										<asp:ImageButton id="BtnReturn" runat="server" ImageUrl="images/dh_return.GIF" Width="64px" OnClick="BtnReturn_Click"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TABLE>
			&nbsp;
		</form>
	</BODY>
</HTML>

