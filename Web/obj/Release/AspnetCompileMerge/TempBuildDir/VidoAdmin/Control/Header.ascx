<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Maticsoft.Web.VidoAdmin.Control.Header" %>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<div class="header">
    <div class="title"><a href="Index.aspx">�Ƿ�Ӱ�ӹ���ϵͳ</a></div>
    <div class="header_right">��ǰ����Ա��<%=ManagerName %> <a href="ConfigIndex.aspx?Action=OpenEdit&ConfigURL=ConfigSys" class="settings">ϵͳ����</a> <a class="logout" onclick="Logout()">�˳�ϵͳ</a><a href="../Index.aspx" class="web" target="_blank">�鿴��վ</a></div>
    <div class="menu">
        <ul>
            <li onmouseover="SetSubmenu(1);"><a name="MenuA" href="ManagerIndex.aspx">ϵͳ����</a></li>
            <li onmouseover="SetSubmenu(2);"><a name="MenuA" href="VideoIndex.aspx">��Ƶ����</a></li>
            <li onmouseover="SetSubmenu(3);"><a name="MenuA" href="UsersIndex.aspx">��Ա����</a></li>
            <li onmouseover="SetSubmenu(4);"><a name="MenuA" href="ReportIndex.aspx">ͳ��ͼ��</a></li>
            <li onmouseover="SetSubmenu(5);"><a name="MenuA" href="AdIndex.aspx">����</a></li>
        </ul>
    </div>
</div>
<div id="Submenu1" name="Submenu" class="Submenu">
    <ul>
        <li><a href="ManagerIndex.aspx">����Ա</a></li>
        <li><a href="ConfigIndex.aspx?Action=OpenEdit&ConfigURL=ConfigSys">ϵͳ����</a></li>
    </ul>
</div>
<div id="Submenu2" class="Submenu">
    <ul>
        <li><a href="VideoIndex.aspx">ȫ����Ƶ</a></li>
        <li><a href="VideoSearch.aspx">������Ƶ</a></li>
    </ul>
</div>
<div id="Submenu3" class="Submenu">
    <ul>
        <li><a href="UsersIndex.aspx">ȫ����Ա</a></li>
        <li><a href="Error/404.html#">վ����Ϣ���ͼ�¼</a></li>
    </ul>
</div>
<div id="Submenu4" class="Submenu">
    <ul>
        <li><a href="ReportIndex.aspx">��Ҫ</a></li>
        <li><a href="LogIndex.aspx">������־</a></li>
    </ul>
</div>
<div id="Submenu5" class="Submenu">
    <ul>
        <li><a href="AdIndex.aspx">������</a></li>
        <li><a href="LinkIndex.aspx">�������ӹ���</a></li>
        <li><a href="MessageIndex.aspx">���԰����</a></li>
    </ul>
</div>
<script language="javascript">
    switch (PageTag) {
        //���ݸ���ҳ���ص�PageTag����������Ĭ����ʾ���Ӳ˵�
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
        //����Ҫ��ʾ���Ӳ˵�
        var MenuCount = document.getElementsByName("MenuA").length;
        for (var i = 1; i <= MenuCount; i++) {
            document.getElementById("Submenu" + i).style.display = "none";
            document.getElementsByName("MenuA").item(i - 1).className = "";
        }
        document.getElementById("Submenu" + CurrentSubmenu).style.display = "block";
        document.getElementsByName("MenuA").item(CurrentSubmenu - 1).className = "selected";
    }
</script>
