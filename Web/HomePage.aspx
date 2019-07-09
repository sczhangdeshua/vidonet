<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Maticsoft.Web.HomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=NetName %>-首页</title>
    <link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/pageBarStyle.css" rel="stylesheet" />
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/HomePage.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/layer/layer.js"></script>
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="My Show Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <script src="js/system.js"></script>
    <link href="css/megamenu.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="js/megamenu.js"></script>
    <script>$(document).ready(function () { $(".megamenu").megamenu(); });</script>
    <script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default',
                width: 'auto',
                fit: true
            });
        });
    </script>

    <link rel="stylesheet" href="css/menu.css" />
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1200);
            });
        });
    </script>
    <style>
        .divButton {
            border: 1px solid #A6D2FF;
            height: 30px;
            float: left;
            background-color: #FFF;
            padding: 5px 8px 8px 8px;
            margin: 3px;
            cursor: pointer;
            text-align: center;
        }

            .divButton:hover {
                background-color: #D2E9FF;
                border-color: #39F;
            }
    </style>

</head>
<body>
    <div class="header-top-strip" id="home">
        <div class="container">
            <div class="header-top-left">
                <p><a href="javascript:void(0)">欢迎来到<%=NetName %></a> </p>
                <div id="small-dialog" class="mfp-hide">
                </div>
            </div>
            <div class="header-top-right">
                <a onclick="reward()" style="cursor: pointer">打赏站长</a>
                <link href="css/popuo-box.css" rel="stylesheet" type="text/css" media="all" />
                <script src="js/jquery.magnific-popup.js" type="text/javascript"></script>

                <script>
                    $(document).ready(function () {
                        $('.popup-with-zoom-anim').magnificPopup({
                            type: 'inline',
                            fixedContentPos: false,
                            fixedBgPos: true,
                            overflowY: 'auto',
                            closeBtnInside: true,
                            preloader: false,
                            midClick: true,
                            removalDelay: 300,
                            mainClass: 'my-mfp-zoom-in'
                        });

                    });
                </script>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="container">
            <div class="main-content ">
                <div class="header">
                    <div class="logo">
                        <a href="index.html">
                            <h1><a href="HomePage.aspx"><%=NetName %></a></h1>
                        </a>
                    </div>
                    <div class="top-search ">
                        <form class="navbar-form navbar-right">
                            <input id="textSearch" type="text" class="form-control" placeholder="请搜索你想要的" />
                            <input type="button" value="搜索" style="width: 70px; height: 30px" class="glyphicon glyphicon-ok form-control-feedback " onclick="Search()" />
                        </form>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="bootstrap_container">
                    <nav class="navbar navbar-default w3_megamenu" role="navigation">
                        <div class="navbar-header">
                            <button type="button" data-toggle="collapse" data-target="#defaultmenu" class="navbar-toggle"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                            <a href="index.html" class="navbar-brand"></a>
                        </div>

                        <div id="defaultmenu" class="navbar-collapse collapse">
                            <ul class="nav navbar-nav">
                                <li class="dropdown w3_megamenu-fw"><a data-toggle="dropdown" class="dropdown-toggle" onclick="Tv('OpenTv','f070d276-f807-408e-8a00-df7cc248ac92')">电影</a>
                                </li>
                                <li class="dropdown w3_megamenu-fw"><a data-toggle="dropdown" class="dropdown-toggle" onclick="Tv('OpenTv','0d4e1ba8-6b8d-438e-a7f0-50b68e8fd406')">电视剧</a>
                                </li>
                                <li class="dropdown w3_megamenu-fw"><a data-toggle="dropdown" class="dropdown-toggle" onclick="Tv('OpenTv','53d91043-4c9d-4ecb-b10e-876001c8d0e4')">动漫</a>
                                </li>
                                <li class="dropdown w3_megamenu-fw"><a data-toggle="dropdown" class="dropdown-toggle" onclick="Tv('OpenTv','490a0935-0cc6-4943-9ed4-2a87a943c733')">其它</a>
                                </li>
                            </ul>

                        </div>
                    </nav>
                </div>
            </div>
            <div class="trailers-now-showing" id="divTvList">
                <script>
                    Tv('OpenTv', 'f070d276-f807-408e-8a00-df7cc248ac92');
                </script>
            </div>
            <script>
                window.onresize = res;
                function res() {
                    var temp = document.documentElement.clientWidth
                    var Imgh = document.getElementsByClassName("ImgH");
                    if ( temp < 600) {
                        
                        for (var i = 0; i < Imgh.length; i++) {
                            Imgh[i].style.height = "100px";
                        }
                    }
                    if(temp>600)
                    {
                        for (var i = 0; i < Imgh.length; i++) {
                            Imgh[i].style.height = "210px";
                        }
                    }
                }
            </script>

            <div class="footer">
                <span>免责声明：本网站所有内容都是靠程序在互联网上自动搜集而来，仅供测试和学习交流。</span><br />
                <span>本站所有资源均收集自互联网，没有提供影片资源存储，也未参与录制、上传</span>
                <br />
                <span>目前正在逐步删除和规避程序自动搜索采集到的不提供分享的版权影视 </span>
                <br />
                <span>若侵犯了您的权益，《请提供相关版权文件》发邮件通知站长，我们将在24小时内处理,站长邮箱：1797716952@qq.com</span><br />
                <div class="clearfix"></div>
            </div>
</body>
</html>
 <script>
     setTimeout('Yan()', 3000);
     function Yan() {
         var temp = document.documentElement.clientWidth
         var Imgh = document.getElementsByClassName("ImgH");
         if (temp < 600) {
             for (var i = 0; i < Imgh.length; i++) {
                 Imgh[i].style.height = "100px";
             }
         }
         if (temp > 600) {
             for (var i = 0; i < Imgh.length; i++) {
                 Imgh[i].style.height = "210px";
             }
         }
     }
   
</script>
