<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�Ƿ�Ӱ�ӹ���ϵͳ</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script src="Script/jquery-3.1.1.js"></script>
    <script src="Script/jquery.form.js"></script>
    <script src="Script/layer/layer.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="Script/MYSystem.js.cs/Login.js"></script>
    <link href="css/Adminstyle.css" rel="stylesheet" />
</head>

<body onkeypress="event.keyCode==13? Login() : void(0);">
    <div id="loginpanelwrap">
        <div class="loginheader">
            <div class="logintitle">�Ƿ�Ӱ��ϵͳ</div>
        </div>
        <div class="loginform">
            <div class="loginform_row">
                <label>��&nbsp;��&nbsp;��:</label>
                <input id="txtManagerName" type="text" class="loginform_input" value="admin"/>
            </div>
            <div class="loginform_row">
                <label>��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��:</label>
                <input id="txtManagerPassword" type="password" class="loginform_input" value="666666"/>
            </div>
            <div class="loginform_row">
                <input type="submit" class="loginform_submit" value="��¼" onclick="Login()" />
            </div>
            <div class="clear"></div>
        </div>
        <div class="footer">Copyright &copy; 2017-2019  ��Ϣ�����о����� ��Ȩ����</div>
    </div>
</body>
</html>
