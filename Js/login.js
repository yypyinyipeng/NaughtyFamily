$(document).ready(function () {

    $("#get-register-name").blur(function () {
        var registerName = $("#get-register-name").val();
        if (registerName != "") {
            var registerName = registerName.toString();
            $.ajax({
                url: "/Home/checkRegister",
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
            alert("用户名不能为空！");
            return false;
        }
    });

    $("#get-register-pwd").blur(function () {
        var registerPwd = $("#get-register-pwd").val();
        if (registerPwd == "") {
            alert("密码不能为空!");
            return false;
        }
    });

    $("#get-register-repwd").blur(function () {
        var registerRePwd = $("#get-register-repwd").val();
        var registerPwd = $("#get-register-pwd").val();
        if (registerRePwd != registerPwd) {
            alert("重复密码输入的不一致!");
            return false;
        }
    });

    $("#register-submit").click(function () {
        var registerName = $("#get-register-name").val();
        var registerPwd = $("#get-register-pwd").val();
        $.ajax({
            url: "/Home/userRegister",
            type: "post",
            data: { "registerName": registerName, "registerPwd": registerPwd }
        }).done(function (data) {
            if (data.Statu == "OK") {
                alert("注册成功!");
                return true;
            }
            else {
                alert("注册失败");
                return false;
            }
        });
    });



});
