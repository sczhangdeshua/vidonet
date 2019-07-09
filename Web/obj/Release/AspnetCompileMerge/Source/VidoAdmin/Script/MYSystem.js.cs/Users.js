function InitUsersList() {
    //功能：初始化并加载用户列表
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/UsersList.aspx',
        data: {
            
        },
        success: function (result) {
            layer.close(loadIndex);
            try {
                divUsersList.innerHTML = result;
            } catch (ex) {
                try {
                    parent.divUsersList.innerHTML = result;
                } catch (ex) {
                    //当前是专用搜索页，不能直接重新加载图文列表，只能重新搜索一次
                    GetUsersSearch();
                }
            }
        },
        error: function (result) {
            //错误处理代码
            layer.msg("服务器错误，请重试！6104");
        }
    });
}
function EditUsersDetail(ActionMethod) {
    //功能：打开会员详情编辑窗口或执行会员详情的创建
    //语法：EditUsersDetail(会员GUID, 操作模式)
    //说明：
    //如果是修改数据，GUID传会员自身GUID
    //如果是新建数据，GUID传0
    //操作模式为：OpenCreate打开新建窗口 , OpenEdit打开修改窗口 , ExecCreate执行新建，ExecEdit执行修改
    switch (ActionMethod) {
        case "OpenCreate"://打开新建窗口
            layer.open({
                type: 2,
                title: '编辑详情',
                area: ['510px', '275px'],
                resize: false,
                closeBtn: false,
                content: 'UsersDetailEdit.aspx?ActionMethod=OpenCreate'
            });
            break;
        case "ExecCreate"://执行新建
            //检查用户名称
            if (document.getElementById("txtUsersDetailName").value == "") {
                layer.tips("必填项", "#txtUsersDetailName");
                document.getElementById("txtUsersDetailName").focus();
                return;
            }
            //检查用户账户
            if (document.getElementById("txtUserAccount").value == "") {
                layer.tips("必填项", "#txtUserAccount");
                document.getElementById("txtUserAccount").focus();
                return;
            }
            //检查密码
            if (document.getElementById("txtUsersDetailLoginPassword1").value == "") {
                layer.tips("必填项", "#txtUsersDetailLoginPassword1");
                document.getElementById("txtUsersDetailLoginPassword1").focus();
                return;
            }
            //检查邮箱
            if (document.getElementById("txtUsersDetailEmail").value == "") {
                layer.tips("必填项", "#txtUsersDetailEmail");
                document.getElementById("txtUsersDetailEmail").focus();
                return;
            }
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Users.ashx?action=CreateUsersDetail',
                data: {
                    UserName: document.getElementById("txtUsersDetailName").value,
                    UserAccount: document.getElementById("txtUserAccount").value,
                    UserPassWord: document.getElementById("txtUsersDetailLoginPassword1").value,
                    UserMail: document.getElementById("txtUsersDetailEmail").value,
                    UsersState: document.getElementById("ddlUsersDatailState").value
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
                            InitUsersList();
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！6588");
                }
            });
            break;
      
        default:
            layer.msg("服务器错误，请重试！5102");
            break;
    }
}
function EditUsersPassword(GUID, ActionMethod) {
    //功能：打开用户密码设置窗口
    //语法：EditUsersPassword(用户GUID, 操作模式)
    //说明：
    //操作模式为：OpenEdit打开设置窗口 , ExecEdit执行设置
    switch (ActionMethod) {
        case "OpenEdit"://打开设置窗口
            layer.open({
                type: 2,
                title: '修改用户密码',
                area: ['480px', '142px'],
                resize: false,
                closeBtn: false,
                content: 'UsersPasswordEdit.aspx?GUID=' + GUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecEdit"://执行设置
            if (document.getElementById("txtUsersPassword1").value == "") {
                layer.tips("必填项", "#txtUsersPassword1");
                return;
            }
            if (document.getElementById("txtUsersPassword2").value == "") {
                layer.tips("必填项", "#txtUsersPassword2");
                return;
            }
            if (document.getElementById("txtUsersPassword1").value != document.getElementById("txtUsersPassword2").value) {
                layer.tips("密码不一致！", "#txtUsersPassword2");
                layer.tips("密码不一致！", "#txtUsersPassword1");
                return;
            }

            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Users.ashx?action=UsersPasswordEdit',
                data: {
                    GUID: GUID,
                    UserPassWord:document.getElementById("txtUsersPassword1").value 
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
                            InitUsersList();
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！6588");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！66902");
            break;
    }
}
function EditUsersUserNameMail(GUID, ActionMethod) {
    //功能：打开用户密码设置窗口
    //语法：EditUsersPassword(用户GUID, 操作模式)
    //说明：
    //操作模式为：OpenEdit打开设置窗口 , ExecEdit执行设置
    switch (ActionMethod) {
        case "OpenEdit"://打开设置窗口
            layer.open({
                type: 2,
                title: '修改用户昵称和邮箱',
                area: ['480px', '250px'],
                resize: false,
                closeBtn: false,
                content: 'UsersUserNameMailEdit.aspx?GUID=' + GUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecEdit"://执行设置
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Users.ashx?action=UsersUserNameMailEdit',
                data: {
                    GUID: GUID,
                    UsersName: document.getElementById("txtUsersName").value,
                    UsersMail: document.getElementById("txtUsersMail").value
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
                            InitUsersList();
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！6588");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！66902");
            break;
    }
}
function EditUsersState(GUID, ActionMethod) {
    //功能：设置用户是否可以登录
    //语法：EditUsersPassword(用户GUID, 操作模式)
    //说明：
    //操作模式为：OpenEdit打开设置窗口 , ExecEdit执行设置
    switch (ActionMethod) {
        case "OpenEdit"://打开设置窗口
            layer.open({
                type: 2,
                title: '修改用户昵称和邮箱',
                area: ['480px', '250px'],
                resize: false,
                closeBtn: false,
                content: 'UserStateEdit.aspx?GUID=' + GUID + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecEdit"://执行设置
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Users.ashx?action=UsersStateEdit',
                data: {
                    GUID: GUID,
                    UsersState: document.getElementById("ddlUsersDatailState").options[document.getElementById("ddlUsersDatailState").selectedIndex].value
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
                            InitUsersList();
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！6588");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！66902");
            break;
    }
}
function SetUsersState(UsersState, ActionMethod) {
    //功能：设置产品是否上架
    //语法：SetUsersDetailVisible(int 1上架，0下架)
    //说明：操作模式用于表示本功能的调用方，如果在搜索页面调用本功能，传入"Search"，如果在常规列表页调用，则可为空不传值
    layer.confirm("确定要" + (UsersDetailVisible == 1 ? '上架' : '下架') + "？", { icon: 3, closeBtn: false, title: false },
    function (index) {
        var loadIndex = layer.load();
        $.ajax({
            async: true,
            cache: false,
            type: 'post',
            url: '/Admin/AdminSystem.ashx?action=SetUsersDetailVisible&UsersDetailVisible=' + UsersDetailVisible,
            data: {
                GUID: chkBoxValue
            },
            //第三步：AJAX回调处理
            success: function (result) {
                //回调成功的处理代码
                layer.close(loadIndex);
                switch (ActionMethod) {
                    case "Search"://由搜索页面调用本功能，则重新加载搜索程序
                        GetUsersSearch();
                        break;
                    default://由常规页面调用本功能，则重新加载列表初始化程序
                        InitUsersList(cookie("UsersCategoryGUID"));
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
function EditUsersStateAttr(UsersGUIDList, ActionMethod) {
    //功能：打开用户状态设置窗口
    //语法：EditUsersState(用户GUID列表, 操作模式)
    //说明：
    //如果是同时设置多个用户的状态，UsersGUIDList为UsersGUID1,UsersGUID2,...
    //如果为单个用户设置状态，UsersGUIDList为1个用户GUID，不带逗号
    //操作模式为：OpenEdit打开设置窗口 , ExecEdit执行设置
    switch (ActionMethod) {
        case "OpenCreate"://打开设置窗口
            var chkBoxValue = GetCheckBoxValue('checkbox');
            if (chkBoxValue.length < 2) {
                layer.msg("请至少选择一条数据！");
                return;
            }
            layer.open({
                type: 2,
                title: '编辑多个用户状态状态',
                area: ['460px', '240px'],
                resize: false,
                closeBtn: false,
                content: 'UserStateAttr.aspx?UsersGUIDList=' + chkBoxValue + '&ActionMethod=OpenEdit'
            });
            break;
        case "ExecEdit"://修改多个用户状态
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Users.ashx?action=EditUsersStateAttr',
                data: {
                    GUID: UsersGUIDList,
                    UserState: document.getElementById('rdoUserState').checked ? 1 : 0
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
                            InitUsersList();
                            CloseLayerWindow();
                        }
                        );
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！6588");
                }
            });
            break;
        default:
            layer.msg("服务器错误，请重试！66902");
            break;
    }
}
function DeleteUsers(GUID) {
    //功能：打开确认删除提示
    //语法：DeleteUsers(分类的GUID)
    layer.confirm("确定要删除？", { icon: 3, closeBtn: false, title: false },
        function (index) {
            var loadIndex = layer.load();
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Users.ashx?action=DeleteUsers',
                data: {
                    GUID: GUID
                },
                success: function (result) {
                    InitUsersList();
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
function GetUsersListSearch(UsersName, UserAccount,txtUserMail,ddlUsersDatailState, Action) {
    //功能：获取用户搜索列表，在用户列表中调用
    //语法：GetUsersListSearch(用户名称关键词, 正文内容关键词, 清空条件)
    //说明：如果要清空查询条件，Action传入Clear
    var loadIndex = layer.load();
    UsersName = (UsersName != null) ? (UsersName.value) : ("");
    UserAccount = (UserAccount != null) ? (UserAccount.value) : ("");
    txtUserMail = (txtUserMail != null) ? (txtUserMail.value) : ("");
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Users.ashx?action=GetUsersListSearch',
        data: {
            UserName: UsersName,
            UserAccount: UserAccount,
            UserMail: txtUserMail,
            UserState: ddlUsersDatailState,
            Clear: Action
        },
        success: function (result) {
            layer.close(loadIndex);
            divUsersList.innerHTML = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！57189");
        }
    });
}
