let BId; //Globle varivale
$(function () {
    BId = window.location.search.substring(1);
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
            "<td>" + s.antallStock + "</td>" +
            "<td>" + s.endring + "</td>" +
            "<td>" + s.sistePrise + "</td>" +
            "<td>" + s.volume + "</td>" +
            "<td> <a type='button' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#kjope' onclick='lagreSId(" + s.sId + ")'>Kjøpe</a></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#Stocks").html(ut);
}
function lagreSId(SId) {
    $("#SId").val(SId);
    $("#BId").val(BId);
}

function KjopeStock() {
    const url = "Stock/kjopestocks"
    const brukerStock = {
        antallstock: $("#antallStocks").val(),
        DateAndTime: $("#datoTid").val(),
        BId: $("#BId").val(),
        SId: $("#SId").val()
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
function minStock() {
    if (BId != null) {
        window.location.href = 'BrukerStocks.html?' + BId;
    }
    else {
        $("#feilLogin").hmtl("Du må logg deg inn først!")
    }
}