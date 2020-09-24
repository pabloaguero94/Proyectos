var nom = document.getElementById('txtNombre');
var ape = document.getElementById('txtApellido');
var edad = document.getElementById('txtEdad');
var rMala = document.getElementById('Mala');
var rBuena = document.getElementById('Buena');
var rMuyBuena = document.getElementById('MuyBuena');
var cCafeteria = document.getElementById('chkCafeteria');
var cPanaderia = document.getElementById('chkPanaderia');
var cAcepta = document.getElementById('chkAcepta');


txtNombre.focus();


class Respuesta{
  constructor(nombre, apellido, edad, opinion, compra){
    this.nombre = nombre;
    this.apellido = apellido;
    this.edad = edad;
    this.opinion = opinion;
    this.compra = compra;
  }

  toString(){
    return "Nombre: " + this.nombre + ", Apellido: " + this.apellido + ", Edad: " + this.edad + ", Opinion: " + this.opinion + ", Compra " + this.compra
  }
}

function validar(){
  if (txtNombre.value == "") {
    alert("Ingrese su nombre")
    return false;
  }

  if (txtApellido.value == "") {
    alert("Ingrese el apellido")
    return false;
  }

  var edad = txtEdad.value;
  if (edad < 18 || edad > 100) {
    alert("Ingrese una edad valida")
    return false;
  }

  if (Buena.checked == false && Mala.checked == false && MuyBuena.checked == false) {
    alert("Ingrese una opinion del servicio")
    return false;
  }

  if (chkCafeteria.checked == false && chkPanaderia.checked == false ) {
    alert("Ingrese en que area fue atendido")
    return false;
  }

  if (chkAcepta.checked == false) {
    alert("¿Acepta los terminos y condiciones?")
    return false;
  }

  else{
    return true;
  }


}


  var vectorRespuestas = [];

function agregarRespuesta(){

  if (!validar()) {
    return;
  }

function queCompro(){
  if (cCafeteria.checked && cPanaderia.checked) {
      var ambas = "Cafeteria y Panaderia";
      return ambas;
  } else {
    if (cCafeteria.checked && cPanaderia.checked == false) {
      var cafe = "Cafeteria";
      return cafe;
    } else {
      var pan ="Panaderia";
      return pan;
    }
  }
}

  function queOpinion(){
    if (rMala.checked == true) {
      var m = "Mala";
      return m;
    }

    if (rBuena.checked == true) {
      var b = "Buena";
      return b
    }

    if (rMuyBuena.checked == true) {
      var mb = "Muy buena";
      return mb;
    }
  }

    var opinion = queOpinion();
    var compra = queCompro();

    var respuestaNueva = new Respuesta(nom.value, ape.value, edad.value, opinion, compra)
    vectorRespuestas.push(respuestaNueva);
    alert("Respuesta agregada")
}

  function listarRespuestas(){
    var div1 = document.getElementById("div1");
    var cadena = "<ol>";
    for (var i = 0; i < vectorRespuestas.length; i++) {
      cadena += "<li>" + vectorRespuestas[i].toString() + "</li>";
    }

    cadena += "</ol>";
    div1.innerHTML = cadena;
  }
