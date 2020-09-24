using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundoParcialProg3.Models
{
    public class AutoMarca
    {
        public int IdAuto { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public int Kilometraje { get; set; }
        public bool Promocion { get; set; }
        public float Precio { get; set; }

        public AutoMarca(int idAuto, string patente, string marca, int km, bool promocion, float precio)
        {
            IdAuto = idAuto;
            Patente = patente;
            Marca = marca;
            Kilometraje = km;
            Promocion = promocion;
            Precio = precio;
        }

        public double CalcularPrecio()
        {
            if (this.Promocion)
            {
                return Precio - (Precio * 0.1);
            }
            else
                return Precio;
        }

        public string EstaOferta()
        {
            if (this.Promocion)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }
        }
    }
}