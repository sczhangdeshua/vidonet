<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoAttribConfigEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoAttribConfigEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/system.js"></script>
<script src="Script/MYSystem.js.cs/Video.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />

<form id="form1" runat="server">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">属性名称:</label>
            <input id="txtVideoAttribConfigName" type="text" class="form_input" runat="server" />
        </div>
        <div class="form_row">
            <label style="margin-top: 6px;">属性说明:</label>
            <textarea id="txtVideoAttribConfigDescribe" class="form_input" style="height: 80px;" runat="server"></textarea>
        </div>
        <div class="form_row">
            <input type="button" class="btn green" value="确定" style="margin-left: 168px;" onclick="EditVideoAttribConfig(QueryString('VideoCategoryGUID'), QueryString('ActionMethod').replace('Open', 'Exec'), QueryString('VideoAttribConfigGUID'))" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>
</form>
