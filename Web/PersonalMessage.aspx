<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalMessage.aspx.cs" Inherits="Maticsoft.Web.PersonalMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <link href="css/signin.css" rel="stylesheet" />
    <script src="js/ie-emulation-modes-warning.js"></script>
    <script src="js/ie10-viewport-bug-workaround.js"></script>
    <script src="js/PersonalMessage.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.form.js"></script>
    <script src="js/layer/layer.js"></script>
    <script src="js/jquery.min.js"></script>
    <title><%=NetName %>-个人信息</title>
</head>
<body>
    <marquee direction="left" style="color: red">本站不会向个人收取任何费用。加QQ群272757417找群主拿取免费账号</marquee>
    <div class="container text-center center-block">
        <h2 class="form-signin-heading">个人信息</h2>
        <form class="form-signin" runat="server">
            <img class="img-circle" src="HeadPortraitImages/<%=HeadPortrait %> " style="height: 100px; width: 150px;" id="HeadPortraitImg" alt="无图"   />
            <div class="input-group">
                <input type="file" class="form-control" runat="server" id="fileName" style="cursor: pointer;" />
                <input type="hidden" runat="server" id="hidImg" />
                <asp:Button ID="Button1" runat="server" Text="上传头像" OnClick="Button1_Click" />
            </div>
            <br />
            <span class="pull-right"><a href="HomePage.aspx">首页</a></span><br />
            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a href="#One" data-toggle="collapse" data-parent="#accordion">昵称</a>
                        </h4>
                    </div>
                    <div id="One" class="panel-collapse collapse" data-toggle="modal" data-target="#myModal">
                        <div style="cursor: pointer" class="panel-body" onclick="Name()">
                            <span id="divName" runat="server"><%=Name %></span>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a href="#Two" data-toggle="collapse" data-parent="#accordion">账户</a>
                        </h4>
                    </div>
                    <div id="Two" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%=Account %>
                            <input type="hidden" runat="server" id="hidAccount" />
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a href="#Three" data-toggle="collapse" data-parent="#accordion">注册时间</a>
                        </h4>
                    </div>
                    <div id="Three" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%=ExpireTime %>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a href="#Forre" data-toggle="collapse" data-parent="#accordion">观看记录</a>
                        </h4>
                    </div>
                    <div id="Forre" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%=WatchRecord %>
                        </div>
                    </div>
                </div>
            </div>
            <span style="color: #4cff00">注：点击昵称即可改名</span>
        </form>
    </div>

    <%-- ------------ --%>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">修改昵称</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12" style="border-right: 1px dotted #C2C2C2; padding-right: 30px;">
                            <div class="tab-content">
                                <div class="tab-pane active" id="Login">
                                    <form role="form" class="form-horizontal">
                                        <div class="form-group">
                                            <label for="email" class="col-sm-2 control-label">
                                                旧昵称
                                            </label>
                                            <div class="col-sm-10">
                                                <input type="text" class="form-control" id="pastNickname" readonly placeholder="旧昵称" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1" class="col-sm-2 control-label">
                                                新昵称
                                            </label>
                                            <div class="col-sm-10">
                                                <input type="text" id="newNickName" class="form-control" maxlength="20" placeholder="请输入新昵称" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-2">
                                            </div>
                                            <div class="col-sm-10">
                                                <button type="button" class="btn btn-primary btn-sm" onclick="amend()">
                                                    修改
                                                </button>
                                                <span style="color: red" id="amendSpan"></span>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
