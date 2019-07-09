<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoIndex.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.VideoIndex" %>

<%@ Register Src="~/VidoAdmin/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/VidoAdmin/Control/Footer.ascx" TagPrefix="uc2" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>非凡影视管理系统</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script language="javascript">
        //向菜单控制程序转入当前页的类型名称，比如：Index代表系统管理类型页，Video代表产品管理类型页
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
    InitVideoCategory();//调用左侧分类

   <%-- EC_6MonthVideoDetailBrowseCountTOP10([<%//=BasePage_VideoDetailName%>], [<%//=BasePage_VideoDetailBrowseCount%>]);
    function EC_6MonthVideoDetailBrowseCountTOP10(VideoDetailName, VideoDetailBrowseCount) {
        //加载图表：最近6个月图文点击量TOP10
        var myChart = echarts.init(document.getElementById('divEC_6MonthVideoDetailBrowseCountTOP10'));
        option = {
            animation: true,
            title: {
                text: '最近6个月图文点击量TOP10',
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
                    name: '数量',
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
                text: '空图表，待完善',
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
                        { value: 111, name: '测试数据' },
                        { value: 155, name: '测试数据' },
                        { value: 188, name: '测试数据' },
                    ]
                }
            ]
        };
        myChart.setOption(option);
    }

</script>