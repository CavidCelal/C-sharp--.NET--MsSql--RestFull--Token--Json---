

function DoTest() {

    $.ajax({
        url: "/Home/GetTest",
        success: function (result, e, f) {
            if (f.status === 200) {
                alert(result);
                document.getElementById('LblDataResult').innerText = result;
            }
            else {
                alert("Bir hata meydana geldi.");
            }
        },
        data: { "Key": "value", "Key": "value" },
        method: "GET"
    }).done(function (result, e, f) {
        var f = result;
    }).fail(function (result, e, f) {
        var g = result;
    }).catch(function (result, e, f) {
        var h = result;
    }).progress(function (result, e, f) {
        var y = result;
    });

}


function DoPostTest() {

    $.ajax({
        url: "/Home/PostTest",
        success: function (result, e, f) {
            if (f.status === 200) {
                alert(result);
            }
            else {
                alert("Bir hata meydana geldi.");
            }
        },
        data: { "Name": "Tunç", "Surname": "Güleç" },
        method: "POST"
    }).done(function (result, e, f) {
        var f = result;
    }).fail(function (result, e, f) {
        var g = result;
    }).catch(function (result, e, f) {
        var h = result;
    }).progress(function (result, e, f) {
        var y = result;
    });

}


function DoTestRestFull() {

    $.ajax({
        url: "https://localhost:44355/Api/Token/12",
        success: function (result, e, f) {
            if (f.status === 200) {
                alert(result);
            }
            else {
                alert("Bir hata meydana geldi.");
            }
        },        
        method: "GET"
    }).done(function (result, e, f) {
        var f = result;
    }).fail(function (result, e, f) {
        var g = result;
    }).catch(function (result, e, f) {
        var h = result;
    }).progress(function (result, e, f) {
        var y = result;
    });

}
