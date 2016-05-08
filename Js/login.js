$(document).ready(function () {

    $("#get-register-name").blur(function () {
        var registerName = $("#get-register-name").val();
        if (registerName != "") {
            $.ajax({
                url: "/Home/userRegister",
                type: "post",
                data: { "registerName": registerName }
            }).done(function (data) {
                if (data.Statu == "OK") {
                    alert("该用户名可以使用");
                    return true;
                }
                if (data.Statu = "NOK") {
                    alert("该用户名已被使用");
                }
            });
        }
        else {
            $('#111').popover('show')
            //alert("用户名不能为空！");
            return false;
        }
    });

});
