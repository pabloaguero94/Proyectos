class Encuesta {

    constructor(nombre, apellido, edad, opinion, panaderia, cafeteria) {
        this.nombre = nombre; //String
        this.apellido = apellido; //String
        this.edad = edad; // int (lo convierte a string como otros lenguajes)
        this.opinion = opinion; // String 
        this.panaderia = panaderia; // BOOLEAN, tiene valor true o false del checkbox
        this.cafeteria = cafeteria; // si los muestro en el toString asi como estan devuelve la palabra true o false
    }

    suCompra() { // metodo que hago porque necesito un String para mostrar la compra de pana y/o cafe en el toString()
        var compra;
        if (this.panaderia === true && this.cafeteria === true) { //SI AMBOS check estan tildados la compra es ...
            compra = "panaderia y cafeteria";
        } else if (this.panaderia === true) { // SI NO, si esta tildado panaderia pero cafeteria no entonces la compra es panaderia
            compra = "panaderia";
        } else { // por descarte la compra es cafeteria
            compra = "cafeteria";
        }
        return compra; //devuelvo el STRING compra
    }

    toString() {
        return "La persona " + this.nombre + " " + this.apellido + " de " + this.edad + " años opinó que su experiencia en la compra de " + this.suCompra() + " fue " + this.opinion;
    }
}