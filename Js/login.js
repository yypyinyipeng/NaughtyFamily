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
                    alert(data.Msg);
                    return true;
                }
                if (data.Statu = "NOK") {
                    alert(data.Msg);
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
        var registerRePwd = $("#get-register-repwd").val();
        if (registerName != "" && registerPwd != "" && registerRePwd != "") {
            var registerName = registerName.toString();
            var registerPwd = registerPwd.toString();
            $.ajax({
                url: "/Home/userRegister",
                type: "post",
                data: { "registerName": registerName, "registerPwd": registerPwd }
            }).done(function (data) {
                if (data.Statu == "OK") {
                    alert(data.Msg);
                    return true;
                }
                else {
                    alert(data.Msg);
                    return false;
                }
            });
        }
        else {
            alert("请填写信息!");
        }
    });

    $("#signin-submit").click(function () {
        var signinName = $("#get-signin-name").val();
        var signinPwd = $("#get-signin-pwd").val();

        if (signinName == "") {
            alert("用户名不能为空!");
            return false;
        }
        if (signinPwd == "") {
            alert("密码不能为空！");
            return false;
        }
        $.ajax({
            url: "/Home/userSignIn",
            type: "post",
            data: { "signinName": signinName, "signinPwd": signinPwd }
        }).done(function (data) {
            if (data.Statu == "OK") {
                alert(data.Msg);
                return true;
            }
            if (data.Statu == "NOK") {
                alert(data.Msg);
            }
        });
    });

});
