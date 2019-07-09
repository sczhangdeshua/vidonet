<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserStateEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UserStateEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<script src="Script/calendar.js"></script>
<script src="Script/MYSystem.js.cs/Users.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />

<form id="form1" runat="server">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">当&nbsp;&nbsp;前&nbsp;&nbsp;状&nbsp;&nbsp;态:</label>
            <select id="ddlUsersDatailState" runat="server" class="form_select" style="width: 210px;">
                <option  value="1">正常</option>
                <option  value="0">锁定</option>
            </select>
        </div>
        <div class="form_row">
            <input type="button" class="btn green" value="确定" style="margin-left: 168px;" onclick="EditUsersState(QueryString('GUID'),QueryString('ActionMethod').replace('Open', 'Exec'))" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>

</form>

