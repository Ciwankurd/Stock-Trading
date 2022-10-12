function Brukerlogin() {
    const Bruker = {
        brukernavn: $("#brukernavn").val(),
        password: $("#pass").val(),
    }
    const url = "Stock/logginn";
    $.get(url, Bruker, function (BId) {
        window.location.href = 'index.html?'+BId;
    })
        .fail(function (feil) {
            if (feil.status == 401) {  // ikke logget inn, redirect til loggInn.html
                window.location.href = 'login.html';
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}
function Adminlogin() {
    const Bruker = {
        brukernvan: $("#Adminnavn").val(),
        password: $("#Adminpass").val(),
    }
    const url = "Stock/logginn";
    $.get(url, Bruker, function (OK) {
        window.location.href = 'Admin.html';
    })
        .fail(function (feil) {
            if (feil.status == 401) {  // ikke logget inn, redirect til loggInn.html
                window.location.href = 'login.html';
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}
function RegistereBruker() {
    const Bruker = {
        brukernavn: $("#Bnavn").val(),
        password: $("#Bpass").val(),
    }
    const url = "Stock/registereBruker";
    $.get(url, Bruker, function (OK) {
        window.location.href = 'login.html';
    })
        .fail(function (feil) {
            if (feil.status == 401) {  // ikke logget inn, redirect til loggInn.html
                window.location.href = 'login.html';
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}