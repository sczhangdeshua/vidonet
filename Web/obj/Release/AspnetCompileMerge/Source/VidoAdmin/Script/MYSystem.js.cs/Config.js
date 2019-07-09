function InitConfig(ConfigURL, Action) {
    //功能：加载各个设置页面
    //语法：InitConfig(设置页面文件名,加载方式)
    //说明：
    //加载方式为：OpenEdit | ExecEdit
    //将所有表单元素的name统一为ConfigValue
    //将placeholder或title设置为项目名称，读取的时候优先读取title，若为空串，则读取placeholder
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: ConfigURL,
        data: {
            Action: Action
        },
        success: function (result) {
            document.getElementById("divConfigList").innerHTML = result;
            var ConfigKeyList = "";
            var ConfigValue = document.getElementsByName("ConfigValue");
            for (var i = 0; i < ConfigValue.length; i++) {
                if (ConfigValue.item(i).title != "") {
                    ConfigKeyList += ConfigValue.item(i).title + ",";
                } else {
                    ConfigKeyList += ConfigValue.item(i).placeholder + ",";
                }
            }
            ConfigKeyList = ConfigKeyList.substring(0, ConfigKeyList.length - 1);
            $.ajax({
                async: true,
                cache: false,
                type: 'post',
                url: '/VidoAdmin/ashx/Config.ashx?action=GetConfigValueList',
                data: {
                    ConfigKeyList: ConfigKeyList
                },
                success: function (result) {
                    var result = result.split(',');
                    var ArrTemp = null;
                    for (var i = 0; i < ConfigValue.length; i++) {
                        for (var j = 0; j < result.length; j++) {
                            ArrTemp = result[j].split('@');
                            if (ConfigValue.item(i).title == ArrTemp[0] || ConfigValue.item(i).placeholder == ArrTemp[0]) {
                                for (var k = 1; k < ArrTemp.length; k++) {
                                    switch (ConfigValue.item(i).type) {
                                        case "text"://处理来自文本框的数据值
                                            ConfigValue.item(i).value += ArrTemp[k] + "@";
                                            break;
                                        case "select-one"://处理来自下拉列表框的数据值
                                            ConfigValue.item(i).value = ArrTemp[k];
                                            break;
                                        case "textarea"://处理来自多行文本框的数据值
                                            ConfigValue.item(i).value += ArrTemp[k] + "@";
                                            break;
                                    }
                                }
                                if (ConfigValue.item(i).type != "select-one") {
                                    ConfigValue.item(i).value = ConfigValue.item(i).value.substr(0, ConfigValue.item(i).value.length - 1);
                                }
                            }
                            ArrTemp = null;
                        }
                    }
                    return;
                },
                error: function (result) {
                    layer.close(loadIndex);
                    layer.msg("服务器错误，请重试！08995");
                }
            });
            layer.close(loadIndex);
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！08598");
        }
    });
}

function SaveConfig(ConfigURL) {
    //功能：保存各项系统设置
    //语法：SaveConfig(设置页面文件名)
    //说明：
    //将所有表单元素的name统一为ConfigValue
    //将placeholder或title设置为项目名称，读取的时候优先读取title，若为空串，则读取placeholder
    /*
    定义 下拉列表框 例子：
    <select name="ConfigValue" title="网站状态">
        <option value="运行">运行</option>
        <option value="停止">停止</option>
    </select>

    定义 多行文本框 例子：
    <textarea name="ConfigValue" class="form_textarea" style="width:330px;" placeholder="网站介绍"></textarea>
    */
    var Result = "";
    var ConfigValue = document.getElementsByName("ConfigValue");
    for (var i = 0; i < ConfigValue.length; i++) {
        if (ConfigValue.item(i).title != "") {
            switch (ConfigValue.item(i).type) {
                case "text"://处理来自文本框的数据值
                    Result += ConfigValue.item(i).title + "@" + ConfigValue.item(i).value + ",";
                    break;
                case "select-one"://处理来自下拉列表框的数据值
                    Result += ConfigValue.item(i).title + "@" + ConfigValue.item(i).value + ",";
                    break;
                case "textarea"://处理来自多行文本框的数据值
                    Result += ConfigValue.item(i).title + "@" + ConfigValue.item(i).value + ",";
                    break;
            }
        } else {
            switch (ConfigValue.item(i).type) {
                case "text"://处理来自文本框的数据值
                    Result += ConfigValue.item(i).placeholder + "@" + ConfigValue.item(i).value + ",";
                    break;
                case "select-one"://处理来自下拉列表框的数据值
                    Result += ConfigValue.item(i).placeholder + "@" + ConfigValue.item(i).value + ",";
                    break;
                case "textarea"://处理来自多行文本框的数据值
                    Result += ConfigValue.item(i).placeholder + "@" + ConfigValue.item(i).value + ",";
                    break;
            }
        }
    }
    Result = Result.substring(0, Result.length - 1);

    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Config.ashx?action=SaveConfig',
        data: {
            ConfigValue: Result,
            ConfigURL: ConfigURL
        },
        success: function (result) {
            layer.close(loadIndex);
            layer.msg(result);
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！0158");
        }
    });

}