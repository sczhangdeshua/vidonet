<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoSearchList.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoSearchList" %>


<link rel="stylesheet" type="text/css" href="style.css" />
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />

<form id="form1" runat="server">

    <table id="rounded-corner">
        <thead>
            <tr>
                <td align="center" valign="middle">
                    <input type="checkbox" id="checkbox" title="全选" onclick="SetCheckBoxState('checkbox', 'checkbox')" />
                </td>
                <td align="left" valign="middle" colspan="7">
                    <div class="divButton" title="使影视不在前端显示出来" onclick="SetVideoDetailVisible(0,'Search')">下映</div>
                    <div class="divButton" title="恢复影视在前端的显示" onclick="SetVideoDetailVisible(1,'Search')">上映</div>
                    <div class="divButton" title="永久删除影视及其对应的文件" style="background-color: #FFA2A2; color: #F00;" onclick="DeleteVideoDetail('','Search')">删除</div>
                </td>
            </tr>
            <tr>
                <th width="3%" align="left" valign="middle">&nbsp;</th>
                <th width="20%" align="center" valign="middle">影视名称</th>
                <th width="30%" align="center" valign="middle">影视详情</th>
                <th width="10%" align="left" valign="middle">是否完结</th>
                <th width="10%" align="left" valign="middle">所属分类</th>
                <th width="7%" align="left" valign="middle">浏览次数</th>
                <th width="7%" align="left" valign="middle">是否上映</th>
                <th width="5%" align="center" valign="middle">编辑</th>
                <th width="5%" align="center" valign="middle">删除</th>
            </tr>
        </thead>
        <tbody>
            <asp:repeater id="rptList" runat="server">
            <ItemTemplate>
            <tr>
                <td align="left" valign="middle">
                    <input type="checkbox" name="checkbox" value="<%#Eval("VideoDetailGUID") %>"/>
                </td>
                <td align="left" valign="middle"><div class="divButton3" onclick="EditVideoDetail('<%#Eval("VideoDetailGUID") %>', 'OpenEdit')"><%# common.GetSubString(Eval("VideoDetailName").ToString(),15,"...") %></div></td>
                <td align="left" valign="middle"><%#common.GetSubString(common.HTMLFilter(Eval("VideoDetailContent").ToString()),22,"...") %></td>
                <td align="left" valign="middle"><%#bllVideoDetail.ExGetVideoDetailSequel((int)Eval("VideoDetailSequel"))  %></td>
                <td align="left" valign="middle"><%#Eval("VideoCategorName")  %></td>
                <td align="left" valign="middle"><%#Eval("VideoDetailBrowseCount") %></td>
                <td align="left" valign="middle"><%#bllVideoDetail.ExGetVideoDetailVisible((int)Eval("VideoDetailVisible")) %></td>
                <td align="center" valign="middle">
                    <i class="layui-icon" alt="编辑" title="编辑" style="cursor: pointer; font-size: 22px;" onclick="EditVideoDetail('<%#Eval("VideoDetailGUID") %>', 'OpenEdit')">&#xe642;</i>
                </td>
                <td align="center" valign="middle">
                    <i class="layui-icon" alt="删除" title="删除" style="cursor: pointer; font-size: 22px;" onclick="DeleteVideoDetail('<%#Eval("VideoDetailGUID") %>','Search')">&#xe640;</i>
                </td>
            </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
            <tr style="background-color:#dde8f0;">
                <td align="left" valign="middle">
                    <input type="checkbox" name="checkbox" value="<%#Eval("VideoDetailGUID") %>"/>
                </td>
                <td align="left" valign="middle"><div class="divButton3" onclick="EditVideoDetail('<%#Eval("VideoDetailGUID") %>', 'OpenEdit')"><%# common.GetSubString(Eval("VideoDetailName").ToString(),15,"...") %></div></td>
                <td align="left" valign="middle"><%#common.GetSubString(common.HTMLFilter(Eval("VideoDetailContent").ToString()),35,"...") %></td>
                <td align="left" valign="middle"><%#bllVideoDetail.ExGetVideoDetailSequel((int)Eval("VideoDetailSequel"))  %></td>
                <td align="left" valign="middle"><%#Eval("VideoCategorName")  %></td>
                <td align="left" valign="middle"><%#Eval("VideoDetailBrowseCount") %></td>
                <td align="left" valign="middle"><%#bllVideoDetail.ExGetVideoDetailVisible((int)Eval("VideoDetailVisible")) %></td>
                <td align="center" valign="middle">
                    <i class="layui-icon" alt="编辑" title="编辑" style="cursor: pointer; font-size: 22px;" onclick="EditVideoDetail('<%#Eval("VideoDetailGUID") %>', 'OpenEdit')">&#xe642;</i>
                </td>
                <td align="center" valign="middle">
                    <i class="layui-icon" alt="删除" title="删除" style="cursor: pointer; font-size: 22px;" onclick="DeleteVideoDetail('<%#Eval("VideoDetailGUID") %>','Search')">&#xe640;</i>
                </td>
            </tr>
            </AlternatingItemTemplate>
            </asp:repeater>
            <tr>
                <td colspan="9" align="center">
                    <label id="lblNoData" runat="server" class="NoData">未找到相关数据！</label>
                </td>
            </tr>
        </tbody>
    </table>
</form>

