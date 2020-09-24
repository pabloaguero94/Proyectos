using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMPersonas.Models
{
    public class Persona
    {
        public Persona()
        {

        }

        public Persona(int id, string nombre, string apellido, int edad)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;

        public string Apellido {
            get { return apellido; }
            set { apellido = value; }
        }

        private int edad;

        public int Edad {
            get { return edad; }
            set { edad = value; }
        }

        public int IdEstadoCivil { get => idEstadoCivil; set => idEstadoCivil = value; }

        private int idEstadoCivil;

        public override string ToString()
        {
            return id + ": " + nombre + " " + apellido + " - " + edad;
        }
    }
}