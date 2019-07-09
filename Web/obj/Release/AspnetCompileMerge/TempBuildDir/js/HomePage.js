//退出登录
function exit() {
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/HomePage.ashx?action=exit',
        data: {

        },
        success: function (result) {
            layer.close(loadIndex);
            var serverData = result.split(':');
            if (serverData[0] == 'okexit') {
                window.location = serverData[1];
                return;
            }

            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            window.location = "/Error.aspx";
        }
    });

}
//判断是否登录
function ifAccess(GUID) {
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/HomePage.ashx?action=Register',
        data: {
            GUID:GUID
        },
        success: function (result) {
            window.location = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！");
        }
    });
}

//打开打赏窗口
function reward() {
    layer.open({
        type: 2,    //弹窗模式：2为加载URL
        title: '打赏页面',  //小窗口标题
        area: ['90%', '90%'],   //小窗口宽高
        resize: false,
        closeBtn: true,
        content: 'NoRegisterPay.aspx'
    });
}

//播放那个视频动漫，电视剧，电影
function Tv(Pian, GUID) {
    switch (Pian)
    {
        case "OpenTv":
                var loadIndex = layer.load();
                $.ajax({
                    async: true,
                    cache: false,
                    type: 'post',
                    url: '/TvDatil.aspx',
                    data: {
                        GUID: GUID
                    },
                    success: function (result) {
                        layer.close(loadIndex);
                        document.getElementById("divTvList").innerHTML = result;
                    },
                    error: function (result) {
                        layer.msg("错误，请重试！09");
                    }
                });
            break;
    }
}

//搜索的视频影片
function Search() {
    var SearchString = document.getElementById('textSearch').value;
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/ashx/HomePage.ashx?action=Search',
        data: {
            SearchString: SearchString
        },
        success: function (result) {
            layer.close(loadIndex);
            var serverData = result.split(',');
            var html;
            html = "<div class='trailers-now-showing-grids'>";
            html += " <div class='col-md-2 trailers-now-showing-grid text-center' style='cursor: pointer;'>"
            html += "<a  class='Access' onclick=\"ifAccess(\'" + serverData[0] + "\')\">";
            html += "<img src='" +serverData[2]+ "' /></a>";
            html += "<a  class='t-n-s-more Access' onclick=\"ifAccess(\'" + serverData[0] + "\')\"> " + serverData[1] + " </a>";
            html += "</div>";
            html += "<div class='clearfix'></div>";
            document.getElementById("divTvList").innerHTML = html;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("错误，请重试！17");
        }
    });
}


