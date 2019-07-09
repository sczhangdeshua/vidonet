<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userRegister.aspx.cs" Inherits="Maticsoft.Web.userRegister" %>

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
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/jquery.form.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="js/system.js"></script>
    <script src="js/layer/layer.js"></script>
    <title><%=NetName %>-注册</title>
</head>
<body>
    <marquee direction="left" style="color: red">本站不会向个人收取任何费用。加QQ群272757417找群主拿取免费账号</marquee>
    <div class="container text-center ">
        <h2 class="form-signin-heading "><a href="HomePage.aspx"><%=NetName %></a></h2>
        <form class="form-signin" style="padding: 0px">
                <input type="text" id="inputUserName" maxlength="20" class="form-control" style="width: 331px" placeholder="填写你的昵称" onblur="NickName()" runat="server" />
                <span class="pull-left" id="spaninputUserName"></span>
            <br />
            <input type="text"  id="inputAccount" class="form-control" maxlength="20" style="width: 331px" placeholder="填写你账户：*必须数字·字母·数字字母组合" onblur="Account()" runat="server" />
            <span  class="pull-left" id="spaninputAccount" ></span>
            <br />
            <input type="password" class="form-control" maxlength="16" style="width: 331px" placeholder="请填写你的密码" id="inputPassWord" onblur="PassWord()" runat="server"/>
            <span  class="pull-left" id="spaninputPassWord"></span>
            <br />
            <input type="email" class="form-control" style="width: 331px" maxlength="40" placeholder="请填写你的邮箱：*要正确·关乎改密" id="inputUserMail" onblur="Email()" />
            <span  class="pull-left" id="spaninputUserMail"></span>
            <br />
            <div class="input-group">
                <input type="text" class="form-control " style="width: 141px; top: 0px; left: 0px;" placeholder="请输入验证码" id="inputCode" runat="server"/>
                <img style="width: 100px; height: 44px; background: #95fc11;cursor:pointer" class="input-group-addon" id="imgCode" src="ashx/ValidateCode.ashx" onclick="ClickValidateCode()"/>
            </div>
            <label class="pull-right"><a href="Login.aspx" style="color: green; cursor: pointer">立即登陆</a></label><br />
            <input type="button" class="btn  btn-danger" style="width: 200px; margin-left: 50px" onclick="Register()" value="注册"/>
        </form>
    </div>
</body>
</html>
