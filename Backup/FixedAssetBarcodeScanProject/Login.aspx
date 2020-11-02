<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FixedAssetBarcodeScanProject.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>固铂成山（山东）轮胎有限公司-固定资产条码系统-登录页</title>
		<SCRIPT language="JavaScript">
		    function Trim(str) {
		        if (str.charAt(0) == " ") {
		            str = str.slice(1);
		            str = Trim(str);
		        }
		        return str;
		    }

		    function ValueIfEmpty() {
		        var doc = document.forms[0];
		        var tempstr1 = Trim(doc.txtUserName.value);

		        if (tempstr1 == "") {
		            alert("请输入用户名称!");
		            doc.txtUserName.focus();
		            return false;
		        }
		    }
		</SCRIPT>
	</head>
	<body onload="javascript:FrmLogin.txtUserName.focus()">
		<form id="FrmLogin" name="FrmLogin" method="post" runat="server">
			<div align="center">
                <table style="width: 625px">
                    <tr>
                        <td style="width: 621px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 621px">
                            <asp:Panel ID="Panel1" runat="server" BackImageUrl="images/login.jpg" Height="400px"
                                Width="600px" TabIndex="11">
                                <table style="width: 597px">
                                    <tr>
                                        <td style="height: 37px">
                                        </td>
                                        <td style="width: 222px; height: 37px">
                                        </td>
                                        <td style="height: 37px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 291px">
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="width: 3px">
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="width: 3px">
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="width: 3px">
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 222px; height: 291px">
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 73px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 73px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 73px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="height: 291px" valign="bottom">
                                            <table>
                                                <tr>
                                                    <td colspan="2" style="height: 21px">
														<asp:label id="lblErrorMessageTop" runat="server" Width="329px" Font-Names="宋体" ForeColor="Red"
															Font-Bold="True" Font-Underline="False" TabIndex="6"></asp:label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 275px; height: 21px">
                                                        <asp:Label ID="lblUserName" runat="server" Font-Size="Small" Text="用户名:"></asp:Label></td>
                                                    <td align="left" style="width: 275px; height: 21px">
                                                        <input id="txtUserName" style="BORDER-RIGHT: #6790ff 1px solid; BORDER-TOP: #6790ff 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: #6790ff 1px solid; WIDTH: 150px; BORDER-BOTTOM: #6790ff 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
															tabindex="1" type="text" maxlength="50" name="txtUserName" runat="server"/></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 275px; height: 22px;">
                                                        <asp:Label ID="lblPassword" runat="server" Font-Size="Small" Text="密   码:"></asp:Label></td>
                                                    <td align="left" style="width: 275px; height: 22px;">
                                                        <input id="txtPassWord" style="BORDER-RIGHT: #6790ff 1px solid; BORDER-TOP: #6790ff 1px solid; VERTICAL-ALIGN: baseline; BORDER-LEFT: #6790ff 1px solid; WIDTH: 150px; BORDER-BOTTOM: #6790ff 1px solid; HEIGHT: 18px; TEXT-ALIGN: left"
															tabindex="2" type="password" maxlength="50" name="txtPassWord" runat="server"/></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 275px; height: 22px;">
                                                    </td>
                                                    <td align="left" style="width: 275px; height: 22px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 275px; height: 20px">
                                                        <asp:Button ID="btnDenglu" runat="server" BorderStyle="Double" BorderWidth="1px"
                                                            Height="20px" OnClick="btnDenglu_Click" Text="登录" Width="50px" TabIndex="4" /></td>
                                                    <td align="left" style="width: 275px; height: 20px">
                                                        <asp:Button ID="btnquxiao" runat="server" BorderStyle="Double" BorderWidth="1px"
                                                            Height="20px" OnClick="btnquxiao_Click" Text="退出" Width="50px" TabIndex="5" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 32px">
                                        </td>
                                        <td style="width: 222px; height: 32px">
                                        </td>
                                        <td style="height: 32px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
			</div>
		</form>
	</body>
</html>
