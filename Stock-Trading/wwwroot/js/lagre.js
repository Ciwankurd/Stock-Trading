function LagreStock() {
    const stock = {

        SId: $("#SId").val(),
        Tegn: $("#Tegn").val(),
        SelskapNavn: $("#SelskapNavn").val(),
        AntallStock: $("#AnatallStock").val(),
        Endring: $("#Endring").val(),
        SistePrise: $("#SistePrise").val(),
        volume: $("#volume").val()
    };
    $.post("Stock/lagreStock", stock, function () {
        window.location.href = 'Admin.html';
    })
        .fail(function (feil) {
            if (feil.status == 401) {  // ikke logget inn, redirect til loggInn.html
                window.location.href = 'loggInn.html';
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}

