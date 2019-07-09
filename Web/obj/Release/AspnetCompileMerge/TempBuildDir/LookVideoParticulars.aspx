<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookVideoParticulars.aspx.cs" Inherits="Maticsoft.Web.LookVideoParticulars" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=NetName %>-播放</title>
    <link href="css/bootstrap.css" rel='stylesheet' type='text/css' media="all" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="js/jquery-3.1.1.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/HomePage.js"></script>
    <script src="js/LookVideoParticulars.js"></script>
    <script src="js/layer/layer.js"></script>
    <%--<meta name="viewport" content="width=device-width, initial-scale=1" />--%>
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="My Show Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="css/megamenu.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="js/megamenu.js"></script>
    <script>$(document).ready(function () { $(".megamenu").megamenu(); });</script>
    <script type="text/javascript" src="js/jquery.leanModal.min.js"></script>
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link rel="shortcut icon" href="images/e2b80f83d68664dcd85cd4bc89c3a6dc.png" />
    <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
    <script>
        window.onload = function () {
            var temp = document.documentElement.clientWidth
            var Imgh = document.getElementById("divVideo");
            if (temp < 600) {
                Imgh.style.height = "200px";
            }
            if (temp > 600) {
                Imgh.style.height = "500px";
            }
        }

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

        video {
            position: fixed;
            right: 0px;
            bottom: 0px;
            min-width: 100%;
            min-height: 100%;
            height: auto;
            width: auto;
            /*加滤镜*/
            -webkit-filter: grayscale(100%);
            filter: grayscale(100%);
        }

        source {
            min-width: 100%;
            min-height: 100%;
            height: auto;
            width: auto;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion           
                width: 'auto', //auto or any width like 600px
                fit: true   // 100% fit in a container
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
</head>
<body>
    <marquee direction="left" style="color: red">本站不会向个人收取任何费用。加QQ群272757417找群主拿取免费账号</marquee>
    <div class="header-top-strip" id="home">
        <div class="container">
            <div class="header-top-left">
                <p><a href="HomePage.aspx">首页</a> </p>
                <div id="small-dialog" class="mfp-hide">
                </div>
            </div>
            <div class="header-top-right">
                <a onclick="ifAccess()" style="cursor: pointer">打赏站长</a>
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
                                <li class="dropdown w3_megamenu-fw"><a href="/HomePage.aspx">首页</a>
                                </li>
                            </ul>
                        </div>
                    </nav>
                    <!-- end navbar navbar-default w3_megamenu -->
                </div>
                <!-- end container -->

                <!-- AddThis Smart Layers END -->
                <!----->
                <div class="m-single-article">
                    <div id="divVideo" style="height:500px;width:100%;">
                        <iframe  width="100%" height="100%"  src="<%=Interface %><%=DXS %>"></iframe>
                    </div>
                    <div id="J" style="width: 100%; height: auto; border: 1px solid gray;" runat="server">
                    </div>
                    <div class="review-info">
                        <p class="info"><strong>名称</strong>: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span><%=NameVideo %></span></p>
                        <p class="info"><strong>视频简介</strong>: <span><%=VideoConent %></span></p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="footer">
                <span>免责声明：本网站所有内容都是靠程序在互联网上自动搜集而来，仅供测试和学习交流。</span><br />
                <span>本站所有资源均收集自互联网，没有提供影片资源存储，也未参与录制、上传 </span>
                <br />
                <span>目前正在逐步删除和规避程序自动搜索采集到的不提供分享的版权影视 </span>
                <br />
                <span>若侵犯了您的权益，《请提供相关版权文件》发邮件通知站长，我们将在24小时内处理,站长邮箱：1797716952@qq.com</span><br />
            </div>
        </div>
        <div style="display: none">
            <div id="hd" runat="server">
            </div>
        </div>
</body>
</html>

 <script>
     window.onresize = res;
     function res() {
         var temp = document.documentElement.clientWidth
         var Imgh = document.getElementById("divVideo");
         if (temp < 600) {
                 Imgh.style.height = "170px";
         }
         if (temp > 600) {
                 Imgh.style.height = "500px";
         }
     }
 </script>
