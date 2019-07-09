<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoRegisterPay.aspx.cs" Inherits="Maticsoft.Web.NoRegisterPay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="utf-8" />
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/NoRegisterPay.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <title><%=NetName %>-打赏</title>
</head>
<body>
    <form id="form1" runat="server" class="text-center">
        <div class="container-fluid a">
            <marquee direction="left" style="color: red">注：打赏本站站长(自愿打赏没有强制行)。</marquee>
            <div class="row">
                    <div class="col-xs-6 col-sm-4">
                        <label><input type="radio" name="pay" checked="checked"><img class="img-thumbnail" src="images/WeChat.jpg" width="126" height="100" /></label><br />
                        <span>微信支付</span>
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <label><input type="radio" name="pay"><img class="img-thumbnail" src="images/QQ.jpg" width="126" height="100" /></label><br />
                        <span>QQ支付</span>
                    </div>
                    <div class="col-xs-6 col-sm-4">
                        <label><input type="radio" name="pay"><img class="img-thumbnail" src="images/ZFB.jpg" width="126" height="100" /></label><br />
                        <span>支付宝支付</span>
                    </div>
            </div>
        </div>
        <br /><br />
        
        <br /><br />
        <button type="button" class="btn btn-lg btn-warning" onclick="Pay()" style="width:230px;">点击显示对应应用二维码</button><br /><br />
        <img id="imgTwoWeiMa" class="img-thumbnail" />
        
    </form>
</body>
</html>
