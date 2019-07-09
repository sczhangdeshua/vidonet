<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoAttribConfig.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoAttribConfig" %>
<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/MYSystem.js.cs/Video.js"></script>
<script src="Script/system.js"></script>
<link rel="stylesheet" type="text/css" href="style.css" />

<div id="right_content" style="width: 97%;">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4" align="left" valign="top">
                <h2>复制属性</h2>
                <table id="rounded-corner" style="width: 100%;">
                    <tr class="even">
                        <td align="left" valign="middle">
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td width="20%" height="30" align="left" valign="middle">属性来自于：</td>
                                    <td width="60%" align="left" valign="middle">
                                        <select name="select" id="select" class="form_select" style="width: 400px;">
                                            <option value="0" selected="selected">请选择产品分类</option>
                                            <asp:repeater runat="server" id="rptList">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("VideoCategoryGUID") %>"><%#Eval("VideoCategorName") %></option>
                                                </ItemTemplate>
                                            </asp:repeater>
                                        </select></td>
                                    <td width="20%" align="left" valign="middle">
                                        <input type="submit" name="button" id="button" value="复制" class="btn green" onclick="OpenVideoAttribConfigCopyList(document.getElementById('select').value)" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <div class="form_row">
        <input type="button" class="btn yellow" value="新建属性" onclick="EditVideoAttribConfig(QueryString('VideoCategoryGUID'), 'OpenCreate')" />
        <input type="button" class="btn red" value="关闭" onclick="CloseLayerWindow()" />
    </div>
    <div id="divVideoAttribConfigList"></div>
</div>
<input type="button" style="margin-left: 43%;" class="btn red" value="关闭" onclick="CloseLayerWindow()" />
<script language="javascript">
    InitVideoAttribConfigList(QueryString("VideoCategoryGUID"));
</script>

