function InitManagerList() {
    //功能：初始化并加载管理员列表
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ManagerList.aspx',
        data: {
        },
        success: function (result) {
            layer.close(loadIndex);
            try {
                divManagerList.innerHTML = result;
            } catch (ex) {
                try {
                    parent.divManagerList.innerHTML = result;
                } catch (ex) {
                }
            }
        },
        error: function (result) {
            //错误处理代码
            layer.msg("服务器错误，请重试！7104");
        }
    });
}

function EditManager(ManagerGUID, ActionMethod) {
    //功能：打开管理员编辑窗口或执行管理员的创建、修改等操作
    //语法：EditManager(管理员GUID , 操作模式)
    //说明：
    //如果是创建管理员，ManagerGUID则为0
    //如果是修改管理员，ManagerGUID则为自身GUID
    //操作模式为：OpenCreate打开新建窗口 , OpenEdit打开修改窗口 , ExecCreate执行新建，ExecEdit执行修改

    switch (ActionMethod) {
        case "OpenCreate"://打开新建窗口
            layer.open({
                type: 2,
                title: '编辑管理员',
                area: ['510px', '272px'],
                resize: false,
                closeBtn: false,
                content: 'ManagerEdit.aspx?ManagerGUID=' + ManagerGUID + '&ActionMethod=OpenCreate'
            });
            break;
        case "OpenEdit"://打开修改窗口
            layer.open({
                type: 2,
                title: '编辑管理员',
                area: ['510px', '272px'],
                resize: false,
                closeBtn: false,
                content: 'ManagerEdit.aspx?ManagerGUID=' + ManagerGUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecCreate"://执行新建
            if (document.getElementById("txtManagerName").value == "") {
                layer.tips("必填项", "#txtManagerName");
                return;
            }
            if (document.getElementById("txtManagerUserName").value == "") {
                layer.tips("必填项", "#txtManagerUserName");
                return;
            }
            if (document.getElementById("txtManagerPassword1").value == "") {
                layer.tips("必填项", "#txtManagerPassword1");
                return;
            }
            if (document.getElementById("txtManagerPassword2").value == "") {
                layer.tips("必填项", "#txtManagerPassword2");
                return;
            }
            if (document.getElementById("txtManagerPassword1").value != document.getElementById("txtManagerPassword2").value) {
                layer.tips("密码不一致！", "#txtManagerPassword2");
                layer.tips("密码不一致！", "#txtManagerPassword1");
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/AdminSystem.ashx?action=CreateManager',
                data: {
                    ManagerUserName:document.getElementById("txtManagerUserName").value,
                    ManagerAccount: document.getElementById("txtManagerName").value,
                    AdminPasswrod: document.getElementById("txtManagerPassword1").value
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
                            InitManagerList();
                            CloseLayerWindow();
                        });
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！7908");
                }
            });
            break;
        case "ExecEdit"://执行修改
            if (document.getElementById("txtManagerName").value == "") {
                layer.tips("必填项", "#txtManagerName");
                return;
            }
            if (document.getElementById("txtManagerUserName").value == "") {
                layer.tips("必填项", "#txtManagerUserName");
                return;
            }
            if (document.getElementById("txtManagerPassword1").value != document.getElementById("txtManagerPassword2").value) {
                layer.tips("密码不一致！", "#txtManagerPassword2");
                layer.tips("密码不一致！", "#txtManagerPassword1");
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/AdminSystem.ashx?action=EditManager',
                data: {
                    ManagerUserName: document.getElementById("txtManagerUserName").value,
                    AdminPasswrod: document.getElementById("txtManagerPassword1").value,
                    ManagerGUID: ManagerGUID
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
                            InitManagerList();
                            CloseLayerWindow();
                        });
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！7701");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！79542");
            break;
    }

}


function DeleteManager(ManagerGUID) {
    //功能：打开确认删除提示
    //语法：DeleteManager(分类的GUID)
    layer.confirm("确定要删除？", { icon: 3, closeBtn: false, title: false },
        function (index) {
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/AdminSystem.ashx?action=DeleteManager',
                data: {
                    ManagerGUID: ManagerGUID
                },
                success: function (result) {
                    InitManagerList();
                    layer.close(loadIndex);
                    layer.msg(result);
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！7505");
                }
            });
            layer.close(index);
        });
}

function CloseLayerWindow() {
    //功能：关闭由Layer弹出的小窗口
    var layerWindowIndex = parent.layer.getFrameIndex(window.name);//获取窗口索引
    parent.layer.close(layerWindowIndex); //关闭主窗体
}


