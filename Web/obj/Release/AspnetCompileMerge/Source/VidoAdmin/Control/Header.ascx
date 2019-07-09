<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Maticsoft.Web.VidoAdmin.Control.Header" %>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<div class="header">
    <div class="title"><a href="Index.aspx">非凡影视管理系统</a></div>
    <div class="header_right">当前管理员：<%=ManagerName %> <a href="ConfigIndex.aspx?Action=OpenEdit&ConfigURL=ConfigSys" class="settings">系统设置</a> <a class="logout" onclick="Logout()">退出系统</a><a href="../Index.aspx" class="web" target="_blank">查看网站</a></div>
    <div class="menu">
        <ul>
            <li onmouseover="SetSubmenu(1);"><a name="MenuA" href="ManagerIndex.aspx">系统管理</a></li>
            <li onmouseover="SetSubmenu(2);"><a name="MenuA" href="VideoIndex.aspx">视频管理</a></li>
            <li onmouseover="SetSubmenu(3);"><a name="MenuA" href="UsersIndex.aspx">会员管理</a></li>
            <li onmouseover="SetSubmenu(4);"><a name="MenuA" href="ReportIndex.aspx">统计图表</a></li>
            <li onmouseover="SetSubmenu(5);"><a name="MenuA" href="AdIndex.aspx">其它</a></li>
        </ul>
    </div>
</div>
<div id="Submenu1" name="Submenu" class="Submenu">
    <ul>
        <li><a href="ManagerIndex.aspx">管理员</a></li>
        <li><a href="ConfigIndex.aspx?Action=OpenEdit&ConfigURL=ConfigSys">系统设置</a></li>
    </ul>
</div>
<div id="Submenu2" class="Submenu">
    <ul>
        <li><a href="VideoIndex.aspx">全部视频</a></li>
        <li><a href="VideoSearch.aspx">搜索视频</a></li>
    </ul>
</div>
<div id="Submenu3" class="Submenu">
    <ul>
        <li><a href="UsersIndex.aspx">全部会员</a></li>
        <li><a href="Error/404.html#">站内消息发送记录</a></li>
    </ul>
</div>
<div id="Submenu4" class="Submenu">
    <ul>
        <li><a href="ReportIndex.aspx">概要</a></li>
        <li><a href="LogIndex.aspx">操作日志</a></li>
    </ul>
</div>
<div id="Submenu5" class="Submenu">
    <ul>
        <li><a href="AdIndex.aspx">广告管理</a></li>
        <li><a href="LinkIndex.aspx">友情链接管理</a></li>
        <li><a href="MessageIndex.aspx">留言板管理</a></li>
    </ul>
</div>
<script language="javascript">
    switch (PageTag) {
        //根据各子页传回的PageTag变量，设置默认显示的子菜单
        case "Index":
            SetSubmenu(1);
            break;
        case "Article":
            SetSubmenu(2);
            break;
        case "Users":
            SetSubmenu(3);
            break;
        case "Report":
            SetSubmenu(4);
            break;
        case "Other":
            SetSubmenu(5);
            break;
        default:
            SetSubmenu(1);
            break;
    }

    function SetSubmenu(CurrentSubmenu) {
        //设置要显示的子菜单
        var MenuCount = document.getElementsByName("MenuA").length;
        for (var i = 1; i <= MenuCount; i++) {
            document.getElementById("Submenu" + i).style.display = "none";
            document.getElementsByName("MenuA").item(i - 1).className = "";
        }
        document.getElementById("Submenu" + CurrentSubmenu).style.display = "block";
        document.getElementsByName("MenuA").item(CurrentSubmenu - 1).className = "selected";
    }
</script>
