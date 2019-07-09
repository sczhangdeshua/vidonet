<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersUserNameMailEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UsersUserNameMailEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/MYSystem.js.cs/Users.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />

<div class="tabcontent">
    <div class="form_row">
        <label style="margin-top: 6px; width: 100%;">当前昵称：<span style="color: #f00; font-size: 16px;"><%=Name %></span></label>
    </div>
    <div class="form_row">
        <label style="margin-top: 6px;">新昵称:</label>
        <input id="txtUsersName" type="text"  class="form_input" style="width: 230px; " />
        
    </div>
    <div class="form_row">
        <label style="margin-top: 6px;">新邮箱:</label>
        <input id="txtUsersMail" type="text"  class="form_input" style="width: 230px;" />
    </div>
    <div class="form_row">
        <input type="button" class="btn green" value="确定" onclick="EditUsersUserNameMail(QueryString('GUID'), QueryString('ActionMethod').replace('Open', 'Exec'))" style="margin-left: 150px;" />
        <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
    </div>
</div>
