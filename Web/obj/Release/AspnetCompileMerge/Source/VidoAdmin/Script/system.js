/******公共方法******/
function Ltrim(_string) {
    //功能：去掉字串左边的空格
    if (_string != null) {
        return _string.replace(/^( +)/g, "");
    } else {
        return "";
    }
}
function Rtrim(_string) {
    //功能：去掉字串右边的空格
    if (_string != null) {
        return _string.replace(/( +)$/g, "$1");
    } else {
        return "";
    }
}
function Trim(_string) {
    //功能：去掉字串两端的空格
    if (_string != null) {
        return _string.replace(/( +)$/g, "").replace(/^( +)/g, "");
    } else {
        return "";
    }
}
function QueryString(_QueryStringKey) {
    //功能：返回指定URL参数的值
    //语法：QueryString(string URL参数名称)
    var reg = new RegExp("(^|&)" + _QueryStringKey + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return "";
}
function cookie(_cookieKey, _cookieValue) {
    //功能：返回或设置指定cookie的值
    //语法：cookie(string cookie键名称，string cookie键值)
    //说明：在返回cookie值时，如果找不到指定的cookie，返回空字符串""；在设置cookie值时，如果指定键值已存在，则覆盖旧值，若键值不存在，则新建键值并赋值
    if (_cookieValue == null) {
        //仅有_cookieKey参数，返回指定cookie的值
        if (document.cookie.length > 2) {
            var _cookieValue = "";
            var _cookieItem = document.cookie.split(";");
            for (var i = 0; i <= _cookieItem.length - 1; i++) {
                var _cookieKeyTemp = Trim(_cookieItem[i].split("=")[0]);
                var _cookieValueTemp = Trim(_cookieItem[i].split("=")[1]);
                if (_cookieKeyTemp == _cookieKey) {
                    _cookieValue = _cookieValueTemp;
                    break;
                } else {
                    _cookieValue = "";
                }
            }
        } else {
            _cookieValue = "";
        }
        return _cookieValue;
    } else {
        //转入_cookieValue参数，设置指定cookie的值
        document.cookie = _cookieKey + "=" + _cookieValue;
        return _cookieValue;
    }
}
function SetCheckBoxState(TargetCheckBoxName, SourceCheckBoxId) {
    //功能：设置复选框的全选/全不选状态
    //语法：SetCheckBoxState(目标复选框的Name, 源复选框的Id) {
    var SourceCheckBoxState = document.getElementById(SourceCheckBoxId).checked;
    var TargetChkBoxList = document.getElementsByName(TargetCheckBoxName);
    for (var i = 0; i < TargetChkBoxList.length; i++) {
        TargetChkBoxList[i].checked = SourceCheckBoxState;
    }
}
function GetCheckBoxValue(CheckBoxName) {
    //功能：返回复选框的选定值字符串
    //语法：GetCheckBoxValue(CheckBoxName)
    var result = "";
    var ChkBoxList = document.getElementsByName(CheckBoxName);
    for (var i = 0; i < ChkBoxList.length; i++) {
        if (ChkBoxList[i].checked == true) {
            result += ChkBoxList[i].value + ",";
        }
    }
    result = result.substring(0, result.length - 1);
    return result;
}
function GetRadioValue(_radioName) {
    //功能：返回单选框的选定值value值字符串
    //语法：getRadioValue(一组单选框的name属性值)
    //说明：注意将同一组单选框的name属性设置为相同的，可以不用设置id值
    var _rdo = document.getElementsByName(_radioName);
    for (var i = 0; i < _rdo.length; i++) {
        if (_rdo[i].checked) {
            return _rdo[i].value.toString();
        }
    }
}
function GetMoneyValue(_price)
    //功能：返回统一的货币元角分厘格式，123.000，直接去掉超出的小数位，不作四舍五入
{
    var _result = "0.000";
    if (_price > 0) {
        if (_price == parseInt(_price)) {//成交价为整数，直接加.00
            _result = _price + ".000";
        }
        else {//成交价带有小数
            _result = _price + "0";
            _result = _result.split('.')[0] + "." + _result.split('.')[1].substring(0, 3);
        }
    }
    return _result;
}
function CloseLayerWindow() {
    //功能：关闭由Layer弹出的小窗口
    var layerWindowIndex = parent.layer.getFrameIndex(window.name);//获取窗口索引
    parent.layer.close(layerWindowIndex); //关闭主窗体
}
function GotoPage(PagePosition, Table) {
    //功能：对列表进行分页
    //语法：GotoPage(页面定位, 分页表名) 
    var loadIndex = layer.load();
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/VidoAdmin/ashx/Video.ashx?action=GotoPage',
        data: {
            PagePosition: PagePosition,
            Table: Table,
        },
        success: function (result) {
            layer.close(loadIndex);
            document.getElementById("div" + Table + "List").innerHTML = result;
            return;
        },
        error: function (result) {
            layer.close(loadIndex);
            layer.msg("服务器错误，请重试！0122");
        }
    });
}
/******公共方法end******/
