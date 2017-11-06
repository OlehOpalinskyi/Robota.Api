$(function () {
    var baseUrl = 'http://localhost:58665/';
    $('#login').click(function () {
        var name = $('#login-name').val();
        var pass = $('#login-pass').val();
        var obj = {
            grant_type: 'password',
            username: name,
            password: pass
        }
        $.ajax({
            url: baseUrl + 'token',
            method: 'post',
            data: obj,
            error: function (jqXHR) {
                alert(jqXHR.responseJSON.error_description);
            },
            success: function (data) {
                var token = 'Bearer ' + data.access_token;
                localStorage.setItem('token', token);
                window.location.replace("index.html");
            }
        })
    });
});