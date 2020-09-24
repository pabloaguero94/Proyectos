using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundoParcialProg3.Models
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nombre { get; set; }

        public Marca(int idMarca, string nombre)
        {
            IdMarca = idMarca;
            Nombre = nombre;
        }
    }
}