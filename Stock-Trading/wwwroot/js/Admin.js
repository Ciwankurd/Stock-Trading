$(function() {
    hentAlleStocks();
});


function hentAlleStocks() {

    $.get("Stock/hentAlleStocks", function (stocks) {
        console.log(stocks)
        formaterStocks(stocks);
    })
        .fail(function (feil) {
            if (feil.status == 401) {
                window.location.href = 'loggInn.html'; // ikke logget inn, redirect til loggInn.html
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}


function formaterStocks(stocks) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>SId</th><th>Tegn</th><th>Selskap</th><th>Antall Stock</th><th>Endring</th><th>Siste Pirse</th><th>Volume</th>" +
        "</tr>";
    for (let s of stocks) {
        ut += "<tr>" +
            "<td>" + s.sId + "</td>" +
            "<td>" + s.tegn + "</td>" +
            "<td>" + s.selskapNavn + "</td>" +
            "<td>" +s.antallStock  + "</td>" +
            "<td>" + s.endring + "</td>" +
            "<td>" + s.sistePrise + "</td>" +
            "<td>" + s.volume + "</td>" +
            "<td> <a class='btn btn-primary'  href='endre.html?SId=" + s.sId + "'>Endre</a></td>" +
            "<td> <button class='btn btn-danger' onclick='slettStock(" + s.sId + ")'>Slett</button></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#Stocks").html(ut);
}

function slettStock(id) {
    const url = "Stock/slettStock?SId=" + id;

    $.get(url, function () {
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