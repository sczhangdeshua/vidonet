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
            <marquee direction="left" style="color: red">注：打赏本站站长(自愿打赏没有强制行)。加QQ群272757417找群主拿去免费账号</marquee>
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
        <div>
            <span style="font-size:18px">打赏<button type="button" class="btn btn-xs btn-default" style="width:30px;height:22px;" onclick="reduce()">-</button><input id="zfys" type="text" value="1" style="width: 40px;height:30px;" onblur="inputMoney()" /><button type="button" class="btn btn-xs btn-default" style="width:30px;height:22px;" onclick="add()">+</button>元</span><br />
        </div>
        <br /><br />
        <button type="button" class="btn btn-lg btn-warning" onclick="Pay()" style="width:230px;">点击显示对应应用二维码</button><br /><br />
        <span style="color:#9cf21f">注：易宝支付可以在界面指定打赏金额</span><br />
        <img id="imgTwoWeiMa" class="img-thumbnail" />
        
    </form>
</body>
</html>
