<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.ManagerEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<script src="Script/MYSystem.js.cs/Manager.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />

<form id="form1" runat="server">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">管理员账户:</label>
            <input id="txtManagerName" type="text" class="form_input" runat="server" />
        </div>
        <div  class="form_row"  >
            <label style="margin-top: 6px;">管理员昵称:</label>
            <input id="txtManagerUserName" type="text" class="form_input" runat="server" />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">登录密码:</label>
            <input id="txtManagerPassword1" type="password" class="form_input" <%=Request["ActionMethod"]=="OpenEdit"? "placeholder=\"如不修改请留空\"" : "" %> />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">确认密码:</label>
            <input id="txtManagerPassword2" type="password" class="form_input"  <%=Request["ActionMethod"]=="OpenEdit"? "placeholder=\"如不修改请留空\"" : "" %>  />
        </div>
        <div class="form_row">
            <input type="button" class="btn green" value="确定" style="margin-left: 168px;" onclick="EditManager(QueryString('ManagerGUID'), QueryString('ActionMethod').replace('Open', 'Exec'))" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>
</form>