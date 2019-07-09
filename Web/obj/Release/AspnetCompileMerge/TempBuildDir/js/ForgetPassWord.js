
//邮箱验证码
function sendCode() {
    var InputBtn = document.getElementById('InputSend');
    if (document.getElementById('inputEmail').value == '') {
        layer.msg("请输邮箱号码");
        return;
    }
    InputBtn.setAttribute("disabled", "true");
    Countdown();
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/ForgetPassWord.ashx?action=sendCode',
        data: {
            UserMail: document.getElementById('inputEmail').value,
        },
        success: function (result) {
            if (result == 'ok')
            {
                document.getElementById('sapnInputCode').innerHTML = '';
            } else
            {
                document.getElementById('sapnInputCode').innerHTML = '*请输入正确的验证码';
            }
            layer.close(loadIndex);
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            window.location = '/Error.aspx?webPage=忘记密码邮箱';
        }
    });
}
var t,c=60;
function Countdown() {
    var InputBtn = document.getElementById('InputSend');
    document.getElementById('InputSend').value = c;
    c--;
    t = setTimeout('Countdown()', 1000);
    
    if(c<1)
    {
        document.getElementById('InputSend').value = "发送验证码";
        clearTimeout(t);
        c = 60;
        InputBtn.removeAttribute("disabled");
    }
    
}
function Account() {
    if(document.getElementById('inputAccount').value!='')
    {
        document.getElementById('sapanInputAccount').innerHTML = '';
    }
}
function Code() {
    if (document.getElementById('inputCode').value != '') {
        document.getElementById('sapnInputCode').innerHTML = '';
    }
}
function ResetPassword() {
    if (document.getElementById('resetPassWord').value != '') {
        document.getElementById('spanInputPassWord').innerHTML = '';
    }
}

function OKVerify() {
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/ForgetPassWord.ashx?action=OKVerify',
        data: {
            UserAccount: document.getElementById('inputAccount').value,
            UserMail: document.getElementById('inputEmail').value,
            Code: document.getElementById('inputCode').value,
            ResetUserPassWord: document.getElementById('resetPassWord').value
        },
        success: function (result) {
            layer.close(loadIndex);
            var ServerData = result.split(':');
            if (ServerData[0] == 'onAccount')
            {
                document.getElementById('sapanInputAccount').innerHTML = ServerData[1];
                return;
            }
            if (ServerData[0] == 'onMail') {
                document.getElementById('spanInputEmail').innerHTML = ServerData[1];
                return;
            }
            if (ServerData[0] == 'onCode') {
                document.getElementById('sapnInputCode').innerHTML = ServerData[1];
                return;
            }
            if (ServerData[0] == 'onWord') {
                document.getElementById('spanInputPassWord').innerHTML = ServerData[1];
                return;
            }
            if(ServerData[0]=='okUrl')
            {
                window.location = ServerData[1];
            }
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！");
        }
    });
}

//邮箱判断
function Email() {
    var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var UserMail = document.getElementById('inputEmail').value;
    if (UserMail == "") {
        document.getElementById('spanInputEmail').innerHTML = '*邮箱不能为空哦';
        document.getElementById('spanInputEmail').style.color = "red";
        return;
    }
    if (reg.test(UserMail)) {
        document.getElementById('spanInputEmail').innerHTML = '';
    }else
    {
        document.getElementById('spanInputEmail').innerHTML = '*请输入有效的邮箱';
    }
}