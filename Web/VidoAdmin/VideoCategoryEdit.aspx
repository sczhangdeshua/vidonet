<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoCategoryEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoCategoryEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/MYSystem.js.cs/Video.js"></script>
<script src="Script/system.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<link rel="stylesheet" type="text/css" href="style.css" />

<form id="form1" runat="server">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">分类名称:</label>
            <input id="txtVideoCategoryName" type="text" class="form_input" runat="server" />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">介绍说明:</label>
            <textarea id="txtVideoCategoryDescribe" class="form_input" style="height: 80px;" runat="server"></textarea>
        </div>
        <div class="form_row">
            <input type="button" class="btn green" value="确定" style="margin-left: 168px;" onclick="EditVideoCategory(QueryString('VideoCategoryGUID'), QueryString('ActionMethod').replace('Open', 'Exec'))" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>
</form>