function _openFilter() {
    document.getElementById("filtros").style.display ="block";
}

function _closeFilter() {
    document.getElementById("filtros").style.display = "none";
    document.getElementById("listaReceitas").style.display = "block";
}
function _executeFilter() {
    document.getElementById("receitasFiltros").style.display = "block";
    document.getElementById("listaReceitas").style.display = "none";
}
function _noFilter() {
    document.getElementById("receitasFiltros").style.display = "none";
    document.getElementById("listaReceitas").style.display = "block";
}


function _showMassas() {
    var checkBox = document.getElementById("Massa");
    var text = document.getElementById("receitasMassas");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}

function _showPizza() {
    var checkBox = document.getElementById("Pizza");
    var text = document.getElementById("receitasPizza");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}
function _showTartes() {
    var checkBox = document.getElementById("Tarte");
    var text = document.getElementById("receitasTartes");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}

function _showCarnes() {
    var checkBox = document.getElementById("Carne");
    var text = document.getElementById("receitasCarne");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}

function _showPeixe() {
    var checkBox = document.getElementById("Peixe");
    var text = document.getElementById("receitasPeixe");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}
function _showEntradas() {
    var checkBox = document.getElementById("Entradas");
    var text = document.getElementById("receitasEntradas");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}

function _showSobremesas() {
    var checkBox = document.getElementById("Sobremesa");
    var text = document.getElementById("receitasSobremesa");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}


function _showVegetariano() {
    var checkBox = document.getElementById("Vegetariano");
    var text = document.getElementById("receitasVegetariano");
    if (checkBox.checked == true) {
        text.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    } else {
        text.style.display = "none";
    }

}


function changeFunc() {
    var selectBox = document.getElementById("selectBox");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    if (selectedValue == 15) {
        var text15 = document.getElementById("tempo15");
        text15.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";
    }
    else if (selectedValue == 30) {
        var text30 = document.getElementById("tempo30");
        text30.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";

    }
    else if (selectedValue == 45) {
        var text45 = document.getElementById("tempo45");
        text45.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";

    }
    else if (selectedValue == 60) {
        var text60 = document.getElementById("tempo60");
        text60.style.display = "block";
        document.getElementById("listaReceitas").style.display = "none";

    }

}