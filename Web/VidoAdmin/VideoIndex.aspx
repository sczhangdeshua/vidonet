<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoIndex.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoIndex" %>

<%@ Register Src="~/VidoAdmin/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/VidoAdmin/Control/Footer.ascx" TagPrefix="uc2" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�Ƿ�Ӱ�ӹ���ϵͳ</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script language="javascript">
        //��˵����Ƴ���ת�뵱ǰҳ���������ƣ����磺Index����ϵͳ��������ҳ��Video�����Ʒ��������ҳ
        var PageTag = "Video";
    </script>
    <script src="Script/jquery-3.1.1.js"></script>
    <script src="Script/jquery.form.js"></script>
    <script src="Script/layer/layer.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="Script/system.js"></script>
    <script src="Script/MYSystem.js.cs/Video.js"></script>
    <script src="Script/echarts.js"></script>
</head>


<body>
    <form runat="server">
        <div id="panelwrap">
            <uc1:Header ID="Header1" runat="server" />
            <div class="center_content">
                <table align="center" cellpadding="0" cellspacing="0" width="100%" height="550">
                    <tr>
                        <td width="21%" align="left" valign="top">
                            <div id="divVideoCategory"></div>
                        </td>
                        <td width="79%" align="left" valign="top">
                            <div id="divVideoList">
                                <div id="divEC_6MonthVideoDetailAddDateCount" style="width: 520px; height: 310px; float: left;"></div>
                                <div id="divEC_pie" style="width: 480px; height: 310px; float: left;"></div>
                                <div id="divEC_6MonthVideoDetailBrowseCountTOP10" style="width: 520px; height: 310px;"></div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
<script language="javascript">
    InitVideoCategory();//����������

   <%-- EC_6MonthVideoDetailBrowseCountTOP10([<%//=BasePage_VideoDetailName%>], [<%//=BasePage_VideoDetailBrowseCount%>]);
    function EC_6MonthVideoDetailBrowseCountTOP10(VideoDetailName, VideoDetailBrowseCount) {
        //����ͼ�����6����ͼ�ĵ����TOP10
        var myChart = echarts.init(document.getElementById('divEC_6MonthVideoDetailBrowseCountTOP10'));
        option = {
            animation: true,
            title: {
                text: '���6����ͼ�ĵ����TOP10',
            },
            tooltip: {
                trigger: 'axis'
            },
            yAxis: [
                {
                    type: 'category',
                    data: VideoDetailName
                }
            ],
            xAxis: [
                {
                    type: 'value'
                }
            ],
            series: [
                {
                    name: '����',
                    type: 'bar',
                    data: VideoDetailBrowseCount
                }
            ]
        };
        myChart.setOption(option);
    }--%>

    EC_pie();
    function EC_pie() {
        var myChart = echarts.init(document.getElementById('divEC_pie'));
        option = {
            title: {
                text: '��ͼ��������',
                x: 'center'
            },
            tooltip: {
                trigger: 'item'
            },
            series: [
                {
                    type: 'pie',
                    radius: '70%',
                    center: ['46%', '50%'],
                    data: [
                        { value: 111, name: '��������' },
                        { value: 155, name: '��������' },
                        { value: 188, name: '��������' },
                    ]
                }
            ]
        };
        myChart.setOption(option);
    }

</script>