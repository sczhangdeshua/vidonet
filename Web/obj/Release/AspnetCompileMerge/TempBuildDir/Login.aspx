<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Maticsoft.Web.Login" %>

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
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="js/ie-emulation-modes-warning.js"></script>
    <script src="js/ie10-viewport-bug-workaround.js"></script>
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/jquery.form.js"></script>
    <script src="js/system.js"></script>
    <script src="js/layer/layer.js"></script>
    <title><%=NetName %>-登录</title>
</head>
<body>
        <div class="container">
            <form class="form-signin">
                <h2 class="form-signin-heading"><a href="HomePage.aspx"><%=NetName %></a></h2>
                <input type="text" id="inputAccount" class="form-control"  placeholder="请输入账户"  /><br />
                <input type="password" id="inputPassword" class="form-control" placeholder="请输入密码" />
                <div class="input-group text-center">
                     <input type="text" id="inputCode" class="form-control" style="width:130px" placeholder="验证码" /><img style="width: 100px; height: 44px; background: #95fc11;cursor:pointer" class="input-group-addon" id="imgCode" src="ashx/ValidateCode.ashx" onclick="ClickValidateCode()"/>
                    </div>
                <div class="checkbox a">
                    <label>
                        <input type="checkbox" id="checkboId" checked="checked" value="remember-me" />
                        记住密码
                    </label>
                    <label class="pull-right">
                        <a href="/ForgetPassWord.aspx" style="color: #00CC00" >忘记密码</a>
                    </label>
                </div>
                <div class="btn btn-lg btn-primary btn-block" onclick="Login()">登录</div>
                <!--<div class="btn-group center-block" style="cursor:pointer">
			<div class="text-center" style="color#999999">其它的登录方式</div>
			<div class="caret center-block" style="color:#999999" ></div>
		</div> -->
            </form>
        </div>
</body>
</html>
