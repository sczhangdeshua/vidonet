<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TvDatil.aspx.cs" Inherits="Maticsoft.Web.TvDatil" %>

<body>
   <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptVideoList_ItemDataBound">
        <ItemTemplate>
                <div class="col-md-2  trailers-now-showing-grid text-center" style="cursor: pointer;">
                    <a  class="Access" onclick="ifAccess('<%#Eval("GUID") %>')">
                        <img class="ImgH"  src="<%#Eval("VideoDetailImgeURL") %>" alt="2" style="height:215px"   /></a>
                    <a  class="t-n-s-more" onclick="ifAccess('<%#Eval("GUID") %>')" style="height:25px;"><%#Eval("VideoDetailName") %></a>
                    <a  class="t-n-s-m" onclick="ifAccess('<%#Eval("GUID") %>')"><asp:Label ID="lblType" runat="server"></asp:Label></a>
                </div>
           <%--  <%#((int)Eval("FID")%6)==0?"<div class='clearfix'></div>":"" %>--%>
            
        </ItemTemplate>
    </asp:Repeater>
         <div class="clearfix"></div>
   
    <label id="lblNoData" runat="server" class="NoData" style="margin-left: 40%;">未找到相关数据！</label>
    <div id="divPager" runat="server" class="text-center">
    <div class="divButton" onclick="GotoPage('FP','Tv','<%=GUID %>')">|&lt; 首页</div>
    <div class="divButton" onclick="GotoPage('PP','Tv','<%=GUID %>')">&lt;&lt; 上页</div>
    <div class="divButton" onclick="GotoPage('NP','Tv','<%=GUID %>')">下页 &gt;&gt;</div>
    <div class="divButton" onclick="GotoPage('LP','Tv','<%=GUID %>')">尾页 &gt;|</div>
    <div class="divButton">当前：<%=Pager.PageCurrent%>/<%=Pager.PageCount%> 页</div>
    <hr noshade="noshade" />
</div>
    <div class="clearfix"></div>
</body>
