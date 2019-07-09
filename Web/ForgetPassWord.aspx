<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassWord.aspx.cs" Inherits="Maticsoft.Web.ForgetPassWord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/ie10-viewport-bug-workaround.css" rel="stylesheet" />
    <link href="css/signin.css" rel="stylesheet" />
    <script src="js/ie-emulation-modes-warning.js"></script>
    <script src="js/ie10-viewport-bug-workaround.js"></script>
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/jquery.form.js"></script>
    <script src="js/ForgetPassWord.js"></script>
    <script src="js/layer/layer.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <title><%=NetName %>-忘记密码</title>
</head>
<body>
    <div class="container">
        <form class="form-signin">
            <h2><a href="HomePage.aspx"><%=NetName %></a></h2>
            <span class="pull-right"><a href="Login.aspx">已有账户</a></span>
            <input type="text" class="form-control" maxlength="20" id="inputAccount" placeholder="请输入账户" onblur="Account()" />
            <span style="color:red" id="sapanInputAccount"></span>
            <br />
            <input type="email" class="form-control" maxlength="40" id="inputEmail" placeholder="输入你的邮箱" onblur="Email()"/>
            <span style="color:red" id="spanInputEmail"></span>
            <br />
            <div class="input-group">
                <input type="text" class="form-control" maxlength="10" id="inputCode"  style="width:200px" placeholder="填写验证码" onblur="Code()" />
                <input class="input-group-addon btn btn-lg btn-default" style="width: 100px; height: 44px;"  type="button"  value="发送验证码" id="InputSend" onclick="sendCode()"/>
            </div>
             <span style="color:red" id="sapnInputCode"></span>
            <br />
            <input type="password" maxlength="16" class="form-control" id="resetPassWord" placeholder="重置新密码" onblur="ResetPassword()"/>
            <span style="color:red" id="spanInputPassWord"></span>
            <br />
            <input type="button" class="btn btn-lg btn-primary pull-right" style="height:45px;width:100px"  value="完成" onclick="OKVerify()"/>

        </form>
    </div>

</body>
</html>
