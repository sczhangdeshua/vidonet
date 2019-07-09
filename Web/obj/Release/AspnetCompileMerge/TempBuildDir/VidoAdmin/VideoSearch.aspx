<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoSearch.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoSearch" %>

<%@ Register Src="~/VidoAdmin/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/VidoAdmin/Control/Footer.ascx" TagPrefix="uc2" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>非凡影视管理系统</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script language="javascript">
        //向菜单控制程序转入当前页的类型名称，比如：Index代表系统管理类型页，Video代表影视管理类型页
        var PageTag = "Video";
    </script>
    <script src="Script/jquery-3.1.1.js"></script>
    <script src="Script/jquery.form.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="Script/layer/layer.js"></script>
    <script src="Script/system.js"></script>
    <script src="Script/calendar.js"></script>
    <script src="Script/MYSystem.js.cs/Video.js"></script>
    <link href="Script/layui/css/layui.css" rel="stylesheet" />
</head>


<body>
    <div id="panelwrap">
        <uc1:Header ID="Header1" runat="server" />
        <div class="center_content">
            <table align="center" cellpadding="0" cellspacing="0" width="100%" height="550">
                <tr>
                    <td width="60%" align="center" valign="middle" height="110">
                        <input type="text" class="form_input_search_bigLeft" id="txtKey" placeholder="输入影视名称" onkeypress="event.keyCode==13? GetVideoSearch() : void(0);" />
                        <input type="button" class="form_input_search_bigRight" value="搜索" onclick="GetVideoSearch()" />
                    </td>
                    <td width="30%" align="left" valign="middle" style="padding-top: 20px;">
                        <div>
                            <input type="checkbox" id="chkVideoDetailVisible" value="0" />仅看已下映的影视</div>
                        <br />
                        <label>添加时间:</label>
                        <input id="txtVideoDetailAddDateStart" value="" readonly="readonly" type="text" class="form_input_search" runat="server" style="width: 150px;" placeholder="不限" onfocus="new Calendar().show(this);" />
                        至<input id="txtVideoDetailAddDateEnd" value="" readonly="readonly" type="text" class="form_input_search" runat="server" style="width: 150px;" placeholder="不限" onfocus="new Calendar().show(this);" />

                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" colspan="2">
                        <div id="divVideoList"></div>
                    </td>
                </tr>
            </table>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </div>
</body>
</html>
