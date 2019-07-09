<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoDetailEdit.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoDetailEdit" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/MYSystem.js.cs/Video.js"></script>
<script src="Script/system.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script charset="utf-8" src="Script/ueditor/ueditor.config.js"></script>
<script charset="utf-8" src="Script/ueditor/ueditor.all.min.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />

<form id="form1" runat="server">
    <div class="tabcontent">
        <div class="form_row">
            <label style="margin-top: 6px;">影视名称:</label>
            <input id="txtVideoDetailName" type="text" class="form_input" runat="server" style="width: 660px;" />
        </div>
        <div class="form_row">

            <label style="margin-top: 6px;">影视来源URL:</label>
            <input id="txtVideoDetailSource" type="text" class="form_input" style="width: 260px;" runat="server" value="无特殊说明"  />
            <label style="margin-top: 6px;margin-left: 50px;">图片来源URL:</label>
            <input id="VideoDetailImgeURL" type="text" class="form_input" style="width: 250px;" runat="server" value="Images/noImage.gif" />
          
        </div>
        <div class="form_row">
            <label style="margin-top: 6px; width: 300px;">
                是否上映:
                <input id="rdoVideoDetailVisible1" runat="server" name="rdoVideoDetailVisible" checked="true" value="1" type="radio" style="margin-left: 50px;" />是
                <input id="rdoVideoDetailVisible0" runat="server" name="rdoVideoDetailVisible" value="0" type="radio" />否
            </label>
            <label style="margin-top: 6px; width: 300px;">
                是否以完结:
                <input id="rdoVideoDetailSequel1" runat="server" name="rdoVideoDetailSequel" checked="true" value="1" type="radio" style="margin-left: 50px;" />是
                <input id="rdoVideoDetailSequel0" runat="server" name="rdoVideoDetailSequel" value="0" type="radio" />否
            </label>
            <label style="margin-top: 6px; width: 300px;">
                是否热搜:
                <input id="rdoHotSearch1" runat="server" name="rdoHotSearch" checked="true" value="1" type="radio" style="margin-left: 50px;" />是
                <input id="rdoHotSearch0" runat="server" name="rdoHotSearch" value="0" type="radio" />否
            </label>
        </div>
        <div class="form_row">
             <label style="margin-top: 6px">浏览次数:</label>
            <input id="txtVideoDetailBrowseCount" type="text" class="form_input" style="width: 260px;" value="0" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')" />
        </div>
        <!--动态属性区-->
        <div id="divVideoAttribConfigList" class="form_row" style="border: 2px solid #CCCCCC; padding: 8px 0px;" runat="server">
            <asp:repeater runat="server" id="rptList">
                <ItemTemplate>
                    <label style="margin-top: 6px; margin-left: 25px;"><%#Eval("VideoAttribConfigName") %>:</label>
                    <input name="hidVideoAttribConfigGUID" type="hidden" value="<%#Eval("GUID")%>" />
                    <input name="txtVideoAttribValue" type="text" class="form_input" style="width: 250px; margin-bottom:6px;" placeholder="<%#Eval("VideoAttribConfigDescribe") %>" value="<%#Eval("VideoAttribValueValue")%>" />
                </ItemTemplate>
            </asp:repeater>
        </div>
        <!--动态属性区end-->

        <div class="form_row">
            <label id="lblVideoDetailContentTip" style="margin-top: 6px;">影视详情:</label>
        </div>
        <div class="form_row">
            <script id="txtVideoDetailContent" type="text/plain" style="width: 100%; height: 330px;"></script>
        </div>

        <div class="form_row">
            <input type="button" class="btn green" value="确定" style="margin-left: 40%;" onclick="EditVideoDetail(QueryString('GUID'), QueryString('ActionMethod').replace('Open', 'Exec'))" />
            <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
        </div>
    </div>
</form>
<script type="text/javascript">
    var ue = UE.getEditor('txtVideoDetailContent', {
        scaleEnabled: true,
        elementPathEnabled: false,
        wordCount: false
    });

    //设置编辑器的默认数据
    if (QueryString("ActionMethod") == "OpenEdit") {
        var loadIndex = layer.load(2);
        setTimeout("SetUEContent()", 1888);
        function SetUEContent() {
            UE.getEditor('txtVideoDetailContent').setContent('<%=modelVideoDetail.VideoDetailContent.Replace("\r\n","")%>');
            layer.close(loadIndex);
        }
    }

</script>

