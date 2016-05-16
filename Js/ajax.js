var lock = false;
var page = 0;

function ChangeDateFormat(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }

    return "";
}

function loadData() {
    if (lock) {
        return;
    }
    else {
        $("#get-more").text("正在拼命加载中......");
        lock = true;
        $.ajax({
            url: "/Home/Index",
            type: "post",
            data: { "page": page }
        }).done(function (data) {
            if (data.Statu == "end") {
                $("#get-more").html(data.Msg);
                return false;
            }
            if (data.Statu == "OK") {
                var str = "<div class=’news-grids’>";
                for (var i = 0; i < data.Data.length; i++) {
                    str += "<div class='col-md-3 news-grid wow bounceIn animated'data-wow-delay='0.4s'style='visibility: visible; -webkit-animation-delay: 0.4s;'><a href='/Home/Detail?id='" + data.Data[i].PId + "'>Pet Name:" + data.Data[i].pet_name + "</a><span>Update date:" + ChangeDateFormat(data.Data[i].update_date) + "</span><a class='mask' href=/Home/Detail?id=" + data.Data[i].PId + "><img src=/" + data.Data[i].pet_pic_url + " class='img-responsive zoom-img' alt='' /></a><div class='news-info'><p>" + data.Data[i].pet_sumamry + "</p><a class='button' href='#'></a></div></div>";
                }
                str = str + "<div class='clearfix'></div></div>";
                $("#container").append(str);
                $("#get-more").html(data.Msg);
            }
            if (data.Data.length == 4) {
                lock = false;
                page++;
            }
            else {
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