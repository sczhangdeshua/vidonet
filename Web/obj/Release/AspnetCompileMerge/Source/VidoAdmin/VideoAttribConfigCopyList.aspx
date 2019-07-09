<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoAttribConfigCopyList.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoAttribConfigCopyList" %>

<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/system.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/MYSystem.js.cs/Video.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />

<form id="form1" runat="server">
    <table id="rounded-corner" style="width: 98%;">
        <thead>
            <tr>
                <th width="10%" align="center" valign="middle">
                    <input type="checkbox" id="checkbox" title="全选" onclick="SetCheckBoxState('checkbox', 'checkbox')" /></th>
                <th width="40%" align="left" valign="middle">属性名称</th>
                <th width="50%" align="left" valign="middle">属性说明</th>
            </tr>
        </thead>
        <tbody>
            <asp:repeater id="rptList" runat="server">
            <ItemTemplate>
            <tr class="even">
                <td align="center" valign="middle">
                    <input type="checkbox" name="checkbox" value="<%#Eval("GUID") %>"/>
                </td>
                <td align="left" valign="middle" title="<%#Eval("VideoAttribConfigName") %>"><%#common.GetSubString(Eval("VideoAttribConfigName").ToString(),13,"...") %></td>
                <td align="left" valign="middle" title="<%#Eval("VideoAttribConfigDescribe") %>"><%#common.GetSubString(Eval("VideoAttribConfigDescribe").ToString(),13,"...") %></td>
            </tr>
        </ItemTemplate>
        </asp:repeater>
        </tbody>
    </table>
    <br/>
    <div class="form_row">
        <input type="button" class="btn green" value="确定" style="margin-left: 37%;" onclick="CopyVideoAttribConfig()" />
        <input type="button" class="btn red" value="取消" onclick="CloseLayerWindow()" />
    </div>

</form>

