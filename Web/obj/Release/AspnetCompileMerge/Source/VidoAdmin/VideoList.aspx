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
                                            <input type="checkbox" id="checkbox" title="ȫѡ" onclick="SetCheckBoxState('checkbox', 'checkbox')" />
                                        </td>
                                        <td align="left" valign="middle">
                                            <div class="divButton" title="ʹӰ�Ӳ���ǰ����ʾ����" onclick="SetVideoDetailVisible(0)">��ӳ</div>
                                            <div class="divButton" title="�ָ�Ӱ����ǰ�˵���ʾ" onclick="SetVideoDetailVisible(1)">��ӳ</div>
                                            <div class="divButton" title="����ɾ��Ӱ�Ӽ����Ӧ���ļ�" style="background-color: #FFA2A2; color: #F00;" onclick="DeleteVideoDetail()">ɾ��</div>
                                        </td>
                                        <td align="left" valign="middle">
                                            <input type="button" id="button" value="�½�Ӱ��" class="btn yellow" onclick="EditVideoDetail('0', 'OpenCreate')" /></td>
                                        <td width="190" align="left" valign="middle">
                                            <div class="divButton" onclick="SetVideoDetailListOrder('VideoDetailAddDate','ASC')">���ʱ���</div>
                                            <div class="divButton" onclick="SetVideoDetailListOrder('VideoDetailAddDate','DESC')">���ʱ�䨋</div>
                                        </td>
                                        <td align="left" valign="middle">
                                            <table width="535" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="center" valign="middle" width="120">Ӱ���Ƿ���᣺</td>
                                                    <td align="left" valign="middle">
                                                        <input type="text" class="form_input_search" id="txtVideoDetailSequel" value="<%=Session["VideoDetailSequel"] %>" size="8" onkeypress="event.keyCode==13? GetVideoDetailListSearch(txtVideoDetailName,txtVideoDetailContent) : void(0);" /></td>
                                                     <td align="center" valign="middle" width="50">���ţ�</td>
                                                    <td align="left" valign="middle">
                                                        <input type="text" class="form_input_search" id="txtHotSearch" value="<%=Session["HotSearch"] %>" size="8" onkeypress="event.keyCode==13? GetVideoDetailListSearch(txtVideoDetailName,txtVideoDetailContent) : void(0);" /></td>
                                                    <td align="left" valign="middle">
                                                        <input type="button" id="button" value="����" class="btn green" onclick="GetVideoDetailListSearch(txtVideoDetailSequel, txtHotSearch)" />
                                                        <input type="button" id="button" value="�������" class="btn red" onclick="GetVideoDetailListSearch(null,null, 'Clear')" />
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
                                                        <td colspan="3" align="left" valign="top">����ʱ�䣺<%#((DateTime)Eval("VideoDetailAddDate")).ToString("yyyy-MM-dd HH:mm") %>&nbsp;&nbsp;&nbsp;״̬��<%#bllVideoDetail.ExGetVideoDetailVisible((int)Eval("VideoDetailVisible")) %>&nbsp;&nbsp;&nbsp;�Ƿ����:<%#bllVideoDetail.ExGetVideoDetailSequel((int)Eval("VideoDetailSequel")) %>&nbsp;�Ƿ�����:<%#bllVideoDetail.ExGetHotSearch((int)Eval("HotSearch")) %></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            </asp:repeater>
                                            <label id="lblNoData" runat="server" class="NoData">δ�ҵ�������ݣ�</label>
                                        </td>
                                    </tr>
                                </table>
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="4" align="left" valign="middle">
                                <div class="divButton" onclick="GotoPage('FP','Video')">|&lt; ��ҳ</div>
                                <div class="divButton" onclick="GotoPage('PP','Video')">&lt;&lt; ��һҳ</div>
                                <div class="divButton" onclick="GotoPage('NP','Video')">��һҳ &gt;&gt;</div>
                                <div class="divButton" onclick="GotoPage('LP','Video')">βҳ &gt;|</div>
                               <div class="divButton">��ǰ��<%=Pager.PageCurrent%>/<%=Pager.PageCount%> ҳ</div>
                                <div class="divButton">���ݣ�<%=Pager.RecordCount%> ��</div>
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
