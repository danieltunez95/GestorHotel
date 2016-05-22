function cellClick(id) {
    if (MATRIZ.length == 0) {
        generarPlantilla();
    }

    var celda = document.getElementById(id);
    
    if (celda.style.backgroundColor == "red")
        celda.style.backgroundColor = "dodgerblue";
    else
        celda.style.backgroundColor = "red";

    var coordenadas = id.split("_");
    rellenarTabla(coordenadas[0], coordenadas[1]);
}

function rellenarTabla(x, y) {
    if (MATRIZ[x][y] != 1)
        MATRIZ[x][y] = 1;
    else
        MATRIZ[x][y] = 0;
}
function generarPlantilla() {
    var x = document.getElementById("largoDisabledBox").value;
    var y = document.getElementById("anchoDisabledBox").value;

    for (var i = 0; i < x; i++) {
        MATRIZ[i] = new Array();
        for (var t = 0; t < y; t++) {
            MATRIZ[i][t] = "0";
        }
    }
}

function crearPlanta() {
    document.getElementById("hiddenHotel").innerHTML = MATRIZ.join("/");
}

var MATRIZ = new Array();
