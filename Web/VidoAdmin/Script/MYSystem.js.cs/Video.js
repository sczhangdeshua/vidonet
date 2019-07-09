function InitVideoCategory() {
    //功能：初始化并加载影视分类
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/VideoCategory.aspx',
        data: {
        },
        success: function (result) {
            //正确处理代码
            layer.close(loadIndex);
            try {
                divVideoCategory.innerHTML = result;
            } catch (ex) {
                //如果是子窗体调用分类的容器，则需要指定parent
                parent.divVideoCategory.innerHTML = result;
            }
            if (cookie("VideoCategoryMenuOpen") != "") {
                if (document.getElementById(cookie("VideoCategoryMenuOpen")) != null) {
                    document.getElementById(cookie("VideoCategoryMenuOpen")).style.display = "block";
                }
                if (parent.document.getElementById(cookie("VideoCategoryMenuOpen")) != null) {
                    parent.document.getElementById(cookie("VideoCategoryMenuOpen")).style.display = "block";
                }
            }
        },
        error: function (result) {
            //错误处理代码
            layer.msg("服务器错误，请重试！5003");
        }
    });
}
function EditVideoCategory(VideoCategoryGUID, ActionMethod) {
    //功能：打开分类编辑窗口或执行分类的创建、修改等操作
    //语法：EditVideoCategory(分类所属的上级分类GUID | 自身GUID, 操作模式)
    //说明：
    //如果是创建子分类，VideoCategoryGUID则为新分类所属的上级分类GUID
    //如果是创建顶层分类，VideoCategoryGUID则为0
    //如果是修改分类，VideoCategoryGUID则为自身GUID
    //操作模式为：OpenCreate打开新建窗口 , OpenEdit打开修改窗口 , ExecCreate执行新建，ExecEdit执行修改
    switch (ActionMethod) {
        case "OpenCreate"://打开新建窗口
            layer.open({
                type: 2,
                title: '编辑分类',
                area: ['510px', '232px'],
                resize: false,
                closeBtn: false,
                content: 'VideoCategoryEdit.aspx?VideoCategoryGUID=' + VideoCategoryGUID + '&ActionMethod=OpenCreate'
            });
            break;
        case "OpenEdit"://打开修改窗口
            layer.open({
                type: 2,
                title: '编辑分类',
                area: ['510px', '232px'],
                resize: false,
                closeBtn: false,
                content: 'VideoCategoryEdit.aspx?VideoCategoryGUID=' + VideoCategoryGUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecCreate"://执行新建
            if (document.getElementById("txtVideoCategoryName").value == "") {
                layer.tips("必填项", "#txtVideoCategoryName")
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=CreateVideoCategory',
                data: {
                    VideoCategoryName: document.getElementById('txtVideoCategoryName').value,
                    VideoCategoryDescribe: document.getElementById('txtVideoCategoryDescribe').value,
                    VideoCategoryGUID: VideoCategoryGUID
                },
                success: function (result) {
                    layer.close(loadIndex);
                    layer.alert(
                        result,
                        {
                            icon: 1,
                            closeBtn: false,
                            title: false
                        },
                        function () {
                            InitVideoCategory();
                            CloseLayerWindow();
                        });
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！0008");
                }
            });
            break;
        case "ExecEdit"://执行修改
            if (document.getElementById("txtVideoCategoryName").value == "") {
                layer.tips("必填项", "#txtVideoCategoryName")
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=EditVideoCategory',
                data: {
                    VideoCategoryName: document.getElementById('txtVideoCategoryName').value,
                    VideoCategoryDescribe: document.getElementById('txtVideoCategoryDescribe').value,
                    VideoCategoryGUID: VideoCategoryGUID
                },
                success: function (result) {
                    layer.close(loadIndex);
                    layer.alert(
                        result,
                        {
                            icon: 1,
                            closeBtn: false,
                            title: false
                        },
                        function () {
                            InitVideoCategory();
                            CloseLayerWindow();
                        });
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！0001");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！0002");
            break;
    }

}
function SetVideoCategoryMenu(GUID) {
    //功能：设置影视分类菜单的展开、折叠
    //语法：SetVideoCategoryMenu(菜单GUID)
    var menu = document.getElementById(GUID);
    if (menu.style.display == "block") {
        menu.style.display = "none";
        cookie("VideoCategoryMenuOpen", "");//在折叠分类菜单的同时保留折叠状态
    } else {
        menu.style.display = "block";
        cookie("VideoCategoryMenuOpen", GUID);//在展开分类菜单的同时保留展开状态
    }
}
function SetVideoCategoryMenuOrder(GUID, Direction) {
    //功能：设置分类菜单的排序号
    //语法：SetProductCategoryMenuOrder(菜单GUID,排序方向)
    //说明：排序方向为'UP'，'DOWN'
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=VideoCategoryMenuOrder',
        data: {
            GUID: GUID,
            Direction: Direction
        },
        success: function (result) {
            layer.close(loadIndex);
            InitVideoCategory();
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！5007");
        }
    });
}
function DeleteVideoCategory(VideoCategoryGUID) {
    //功能：打开确认删除提示
    //语法：DeleteVideoCategory(分类的GUID)
    layer.confirm("确定要删除？", { icon: 3, closeBtn: false, title: false },
        function (index) {
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=DeleteVideoCategory',
                data: {
                    VideoCategoryGUID: VideoCategoryGUID
                },
                success: function (result) {
                    InitVideoCategory();
                    layer.close(loadIndex);
                    layer.msg(result);
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！0005");
                }
            });
            layer.close(index);
        });
}
function OpenVideoAttribConfig(VideoCategoryGUID, VideoCategoryName) {
    //功能：打开影视动态属性配置主界面
    //语法：InitVideoAttrib(影视分类GUID,影视分类名称)
    cookie("OpenVideoAttribConfigTemp", VideoCategoryGUID);
    VideoCategoryName = (VideoCategoryName != null ? " - " + VideoCategoryName : '');
    layer.open({
        type: 2,
        title: '影视动态属性' + VideoCategoryName,
        area: ['700px', '600px'],
        resize: false,
        closeBtn: false,
        content: 'VideoAttribConfig.aspx?VideoCategoryGUID=' + VideoCategoryGUID
    });
}
function InitVideoAttribConfigList(VideoCategoryGUID) {
    //功能：加载影视动态属性列表
    var loadIndex = layer.load();
    if (VideoCategoryGUID == null || VideoCategoryGUID == '') {
        VideoCategoryGUID = QueryString("VideoCategoryGUID");
    }
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/VideoAttribConfigList.aspx',
        data: {
            VideoCategoryGUID: VideoCategoryGUID
        },
        success: function (result) {
            layer.close(loadIndex);
            try {
                document.getElementById('divVideoAttribConfigList').innerHTML = result;
            } catch (ex) {
                parent.document.getElementById('divVideoAttribConfigList').innerHTML = result;
            }
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！5088");
        }
    });

}
function OpenVideoAttribConfigCopyList(VideoCategoryGUID) {
    //功能：打开动态属性复制对话框
    //语法：OpenVideoAttribConfigCopyList(影视分类GUID)
    if (VideoCategoryGUID == '0') {
        layer.msg("请选择影视分类！");
        return;
    }
    layer.open({
        type: 2,
        title: '影视动态属性',
        area: ['580px', '400px'],
        resize: false,
        closeBtn: false,
        content: 'VideoAttribConfigCopyList.aspx?VideoCategoryGUID=' + VideoCategoryGUID
    });
}
function CopyVideoAttribConfig() {
    //功能：复制选中的影视动态属性
    layer.confirm("确定复制？", { icon: 3, closeBtn: false, title: false },
    function (index) {
        var loadIndex = layer.load();
        //先调用CheckBox的多选值GUID列表
        var chkBoxValue = GetCheckBoxValue('checkbox');
        if (chkBoxValue.length < 2) {
            layer.close(loadIndex);
            layer.msg("请至少选择一条数据！");
            return;
        }
        layer.msg("正在复制，请稍候......");
        $.ajax({
            async: true,
            cache: false,
            type: 'post',
            url: '/VidoAdmin/ashx/Video.ashx?action=CopyVideoAttribConfig',
            data: {
                GUID: chkBoxValue,
                VideoCategoryGUID: cookie('OpenVideoAttribConfigTemp')
            },
            success: function (result) {
                layer.close(loadIndex);
                layer.msg(result);
                InitVideoAttribConfigList(cookie('OpenVideoAttribConfigTemp'));
                CloseLayerWindow();
                return;
            },
            error: function (result) {
                layer.close(loadIndex);
                layer.msg("服务器错误，请重试！5386");
            }
        });
        layer.close(index);
    });
}
function SetVideoAttribConfigOrder(GUID, Direction) {
    //功能：设置动态属性的排序号
    //语法：SetVideoAttribConfigOrder(动态8属性GUID,排序方向)
    //说明：排序方向为'UP'，'DOWN'
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=VideoAttribConfigOrder',
        data: {
            GUID: GUID,
            Direction: Direction
        },
        success: function (result) {
            layer.close(loadIndex);
            InitVideoAttribConfigList(cookie('OpenVideoAttribConfigTemp'));
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！5027");
        }
    });
}
function EditVideoAttribConfig(VideoCategoryGUID, ActionMethod, VideoAttribConfigGUID) {
    //功能：打开影视动态属性编辑窗口或执行动态属性的创建、修改等操作
    //语法：EditVideoAttribConfig(影视分类GUID, 操作模式,[动态属性GUID])
    //说明：
    //如果是创建动态属性，VideoCategoryGUID则为对应影视分类的GUID，不传入动态属性GUID
    //如果是修改分类，VideoCategoryGUID则为对应影视分类的GUID，并且需要传入要修改的动态属性GUID
    //操作模式为：OpenCreate打开新建窗口 , OpenEdit打开修改窗口 , ExecCreate执行新建，ExecEdit执行修改
    switch (ActionMethod) {
        case "OpenCreate"://打开新建窗口
            layer.open({
                type: 2,
                title: '编辑动态属性',
                area: ['510px', '232px'],
                resize: false,
                closeBtn: false,
                content: 'VideoAttribConfigEdit.aspx?VideoCategoryGUID=' + VideoCategoryGUID + '&ActionMethod=OpenCreate'
            });
            break;
        case "OpenEdit"://打开修改窗口
            layer.open({
                type: 2,
                title: '编辑动态属性',
                area: ['510px', '232px'],
                resize: false,
                closeBtn: false,
                content: 'VideoAttribConfigEdit.aspx?VideoCategoryGUID=' + VideoCategoryGUID + '&VideoAttribConfigGUID=' + VideoAttribConfigGUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecCreate"://执行新建
            if (document.getElementById("txtVideoAttribConfigName").value == "") {
                layer.tips("必填项", "#txtVideoAttribConfigName")
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=CreateVideoAttribConfig',
                data: {
                    VideoAttribConfigName: document.getElementById('txtVideoAttribConfigName').value,
                    VideoAttribConfigDescribe: document.getElementById('txtVideoAttribConfigDescribe').value,
                    VideoCategoryGUID: VideoCategoryGUID
                },
                success: function (result) {
                    layer.close(loadIndex);
                    layer.alert(
                        result,
                        {
                            icon: 1,
                            closeBtn: false,
                            title: false
                        },
                        function () {
                            InitVideoAttribConfigList(VideoCategoryGUID);
                            CloseLayerWindow();
                        });
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！5098");
                }
            });
            break;
        case "ExecEdit"://执行修改
            if (document.getElementById("txtVideoAttribConfigName").value == "") {
                layer.tips("必填项", "#txtVideoAttribConfigName")
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=EditVideoAttribConfig',
                data: {
                    VideoAttribConfigName: document.getElementById('txtVideoAttribConfigName').value,
                    VideoAttribConfigDescribe: document.getElementById('txtVideoAttribConfigDescribe').value,
                    VideoAttribConfigGUID: VideoAttribConfigGUID
                },
                success: function (result) {
                    layer.close(loadIndex);
                    layer.alert(
                        result,
                        {
                            icon: 1,
                            closeBtn: false,
                            title: false
                        },
                        function () {
                            InitVideoAttribConfigList(VideoCategoryGUID);
                            CloseLayerWindow();
                        });
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！5099");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！5055");
            break;
    }

}
function DeleteVideoAttribConfig(VideoCategoryGUID, VideoAttribConfigGUID) {
    //功能：打开确认删除提示
    //语法：DeleteVideoAttribConfig(影视分类GUID,动态属性GUID)

    //在弹出确定删除对话框之前，先对被删除属性的关联数据进行一次查询统计
    var loadIndex = layer.load();
    $.ajax({
        async: false,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=GetVideoAttribCountInVideoDetail',
        data: {
            VideoAttribConfigGUID: VideoAttribConfigGUID
        },
        success: function (result) {
            layer.close(loadIndex);
            GetVideoAttribCountInVideoDetail = result;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！5899");
        }
    });
    layer.confirm("当前属性与" + GetVideoAttribCountInVideoDetail + "个影视有关联，确定要删除？", { icon: 3, closeBtn: false, title: false },
        function (index) {
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=DeleteVideoAttribConfig',
                data: {
                    VideoAttribConfigGUID: VideoAttribConfigGUID
                },
                success: function (result) {
                    InitVideoAttribConfigList(VideoCategoryGUID);
                    layer.close(loadIndex);
                    layer.msg(result);
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！5885");
                }
            });
            layer.close(index);
        });
}
function InitVideoList(VideoCategoryGUID) {
    //功能：初始化并加载影视列表
    cookie('VideoCategoryGUID', VideoCategoryGUID);
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/VideoList.aspx',
        data: {
            VideoCategoryGUID: VideoCategoryGUID
        },
        success: function (result) {
            //正确处理代码
            layer.close(loadIndex);
            try {
                divVideoList.innerHTML = result;
            } catch (ex) {
                try {
                    parent.divVideoList.innerHTML = result;
                } catch (ex) {
                    //当前是专用搜索页，不能直接重新加载影视列表，只能重新搜索一次
                    GetVideoSearch();
                    
                }
            }
        },
        error: function (result) {
            //错误处理代码
            layer.msg("服务器错误，请重试！5504");
        }
    });
}
function EditVideoDetail(GUID, ActionMethod) {
    //功能：打开影视详情编辑窗口或执行影视详情的创建、修改等操作
    //语法：EditVideoDetail(当前影视所属的分类GUID, 操作模式)
    //说明：
    //如果是修改数据，GUID传影视自身GUID
    //如果是新建数据，GUID传0
    //操作模式为：OpenCreate打开新建窗口 , OpenEdit打开修改窗口 , ExecCreate执行新建，ExecEdit执行修改
    switch (ActionMethod) {
        case "OpenCreate"://打开新建窗口
            layer.open({
                type: 2,
                title: '编辑详情',
                area: ['800px', '90%'],
                resize: false,
                closeBtn: false,
                content: 'VideoDetailEdit.aspx?GUID=' + GUID + '&ActionMethod=OpenCreate'
            });
            break;
        case "OpenEdit"://打开修改窗口
            layer.open({
                type: 2,
                title: '编辑详情',
                area: ['800px', '90%'],
                resize: false,
                closeBtn: false,
                content: 'VideoDetailEdit.aspx?GUID=' + GUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecCreate"://执行新建
            //检查影视名称
            if (document.getElementById("txtVideoDetailName").value == "") {
                layer.tips("必填项", "#txtVideoDetailName");
                document.getElementById("txtVideoDetailName").focus();
                return;
            }
            //检查图片来源URL,默认Images/noImage.gif无图
            if (document.getElementById("VideoDetailImgeURL").value == "") {
                layer.tips("默认为Images/noImage.gif", "#VideoDetailImgeURL");
                document.getElementById("VideoDetailImgeURL").focus();
                document.getElementById("VideoDetailImgeURL").value = "Images/noImage.gif";
                return;
            }
            //检查浏览次数
            if (document.getElementById("txtVideoDetailBrowseCount").value == "") {
                layer.tips("默认为0", "#txtVideoDetailBrowseCount");
                document.getElementById("txtVideoDetailBrowseCount").focus();
                document.getElementById("txtVideoDetailBrowseCount").value = "0";
                return;
            }
            //检查正文内容
            if (!UE.getEditor('txtVideoDetailContent').hasContents()) {
                layer.tips("必填项", "#lblVideoDetailContentTip");
                UE.getEditor('txtVideoDetailContent').focus();
                return;
            }
            var loadIndex = layer.load();
            //处理动态属性
            var hidVideoAttribConfigGUID = document.getElementsByName("hidVideoAttribConfigGUID");
            var txtVideoAttribValue = document.getElementsByName("txtVideoAttribValue");
            var VideoAttribConfigGUID = '';
            var VideoAttribValueValue = '';
            for (var i = 0; i < hidVideoAttribConfigGUID.length; i++) {
                if (txtVideoAttribValue.item(i).value != '') {
                    VideoAttribConfigGUID += hidVideoAttribConfigGUID.item(i).value + ",";
                    VideoAttribValueValue += txtVideoAttribValue.item(i).value + ",";
                }
            }
            if (VideoAttribConfigGUID != '' && VideoAttribValueValue != '') {
                VideoAttribConfigGUID = VideoAttribConfigGUID.substring(0, VideoAttribConfigGUID.length - 1);
                VideoAttribValueValue = VideoAttribValueValue.substring(0,VideoAttribValueValue.length-1);
            }
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=CreateVideoDetail',
                data: {
                    VideoCategoryGUID: cookie('VideoCategoryGUID'),
                    VideoDetailName: document.getElementById('txtVideoDetailName').value,
                    VideoDetailSource: document.getElementById('txtVideoDetailSource').value,
                    VideoDetailContent: UE.getEditor('txtVideoDetailContent').getContent(),
                    VideoDetailBrowseCount: document.getElementById('txtVideoDetailBrowseCount').value,
                    VideoDetailImgeURL: document.getElementById('VideoDetailImgeURL').value,
                    VideoDetailVisible: document.getElementById('rdoVideoDetailVisible1').checked ? "1" : "0",
                    VideoAttribConfigGUID: VideoAttribConfigGUID,
                    VideoAttribValueValue: VideoAttribValueValue,
                    VideoDetailSequel: document.getElementById('rdoVideoDetailSequel1').checked ? "1" : "0",
                    HotSearch: document.getElementById('rdoHotSearch1').checked ? "1" : "0",
                },
                success: function (result) {
                    layer.close(loadIndex);
                    layer.alert(
                        result,
                        {
                            icon: 1,
                            closeBtn: false,
                            title: false
                        }
                        ,
                        function () {
                            InitVideoList();
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！5988");
                }
            });
            break;
        case "ExecEdit"://执行修改
            //检查影视名称
            if (document.getElementById("txtVideoDetailName").value == "") {
                layer.tips("必填项", "#txtVideoDetailName");
                document.getElementById("txtVideoDetailName").focus();
                return;
            }
            //检查图片来源URL,默认Images/noImage.gif无图
            if (document.getElementById("VideoDetailImgeURL").value == "") {
                layer.tips("默认为Images/noImage.gif", "#VideoDetailImgeURL");
                document.getElementById("VideoDetailImgeURL").focus();
                document.getElementById("VideoDetailImgeURL").value = "Images/noImage.gif";
                return;
            }
            //检查浏览次数
            if (document.getElementById("txtVideoDetailBrowseCount").value == "") {
                layer.tips("默认为0", "#txtVideoDetailBrowseCount");
                document.getElementById("txtVideoDetailBrowseCount").focus();
                document.getElementById("txtVideoDetailBrowseCount").value = "0";
                return;
            }
            //检查正文内容
            if (!UE.getEditor('txtVideoDetailContent').hasContents()) {
                layer.tips("必填项", "#lblVideoDetailContentTip");
                UE.getEditor('txtVideoDetailContent').focus();
                return;
            }

            var loadIndex = layer.load();
            //处理动态属性
            var hidVideoAttribConfigGUID = document.getElementsByName("hidVideoAttribConfigGUID");
            var txtVideoAttribValue = document.getElementsByName("txtVideoAttribValue");
            var VideoAttribConfigGUID = '';
            var VideoAttribValueValue = '';
            for (var i = 0; i < hidVideoAttribConfigGUID.length; i++) {
                if (txtVideoAttribValue.item(i).value != '') {
                    VideoAttribConfigGUID += hidVideoAttribConfigGUID.item(i).value + ",";
                    VideoAttribValueValue += txtVideoAttribValue.item(i).value + ",";
                }
            }
            if (VideoAttribConfigGUID != '' && VideoAttribValueValue != '') {
                VideoAttribConfigGUID = VideoAttribConfigGUID.substring(0, VideoAttribConfigGUID.length - 1);
                VideoAttribValueValue = VideoAttribValueValue.substring(0, VideoAttribValueValue.length - 1);
            }

            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Video.ashx?action=EditVideoDetail',
                data: {
                    GUID: GUID,
                    VideoDetailName: document.getElementById('txtVideoDetailName').value,
                    VideoDetailSource: document.getElementById('txtVideoDetailSource').value,
                    VideoDetailContent: UE.getEditor('txtVideoDetailContent').getContent(),
                    VideoDetailBrowseCount: document.getElementById('txtVideoDetailBrowseCount').value,
                    VideoDetailImgeURL: document.getElementById('VideoDetailImgeURL').value,
                    VideoDetailVisible: document.getElementById('rdoVideoDetailVisible1').checked ? "1" : "0",
                    VideoAttribConfigGUID: VideoAttribConfigGUID,
                    VideoAttribValueValue: VideoAttribValueValue,
                    VideoDetailSequel: document.getElementById('rdoVideoDetailSequel1').checked ? "1" : "0",
                    HotSearch: document.getElementById('rdoHotSearch1').checked ? "1" : "0",
                },
                success: function (result) {
                    layer.close(loadIndex);
                    layer.alert(
                        result,
                        {
                            icon: 1,
                            closeBtn: false,
                            title: false
                        }
                        ,
                        function () {
                            InitVideoList(cookie('VideoCategoryGUID'));
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！5999");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！5102");
            break;
    }
}
function SetVideoDetailListOrder(Field, Order) {
    //功能：设置影视列表的显示排序
    //语法：SetVideoDetailListOrder(字段名, 排序方式)
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=SetVideoDetailListOrder',
        data: {
            VideoDetailField: Field,
            VideoDetailOrder: Order,
            VideoCategoryGUID: cookie('VideoCategoryGUID')
        },
        success: function (result) {
            layer.close(loadIndex);
            divVideoList.innerHTML = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！57893");
        }
    });
}
function SetVideoDetailVisible(VideoDetailVisible, ActionMethod) {
    //功能：设置影视是否上架
    //语法：SetVideoDetailVisible(int 1上架，0下架)
    //说明：操作模式用于表示本功能的调用方，如果在搜索页面调用本功能，传入"Search"，如果在常规列表页调用，则可为空不传值
    layer.confirm("确定要" + (VideoDetailVisible == 1 ? '上映' : '下映') + "？", { icon: 3, closeBtn: false, title: false },
    function (index) {
        var loadIndex = layer.load();
        var chkBoxValue = GetCheckBoxValue('checkbox');
        if (chkBoxValue.length < 2) {
            layer.close(loadIndex);
            layer.msg("请至少选择一条数据！");
            return;
        }
        $.ajax({
            async: true,
            cache: false,
            type: 'post',
            url: '/VidoAdmin/ashx/Video.ashx?action=SetVideoDetailVisible&VideoDetailVisible=' + VideoDetailVisible,
            data: {
                GUID: chkBoxValue
            },
            //第三步：AJAX回调处理
            success: function (result) {
                //回调成功的处理代码
                layer.close(loadIndex);
                switch (ActionMethod) {
                    case "Search"://由搜索页面调用本功能，则重新加载搜索程序
                        GetVideoSearch();
                        break;
                    default://由常规页面调用本功能，则重新加载列表初始化程序
                        InitVideoList(cookie("VideoCategoryGUID"));
                        break;
                }
                return;
            },
            error: function (result) {
                layer.close(loadIndex);
                layer.msg("服务器错误，请重试！5906");
            }
        });
        layer.close(index);
    });
}
function GetVideoDetailListSearch(VideoDetailSequel, HotSearch, Action) {
    //功能：获取影视搜索列表，在常规影视列表中调用
    //语法：GetVideoDetailListSearch(影视名称关键词, 正文内容关键词, 清空条件)
    //说明：如果要清空查询条件，Action传入Clear
    var loadIndex = layer.load();
    VideoDetailSequel = (VideoDetailSequel != null) ? (VideoDetailSequel.value) : ("2");
    HotSearch = (HotSearch != null) ? (HotSearch.value) : ("2");
    VideoCategoryGUID = cookie('VideoCategoryGUID');
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=GetVideoDetailListSearch',
        data: {
            VideoDetailSequel: VideoDetailSequel,
            HotSearch: HotSearch,
            Clear: Action
        },
        success: function (result) {
            layer.close(loadIndex);
            divVideoList.innerHTML = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！57189");
        }
    });
}
function GetVideoSearch() {
    //功能：获取影视搜索列表，在影视搜索页面中调用
    var loadIndex = layer.load();
    try {
        var txtKey = document.getElementById("txtKey").value;
        var chkVideoDetailVisible = document.getElementById("chkVideoDetailVisible").checked ? "0": "1";
        var txtVideoDetailAddDateStart = document.getElementById("txtVideoDetailAddDateStart").value;
        var txtVideoDetailAddDateEnd = document.getElementById("txtVideoDetailAddDateEnd").value;
    } catch (ex) {
        var txtKey = parent.document.getElementById("txtKey").value;
        var chkVideoDetailVisible = parent.document.getElementById("chkVideoDetailVisible").checked ? "0" : "1";
        var txtVideoDetailAddDateStart = parent.document.getElementById("txtVideoDetailAddDateStart").value;
        var txtVideoDetailAddDateEnd = parent.document.getElementById("txtVideoDetailAddDateEnd").value;
    }
    if (txtKey == '') {
        layer.msg("请输入关键词！");
        layer.close(loadIndex);
        return;
    }
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=GetVideoSearch',
        data: {
            key: txtKey,
            VideoDetailVisible: chkVideoDetailVisible,
            VideoDetailAddDateStart: txtVideoDetailAddDateStart,
            VideoDetailAddDateEnd: txtVideoDetailAddDateEnd
        },
        success: function (result) {
            layer.close(loadIndex);
            try {
                document.getElementById("divVideoList").innerHTML = result;
            } catch (ex) {
                parent.document.getElementById("divVideoList").innerHTML = result;
            }
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！5905");
        }
    });
}
function DeleteVideoDetail(GUID, ActionMethod) {
    //功能：永久删除产品及其对应的文件
    //语法：DeleteVideoDetail(要单个删除的产品GUID , 操作模式)
    //说明：如果要实现批量删除，则GUID为空，批量删除的产品GUID列表由调用方的CheckBox指定
    //说明：操作模式用于表示本功能的调用方，如果在搜索页面调用本功能，传入"Search"，如果在常规列表页调用，则可为空不传值
    layer.confirm("确定要删除？", { icon: 3, closeBtn: false, title: false },
    function (index) {
        var loadIndex = layer.load();
        if (GUID != "" && GUID != null) {
            //GUID不为空的时候，表示要单独删除某一个产品
            var chkBoxValue = GUID;
        } else {
            //批量删除，先调用CheckBox的多选值GUID列表
            var chkBoxValue = GetCheckBoxValue('checkbox');
            if (chkBoxValue.length < 2) {
                layer.close(loadIndex);
                layer.msg("请至少选择一条数据！");
                return;
            }
        }
        $.ajax({
            async: true,
            cache: false,
            type: 'post',
            url: '/VidoAdmin/ashx/Video.ashx?action=DeleteVideoDetail',
            data: {
                GUID: chkBoxValue
            },
            //第三步：AJAX回调处理
            success: function (result) {
                //回调成功的处理代码
                layer.close(loadIndex);
                layer.msg(result);
                switch (ActionMethod) {
                    case "Search"://由搜索页面调用本功能，则重新加载搜索程序
                        GetVideoSearch();
                        break;
                    default://由常规页面调用本功能，则重新加载列表初始化程序
                        InitVideoList(cookie("VideoCategoryGUID"));
                        break;
                }
                return;
            },
            error: function (result) {
                layer.close(loadIndex);
                layer.msg("服务器错误，请重试！1006");
            }
        });
        layer.close(index);
    });
}