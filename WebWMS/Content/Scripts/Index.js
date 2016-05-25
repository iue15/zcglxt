//样式
function readyIndex() {
    $(".main_menu li div").click(function () {
        $(".main_menu li div").removeClass('main_menu leftselected');
        $(this).addClass('main_menu leftselected');
    }).hover(function () {
        $(this).addClass("hoverleftselected");
    }, function () {
        $(this).removeClass("hoverleftselected");
    });
}
/**安全退出**/
function IndexOut() {
    var msg = "<div class='ui_alert'>确认要退出资产管理系统？</div>"
    top.$.dialog({
        id: "confirmDialog",
        lock: true,
        icon: "hits.png",
        content: msg,
        title: "提示",
        button: [
        {
            name: '退出',
            callback: function () {
                Loading(true, "正在退出系统...");
                window.setTimeout(function () {
                    window.opener = null;
                    var wind = window.open('', '_self');
                    wind.close();
                }, 200);
            }
        },
        {
            name: '注销',
            callback: function () {
                Loading(true, "正在注销系统...");
                window.setTimeout(function () {
                    //window.location.href = '/Index.htm';
                    window.location.href = '/Login/Index';//dong
                }, 200);
            }
        },
        {
            name: '取消'
        }
        ]
    });
}
