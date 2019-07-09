
function ifAccess() {
                layer.open({
                    type: 2,    //弹窗模式：2为加载URL
                    title: '打赏页面',  //小窗口标题
                    area: ['90%', '90%'],   //小窗口宽高
                    resize: false,
                    closeBtn: true,
                    content: 'NoRegisterPay.aspx'
                });
}
function Bo(U, GUID) {
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VideoBoFangQi.aspx',
        data: {
            VideoBo: document.getElementById(U).value,
            GUID: GUID,
            Number: Number
        },
        success: function (result) {
            layer.close(loadIndex);
            document.getElementById("divVideo").innerHTML = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！");
        }
    });
}
