<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigIndex.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.ConfigIndex" %>


<%@ Register Src="~/VidoAdmin/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/VidoAdmin/Control/Footer.ascx" TagPrefix="uc2" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>非凡影视管理系统</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script language="javascript">
        //向菜单控制程序转入当前页的类型名称，比如：Index代表系统管理类型页，Product代表产品管理类型页
        var PageTag = "Index";
    </script>
    <script src="Script/jquery-3.1.1.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="Script/jquery.form.js"></script>
    <script src="Script/layer/layer.js"></script>
    <script src="Script/system.js"></script>
    <script src="Script/MYSystem.js.cs/Config.js"></script>
    <script src="Script/calendar.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div id="panelwrap">
            <uc1:Header ID="Header1" runat="server" />
            &nbsp;<div class="center_content">
                <div id="right_wrap">
                    <div id="right_content">
                        <table border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left" valign="top">
                                    <table width="1060" id="rounded-cornerOther">
                                        <thead>
                                            <tr>
                                                <th align="left" valign="middle">
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin-bottom: 8px;">
                                                        <tr>
                                                            <td height="40" align="left" valign="middle" style="padding: 0px 8px 0px 8px;">
                                                                <input class="btn green" type="button" value="保存" onclick="SaveConfig(QueryString('ConfigURL'))" />
                                                                <input class="btn red" type="button" value="取消" onclick="InitConfig('/' + QueryString('ConfigURL') + '.aspx', QueryString('Action'));" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                                                        <tr>
                                                            <td align="left" valign="top" style="padding: 8px;">
                                                                <div id="divConfigList"></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <table width="1045" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin-bottom: 8px;">
                                                        <tr>
                                                            <td height="40" align="left" valign="middle" style="padding: 0px 8px 0px 8px;">
                                                                <input class="btn green" type="button" value="保存" onclick="SaveConfig(QueryString('ConfigURL'))" />
                                                                <input class="btn red" type="button" value="取消" onclick="InitConfig('/' + QueryString('ConfigURL') + '.aspx', QueryString('Action'));" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>

<script language="javascript">
    InitConfig("/VidoAdmin/" + QueryString("ConfigURL") + ".aspx", QueryString("Action"));
</script>
