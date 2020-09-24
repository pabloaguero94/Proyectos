var txtNombre = document.getElementById("txtNombre");
var txtApellido = document.getElementById("txtApellido");
var numEdad = document.getElementById("numEdad");
var opcMB = document.getElementById("opcMB");
var opcB = document.getElementById("opcB");
var opcR = document.getElementById("opcR");
var chkCafeteria = document.getElementById("chkCafeteria");
var chkPanaderia = document.getElementById("chkPanaderia");
var chkAcepta = document.getElementById("chkAcepta");

var divLista = document.getElementById("divLista"); // DEBO TOMAR EL OBJETO DIVLISTA PARA PODER PONERLE LA LISTA

function estaCorrecto() { //VALIDACION DE LOS DATOS
    if (txtNombre.value === "") {
        txtNombre.focus();
        return false;
    }
    if (txtApellido.value === "") {
        txtApellido.focus();
        return false;
    }
    if (numEdad.value === "") {
        numEdad.focus();
        return false;
    }
    if (numEdad.value < 18 || numEdad.value > 120) {
        numEdad.focus();
        return false;
    }
    if (!chkCafeteria.checked && !chkPanaderia.checked) {
        chkCafeteria.focus();
        return false;
    }
    if (!chkAcepta.checked) {
        chkAcepta.focus();
        return false;
    }
    return true;
}

encuestas = []; // Creo el vector para guardar las encuestas 

function agregarEncuesta() {
    if (!estaCorrecto()) {
        alert("Error!! Revise los datos..");
        return;
    } else {
        var nombre = txtNombre.value; //Se guarda el String del objeto txtNombre en la variable nombre
        var apellido = txtApellido.value;
        var edad = numEdad.value; //Se guarda el int del objeto numEdad en la variable edad

        var opinion; //Opinion tiene que tener un solo valor String, lo creo y depende de cual radio button esta seleccionado le asigno un valor
        if (opcMB.checked)
            opinion = "muy buena";
        else if (opcB.checked)
            opinion = "buena";
        else
            opinion = "regular";

        var panaderia = chkPanaderia.checked; // asigno el valor BOOLEAN (true o false) del objeto checkbox
        var cafeteria = chkCafeteria.checked;
        // los parametros del objeto e son (String nombre,String apellido,int edad,String opinion,boolean panaderia,boolean cafeteria); // VER CONSTRUCTOR DE LA CLASE
        var e = new Encuesta(nombre, apellido, edad, opinion, panaderia, cafeteria); //creo el objeto e(encuesta) de la clase Encuesta con el constructor con parametros y los valores que tome anteriormente
        encuestas.push(e); //inserto el objeto e en el vector encuestas que cree afuera de la funcion
        limpiaCampos(); //deja los campos vacios para agregar una nueva encuesta
        alert("Encuesta enviada con éxito");
    }
}

function listarEncuestas() { // la lista de encuestas que agrego al divLista
    var cadena = "<ol>"; // un String con la etiqueta ol para crear la lista en el div..
    for (var i = 0; i < encuestas.length; i++) { //FOR que recorre el vector encuestas 
        cadena += "<li>" + encuestas[i].toString() + "</li>"; // etiqueta li que abre el elemento de la lista, agrego la encuesta y cierro la etiqueta li, OJO: es concatenacion y acumula en la cadena!!!
    }
    cadena += "</ol>"; // cierro la etiqueta ol que me crea la lista
    divLista.innerHTML = cadena; // Asigno la cadena en el objeto divlista(NO OLVIDAR QUE ARRIBA LO TENGO QUE AGREGAR CON DOCUMENT.GETELEMENTBYID). Es .innerHTML porque tiene etiquetas, en el caso de no ponerlo va asignar todo como un texto incluidas las etiquetas
}

function limpiaCampos() { // Es obvio jajaja
    txtNombre.value = txtApellido.value = numEdad.value = "";
    opcMB.checked = true;
    opcB.checked = opcR.checked = chkCafeteria.checked = chkPanaderia.checked = chkAcepta.checked = false;
}