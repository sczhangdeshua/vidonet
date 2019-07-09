<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.UsersList" %>

<head>
    <link rel="stylesheet" type="text/css" href="style.css" />

    <script src="Script/system.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 15%;
        }
    </style>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
</head>

<form id="form1" runat="server" class="layui-form">

    <table width="1060" id="rounded-cornerOther">
        <thead>
            <tr>
                <th align="left" valign="middle">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin-bottom: 8px;">
                        <tr>
                            <td height="40" style="padding: 0px 8px 0px 8px;">用户名：</td>
                            <td>
                                <input id="txtUsersDetailName" type="text" class="form_input_search" value="<%=Session["UserName"]%>"  style="width: 200px;" placeholder="不限" onkeypress="event.keyCode==13? GetUsersListSearch(txtUsersDetailName, txtUserAccount, txtUserMail, ddlUsersDatailState) : void(0);" /></td>
                             <td height="40" style="padding: 0px 8px 0px 8px;">账户：</td>
                            <td>
                                <input id="txtUserAccount" type="text" value="<%=Session["UserAccount"]%>" class="form_input_search"  style="width: 200px;" placeholder="不限" onkeypress="event.keyCode==13? GetUsersListSearch(txtUsersDetailName, txtUserAccount, txtUserMail, ddlUsersDatailState) : void(0);" /></td>
                            <td height="40" style="padding: 0px 8px 0px 8px;">邮箱：</td>
                            <td>
                                <input id="txtUserMail" type="text" value="<%=Session["UserMail"]%>" class="form_input_search"  style="width: 200px;" placeholder="不限" onkeypress="event.keyCode==13?GetUsersListSearch(txtUsersDetailName, txtUserAccount, txtUserMail, ddlUsersDatailState) : void(0);" /></td>
                        </tr>
                        <tr>
                            <td height="55" style="padding: 0px 8px 0px 8px;">状态：</td>
                            <td>
                                <select id="ddlUsersDatailState" runat="server" class="form_select" style="width: 210px;">
                                    <option value="2" selected="selected">不限</option>
                                    <option value="1">正常</option>
                                    <option value="0">锁定</option>
                                </select>
                            </td>
                            <td colspan="2">
                                <input id="button2" class="btn green" type="button" value="搜索" onclick="GetUsersListSearch(txtUsersDetailName, txtUserAccount, txtUserMail, document.getElementById('ddlUsersDatailState').options[document.getElementById('ddlUsersDatailState').selectedIndex].value)" />
                                <input id="button3" class="btn red" type="button" value="清空条件" onclick="GetUsersListSearch(null, null, null, '2', 'Clear')" />
                            </td>
                        </tr>
                    </table>
                    <div style="width: 1045px; background-color: #fff; margin: 0 auto;">
                        <table id="rounded-corner" style="width: 99%; font-weight: normal;">
                            <thead>
                                <tr>
                                    <th align="left" width="2%" colspan="9" style="background-color: #FFFFFF;">
                                        <input id="button2" class="btn yellow" type="button" value="新建用户" onclick="EditUsersDetail('OpenCreate')" />
                                        <input id="button2" class="btn green" type="button" value="设置用户状态" onclick="EditUsersStateAttr(0, 'OpenCreate')" />
                                    </th>
                                </tr>
                                <tr>
                                    <th align="left" width="2%">
                                        <input type="checkbox" id="checkbox" title="全选" onclick="SetCheckBoxState('checkbox', 'checkbox')" /></th>
                                    <th align="left" width="10%">用户名</th>
                                    <th align="left" width="10%">账户</th>
                                    <th align="left" width="15%">最近登录时间</th>
                                    <th align="left" width="15%">注册时间</th>
                                    <th align="left" class="auto-style1">状态</th>
                                    <th align="center" width="15%">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:repeater  runat="server" id="rptList">
                                    <ItemTemplate>
                                <tr>
                                    <td>
                                        <input type="checkbox" name="checkbox" value="<%#Eval("GUID") %>" /></td>
                                    <td>
                                        <div class="divButton4" ><%#Eval("UserName") %></div>
                                    </td>
                                    <td><%#Eval("UserAccount") %></td>
                                    <td class="auto-style1"><%#Eval("LoginTime") %></td>
                                    <td class="auto-style1"><%#Eval("RegisterTime") %></td>
                                    <td><%#bllUsers.GetState(((int)Eval("UsersState"))) %></td>
                                    <td align="center">
                                        <i class="layui-icon" alt="修改资料" title="修改资料" style="cursor: pointer;" onclick="EditUsersUserNameMail('<%#Eval("GUID") %>','OpenEdit')">&#xe642;</i>
                                        <i class="layui-icon" alt="设置密码" title="设置密码" style="cursor: pointer;" onclick="EditUsersPassword('<%#Eval("GUID") %>', 'OpenEdit')">&#xe60f;</i>
                                        <i class="layui-icon" alt="状态" title="状态" style="cursor: pointer;" onclick="EditUsersState('<%#Eval("GUID") %>', 'OpenEdit')">&#xe614;</i>
                                         <i class="layui-icon" alt="状态" title="状态" style="cursor: pointer;" onclick="DeleteUsers('<%#Eval("GUID") %>')">&#x1006;</i>
                                    </td>
                                </tr>
                                         </ItemTemplate>
                                </asp:repeater>
                            </tbody>
                        </table>
                    </div>
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td align="left" valign="middle">
                                <div class="divButton" onclick="GotoPage('FP','Users')">|&lt; 首页</div>
                                <div class="divButton" onclick="GotoPage('PP','Users')">&lt;&lt; 上一页</div>
                                <div class="divButton" onclick="GotoPage('NP','Users')">下一页 &gt;&gt;</div>
                                <div class="divButton" onclick="GotoPage('LP','Users')">尾页 &gt;|</div>
                               <div class="divButton">当前：<%=Pager.PageCurrent%>/<%=Pager.PageCount%> 页</div>
                             <div class="divButton">数据：<%=Pager.RecordCount%> 条</div>
                </td>
            </tr>
        </tfoot>
    </table>


</form>



