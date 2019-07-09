//判断是什么支付
function Pay() {
    var arrtPay = document.getElementsByName('pay');
    var payLength = arrtPay.length;
    for (var i = 0; i < payLength; i++) {
        if (arrtPay[i].checked ==true)
        {
            switch (i)
            {
                case 0:
                    document.getElementById('imgTwoWeiMa').src = "images/WeChatErWeima.png"; //微信二维码
                    break;
                case 1:
                    document.getElementById('imgTwoWeiMa').src = "images/QQZF.jpg"; //QQ二维码
                    break;
                case 2:
                    document.getElementById('imgTwoWeiMa').src = "images/zfberweima.jpg"; //支付宝二维码
                    break;
                default:
                    document.getElementById('imgTwoWeiMa').src = "";  //无二维码
                    break;
            }
        }
    }
}
//判断是否正确输入
function inputMoney() {
    var Money = document.getElementById('zfys').value;
    var reg = /^\d+$/;
    if(reg.test(Money))
    {
        if (Money > 999)
        {
            document.getElementById('zfys').value = "999";
        }
    }else
    {
        document.getElementById('zfys').value="1";
    }
}
//减月数
function reduce() {
    if (document.getElementById('zfys').value<=0.01)
    {
        document.getElementById('zfys').value = 0.01;
    }
    else
    {
        document.getElementById('zfys').value = document.getElementById('zfys').value - 1;
    }
}
//加月数
function add() {
    if(document.getElementById('zfys').value>=999)
    {
        document.getElementById('zfys').value = 999;
    }else
    {
        var tmp =parseInt(document.getElementById('zfys').value);
        document.getElementById('zfys').value = tmp + 1;
    }
}