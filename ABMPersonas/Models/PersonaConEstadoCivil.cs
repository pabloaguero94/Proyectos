using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMPersonas.Models
{
    public class PersonaConEstadoCivil
    {
        public PersonaConEstadoCivil(int id, string nombre, string apellido, int edad, string nombreEstadoCivil)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.nombreEstadoCivil = nombreEstadoCivil;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string nombreEstadoCivil { get; set; }
    }
}