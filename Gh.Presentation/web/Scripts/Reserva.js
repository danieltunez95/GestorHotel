function siguientePlanta() {
    PLANTA++;

    CheckArrows();
    Restart();
    PrintHotel(PLANTA);
}

function anteriorPlanta() {
    PLANTA--;

    CheckArrows();
    Restart();
    PrintHotel(PLANTA);
}


function CheckArrows() {
    if (PLANTA == ULTIMA_PLANTA)
        document.getElementById("arrowUp").style.visibility = "hidden";
    else
        document.getElementById("arrowUp").style.visibility = "visible";

    if (PLANTA == 0)
        document.getElementById("arrowDown").style.visibility = "hidden";
    else
        document.getElementById("arrowDown").style.visibility = "visible";
}

function PrintHotel(planta) {
    for (var i = 0; i < HOTEL.length; i++) {
        var habitacion = HOTEL[i].replace("[", "").replace("]", "").split(",");
        if (habitacion[0] == planta) {
            document.getElementById(habitacion[2] + "_" + habitacion[1]).setAttribute("onClick", "Reenviar(this.id)");
            if (habitacion[3] == 0)
                document.getElementById(habitacion[2] + "_" + habitacion[1]).setAttribute("class", "celda libre");
            else
                document.getElementById(habitacion[2] + "_" + habitacion[1]).setAttribute("class", "celda ocupada");

        }

    }
    //muestro la flecha hacia arriba
    if (PLANTA != ULTIMA_PLANTA)
        document.getElementById("arrowUp").style.visibility = "visible";
}

function Restart() {
    //oculto todo
    for (var x = 0; x <= LARGO; x++) {
        for (var y = 0; y <= ANCHO; y++) {
            document.getElementById(y + "_" + x).setAttribute("class", "celda invisible");
        }
    }
}

function Reenviar(idPosicion) {
    RESERVA.push(PLANTA + "_" + idPosicion);
    document.getElementById(idPosicion).setAttribute("class", "celda seleccionada");
    if (RESERVA.length >= HABITACIONES)
        window.location = location.href.replace("Reserva", "Comprar") + "?habitaciones=" + RESERVA.join(",");
}

var HOTEL;
var PLANTA = 0;
var ULTIMA_PLANTA;
var LARGO;
var ANCHO;
var HABITACIONES;
var RESERVA = new Array();