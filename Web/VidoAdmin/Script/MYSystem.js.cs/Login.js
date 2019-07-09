
function Login() {
    if (txtManagerName.value == "") {
        layer.tips("请输入用户名", "#txtManagerName")
        return;
    }
    if (txtManagerPassword.value == "") {
        layer.tips("请输入密码", "#txtManagerPassword")
        return;
    }
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/AdminSystem.ashx?action=ManagerLogin',
        data: {
            ManagerName: txtManagerName.value,
            ManagerPassword: txtManagerPassword.value
        },
        success: function (result) {
            //正确处理代码
            layer.close(loadIndex);
            layer.msg(result);
            if (result == "登录成功，正在进入主程序，请稍等！") {
                window.location = "/VidoAdmin/AdminIndex.aspx";
            } else {
                return;
            }
        },
        error: function (result) {
            //错误处理代码
            layer.msg("服务器错误，请重试！0017");
        }
    });
}


