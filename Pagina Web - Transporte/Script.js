var txtNombre = document.getElementById("txtNombre");
var radPers = document.getElementById("rbtPersonas");
var radFlet = document.getElementById("rbtFlete");
var radDeliv = document.getElementById("rbtDelivery");
var txtDist = document.getElementById("txtDistancia");
var txtPr = document.getElementById("txtPrecio");
var div1 = document.getElementById("divLista");

txtNombre.focus();

class Pedido{
  constructor(nombre, tipoViaje, distancia, precio){
  this.nombre = nombre;
  this.tipoViaje = tipoViaje;
  this.distancia = distancia;
  this.precio = precio;
  }

  toString(){
    return "Nombre completo: " + this.nombre + ". Tipo de viaje: " + this.tipoViaje + ". Distancia: " + this.distancia + ". Precio: " + this.precio;
  }
}

function estaCorrecto(){
  if (txtNombre.value == "") {
    alert('Ingrese un nombre')
    return false;
  }

  if (radFlet.checked && txtDist.value == "") {
    alert('Ha solicitado un flete. Ingrese por favor la distancia')
    return false;
  }

  // if (radFlet.checked || radPers.checked || radDeliv.checked && txtPr.value == "") {
  //   alert('No ha ingresado ningun precio')
  //   return false;
  // }

  return true;
}

function quePidio(){
  if (radPers.checked == true) {
    var p = "Taxi";
    return p;
  }

  if (radFlet.checked == true) {
    var f = "Flete";
    return f;
  }

  if (radDeliv.checked == true) {
    var d = "Delivery";
    return d;
  }
}

var vectorPedidos = [];

function agregarPedido(){
  if (!estaCorrecto()) {
    return;
  }

  var nombre = txtNombre.value;
  var tipoViaje = quePidio();
  var distancia = txtDist.value;
  var precio = txtPr.value;

  var nuevoPedido = new Pedido(nombre, tipoViaje, distancia, precio);
  vectorPedidos.push(nuevoPedido);
  alert('Pedido registrado')
}

function listarPedidos(){
  var cadena = "<ol>";
  for (var i = 0; i < vectorPedidos.length; i++) {
    cadena += "<li>" + vectorPedidos[i].toString() + "</li>";
  }
  cadena += "</ol>";

  var totalPrecios = 0;
  for (var i = 0; i < vectorPedidos.length; i++) {
    totalPrecios += parseFloat(vectorPedidos[i].precio);
  }
  var totalPedidos = vectorPedidos.length;

  div1.innerHTML = cadena + "<br>" +
  "Total de pedidos registrados: " + parseFloat(totalPedidos) + "<br>" +
  "Total de precios estimados: " + parseFloat(totalPrecios);
}
