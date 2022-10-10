$(function () {
    const id = window.location.search.substring(1);
    const url = "Stock/hentEnStock?" + id;
    $.get(url, function (stock) {
        $("#SId").val(stock.sId);
        $("#Tegn").val(stock.tegn);
        $("#SelskapNavn").val(stock.selskapNavn);
        $("#AnatallStock").val(stock.antallStock);
        $("#Endring").val(stock.endring);
        $("#SistePrise").val(stock.sistePrise);
        $("#volume").val(stock.volume);
    }); 
});
//new Stock { AnatallStock = 50, Endring = 0.5, SelskapNavn = "OSLO AS", SistePrise = 12.4, Tegn = "OSA", volume = 2.8 };
/*
function validerOgEndreKunde() {
    const fornavnOK = validerFornavn($("#fornavn").val());
    const etternavnOK = validerEtternavn($("#etternavn").val());
    const adresseOK = validerAdresse($("#adresse").val());
    const postnrOK = validerPostnr($("#postnr").val());
    const poststedOK = validerPoststed($("#poststed").val());
    if (fornavnOK && etternavnOK && adresseOK && postnrOK && poststedOK) {
        endreKunde();
    }
}
*/

function EndreStock() {
    const stock = {

        SId: $("#SId").val(), 
        Tegn: $("#Tegn").val(),
        SelskapNavn: $("#SelskapNavn").val(),
        AntallStock: $("#AnatallStock").val(),
        Endring: $("#Endring").val(),
        SistePrise: $("#SistePrise").val(),
        volume: $("#volume").val()
    };
    $.post("Stock/endreStock", stock, function () {
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

