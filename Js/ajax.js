var lock = false;
var page = 0;


function lodaData() {
    if (lock) {
        return;
    }
    else
    {
        $("#get-more").text("正在拼命加载中......");
        lock = true;
        $.ajax({
            url: "/Home/Index",
            type: "post",
            data: { "page": page }
        }).done(function (data) {
            if (data.Statu == "end")
            {
                $("#get-more").html(data.Msg);
                return false;
            }
            if (data.Statu == "OK")
            {
                var str = "";
                for (var dataLength = 0; data.Data.length; dataLength++)
                {
                    str += "";
                }
                $("#container").append(str);
                $("#get-more").html(data.Msg);
            }
            if (data.Data.length == 4) {
                lock = false;
                page++;
            }
            else
            {
                $("#get-more").html("没有更多内容了！");
            }
        });
    }
}

$(document).ready(function () {
    loadData();
    $(window).scroll(function () {
        totalHeight = parseFloat($(window).height()) + parseFloat($(window).scrollTop())
        if ($(document).height() <= totalHeight)
            loadData();
    });
});