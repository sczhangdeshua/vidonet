<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersDetailEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UsersDetailEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<script src="Script/calendar.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/MYSystem.js.cs/Users.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />

<form id="form1" runat="server">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">用户名称:</label>
            <input id="txtUsersDetailName" type="text" class="form_input" runat="server" />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">用户账户:</label>
            <input id="txtUserAccount" type="text" class="form_input" runat="server" />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">登录密码:</label>
            <input id="txtUsersDetailLoginPassword1" type="password" class="form_input" style="width: 145px;" />
             <label style="margin: 6px; width: auto;">邮箱:</label>
            <input id="txtUsersDetailEmail" type="text" class="form_input" runat="server" style="width: 145px;" />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态:</label>
            <select id="ddlUsersDatailState" class="form_select" style="width: 145px;">
                <option value="1">正常</option>
                <option value="0">锁定</option>
            </select>
        </div>
        <div class="form_row">
            <input type="button" class="btn green" value="确定" style="margin-left: 168px;" onclick="EditUsersDetail(QueryString('ActionMethod').replace('Open', 'Exec'))" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>

</form>


