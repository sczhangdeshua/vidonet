<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoCategory.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoCategory" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/MYSystem.js.cs/Video.js"></script>
<script src="Script/system.js"></script>

<link rel="stylesheet" type="text/css" href="style.css" />
<form id="form1" runat="server">
    <div class="sidebar" id="sidebar">
        <h2>产品分类</h2>
        <ul style="padding-left: 5px; width: 180px;">
            <asp:repeater id="rptL1" runat="server" onitemdatabound="rptL1_ItemDataBound">
<ItemTemplate>
		<div id="divL1<%#Eval("GUID") %>" style="margin-bottom:12px;">
            <li style="margin-left:0px;">
            <img src="images/up.png" title="向上移动" class="categoryMenuImage" onclick="SetVideoCategoryMenuOrder('<%#Eval("GUID") %>','UP')"/>
            <img src="images/down.png" title="向下移动" class="categoryMenuImage" onclick="SetVideoCategoryMenuOrder('<%#Eval("GUID") %>','DOWN')"/>
            <img src="images/delete.png" title="删除分类" class="categoryMenuImage" onclick="DeleteVideoCategory('<%#Eval("GUID") %>')"/>
            <img src="images/edit.png" width="13" height="13" title="修改分类" class="categoryMenuImage" onclick="EditVideoCategory('<%#Eval("GUID") %>','OpenEdit')"/>
            <img src="images/attrib.png" width="13" height="13" title="设置动态属性" class="categoryMenuImage" onclick="OpenVideoAttribConfig('<%#Eval("GUID") %>','<%#Eval("VideoCategorName") %>')"/>
            <span class="divButton2" style="font-size:13px;" title="<%#Eval("GUID") %>：<%#Eval("VideoCategorName") %>" onclick="SetVideoCategoryMenu('divL2<%#Eval("GUID") %>')"><%#common.GetSubString(Eval("VideoCategorName").ToString() ,6,"...")%></span>
          </li>
            <div id="divL2<%#Eval("GUID") %>" style="display:none;">
    <asp:Repeater ID="rptL2" runat="server" OnItemDataBound="rptL2_ItemDataBound">
    <ItemTemplate>
            	<li style="margin-left:10px;">
                <img src="images/up.png" title="向上移动" class="categoryMenuImage" onclick="SetVideoCategoryMenuOrder('<%#Eval("GUID") %>','UP')"/>
                <img src="images/down.png" title="向下移动" class="categoryMenuImage" onclick="SetVideoCategoryMenuOrder('<%#Eval("GUID") %>','DOWN')"/>
                <img src="images/delete.png" title="删除分类" class="categoryMenuImage" onclick="DeleteVideoCategory('<%#Eval("GUID") %>')"/>
                <img src="images/edit.png" width="13" height="13" title="修改分类" class="categoryMenuImage" onclick="EditVideoCategory('<%#Eval("GUID") %>','OpenEdit')"/>
                <img src="images/attrib.png" width="13" height="13" title="设置动态属性" class="categoryMenuImage" onclick="OpenVideoAttribConfig('<%#Eval("GUID") %>','<%#Eval("VideoCategorName") %>')"/>
                <span class="divButton2" title="<%#Eval("VideoCategorName") %>" onclick="InitVideoList('<%#Eval("GUID") %>')"><%#common.GetSubString(Eval("VideoCategorName").ToString(),4,"...") %><span style="font-size:8px; color:#666; font-weight:normal;" title="当前分类中的数据量，不含下级">&nbsp;(<%#bllVideoCategory.ExGetVideoDetailCount((string)Eval("GUID"))%>)</span></span>
                </li>
        <asp:Repeater ID="rptL3" runat="server">
        <ItemTemplate>
                <li style="margin-left:20px;">
                <img src="images/up.png" title="向上移动" class="categoryMenuImage" onclick="SetVideoCategoryMenuOrder('<%#Eval("GUID") %>','UP')"/>
                <img src="images/down.png" title="向下移动" class="categoryMenuImage" onclick="SetVideoCategoryMenuOrder('<%#Eval("GUID") %>','DOWN')"/>
                <img src="images/delete.png" title="删除分类" class="categoryMenuImage" onclick="DeleteVideoCategory('<%#Eval("GUID") %>')"/>
                <img src="images/edit.png" width="13" height="13" title="修改分类" class="categoryMenuImage" onclick="EditVideoCategory('<%#Eval("GUID") %>','OpenEdit')"/>
                <img src="images/attrib.png" width="13" height="13" title="设置动态属性" class="categoryMenuImage" onclick="OpenVideoAttribConfig('<%#Eval("GUID") %>','<%#Eval("VideoCategorName") %>')"/>
                <span class="divButton2" title="<%#Eval("VideoCategorName") %>" onclick="InitVideoList('<%#Eval("GUID") %>')"><%# common.GetSubString((string)Eval("VideoCategorName"),4,"…") %><span style="font-size:8px; color:#666;" title="当前分类中的数据量，不含下级">&nbsp;(<%#bllVideoCategory.ExGetVideoDetailCount((string)Eval("GUID"))%>)</span></span>
                </li>
        </ItemTemplate>
        </asp:Repeater>
                    <div style="margin-left:100px;"><img src="images/add.png" title="创建分类" style="cursor:pointer; margin-top:5px;" /><span class="divButton2" onclick="EditVideoCategory('<%#Eval("GUID") %>','OpenCreate')">创建三级</span></div>
    </ItemTemplate>
    </asp:Repeater>
                <div style="margin-left:30px;"><img src="images/add.png" title="创建分类" style="cursor:pointer; margin-top:5px;" /><span class="divButton2" onclick="EditVideoCategory('<%#Eval("GUID") %>','OpenCreate')">创建二级</span></div>
            </div>
        </div>
</ItemTemplate>
</asp:repeater>
            <div style="margin-left: 0px;">
                <img src="images/add.png" title="创建分类" style="cursor: pointer; margin-top: 5px;" /><span class="divButton2" onclick="EditVideoCategory('0','OpenCreate')">创建一级</span>
            </div>
        </ul>
    </div>
</form>
