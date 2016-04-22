function cellClick(id) {
    var celda = document.getElementById(id);
    
    if (celda.style.backgroundColor == "red")
        celda.style.backgroundColor = "dodgerblue";
    else
        celda.style.backgroundColor = "red";
}