<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoAttribConfigList.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoAttribConfigList" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/MYSystem.js.cs/Video.js"></script>
<script src="Script/system.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<link rel="stylesheet" type="text/css" href="style.css" />
<link href="Script/layui/css/layui.css" rel="stylesheet" />

<form id="form1" runat="server">
    <table id="rounded-corner" style="width: 100%;">
        <thead>
            <tr>
                <th width="11%" align="center" valign="middle">排序</th>
                <th width="34%" align="left" valign="middle">属性名称</th>
                <th width="36%" align="left" valign="middle">属性说明</th>
                <th width="15%" align="center" valign="middle">操作</th>
            </tr>
        </thead>
        <tbody>
            <asp:repeater id="rptList" runat="server">
            <ItemTemplate>
            <tr class="even">
                <td align="center" valign="middle">
                    <img src="images/up.png" title="上移" class="categoryMenuImage" onclick="SetVideoAttribConfigOrder('<%#Eval("GUID") %>','UP')"/>
                    <img src="images/down.png" title="下移" class="categoryMenuImage" onclick="SetVideoAttribConfigOrder('<%#Eval("GUID") %>','DOWN')"/>
                </td>
                <td align="left" valign="middle" title="<%#Eval("VideoAttribConfigName") %>" onclick="EditVideoAttribConfig('<%#Eval("VideoCategoryGUID") %>', 'OpenEdit','<%#Eval("GUID") %>')" style="cursor:pointer;"><%#common.GetSubString(Eval("VideoAttribConfigName").ToString(),13,"...") %></td>
                <td align="left" valign="middle" title="<%#Eval("VideoAttribConfigDescribe") %>"><%#common.GetSubString(Eval("VideoAttribConfigDescribe").ToString(),13,"...") %></td>
                <td align="center" valign="middle">
                    <i class="layui-icon" alt="修改" title="修改" style="cursor: pointer;" onclick="EditVideoAttribConfig('<%#Eval("VideoCategoryGUID") %>', 'OpenEdit','<%#Eval("GUID") %>')">&#xe642;</i>&nbsp;&nbsp;
                    <i class="layui-icon" alt="删除" title="删除" style="cursor: pointer;" onclick="DeleteVideoAttribConfig('<%#Eval("VideoCategoryGUID") %>','<%#Eval("GUID") %>')">&#xe640;</i>
                    <input type="hidden" id="hidGetVideoAttribCountInVideoDetail" value="0">
                </td>
            </tr>
        </ItemTemplate>
        </asp:repeater>
        </tbody>
    </table>
</form>

