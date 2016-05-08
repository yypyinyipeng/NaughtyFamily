$(document).ready(function () {

    $("#get-register-name").blur(function () {
        var registerName = $("#get-register-name").val();
        $.ajax({
            url: "/Home/userRegister",
            type: "post",
            data: { "registerName": registerName }
        }).done(function (data) {
            if (data.Statu == "OK")
            {
                alert("该用户名可以使用");
            }
            if (data.Statu = "NOK")
            {
                alert("该用户名已被使用");
            }
        });
    });

});
