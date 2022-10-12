$(function () {
    HentBrukerStocks();
});


function HentBrukerStocks() {
    BId = window.location.search.substring(1);
    const url = "Stock/HentBrukerStocks?BId=" + BId;
    $.get(url, function (BS) {
        console.log(BS);
        formaterStocks(BS);
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




function formaterStocks(BS) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>BID</th><th>Owner</th><th>Stock ID</th><th>Tegn</th><th>Selskap</th><th>Antall Stock</th><th>Dato/Tid</th><th>Endring</th><th>Siste Pirse</th><th>Volume</th>" +
        "</tr>";
    for (let i = 0; i < BS.length; i++) {
        console.log(BS[0].bruker.bId);
        ut += "<tr>" +
            "<td>" + BS[i].bruker.bId + "</td>" +
            "<td>" + BS[i].bruker.brukernavn + "</td>" +
            "<td>" + BS[i].stock.sId + "</td>" +
            "<td>" + BS[i].stock.tegn + "</td>" +
            "<td>" + BS[i].stock.selskapNavn + "</td>" +
            "<td>" + BS[i].antallstock + "</td>" +
            "<td>" + BS[i].dateAndTime + "</td>" +
            "<td>" + BS[i].stock.endring + "</td>" +
            "<td>" + BS[i].stock.sistePrise + "</td>" +
            "<td>" + BS[i].stock.volume + "</td>" +
            "<td> <a type='button' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#selge' onclick='lagreSId(" + BS[i].bsId + ")'>Selge</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#Stocks").html(ut);
}


function lagreSId(bsId) {   
    $("#bSId").val(bsId);     
}
function selgeStock() {
    const url = "Stock/slegeStocks"
    const brukerStock = {
        antallstock: $("#antallStocks").val(),
        DateAndTime: $("#datoTid").val(),
        BSId: $("#bSId").val()
    }
    $.post(url, brukerStock, function (ok) {
        window.location.href = 'BrukerStocks.html?' + BId;
        console.log(ok)
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
