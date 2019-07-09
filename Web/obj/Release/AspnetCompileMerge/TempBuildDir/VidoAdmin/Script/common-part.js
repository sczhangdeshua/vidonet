/**
 * Created by Administrator on 2016/11/25.
 */
/*轮播*/
$(document).ready(function () {
    $(".zixun_r").click(function () {
        if ($(".zixun_l").css("left") == "0px") {
            $(".zixun_l").css("left", "-115px");
            $(this).css("left", "0").html(" 在线客服>>");
        } else {
            $(".zixun_l").css("left", "0");
            $(this).css("left", "113px").html(" 在线客服<<");
        }
    });
    var length, currentIndex = 0, interval, hasStarted = false, //是否已经开始轮播
        t = 3000; //轮播时间间隔
    length = $('.slider-panel').length;//将除了第一张图片隐藏
    $('.slider-panel:not(:first)').hide();//将第一个slider-item设为激活状态
    $('.slider-item:first').addClass('slider-item-selected');//隐藏向前、向后翻按钮
    $('.slider-page').hide();//初始化隐藏向前、向后翻按钮
    $('.slider-panel, .slider-pre, .slider-next').hover(function () {
        stop();
        $('.slider-page').show();
    }, function () {
        start();
        $('.slider-page').hide();
    });
    $('.slider-item').hover(function () {
        stop();
        var preIndex = $(".slider-item").filter(".slider-item-selected").index();
        currentIndex = $(this).index();
        play(preIndex, currentIndex);
    }, function () {
        start();
    });
    $('.slider-pre').on('click', function () {
        pre();
    });
    $('.slider-next').on('click', function () {
        next();
    });
    /* 向前翻页*/
    function pre() {
        var preIndex = currentIndex;
        currentIndex = (--currentIndex + length) % length;
        play(preIndex, currentIndex);
    }
    /*向后翻页*/
    function next() {
        var preIndex = currentIndex;
        currentIndex = ++currentIndex % length;
        play(preIndex, currentIndex);
    }
    //从preIndex页翻到currentIndex页 preIndex 整数，翻页的起始页  currentIndex 整数，翻到的那页
    function play(preIndex, currentIndex) {
        $('.slider-panel').eq(preIndex).fadeOut(500)
            .parent().children().eq(currentIndex).fadeIn(800);
        $('.slider-item').removeClass('slider-item-selected');
        $('.slider-item').eq(currentIndex).addClass('slider-item-selected');
    }
    //开始轮播
    function start() {
        if (!hasStarted) {
            hasStarted = true;
            interval = setInterval(next, t);
        }
    }
    //停止轮播
    function stop() {
        clearInterval(interval);
        hasStarted = false;
    }
    //开始轮播
    start();
});

