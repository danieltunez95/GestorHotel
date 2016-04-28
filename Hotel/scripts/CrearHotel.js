function cellClick(id) {
    if (MATRIZ.length == 0) {
        var largo = document.getElementById("largoTextBox").value;
        var ancho = document.getElementById("anchoTextBox").value;

        for (var i = 0; i < ancho; i++) {
            MATRIZ[i] = new Array();
        }
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
    document.getElementById("matrizOculta").innerText = MATRIZ.join(',');
}

var MATRIZ = new Array();