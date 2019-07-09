<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersPasswordEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UsersPasswordEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<script src="Script/MYSystem.js.cs/Users.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<link rel="stylesheet" type="text/css" href="style.css" />

<div class="tabcontent">
    <div class="form_row">
        <label style="margin-top: 6px;">登录密码:</label>
        <input id="txtUsersPassword1" type="password" class="form_input" style="width: 145px;" <%=Request["ActionMethod"]=="OpenEdit"? "placeholder=\"如不修改请留空\"" : "" %> />
        <label style="margin: 6px; width: auto;">确认:</label>
        <input id="txtUsersPassword2" type="password" class="form_input" style="width: 145px;" <%=Request["ActionMethod"]=="OpenEdit"? "placeholder=\"如不修改请留空\"" : "" %> />
    </div>
    <div class="form_row">
        <input type="button" class="btn green" value="确定" onclick="EditUsersPassword(QueryString('GUID'),QueryString('ActionMethod').replace('Open', 'Exec'))" style="margin-left: 150px;" />
        <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
    </div>
</div>
