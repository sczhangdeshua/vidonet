<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerList.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.ManagerList" %>


<link rel="stylesheet" type="text/css" href="style.css" />
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />

<form id="form1" runat="server">
    <table width="1060" id="rounded-cornerOther">
        <thead>
            <tr>
                <th align="left" valign="middle">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin-bottom: 8px;">
                        <tr>
                            <td height="55" style="padding: 0px 8px 0px 8px;">
                                <input id="button1" class="btn green" type="button" value="新建管理员" onclick="EditManager('0', 'OpenCreate')" /></td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <div style="width: 1045px; background-color: #fff; margin: 0 auto;">
                        <table id="rounded-corner" style="width: 100%; font-weight: normal;">
                            <thead>
                                <tr>
                                    <th align="left">用户名</th>
                                    <th align="left">用户账户</th>
                                    <th align="left">最近登录时间</th>
                                    <th align="center">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:repeater runat="server" id="rptList">
                                <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="divButton4" onclick="EditManager('<%#Eval("GUID") %>','OpenEdit')"><%#Eval("AdminUser") %></div>
                                    </td>
                                    <td><%#Eval("AdminAccount") %></td>
                                    <td><%#Convert.ToDateTime(Eval("AdminLoginDate")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                    <td align="center">
                                        <i class="layui-icon" alt="编辑" title="编辑" style="cursor: pointer; font-size: 22px;" onclick="EditManager('<%#Eval("GUID") %>','OpenEdit')">&#xe642;</i>
                                        <i class="layui-icon" alt="删除" title="删除" style="cursor: pointer; font-size: 22px;" onclick="DeleteManager('<%#Eval("GUID") %>')">&#xe640;</i>
                                    </td>
                                </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                <tr style="background-color:#dde8f0;">
                                    <td>
                                        <div class="divButton4" onclick="EditManager('<%#Eval("GUID") %>','OpenEdit')"><%#Eval("AdminUser") %></div>
                                    </td>
                                    <td><%#Eval("AdminAccount") %></td>
                                    <td><%#Convert.ToDateTime(Eval("AdminLoginDate")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                    <td align="center">
                                        <i class="layui-icon" alt="编辑" title="编辑" style="cursor: pointer; font-size: 22px;" onclick="EditManager('<%#Eval("GUID") %>','OpenEdit')">&#xe642;</i>
                                        <i class="layui-icon" alt="删除" title="删除" style="cursor: pointer; font-size: 22px;" onclick="DeleteManager('<%#Eval("GUID") %>')">&#xe640;</i>
                                    </td>
                                </tr>
                                </AlternatingItemTemplate>
                            </asp:repeater>
                                <tr>
                                    <td colspan="4" align="center">
                                        <label id="lblNoData" runat="server" class="NoData">未找到相关数据！</label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td></td>
            </tr>
        </tfoot>
    </table>
</form>
