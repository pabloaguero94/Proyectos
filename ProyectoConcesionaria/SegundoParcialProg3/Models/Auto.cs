using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundoParcialProg3.Models
{
    public class Auto
    {
        public int IdAuto { get; set; }
        public string Patente { get; set; }
        public int IdMarca { get; set; }
        public int Km { get; set; }
        public bool Promocion { get; set; }
        public float Precio { get; set; }

        public Auto(int idAuto, string patente, int idMarca, int km, bool promocion, float precio)
        {
            IdAuto = idAuto;
            Patente = patente;
            IdMarca = idMarca;
            Km = km;
            Promocion = promocion;
            Precio = precio;
        }

        public Auto()
        {
        }

       
    }
}