<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoList.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoList" %>


<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<script src="Script/jquery-3.1.1.js"></script>
<script src="Script/jquery.form.js"></script>
<script src="Script/layer/layer.js"></script>
<script src="Script/MYSystem.js.cs/Video.js"></script>
<link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
<script src="Script/system.js"></script>
<form runat="server">
    <table width="1060" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
        <tr>
            <td colspan="4" align="left" valign="top">
                <table width="1060" id="rounded-cornerOther">
                    <thead>
                        <tr>
                            <th align="left" valign="middle">
                                <table width="1045" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin-bottom: 8px;">
                                    <tr>
                                        <td height="40" align="left" valign="middle" style="padding: 0px 8px 0px 8px;">
                                            <input type="checkbox" id="checkbox" title="全选" onclick="SetCheckBoxState('checkbox', 'checkbox')" />
                                        </td>
                                        <td align="left" valign="middle">
                                            <div class="divButton" title="使影视不在前端显示出来" onclick="SetVideoDetailVisible(0)">下映</div>
                                            <div class="divButton" title="恢复影视在前端的显示" onclick="SetVideoDetailVisible(1)">上映</div>
                                            <div class="divButton" title="永久删除影视及其对应的文件" style="background-color: #FFA2A2; color: #F00;" onclick="DeleteVideoDetail()">删除</div>
                                        </td>
                                        <td align="left" valign="middle">
                                            <input type="button" id="button" value="新建影视" class="btn yellow" onclick="EditVideoDetail('0', 'OpenCreate')" /></td>
                                        <td width="190" align="left" valign="middle">
                                            <div class="divButton" onclick="SetVideoDetailListOrder('VideoDetailAddDate','ASC')">添加时间▲</div>
                                            <div class="divButton" onclick="SetVideoDetailListOrder('VideoDetailAddDate','DESC')">添加时间▼</div>
                                        </td>
                                        <td align="left" valign="middle">
                                            <table width="535" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="center" valign="middle" width="120">影视是否完结：</td>
                                                    <td align="left" valign="middle">
                                                        <input type="text" class="form_input_search" id="txtVideoDetailSequel" value="<%=Session["VideoDetailSequel"] %>" size="8" onkeypress="event.keyCode==13? GetVideoDetailListSearch(txtVideoDetailName,txtVideoDetailContent) : void(0);" /></td>
                                                     <td align="center" valign="middle" width="50">热门：</td>
                                                    <td align="left" valign="middle">
                                                        <input type="text" class="form_input_search" id="txtHotSearch" value="<%=Session["HotSearch"] %>" size="8" onkeypress="event.keyCode==13? GetVideoDetailListSearch(txtVideoDetailName,txtVideoDetailContent) : void(0);" /></td>
                                                    <td align="left" valign="middle">
                                                        <input type="button" id="button" value="搜索" class="btn green" onclick="GetVideoDetailListSearch(txtVideoDetailSequel, txtHotSearch)" />
                                                        <input type="button" id="button" value="清空条件" class="btn red" onclick="GetVideoDetailListSearch(null,null, 'Clear')" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tbVideoCategoryDescribe" runat="server" width="1045" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF" style="margin-bottom: 8px;">
                                    <tr>
                                        <td id="tdVideoCategoryDescribe" runat="server" height="40" align="left" valign="middle" style="padding: 0px 8px 0px 8px; font-weight: normal; color#666;"></td>
                                    </tr>
                                </table>
                                <table width="1045" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                                    <tr>
                                        <td height="500" align="left" valign="top" style="padding: 8px;">
                                            <asp:repeater id="rptList" runat="server">
                                            <ItemTemplate>
                                                <table width="500" border="0" cellpadding="0" cellspacing="0" style="margin: 0px 12px 20px 0px; float: left; font-size: 12px; font-weight: normal; border: 1px solid #DDDDDD;">
                                                    <tr>
                                                        <td width="20" rowspan="3" align="left" valign="middle" bgcolor="#FFFFCC">
                                                            <input type="checkbox" name="checkbox" value="<%#Eval("GUID") %>"/>
                                                        </td>
                                                        <td width="110" rowspan="3" align="left" valign="top" bgcolor="#FFFFCC" style="padding: 5px 0px 5px 0px;">
                                                            <img src="<%#common.GetImageURL(Eval("VideoDetailImgeURL").ToString())%>" width="100" height="100" border="0" class="imageBorder01" onclick="EditVideoDetail('<%#Eval("GUID") %>', 'OpenEdit')" /></td>
                                                        <td width="5" rowspan="3" align="left" valign="top" style="padding: 5px 0px 5px 0px;">&nbsp;</td>
                                                        <td height="29" colspan="3" align="left" valign="middle"><div class="divButton3" onclick="EditVideoDetail('<%#Eval("GUID") %>', 'OpenEdit')"><%# common.GetSubString(Eval("VideoDetailName").ToString(),26,"...") %></div></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="50" colspan="3" align="left" valign="top"><%#common.GetSubString(common.HTMLFilter(Eval("VideoDetailContent").ToString()),58,"...") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="left" valign="top">发布时间：<%#((DateTime)Eval("VideoDetailAddDate")).ToString("yyyy-MM-dd HH:mm") %>&nbsp;&nbsp;&nbsp;状态：<%#bllVideoDetail.ExGetVideoDetailVisible((int)Eval("VideoDetailVisible")) %>&nbsp;&nbsp;&nbsp;是否完结:<%#bllVideoDetail.ExGetVideoDetailSequel((int)Eval("VideoDetailSequel")) %>&nbsp;是否热门:<%#bllVideoDetail.ExGetHotSearch((int)Eval("HotSearch")) %></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            </asp:repeater>
                                            <label id="lblNoData" runat="server" class="NoData">未找到相关数据！</label>
                                        </td>
                                    </tr>
                                </table>
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="4" align="left" valign="middle">
                                <div class="divButton" onclick="GotoPage('FP','Video')">|&lt; 首页</div>
                                <div class="divButton" onclick="GotoPage('PP','Video')">&lt;&lt; 上一页</div>
                                <div class="divButton" onclick="GotoPage('NP','Video')">下一页 &gt;&gt;</div>
                                <div class="divButton" onclick="GotoPage('LP','Video')">尾页 &gt;|</div>
                               <div class="divButton">当前：<%=Pager.PageCurrent%>/<%=Pager.PageCount%> 页</div>
                                <div class="divButton">数据：<%=Pager.RecordCount%> 条</div>
                            </td>
                        </tr>
                    </tfoot>
                    <tbody>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</form>
