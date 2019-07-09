<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserStateAttr.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UserStateAttr" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<script src="Script/MYSystem.js.cs/Users.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/layui/layui.js"></script>
<link href="Script/layui/css/layui.css" rel="stylesheet" />


<form id="form1" runat="server" class="layui-form">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">会员状态:</label>
            <div class="layui-input-block">
                <input type="radio" name="rdoUserState" id="rdoUserState" checked="checked" value="正常" title="正常">
                <input type="radio" name="rdoUserState" value="锁定" title="锁定">
            </div>
        </div>
        <div class="form_row">
            <input type="button" class="btn green" onclick="EditUsersStateAttr(QueryString('UsersGUIDList'), QueryString('ActionMethod').replace('Open', 'Exec'))" value="确定" style="margin-left: 150px;" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>
</form>

<script>
    layui.use('form', function () {
        var form = layui.form();
    });
</script>
