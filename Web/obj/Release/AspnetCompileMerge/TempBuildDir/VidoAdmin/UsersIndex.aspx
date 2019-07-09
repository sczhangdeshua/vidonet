<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersIndex.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UsersIndex" %>

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
        var PageTag = "Users";
    </script>
    <script src="Script/jquery-3.1.1.js"></script>
    <script src="Script/jquery.form.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="Script/layer/layer.js"></script>
    <script src="Script/MYSystem.js.cs/Users.js"></script>
    <script src="Script/calendar.js"></script>
    <script src="Script/system.js"></script>
    <link href="Script/layui/css/layui.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div id="panelwrap">
            <uc1:Header ID="Header1" runat="server" />
            &nbsp;<div class="center_content">
                <div id="right_wrap">
                    <div id="right_content">
                        <table>
                            <tr>
                                <td>
                                    <div id="divUsersList"></div>
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
    InitUsersList();
</script>

