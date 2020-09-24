using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMPersonas.Models
{
    public class EstadoCivil
    {
        private int id;
        private string nombre;

        public EstadoCivil(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}