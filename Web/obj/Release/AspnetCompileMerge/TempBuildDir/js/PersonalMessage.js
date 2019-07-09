//名字
function Name() {
    document.getElementById('pastNickname').value = document.getElementById('divName').innerText;
}

//修改名字
function amend() {
    var str = document.getElementById('newNickName').value;                             
    if (str.length!=0) {

        var loadIndex = layer.load();
        $.ajax({
            async: true,
            cache: false,
            type: 'post',
            url: '/ashx/PersonalMessage.ashx?action=newUserName',
            data: {
                pastNickname:document.getElementById('pastNickname').value,
                newNickName: document.getElementById('newNickName').value
            },
            success: function (result) {
                var serverData=result.split(':');
                layer.close(loadIndex);
                if (serverData[0] == 'no') {
                    document.getElementById('amendSpan').innerHTML = serverData[1];
                };
                if (serverData[0] == 'ok')
                {
                    document.getElementById('divName').innerHTML = document.getElementById('newNickName').value;
                    document.getElementById('amendSpan').innerHTML = serverData[1];
                }
                return;
            },
            error: function (result) {
                layer.close(loadIndex);
                window.location = "/Error.aspx?webPage=新昵称更改失败";
            }
        });
    } else {
        document.getElementById('amendSpan').innerHTML = '不能为空';
    }
}

