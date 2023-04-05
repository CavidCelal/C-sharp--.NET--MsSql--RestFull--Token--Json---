function Login() {
    var Username = document.getElementById('TxtUsername').value;
    var Password = document.getElementById('TxtPassword').value;
    if (Username === '' || Password === '') {
        ShowAlert('info', 'Hata', 'Her iki alanı doldurun');
    }
    else {
        $.ajax({
            url: "/Api/Login",
            success: function (result, e, f) {
                if (f.status === 200) {
                    if (result != "") {
                        window.location.href = "/Panel/IndexPanel";
                    }
                }
                else {
                    ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
                }
            },
            data: { "Username": Username, "Password": Password },
            method: "POST"
        }).done(function (result, e, f) {
            var f = result;
        }).fail(function (result, e, f) {
            if (result.status === 500) {
                ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
            }
        }).catch(function (result, e, f) {
            var h = result;
        }).progress(function (result, e, f) {
            var y = result;
        });

    }

}

function GetLoginUserDetail() {
    $.ajax({
        url: "/Api/GetLoginUserDetail",
        success: function (result, e, f) {
            if (f.status === 200) {
                var LblNameSurname = document.getElementById('LblNameSurname');
                LblNameSurname.innerHTML = "<b>" + result.Ad + " " + result.Soyad + "</b>"; 
                var LblTitle = document.getElementById('LblTitle');
                LblTitle.innerText = result.Unvan;
                var LblWelcome = document.getElementById('LblWelcome');
                LblWelcome.innerText = "Merhaba " + result.Ad + " " + result.Soyad;
            }
            else {
                ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
            }
        },
        method: "GET"
    }).done(function (result, e, f) {
        var f = result;
    }).fail(function (result, e, f) {
        if (result.status === 500) {
            ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
        }
    }).catch(function (result, e, f) {
        var h = result;
    }).progress(function (result, e, f) {
        var y = result;
    });

}

//success - error - warning - info - question
function ShowAlert(picon, ptitle, ptext) {

    Swal.fire({
        icon: picon,
        title: ptitle,
        text: ptext
    });

}