//用户登录
function Login() {
    if (document.getElementById('inputAccount').value == '') {
        layer.msg("请输入用户名");
        return;
    }
    if (document.getElementById('inputPassword').value == '') {
        layer.msg("请输密码");
        return;
    }
    if (document.getElementById('inputCode').value == '') {
        layer.msg("请输密码");
        return;
    }
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/Login.ashx',
        data: {
            Code: document.getElementById('inputCode').value,
            UserAccount: document.getElementById('inputAccount').value,
            UserPassWord: document.getElementById('inputPassword').value,
            checkboxid: document.getElementById('checkboId').checked ? 1 : 0
        },
        success: function (result) {
            layer.close(loadIndex);
            var serverData = result.split(':');
            if (serverData[0] != 'no') {
                window.location = result;
            } else {
                alert(serverData[1]);
            }
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("联系管理员QQ378801567");
        }
    });
    ClickValidateCode();
}//ok

//昵称判断
function NickName() {
    var UserName = document.getElementById('inputUserName').value;
    if (UserName == "") {
        document.getElementById('spaninputUserName').innerHTML = '*昵称不能为空哦';
        document.getElementById('spaninputUserName').style.color = "red";
        return;
    }
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/userRegister.ashx?action=spanUserName',
        data: {
            UserName: UserName
        },
        success: function (result) {
            var serverResult = result.split(':');
            if (serverResult[0] == 'ok') {
                document.getElementById('spaninputUserName').innerHTML = serverResult[1];
                document.getElementById('spaninputUserName').style.color = "#a19999";
            } else {
                document.getElementById('spaninputUserName').innerHTML = serverResult[1];
                document.getElementById('spaninputUserName').style.color = "red";
            }
            return;
        },
        error: function (result) {
            layer.msg("服务器错误，请重试！");
            window.location = "/Error.aspx?webPage=昵称";
        }
    });
}//ok

//账户判断
function Account() {
    var UserAccount = document.getElementById('inputAccount').value;
    if (UserAccount == "") {
        document.getElementById('spaninputAccount').innerHTML = '*账户不能为空哦';
        document.getElementById('spaninputAccount').style.color = "red";
        return;
    }
    if (UserAccount.length < 6) {
        document.getElementById('spaninputAccount').innerHTML = '*账户不能少于6位哦';
        document.getElementById('spaninputAccount').style.color = "red";
        return;
    }
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/userRegister.ashx?action=spanAccount',
        data: {
            UserAccount: UserAccount
        },
        success: function (result) {
            var serverResult = result.split(':');
            if (serverResult[0] == 'ok') {
                document.getElementById('spaninputAccount').innerHTML = serverResult[1];
                document.getElementById('spaninputAccount').style.color = "#a19999";
            } else {
                document.getElementById('spaninputAccount').innerHTML = serverResult[1];
                document.getElementById('spaninputAccount').style.color = "red";
            }
            return;
        },
        error: function (result) {
            layer.msg("服务器错误，请重试！");
            window.location = "/Error.aspx?webPage=昵称";
        }
    });
} //ok

//密码
function PassWord() {
    var UserPassWord = document.getElementById('inputPassWord').value;
    if (UserPassWord == "") {
        document.getElementById('spaninputPassWord').innerHTML = '*密码不能为空哦';
        document.getElementById('spaninputPassWord').style.color = "red";
        return;
    }
    if (UserPassWord.length < 6) {
        document.getElementById('spaninputPassWord').innerHTML = '*密码不能少于6位哦';
        document.getElementById('spaninputPassWord').style.color = "red";
        return;
    }

}//ok

//邮箱判断
function Email() {
    var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;     
    var UserMail = document.getElementById('inputUserMail').value;
    if (UserMail == "") {
        document.getElementById('spaninputUserMail').innerHTML = '*邮箱不能为空哦';
        document.getElementById('spaninputUserMail').style.color = "red";
        return;
    }
    if (reg.test(UserMail)) {
        $.ajax({
            async: true,
            cache: false,
            type: 'post',
            url: '/ashx/userRegister.ashx?action=spanMail',
            data: {
                UserMail: UserMail
            },
            success: function (result) {
                var serverResult = result.split(':');
                if (serverResult[0] == 'ok') {
                    document.getElementById('spaninputUserMail').innerHTML = serverResult[1];
                    document.getElementById('spaninputUserMail').style.color = "#a19999";
                } else {
                    document.getElementById('spaninputUserMail').innerHTML = serverResult[1];
                    document.getElementById('spaninputUserMail').style.color = "red";
                }
                return;
            },
            error: function (result) {
                layer.msg("服务器错误，请重试！");
                window.location = "/Error.aspx?webPage=昵称";
            }
        });
    } else {
        document.getElementById('spaninputUserMail').innerHTML = '*请输入有效的邮箱';
        document.getElementById('spaninputUserMail').style.color = "red";
    }

}//ok

//点击刷新验证码
function ClickValidateCode() {
    document.getElementById('imgCode').src = "ashx/ValidateCode.ashx?d=" + new Date().getMilliseconds();//获得分秒的值不让他每次访问的地址一样考虑到兼容性
}//ok

//注册 
function Register() {
    ClickValidateCode();
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: 'ashx/userRegister.ashx?action=Register',
        data: {
            UserName: document.getElementById('inputUserName').value,
            UserAccount: document.getElementById('inputAccount').value,
            UserPassWord: document.getElementById('inputPassWord').value,
            UserMail: document.getElementById('inputUserMail').value,
            Code: document.getElementById('inputCode').value
        },
        success: function (result) {
            var serverData = result.split(':');
            if (serverData[0] == 'onCode') {
                document.getElementById('inputCode').value = "";
                layer.msg(serverData[1]);
                layer.close(loadIndex);
                return;
            }
            if (serverData[0] == 'onName') {
                document.getElementById('spaninputUserName').innerHTML = serverData[1];
                document.getElementById('spaninputUserName').style.color = "red";
            }
            if (serverData[0] == 'onAccount') {
                document.getElementById('spaninputAccount').innerHTML = serverData[1];
                document.getElementById('spaninputAccount').style.color = "red";
            }
            if (serverData[0] == 'onPassWord') {
                document.getElementById('spaninputPassWord').innerHTML = serverData[1];
                document.getElementById('spaninputPassWord').style.color = "red";
            }
            if (serverData[0] == 'onMail') {
                document.getElementById('spaninputUserMail').innerHTML = serverData[1];
                document.getElementById('spaninputUserMail').style.color = "red";
            }
            if (serverData[0] == 'onErron')
            {
                window.location = serverData[1];
            }
            if (serverData[0] == 'okRegister')
            {
                layer.msg("注册成功，跳转到登录页");
                document.getElementById('inputUserName').value = "";
                document.getElementById('inputAccount').value = "";
                document.getElementById('inputPassWord').value = "";
                document.getElementById('inputUserMail').value = "";
                document.getElementById('inputCode').value = "";
                ClickValidateCode();
                window.location = serverData[1];
            } if (serverData[0] == 'onRegister')
            {
                layer.msg(serverData[1]);
            }
            layer.close(loadIndex);
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！");
        }
    });
}

function GotoPage(PagePosition, Table, GUID) {
    //功能：对列表进行分页
    //语法：GotoPage(页面定位, 分页表名) 
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/HomePage.ashx?action=GotoPage',
        data: {
            PagePosition: PagePosition,
            Table: Table,
            GUID: GUID
        },
        success: function (result) {
            layer.close(loadIndex);
            document.getElementById("div" + Table + "List").innerHTML = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("错误，请重试！11");
        }
    });
}
//获取传过来的值
function QueryString(_QueryStringKey) {
    //功能：返回指定URL参数的值
    //语法：QueryString(string URL参数名称)
    var reg = new RegExp("(^|&)" + _QueryStringKey + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return "";
}



