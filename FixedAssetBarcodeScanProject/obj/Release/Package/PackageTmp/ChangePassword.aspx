<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="FixedAssetBarcodeScanProject.ChangePassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>修改密码窗口</TITLE>
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
		        var tempstr1 = Trim(doc.t_PassWdOld.value);
		        var tempstr2 = Trim(doc.t_PassWdNew.value);
		        var tempstr3 = Trim(doc.t_PassWdNewCompare.value);

		        //if (tempstr1=="")
		        //{
		        //	alert("原密码不能为空!");
		        //	doc.t_PassWdOld.focus();
		        //	return false
		        //}
		        if (tempstr2 == "") {
		            alert("新密码不能为空!");
		            doc.t_PassWdNew.focus();
		            return false
		        }
		        if (tempstr3 == "") {
		            alert("确认新密码不能为空!");
		            doc.t_PassWdNewCompare.focus();
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
	<BODY leftMargin="0" topMargin="0" onload="javascript:FrmChangePsw.t_PassWdOld.focus()">
		<form id="FrmChangePsw" name="FrmChangePsw" runat="server">
			<TABLE cellSpacing="8" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="FONT-WEIGHT: bold; COLOR: black" vAlign="top" align="left" bgColor="#cbd7ff">&nbsp;&nbsp;<IMG height="11" alt="" src="images/ico_item.gif" width="15" border="0">&nbsp;修改密码</TD>
				</TR>
				<TR vAlign="top">
					<TD style="HEIGHT: 226px">
						<TABLE cellSpacing="1" cellPadding="0" width="100%" bgColor="#c7bebc" border="0">
							<TR>
								<TD style="HEIGHT: 13px" background="images/TrainAD.gif" bgColor="#e6e6e6" height="13">&nbsp;&nbsp;<IMG height="12" alt="" src="images/ico_arrow.gif" width="16" border="0"><FONT style="COLOR: #ff6666">&nbsp;修改密码</FONT></TD>
							</TR>
							<TR id="taskDiv">
								<td bgColor="#ffffff">
									<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
										<tr>
											<td colSpan="4" height="31">
												<TABLE cellSpacing="10" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#ff9900" colSpan="4" style="HEIGHT: 2px"><IMG height="1" alt="" src="../Common/Images/spacer.gif" width="1" border="0"></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 84px; HEIGHT: 18px" align="right"><asp:label id="lblDescription" runat="server">用户名</asp:label></TD>
														<TD style="WIDTH: 413px; HEIGHT: 18px"><FONT face="宋体"><INPUT id="t_StaffCaption" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 288px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	disabled type="text" maxLength="30" size="42" name="t_StaffCaption" runat="server"></FONT></TD>
														<TD style="WIDTH: 53px; HEIGHT: 18px" align="right"><FONT face="宋体"></FONT></TD>
														<TD style="HEIGHT: 18px"><FONT face="宋体"></FONT></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 84px" align="right"><FONT face="宋体">
																<asp:label id="Label7" runat="server">原密码</asp:label></FONT></TD>
														<TD style="WIDTH: 413px"><FONT face="宋体" color="#ff0000"><INPUT id="t_PassWdOld" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 288px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	type="password" maxLength="50" size="42" name="t_PassWdOld" runat="server" tabIndex="1">*</FONT></TD>
														<TD style="WIDTH: 53px" align="right"></TD>
														<TD><FONT face="宋体"></FONT></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 84px; HEIGHT: 18px" align="right">
															<asp:label id="Label8" runat="server">新密码</asp:label></TD>
														<TD style="WIDTH: 413px; HEIGHT: 18px"><FONT face="宋体" color="#ff0000"><INPUT id="t_PassWdNew" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 288px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	type="password" maxLength="50" size="42" name="t_PassWdNew" runat="server" tabIndex="2">*</FONT></TD>
														<TD style="WIDTH: 53px; HEIGHT: 18px" align="right"></TD>
														<TD style="HEIGHT: 18px"><FONT face="宋体"></FONT></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 84px" align="right">
															<asp:label id="Label1" runat="server">确认新密码</asp:label></TD>
														<TD style="WIDTH: 413px"><FONT face="宋体" color="#ff0000"><INPUT id="t_PassWdNewCompare" style="BORDER-RIGHT: lightgrey 1px solid; BORDER-TOP: lightgrey 1px solid; BORDER-LEFT: lightgrey 1px solid; WIDTH: 288px; BORDER-BOTTOM: lightgrey 1px solid; HEIGHT: 18px"
																	type="password" maxLength="50" size="42" name="t_PassWdNewCompare" runat="server" tabIndex="3">*</FONT></TD>
														<TD style="WIDTH: 53px" align="right"><FONT face="宋体"></FONT></TD>
														<TD><FONT face="宋体"></FONT></TD>
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
									<asp:imagebutton id="BtnSave" runat="server" Width="64px" ImageUrl="images/DH_SAVE.GIF" tabIndex="4" OnClick="BtnSave_Click"></asp:imagebutton>
									<asp:imagebutton id="BtnExit" tabIndex="5" runat="server" ImageUrl="images/DH_EXIT.GIF" OnClick="BtnExit_Click"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TABLE>
		</form>
	</BODY>
</HTML>
